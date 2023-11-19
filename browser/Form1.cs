using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using Microsoft.Win32;
using NETCore.Encrypt;
using SharpHook;

namespace browser
{

    public partial class Form1 : Form
    {
        const string AESSalt = "3F2504E0-4F89-11D3-9A0C-0305E82C3301";
        TaskPoolGlobalHook hook = new TaskPoolGlobalHook();
        TabPage plus = new TabPage();
        string? masterPassword = null;

        public bool LControlPressed { get; private set; }

        public Form1()
        {
            InitializeComponent();
        }

        #region UI
        void setSplitterDistanceFixed(int height)
        {
            container.SplitterDistance = height;
        }

        void setContainerSize(int width, int height)
        {
            container.Width = width;
            container.Height = height;
        }

        void setNavigationUI()
        {
            geri.Width = 50;
            geri.Height = 50;
            geri.Left = 4;
            geri.Top = 4;

            ileri.Width = 50;
            ileri.Height = 50;
            ileri.Left = 58;
            ileri.Top = 4;

            yenile.Width = 50;
            yenile.Height = 50;
            yenile.Left = 112;
            yenile.Top = 4;

            adres.Width = Width - geri.Width - ileri.Width - yenile.Width - 30;
            adres.Height = 50;
            adres.Left = 186;
            adres.Top = (58 - adres.Top) / 2;
        }
        #endregion

        void buildTabs()
        {
            var browser = new Browser();
            browser.CoreWebView2InitializationCompleted += (s, e) =>
            {
                browser.CoreWebView2.NewWindowRequested += (sender, e) =>
                {
                    e.Handled = true;
                    createNewTab(e.Uri);
                };
            };

            browser.NavigationCompleted += (sender, e) =>
            {
                adres.Text = browser.Source.ToString();
                var title = browser.CoreWebView2.DocumentTitle;
                if (title.Length > 10)
                    tabs.TabPages[0].Text = browser.CoreWebView2.DocumentTitle.Substring(0, 10) + "...";
                else
                    tabs.TabPages[0].Text = browser.CoreWebView2.DocumentTitle;
            };

            tabs.TabPages[0].Controls.Add(browser);

            plus.Text = "+";
            tabs.TabPages.Add(plus);

            tabs.Click += NewTabFunction;
        }

        void createNewTab(string Url)
        {
            tabs.TabPages.Remove(plus);
            // create new tab
            var tab = new TabPage();
            var newBrowser = new Browser(Url);
            newBrowser.CoreWebView2InitializationCompleted += (s, e) =>
            {
                newBrowser.CoreWebView2.NewWindowRequested += (sender, e) =>
                {
                    e.Handled = true;
                    createNewTab(e.Uri);
                };
            };
            tab.Controls.Add(newBrowser);

            newBrowser.NavigationCompleted += (sender, e) =>
            {
                adres.Text = newBrowser.Source.ToString();
                var title = newBrowser.CoreWebView2.DocumentTitle;
                if (title.Length > 10)
                    tab.Text = newBrowser.CoreWebView2.DocumentTitle.Substring(0, 10) + "...";
                else
                    tab.Text = newBrowser.CoreWebView2.DocumentTitle;
            };

            tabs.TabPages.Add(tab);
            tabs.TabPages.Add(plus);

            tabs.SelectedTab = tab;
        }

        void NewTabFunction(object? sender, EventArgs e)
        {
            // get index of plus tab
            var index = tabs.TabPages.IndexOf(plus);
            // get clicked index
            var clickedIndex = tabs.SelectedIndex;
            // if its last tab
            if (index == clickedIndex)
            {
                createNewTab("https://google.com");
            }

            // if middle clicked
            if (e is MouseEventArgs mouse && mouse.Button == MouseButtons.Middle)
            {
                tabs.SelectedTab.Controls[0].Dispose();
                tabs.TabPages.Remove(tabs.SelectedTab);
            }
        }

        void checkMasterPassword()
        {
            // get master password from Registry
            masterPassword = Registry.GetValue("HKEY_CURRENT_USER\\NinesBrowser", "masterPassword", null) as string;
            // if master password is null
            if (string.IsNullOrEmpty(masterPassword))
            {
                // create master password
                var passwordForm = new MasterPasswordSet();
                passwordForm.MasterPasswordSetEvent += PasswordForm_MasterPasswordSetEvent;
                passwordForm.Show();
            }
        }

        private void PasswordForm_MasterPasswordSetEvent(string encryptedNewPass)
        {
            masterPassword = encryptedNewPass;
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            hook.KeyPressed += Hook_KeyPressed;
            hook.KeyReleased += Hook_KeyReleased;

            container.Dock = DockStyle.Fill;

            checkMasterPassword();
            setSplitterDistanceFixed(58);
            setContainerSize(Width, Height);
            setNavigationUI();

            buildTabs();
            secureBox.Parent = this;
            await hook.RunAsync();
        }

        private void Hook_KeyReleased(object? sender, KeyboardHookEventArgs e)
        {
            if (e.Data.KeyCode == SharpHook.Native.KeyCode.VcLeftControl)
            {
                LControlPressed = false;
            }

            if (e.Data.KeyCode == SharpHook.Native.KeyCode.VcL)
            {
                if (LControlPressed)
                {
                    // invoke delegate to main thread
                    Invoke(new Action(() =>
                    {
                        tabs.Visible = false;
                        secureBox.Visible = true;
                        secureBox.Left =
                        (container.Panel2.Width - secureBox.Width) / 2;

                        secureBox.Top = (container.Panel2.Height - secureBox.Height) / 2 + 50;
                    }));
                }
            }

            // if enter pressed
            if (e.Data.KeyCode == SharpHook.Native.KeyCode.VcEnter)
            {
                Invoke(new Action(() =>
                {
                    if (adres.Focused)
                    {
                        // get selected tab
                        var tab = tabs.SelectedTab;
                        // get browser in tab
                        for (var i = 0; i < tab.Controls.Count; i++)
                        {
                            if (tab.Controls[i] is Browser getBrowser)
                            {
                                // if is not starts with http
                                if (!adres.Text.StartsWith("http"))
                                {
                                    // add https
                                    adres.Text = "https://" + adres.Text;
                                }
                                // navigate to url
                                getBrowser.Source = new Uri(adres.Text);
                            }
                        }
                    }
                }));
            }
        }

        private void Hook_KeyPressed(object? sender, KeyboardHookEventArgs e)
        {
            if (e.Data.KeyCode == SharpHook.Native.KeyCode.VcLeftControl)
            {
                LControlPressed = true;
            }
        }

        private void container_SplitterMoving(object sender, SplitterCancelEventArgs e)
        {
            setSplitterDistanceFixed(50);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            setContainerSize(Width, Height);
            setNavigationUI();
        }

        private void container_SplitterMoved(object sender, SplitterEventArgs e)
        {
            setSplitterDistanceFixed(58);
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.LControlKey && e.KeyCode == Keys.L)
            {
                tabs.Hide();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var decryptedOldPass = EncryptProvider.AESDecrypt(masterPassword, AESSalt.Replace("-",""));
            if (parola.Text == decryptedOldPass)
            {
                secureBox.Visible = false;
                parola.Text = "";
                tabs.Visible = true;
            }
            else
            {
                MessageBox.Show("Parola yanlýþ.");
            }
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                secureBox.Visible = true;
                tabs.Visible = false;
            }

            if (WindowState == FormWindowState.Normal)
            {
                secureBox.Left =
                     (container.Panel2.Width - secureBox.Width) / 2;

                secureBox.Top = (container.Panel2.Height - secureBox.Height) / 2;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            hook.Dispose();
        }

        private void Form1_ResizeBegin(object sender, EventArgs e)
        {
            tabs.Visible = false;
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            tabs.Visible = true;
        }

        private void geri_Click(object sender, EventArgs e)
        {
            // get selected tab
            var tab = tabs.SelectedTab;
            // get browser in tab
            for (var i = 0; i < tab.Controls.Count; i++)
            {
                if (tab.Controls[i] is Browser getBrowser)
                {
                    // navigate to url
                    getBrowser.GoBack();
                }
            }
        }

        private void ileri_Click(object sender, EventArgs e)
        {
            var tab = tabs.SelectedTab;
            for (var i = 0; i < tab.Controls.Count; i++)
            {
                if (tab.Controls[i] is Browser getBrowser)
                {
                    getBrowser.GoForward();
                }
            }
        }

        private void yenile_Click(object sender, EventArgs e)
        {
            var tab = tabs.SelectedTab;
            for (var i = 0; i < tab.Controls.Count; i++)
            {
                if (tab.Controls[i] is Browser getBrowser)
                {
                    getBrowser.Reload();
                }
            }
        }

        private void adres_Click(object sender, EventArgs e)
        {
            // select all text
            adres.SelectAll();
        }
    }
}