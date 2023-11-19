namespace browser
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            container = new SplitContainer();
            yenile = new Button();
            adres = new TextBox();
            ileri = new Button();
            geri = new Button();
            tabs = new TabControl();
            tabPage2 = new TabPage();
            secureBox = new GroupBox();
            button1 = new Button();
            parola = new MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)container).BeginInit();
            container.Panel1.SuspendLayout();
            container.Panel2.SuspendLayout();
            container.SuspendLayout();
            tabs.SuspendLayout();
            secureBox.SuspendLayout();
            SuspendLayout();
            // 
            // container
            // 
            container.Location = new Point(666, 290);
            container.Margin = new Padding(4, 5, 4, 5);
            container.Name = "container";
            container.Orientation = Orientation.Horizontal;
            // 
            // container.Panel1
            // 
            container.Panel1.BackColor = SystemColors.ButtonHighlight;
            container.Panel1.Controls.Add(yenile);
            container.Panel1.Controls.Add(adres);
            container.Panel1.Controls.Add(ileri);
            container.Panel1.Controls.Add(geri);
            // 
            // container.Panel2
            // 
            container.Panel2.Controls.Add(tabs);
            container.Size = new Size(1410, 1090);
            container.SplitterDistance = 198;
            container.SplitterWidth = 7;
            container.TabIndex = 0;
            container.SplitterMoving += container_SplitterMoving;
            container.SplitterMoved += container_SplitterMoved;
            // 
            // yenile
            // 
            yenile.BackgroundImage = Properties.Resources.refresh_arrow;
            yenile.BackgroundImageLayout = ImageLayout.Stretch;
            yenile.FlatAppearance.BorderSize = 0;
            yenile.FlatStyle = FlatStyle.Flat;
            yenile.Location = new Point(209, 0);
            yenile.Margin = new Padding(4, 5, 4, 5);
            yenile.Name = "yenile";
            yenile.Size = new Size(99, 72);
            yenile.TabIndex = 4;
            yenile.UseVisualStyleBackColor = true;
            yenile.Click += yenile_Click;
            // 
            // adres
            // 
            adres.BorderStyle = BorderStyle.None;
            adres.Location = new Point(316, 20);
            adres.Margin = new Padding(4, 5, 4, 5);
            adres.Name = "adres";
            adres.PlaceholderText = "Google ile arama yapın veya adres yazın";
            adres.Size = new Size(1663, 24);
            adres.TabIndex = 3;
            adres.Click += adres_Click;
            // 
            // ileri
            // 
            ileri.BackgroundImage = Properties.Resources.next;
            ileri.BackgroundImageLayout = ImageLayout.Stretch;
            ileri.FlatAppearance.BorderSize = 0;
            ileri.FlatStyle = FlatStyle.Flat;
            ileri.Location = new Point(107, 0);
            ileri.Margin = new Padding(4, 5, 4, 5);
            ileri.Name = "ileri";
            ileri.Size = new Size(99, 72);
            ileri.TabIndex = 1;
            ileri.UseVisualStyleBackColor = true;
            ileri.Click += ileri_Click;
            // 
            // geri
            // 
            geri.BackgroundImage = Properties.Resources.previous;
            geri.BackgroundImageLayout = ImageLayout.Stretch;
            geri.FlatAppearance.BorderSize = 0;
            geri.FlatStyle = FlatStyle.Flat;
            geri.Location = new Point(4, 0);
            geri.Margin = new Padding(4, 5, 4, 5);
            geri.Name = "geri";
            geri.Size = new Size(99, 72);
            geri.TabIndex = 0;
            geri.UseVisualStyleBackColor = true;
            geri.Click += geri_Click;
            // 
            // tabs
            // 
            tabs.Controls.Add(tabPage2);
            tabs.Dock = DockStyle.Fill;
            tabs.Location = new Point(0, 0);
            tabs.Margin = new Padding(4, 5, 4, 5);
            tabs.Name = "tabs";
            tabs.SelectedIndex = 0;
            tabs.Size = new Size(1410, 885);
            tabs.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 34);
            tabPage2.Margin = new Padding(4, 5, 4, 5);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(4, 5, 4, 5);
            tabPage2.Size = new Size(1402, 847);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Google";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // secureBox
            // 
            secureBox.Controls.Add(button1);
            secureBox.Controls.Add(parola);
            secureBox.Location = new Point(41, 762);
            secureBox.Name = "secureBox";
            secureBox.Size = new Size(300, 150);
            secureBox.TabIndex = 0;
            secureBox.TabStop = false;
            secureBox.Text = "Güvenlik";
            secureBox.Visible = false;
            // 
            // button1
            // 
            button1.Location = new Point(72, 98);
            button1.Name = "button1";
            button1.Size = new Size(150, 34);
            button1.TabIndex = 2;
            button1.Text = "Kilit Aç";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // parola
            // 
            parola.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            parola.Location = new Point(72, 42);
            parola.Name = "parola";
            parola.PasswordChar = '*';
            parola.Size = new Size(150, 50);
            parola.TabIndex = 1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2076, 1380);
            Controls.Add(secureBox);
            Controls.Add(container);
            Margin = new Padding(4, 5, 4, 5);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Nines Browser";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            ResizeBegin += Form1_ResizeBegin;
            ResizeEnd += Form1_ResizeEnd;
            SizeChanged += Form1_SizeChanged;
            KeyDown += Form1_KeyDown;
            KeyPress += Form1_KeyPress;
            Resize += Form1_Resize;
            container.Panel1.ResumeLayout(false);
            container.Panel1.PerformLayout();
            container.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)container).EndInit();
            container.ResumeLayout(false);
            tabs.ResumeLayout(false);
            secureBox.ResumeLayout(false);
            secureBox.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer container;
        private Button yenile;
        private TextBox adres;
        private Button ileri;
        private Button geri;
        private TabControl tabs;
        private TabPage tabPage2;
        private GroupBox secureBox;
        private Button button1;
        private MaskedTextBox parola;
    }
}