namespace chessgames
{
    partial class changePassword
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
            this.btnNext = new System.Windows.Forms.Button();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.confirmPasswordLabel = new System.Windows.Forms.Label();
            this.errorNewPassword = new System.Windows.Forms.Label();
            this.errorConfirmPassword = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(294, 262);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(153, 45);
            this.btnNext.TabIndex = 16;
            this.btnNext.Text = "Xác nhận";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.Location = new System.Drawing.Point(248, 119);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.Size = new System.Drawing.Size(262, 22);
            this.txtNewPassword.TabIndex = 15;
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(245, 100);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(122, 16);
            this.passwordLabel.TabIndex = 14;
            this.passwordLabel.Text = "Nhập mật khẩu mới";
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Location = new System.Drawing.Point(248, 201);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.Size = new System.Drawing.Size(262, 22);
            this.txtConfirmPassword.TabIndex = 18;
            this.txtConfirmPassword.TextChanged += new System.EventHandler(this.txtConfirmPassword_TextChanged);
            // 
            // confirmPasswordLabel
            // 
            this.confirmPasswordLabel.AutoSize = true;
            this.confirmPasswordLabel.Location = new System.Drawing.Point(245, 182);
            this.confirmPasswordLabel.Name = "confirmPasswordLabel";
            this.confirmPasswordLabel.Size = new System.Drawing.Size(119, 16);
            this.confirmPasswordLabel.TabIndex = 17;
            this.confirmPasswordLabel.Text = "Xác nhận mật khẩu";
            // 
            // errorNewPassword
            // 
            this.errorNewPassword.AutoSize = true;
            this.errorNewPassword.Location = new System.Drawing.Point(245, 144);
            this.errorNewPassword.Name = "errorNewPassword";
            this.errorNewPassword.Size = new System.Drawing.Size(0, 16);
            this.errorNewPassword.TabIndex = 19;
            // 
            // errorConfirmPassword
            // 
            this.errorConfirmPassword.AutoSize = true;
            this.errorConfirmPassword.Location = new System.Drawing.Point(245, 226);
            this.errorConfirmPassword.Name = "errorConfirmPassword";
            this.errorConfirmPassword.Size = new System.Drawing.Size(0, 16);
            this.errorConfirmPassword.TabIndex = 20;
            // 
            // changePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.errorConfirmPassword);
            this.Controls.Add(this.errorNewPassword);
            this.Controls.Add(this.txtConfirmPassword);
            this.Controls.Add(this.confirmPasswordLabel);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.txtNewPassword);
            this.Controls.Add(this.passwordLabel);
            this.Name = "changePassword";
            this.Text = "changePassword";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Label confirmPasswordLabel;
        private System.Windows.Forms.Label errorNewPassword;
        private System.Windows.Forms.Label errorConfirmPassword;
    }
}