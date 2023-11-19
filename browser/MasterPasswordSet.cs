using Microsoft.Win32;
using NETCore.Encrypt;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace browser
{
    public partial class MasterPasswordSet : Form
    {
        const string AESSalt = "3F2504E0-4F89-11D3-9A0C-0305E82C3301";
        // delegete event
        public delegate void MasterPasswordSetEventHandler(string pass);
        // event
        public event MasterPasswordSetEventHandler MasterPasswordSetEvent;
        public MasterPasswordSet()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // get old password from Registry
            var oldPass = Registry.GetValue("HKEY_CURRENT_USER\\NinesBrowser", "masterPassword", null);


            var decryptedOldPass = "";
                
                if ( oldPass != null)
                    decryptedOldPass = EncryptProvider.AESDecrypt(oldPass.ToString(), AESSalt.Replace("-", ""));

            // check if old password is correct
            if (oldPassword.Text == decryptedOldPass || decryptedOldPass == "" )
            {
                // check if new password is same as retype new password
                if (newPassword.Text == reTypeNewPassword.Text)
                {
                    // encrypt new password
                    var encryptedNewPass = EncryptProvider.AESEncrypt(newPassword.Text, AESSalt.Replace("-", ""));

                    // save new password to Registry
                    Registry.SetValue("HKEY_CURRENT_USER\\NinesBrowser", "masterPassword", encryptedNewPass);

                    // invoke event
                    MasterPasswordSetEvent?.Invoke(encryptedNewPass);

                    // close this form
                    this.Close();
                }
                else
                {
                    // show error message
                    MessageBox.Show("New password and retype new password is not same", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // show error message
                MessageBox.Show("Old password is not correct", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
