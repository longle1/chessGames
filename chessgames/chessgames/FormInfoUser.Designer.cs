namespace chessgames
{
    partial class FormInfoUser
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
            this.ptboxAvatar = new System.Windows.Forms.PictureBox();
            this.lbID = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lbUserName = new System.Windows.Forms.Label();
            this.txtWins = new System.Windows.Forms.TextBox();
            this.lbWins = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lbEmail = new System.Windows.Forms.Label();
            this.txtDefeats = new System.Windows.Forms.TextBox();
            this.lbDefeats = new System.Windows.Forms.Label();
            this.btnChangeImage = new System.Windows.Forms.Button();
            this.btnSaveInfo = new System.Windows.Forms.Button();
            this.btnEditInfo = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ptboxAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // ptboxAvatar
            // 
            this.ptboxAvatar.Location = new System.Drawing.Point(37, 12);
            this.ptboxAvatar.Name = "ptboxAvatar";
            this.ptboxAvatar.Size = new System.Drawing.Size(129, 117);
            this.ptboxAvatar.TabIndex = 0;
            this.ptboxAvatar.TabStop = false;
            // 
            // lbID
            // 
            this.lbID.AutoSize = true;
            this.lbID.Location = new System.Drawing.Point(34, 147);
            this.lbID.Name = "lbID";
            this.lbID.Size = new System.Drawing.Size(20, 16);
            this.lbID.TabIndex = 1;
            this.lbID.Text = "ID";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(37, 166);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(248, 22);
            this.txtID.TabIndex = 2;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(37, 214);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(248, 22);
            this.txtUsername.TabIndex = 4;
            // 
            // lbUserName
            // 
            this.lbUserName.AutoSize = true;
            this.lbUserName.Location = new System.Drawing.Point(34, 195);
            this.lbUserName.Name = "lbUserName";
            this.lbUserName.Size = new System.Drawing.Size(70, 16);
            this.lbUserName.TabIndex = 3;
            this.lbUserName.Text = "Username";
            // 
            // txtWins
            // 
            this.txtWins.Location = new System.Drawing.Point(37, 307);
            this.txtWins.Name = "txtWins";
            this.txtWins.Size = new System.Drawing.Size(248, 22);
            this.txtWins.TabIndex = 8;
            // 
            // lbWins
            // 
            this.lbWins.AutoSize = true;
            this.lbWins.Location = new System.Drawing.Point(34, 288);
            this.lbWins.Name = "lbWins";
            this.lbWins.Size = new System.Drawing.Size(85, 16);
            this.lbWins.TabIndex = 7;
            this.lbWins.Text = "Số trận thắng";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(37, 259);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(248, 22);
            this.txtEmail.TabIndex = 6;
            // 
            // lbEmail
            // 
            this.lbEmail.AutoSize = true;
            this.lbEmail.Location = new System.Drawing.Point(34, 240);
            this.lbEmail.Name = "lbEmail";
            this.lbEmail.Size = new System.Drawing.Size(41, 16);
            this.lbEmail.TabIndex = 5;
            this.lbEmail.Text = "Email";
            // 
            // txtDefeats
            // 
            this.txtDefeats.Location = new System.Drawing.Point(37, 356);
            this.txtDefeats.Name = "txtDefeats";
            this.txtDefeats.Size = new System.Drawing.Size(248, 22);
            this.txtDefeats.TabIndex = 10;
            // 
            // lbDefeats
            // 
            this.lbDefeats.AutoSize = true;
            this.lbDefeats.Location = new System.Drawing.Point(34, 337);
            this.lbDefeats.Name = "lbDefeats";
            this.lbDefeats.Size = new System.Drawing.Size(77, 16);
            this.lbDefeats.TabIndex = 9;
            this.lbDefeats.Text = "Số trận thua";
            // 
            // btnChangeImage
            // 
            this.btnChangeImage.Location = new System.Drawing.Point(187, 91);
            this.btnChangeImage.Name = "btnChangeImage";
            this.btnChangeImage.Size = new System.Drawing.Size(180, 38);
            this.btnChangeImage.TabIndex = 11;
            this.btnChangeImage.Text = "Chọn hình ảnh";
            this.btnChangeImage.UseVisualStyleBackColor = true;
            this.btnChangeImage.Click += new System.EventHandler(this.btnChangeImage_Click);
            // 
            // btnSaveInfo
            // 
            this.btnSaveInfo.Location = new System.Drawing.Point(603, 12);
            this.btnSaveInfo.Name = "btnSaveInfo";
            this.btnSaveInfo.Size = new System.Drawing.Size(180, 38);
            this.btnSaveInfo.TabIndex = 12;
            this.btnSaveInfo.Text = "Lưu thông tin";
            this.btnSaveInfo.UseVisualStyleBackColor = true;
            this.btnSaveInfo.Click += new System.EventHandler(this.btnSaveInfo_Click);
            // 
            // btnEditInfo
            // 
            this.btnEditInfo.Location = new System.Drawing.Point(417, 12);
            this.btnEditInfo.Name = "btnEditInfo";
            this.btnEditInfo.Size = new System.Drawing.Size(180, 38);
            this.btnEditInfo.TabIndex = 13;
            this.btnEditInfo.Text = "Chỉnh sửa thông tin";
            this.btnEditInfo.UseVisualStyleBackColor = true;
            this.btnEditInfo.Click += new System.EventHandler(this.btnEditInfo_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(532, 340);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(116, 38);
            this.btnBack.TabIndex = 14;
            this.btnBack.Text = "Quay lại";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // FormInfoUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnEditInfo);
            this.Controls.Add(this.btnSaveInfo);
            this.Controls.Add(this.btnChangeImage);
            this.Controls.Add(this.txtDefeats);
            this.Controls.Add(this.lbDefeats);
            this.Controls.Add(this.txtWins);
            this.Controls.Add(this.lbWins);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lbEmail);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lbUserName);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.lbID);
            this.Controls.Add(this.ptboxAvatar);
            this.Name = "FormInfoUser";
            this.Text = "FormInfoUser";
            this.Load += new System.EventHandler(this.FormInfoUser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ptboxAvatar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ptboxAvatar;
        private System.Windows.Forms.Label lbID;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lbUserName;
        private System.Windows.Forms.TextBox txtWins;
        private System.Windows.Forms.Label lbWins;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lbEmail;
        private System.Windows.Forms.TextBox txtDefeats;
        private System.Windows.Forms.Label lbDefeats;
        private System.Windows.Forms.Button btnChangeImage;
        private System.Windows.Forms.Button btnSaveInfo;
        private System.Windows.Forms.Button btnEditInfo;
        private System.Windows.Forms.Button btnBack;
    }
}