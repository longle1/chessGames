namespace chessgames
{
    partial class register
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
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.emailLabel = new System.Windows.Forms.Label();
            this.btnRegister = new System.Windows.Forms.Button();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.userNamLabel = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.confirmPasswordLabel = new System.Windows.Forms.Label();
            this.btnComeback = new System.Windows.Forms.Button();
            this.errorUserNameLabel = new System.Windows.Forms.Label();
            this.errorEmailLabel = new System.Windows.Forms.Label();
            this.errorPasswordLabel = new System.Windows.Forms.Label();
            this.errorConfirmPasswordLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(216, 162);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(262, 22);
            this.txtEmail.TabIndex = 9;
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Location = new System.Drawing.Point(213, 143);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(76, 16);
            this.emailLabel.TabIndex = 8;
            this.emailLabel.Text = "Nhập email";
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(165, 363);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(166, 48);
            this.btnRegister.TabIndex = 7;
            this.btnRegister.Text = "Đăng ký";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(216, 80);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(262, 22);
            this.txtUserName.TabIndex = 6;
            // 
            // userNamLabel
            // 
            this.userNamLabel.AutoSize = true;
            this.userNamLabel.Location = new System.Drawing.Point(213, 61);
            this.userNamLabel.Name = "userNamLabel";
            this.userNamLabel.Size = new System.Drawing.Size(103, 16);
            this.userNamLabel.TabIndex = 5;
            this.userNamLabel.Text = "Nhập username";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(216, 235);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(262, 22);
            this.txtPassword.TabIndex = 11;
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(213, 216);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(102, 16);
            this.passwordLabel.TabIndex = 10;
            this.passwordLabel.Text = "Nhập password";
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Location = new System.Drawing.Point(216, 313);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.Size = new System.Drawing.Size(262, 22);
            this.txtConfirmPassword.TabIndex = 13;
            this.txtConfirmPassword.TextChanged += new System.EventHandler(this.txtConfirmPassword_TextChanged);
            // 
            // confirmPasswordLabel
            // 
            this.confirmPasswordLabel.AutoSize = true;
            this.confirmPasswordLabel.Location = new System.Drawing.Point(213, 294);
            this.confirmPasswordLabel.Name = "confirmPasswordLabel";
            this.confirmPasswordLabel.Size = new System.Drawing.Size(119, 16);
            this.confirmPasswordLabel.TabIndex = 12;
            this.confirmPasswordLabel.Text = "Xác nhận mật khẩu";
            // 
            // btnComeback
            // 
            this.btnComeback.Location = new System.Drawing.Point(387, 363);
            this.btnComeback.Name = "btnComeback";
            this.btnComeback.Size = new System.Drawing.Size(166, 48);
            this.btnComeback.TabIndex = 15;
            this.btnComeback.Text = "Quay lại";
            this.btnComeback.UseVisualStyleBackColor = true;
            this.btnComeback.Click += new System.EventHandler(this.btnComeback_Click);
            // 
            // errorUserNameLabel
            // 
            this.errorUserNameLabel.AutoSize = true;
            this.errorUserNameLabel.Location = new System.Drawing.Point(213, 105);
            this.errorUserNameLabel.Name = "errorUserNameLabel";
            this.errorUserNameLabel.Size = new System.Drawing.Size(0, 16);
            this.errorUserNameLabel.TabIndex = 16;
            // 
            // errorEmailLabel
            // 
            this.errorEmailLabel.AutoSize = true;
            this.errorEmailLabel.Location = new System.Drawing.Point(213, 187);
            this.errorEmailLabel.Name = "errorEmailLabel";
            this.errorEmailLabel.Size = new System.Drawing.Size(0, 16);
            this.errorEmailLabel.TabIndex = 17;
            // 
            // errorPasswordLabel
            // 
            this.errorPasswordLabel.AutoSize = true;
            this.errorPasswordLabel.Location = new System.Drawing.Point(213, 260);
            this.errorPasswordLabel.Name = "errorPasswordLabel";
            this.errorPasswordLabel.Size = new System.Drawing.Size(0, 16);
            this.errorPasswordLabel.TabIndex = 18;
            // 
            // errorConfirmPasswordLabel
            // 
            this.errorConfirmPasswordLabel.AutoSize = true;
            this.errorConfirmPasswordLabel.Location = new System.Drawing.Point(213, 338);
            this.errorConfirmPasswordLabel.Name = "errorConfirmPasswordLabel";
            this.errorConfirmPasswordLabel.Size = new System.Drawing.Size(0, 16);
            this.errorConfirmPasswordLabel.TabIndex = 19;
            // 
            // register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.errorConfirmPasswordLabel);
            this.Controls.Add(this.errorPasswordLabel);
            this.Controls.Add(this.errorEmailLabel);
            this.Controls.Add(this.errorUserNameLabel);
            this.Controls.Add(this.btnComeback);
            this.Controls.Add(this.txtConfirmPassword);
            this.Controls.Add(this.confirmPasswordLabel);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.emailLabel);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.userNamLabel);
            this.Name = "register";
            this.Text = "register";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label userNamLabel;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Label confirmPasswordLabel;
        private System.Windows.Forms.Button btnComeback;
        private System.Windows.Forms.Label errorUserNameLabel;
        private System.Windows.Forms.Label errorEmailLabel;
        private System.Windows.Forms.Label errorPasswordLabel;
        private System.Windows.Forms.Label errorConfirmPasswordLabel;
    }
}