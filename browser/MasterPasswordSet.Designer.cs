namespace browser
{
    partial class MasterPasswordSet
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            oldPassword = new TextBox();
            newPassword = new TextBox();
            reTypeNewPassword = new TextBox();
            button1 = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // oldPassword
            // 
            oldPassword.Location = new Point(191, 30);
            oldPassword.Name = "oldPassword";
            oldPassword.PasswordChar = '*';
            oldPassword.PlaceholderText = "Leave blank if you dont have old password";
            oldPassword.Size = new Size(410, 31);
            oldPassword.TabIndex = 0;
            // 
            // newPassword
            // 
            newPassword.Location = new Point(191, 67);
            newPassword.Name = "newPassword";
            newPassword.PasswordChar = '*';
            newPassword.PlaceholderText = "New password";
            newPassword.Size = new Size(410, 31);
            newPassword.TabIndex = 1;
            // 
            // reTypeNewPassword
            // 
            reTypeNewPassword.Location = new Point(191, 104);
            reTypeNewPassword.Name = "reTypeNewPassword";
            reTypeNewPassword.PasswordChar = '*';
            reTypeNewPassword.PlaceholderText = "Re type new password";
            reTypeNewPassword.Size = new Size(410, 31);
            reTypeNewPassword.TabIndex = 2;
            // 
            // button1
            // 
            button1.Location = new Point(428, 169);
            button1.Name = "button1";
            button1.Size = new Size(173, 57);
            button1.TabIndex = 3;
            button1.Text = "Set Password";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(70, 36);
            label1.Name = "label1";
            label1.Size = new Size(121, 25);
            label1.TabIndex = 4;
            label1.Text = "Old Password";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(64, 73);
            label2.Name = "label2";
            label2.Size = new Size(127, 25);
            label2.TabIndex = 5;
            label2.Text = "New Password";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(32, 110);
            label3.Name = "label3";
            label3.Size = new Size(153, 25);
            label3.TabIndex = 6;
            label3.Text = "Re-New Password";
            // 
            // MasterPasswordSet
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(636, 252);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(reTypeNewPassword);
            Controls.Add(newPassword);
            Controls.Add(oldPassword);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "MasterPasswordSet";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MasterPasswordSet";
            TopMost = true;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox oldPassword;
        private TextBox newPassword;
        private TextBox reTypeNewPassword;
        private Button button1;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}