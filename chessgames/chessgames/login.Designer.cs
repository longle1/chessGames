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
            this.userNamLabel = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.forgotPasswordLabel = new System.Windows.Forms.Label();
            this.btnSignUp = new System.Windows.Forms.Button();
            this.errorHideLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // userNamLabel
            // 
            this.userNamLabel.AutoSize = true;
            this.userNamLabel.Location = new System.Drawing.Point(216, 125);
            this.userNamLabel.Name = "userNamLabel";
            this.userNamLabel.Size = new System.Drawing.Size(103, 16);
            this.userNamLabel.TabIndex = 0;
            this.userNamLabel.Text = "Nhập username";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(219, 144);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(262, 22);
            this.txtUserName.TabIndex = 1;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(255, 296);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(166, 48);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Đăng nhập";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(219, 214);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(262, 22);
            this.txtPassword.TabIndex = 4;
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(216, 195);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(102, 16);
            this.passwordLabel.TabIndex = 3;
            this.passwordLabel.Text = "Nhập password";
            // 
            // forgotPasswordLabel
            // 
            this.forgotPasswordLabel.AutoSize = true;
            this.forgotPasswordLabel.Location = new System.Drawing.Point(287, 349);
            this.forgotPasswordLabel.Name = "forgotPasswordLabel";
            this.forgotPasswordLabel.Size = new System.Drawing.Size(96, 16);
            this.forgotPasswordLabel.TabIndex = 5;
            this.forgotPasswordLabel.Text = "Quên mật khẩu";
            this.forgotPasswordLabel.Click += new System.EventHandler(this.forgotPasswordLabel_Click);
            // 
            // btnSignUp
            // 
            this.btnSignUp.Location = new System.Drawing.Point(600, 32);
            this.btnSignUp.Name = "btnSignUp";
            this.btnSignUp.Size = new System.Drawing.Size(166, 48);
            this.btnSignUp.TabIndex = 6;
            this.btnSignUp.Text = "Đăng ký";
            this.btnSignUp.UseVisualStyleBackColor = true;
            this.btnSignUp.Click += new System.EventHandler(this.btnSignUp_Click);
            // 
            // errorHideLabel
            // 
            this.errorHideLabel.AutoSize = true;
            this.errorHideLabel.Location = new System.Drawing.Point(216, 261);
            this.errorHideLabel.Name = "errorHideLabel";
            this.errorHideLabel.Size = new System.Drawing.Size(0, 16);
            this.errorHideLabel.TabIndex = 7;
            // 
            // login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.errorHideLabel);
            this.Controls.Add(this.btnSignUp);
            this.Controls.Add(this.forgotPasswordLabel);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.userNamLabel);
            this.Name = "login";
            this.Text = "login";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.login_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label userNamLabel;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Label forgotPasswordLabel;
        private System.Windows.Forms.Button btnSignUp;
        private System.Windows.Forms.Label errorHideLabel;
    }
}