namespace chessgames
{
    partial class login
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
            this.ptbContainAvt = new System.Windows.Forms.PictureBox();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.errorHideLabel = new System.Windows.Forms.Label();
            this.btnSignUp = new System.Windows.Forms.Button();
            this.forgotPasswordLabel = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.userNamLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ptbContainAvt)).BeginInit();
            this.pnlContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // ptbContainAvt
            // 
            this.ptbContainAvt.BackColor = System.Drawing.Color.White;
            this.ptbContainAvt.Location = new System.Drawing.Point(-1, -1);
            this.ptbContainAvt.Name = "ptbContainAvt";
            this.ptbContainAvt.Size = new System.Drawing.Size(1134, 536);
            this.ptbContainAvt.TabIndex = 0;
            this.ptbContainAvt.TabStop = false;
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pnlContent.Controls.Add(this.errorHideLabel);
            this.pnlContent.Controls.Add(this.btnSignUp);
            this.pnlContent.Controls.Add(this.forgotPasswordLabel);
            this.pnlContent.Controls.Add(this.txtPassword);
            this.pnlContent.Controls.Add(this.passwordLabel);
            this.pnlContent.Controls.Add(this.btnLogin);
            this.pnlContent.Controls.Add(this.txtUserName);
            this.pnlContent.Controls.Add(this.userNamLabel);
            this.pnlContent.Location = new System.Drawing.Point(-1, -1);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1130, 532);
            this.pnlContent.TabIndex = 2;
            // 
            // errorHideLabel
            // 
            this.errorHideLabel.AutoSize = true;
            this.errorHideLabel.Location = new System.Drawing.Point(362, 279);
            this.errorHideLabel.Name = "errorHideLabel";
            this.errorHideLabel.Size = new System.Drawing.Size(0, 16);
            this.errorHideLabel.TabIndex = 15;
            // 
            // btnSignUp
            // 
            this.btnSignUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnSignUp.Font = new System.Drawing.Font("Segoe Print", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.btnSignUp.ForeColor = System.Drawing.Color.Fuchsia;
            this.btnSignUp.Location = new System.Drawing.Point(582, 298);
            this.btnSignUp.Name = "btnSignUp";
            this.btnSignUp.Size = new System.Drawing.Size(224, 61);
            this.btnSignUp.TabIndex = 14;
            this.btnSignUp.Text = "Đăng ký";
            this.btnSignUp.UseVisualStyleBackColor = false;
            this.btnSignUp.Click += new System.EventHandler(this.btnSignUp_Click);
            // 
            // forgotPasswordLabel
            // 
            this.forgotPasswordLabel.AutoSize = true;
            this.forgotPasswordLabel.Font = new System.Drawing.Font("Segoe Print", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.forgotPasswordLabel.ForeColor = System.Drawing.Color.Red;
            this.forgotPasswordLabel.Location = new System.Drawing.Point(462, 385);
            this.forgotPasswordLabel.Name = "forgotPasswordLabel";
            this.forgotPasswordLabel.Size = new System.Drawing.Size(205, 40);
            this.forgotPasswordLabel.TabIndex = 13;
            this.forgotPasswordLabel.Text = "Quên mật khẩu";
            this.forgotPasswordLabel.Click += new System.EventHandler(this.forgotPasswordLabel_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.SystemColors.Info;
            this.txtPassword.Location = new System.Drawing.Point(365, 245);
            this.txtPassword.Multiline = true;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(441, 32);
            this.txtPassword.TabIndex = 12;
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Font = new System.Drawing.Font("Segoe Print", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.passwordLabel.ForeColor = System.Drawing.Color.LightGreen;
            this.passwordLabel.Location = new System.Drawing.Point(358, 202);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(199, 40);
            this.passwordLabel.TabIndex = 11;
            this.passwordLabel.Text = "Nhập password";
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnLogin.Font = new System.Drawing.Font("Segoe Print", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.btnLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnLogin.Location = new System.Drawing.Point(356, 298);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(220, 61);
            this.btnLogin.TabIndex = 10;
            this.btnLogin.Text = "Đăng nhập";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtUserName
            // 
            this.txtUserName.BackColor = System.Drawing.SystemColors.Info;
            this.txtUserName.Location = new System.Drawing.Point(365, 162);
            this.txtUserName.Multiline = true;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(441, 32);
            this.txtUserName.TabIndex = 9;
            // 
            // userNamLabel
            // 
            this.userNamLabel.AutoSize = true;
            this.userNamLabel.Font = new System.Drawing.Font("Segoe Print", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userNamLabel.ForeColor = System.Drawing.Color.LightGreen;
            this.userNamLabel.Location = new System.Drawing.Point(358, 119);
            this.userNamLabel.Name = "userNamLabel";
            this.userNamLabel.Size = new System.Drawing.Size(202, 40);
            this.userNamLabel.TabIndex = 8;
            this.userNamLabel.Text = "Nhập username";
            // 
            // login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1134, 533);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.ptbContainAvt);
            this.Name = "login";
            this.Text = "login";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.login_FormClosed);
            this.Load += new System.EventHandler(this.login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ptbContainAvt)).EndInit();
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox ptbContainAvt;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Label errorHideLabel;
        private System.Windows.Forms.Button btnSignUp;
        private System.Windows.Forms.Label forgotPasswordLabel;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label userNamLabel;
    }
}