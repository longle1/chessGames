namespace chessgames
{
    partial class authAccount
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
            this.txtAuthEmail = new System.Windows.Forms.TextBox();
            this.gmailLabel = new System.Windows.Forms.Label();
            this.txtAuthUserName = new System.Windows.Forms.TextBox();
            this.userNamLabel = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtAuthEmail
            // 
            this.txtAuthEmail.Location = new System.Drawing.Point(229, 182);
            this.txtAuthEmail.Name = "txtAuthEmail";
            this.txtAuthEmail.Size = new System.Drawing.Size(262, 22);
            this.txtAuthEmail.TabIndex = 8;
            // 
            // gmailLabel
            // 
            this.gmailLabel.AutoSize = true;
            this.gmailLabel.Location = new System.Drawing.Point(226, 163);
            this.gmailLabel.Name = "gmailLabel";
            this.gmailLabel.Size = new System.Drawing.Size(76, 16);
            this.gmailLabel.TabIndex = 7;
            this.gmailLabel.Text = "Nhập email";
            // 
            // txtAuthUserName
            // 
            this.txtAuthUserName.Location = new System.Drawing.Point(229, 112);
            this.txtAuthUserName.Name = "txtAuthUserName";
            this.txtAuthUserName.Size = new System.Drawing.Size(262, 22);
            this.txtAuthUserName.TabIndex = 6;
            // 
            // userNamLabel
            // 
            this.userNamLabel.AutoSize = true;
            this.userNamLabel.Location = new System.Drawing.Point(226, 93);
            this.userNamLabel.Name = "userNamLabel";
            this.userNamLabel.Size = new System.Drawing.Size(103, 16);
            this.userNamLabel.TabIndex = 5;
            this.userNamLabel.Text = "Nhập username";
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(276, 240);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(153, 45);
            this.btnNext.TabIndex = 9;
            this.btnNext.Text = "Xác nhận";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // authAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.txtAuthEmail);
            this.Controls.Add(this.gmailLabel);
            this.Controls.Add(this.txtAuthUserName);
            this.Controls.Add(this.userNamLabel);
            this.Name = "authAccount";
            this.Text = "authAccount";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAuthEmail;
        private System.Windows.Forms.Label gmailLabel;
        private System.Windows.Forms.TextBox txtAuthUserName;
        private System.Windows.Forms.Label userNamLabel;
        private System.Windows.Forms.Button btnNext;
    }
}