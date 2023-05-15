namespace chessgames
{
    partial class inputToken
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
            this.txtAuth = new System.Windows.Forms.TextBox();
            this.authLabel = new System.Windows.Forms.Label();
            this.btnSendTokenAgain = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(266, 178);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(153, 45);
            this.btnNext.TabIndex = 12;
            this.btnNext.Text = "Xác nhận";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // txtAuth
            // 
            this.txtAuth.Location = new System.Drawing.Point(222, 98);
            this.txtAuth.Name = "txtAuth";
            this.txtAuth.Size = new System.Drawing.Size(262, 22);
            this.txtAuth.TabIndex = 11;
            // 
            // authLabel
            // 
            this.authLabel.AutoSize = true;
            this.authLabel.Location = new System.Drawing.Point(219, 79);
            this.authLabel.Name = "authLabel";
            this.authLabel.Size = new System.Drawing.Size(113, 16);
            this.authLabel.TabIndex = 10;
            this.authLabel.Text = "Nhập mã xác thực";
            // 
            // btnSendTokenAgain
            // 
            this.btnSendTokenAgain.Location = new System.Drawing.Point(222, 127);
            this.btnSendTokenAgain.Name = "btnSendTokenAgain";
            this.btnSendTokenAgain.Size = new System.Drawing.Size(96, 27);
            this.btnSendTokenAgain.TabIndex = 13;
            this.btnSendTokenAgain.Text = "Gửi lại mã";
            this.btnSendTokenAgain.UseVisualStyleBackColor = true;
            this.btnSendTokenAgain.Click += new System.EventHandler(this.btnSendTokenAgain_Click);
            // 
            // inputToken
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSendTokenAgain);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.txtAuth);
            this.Controls.Add(this.authLabel);
            this.Name = "inputToken";
            this.Text = "inputToken";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.TextBox txtAuth;
        private System.Windows.Forms.Label authLabel;
        private System.Windows.Forms.Button btnSendTokenAgain;
    }
}