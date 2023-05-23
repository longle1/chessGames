namespace chessgames
{
    partial class Form1
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
            this.pnlContainPieces = new System.Windows.Forms.Panel();
            this.txtCountTime = new System.Windows.Forms.TextBox();
            this.listChat = new System.Windows.Forms.RichTextBox();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnSendIcon = new System.Windows.Forms.Button();
            this.btnSendData = new System.Windows.Forms.Button();
            this.pnlContainsIcon = new System.Windows.Forms.Panel();
            this.txtTurnUser = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnOutRoom = new System.Windows.Forms.Button();
            this.avtCurrentPlayer = new System.Windows.Forms.PictureBox();
            this.avtDifPlayer = new System.Windows.Forms.PictureBox();
            this.lbCurrentPlayer = new System.Windows.Forms.Label();
            this.lbDifPlayer = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.avtCurrentPlayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.avtDifPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlContainPieces
            // 
            this.pnlContainPieces.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlContainPieces.Location = new System.Drawing.Point(25, 128);
            this.pnlContainPieces.Name = "pnlContainPieces";
            this.pnlContainPieces.Size = new System.Drawing.Size(290, 497);
            this.pnlContainPieces.TabIndex = 0;
            // 
            // txtCountTime
            // 
            this.txtCountTime.BackColor = System.Drawing.Color.LemonChiffon;
            this.txtCountTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCountTime.Location = new System.Drawing.Point(642, 33);
            this.txtCountTime.Multiline = true;
            this.txtCountTime.Name = "txtCountTime";
            this.txtCountTime.ReadOnly = true;
            this.txtCountTime.Size = new System.Drawing.Size(152, 47);
            this.txtCountTime.TabIndex = 5;
            // 
            // listChat
            // 
            this.listChat.Location = new System.Drawing.Point(1033, 128);
            this.listChat.Name = "listChat";
            this.listChat.Size = new System.Drawing.Size(380, 447);
            this.listChat.TabIndex = 0;
            this.listChat.Text = "";
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(1033, 573);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(261, 42);
            this.txtMessage.TabIndex = 1;
            // 
            // btnSendIcon
            // 
            this.btnSendIcon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnSendIcon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendIcon.Location = new System.Drawing.Point(1290, 573);
            this.btnSendIcon.Name = "btnSendIcon";
            this.btnSendIcon.Size = new System.Drawing.Size(58, 42);
            this.btnSendIcon.TabIndex = 6;
            this.btnSendIcon.Text = "...";
            this.btnSendIcon.UseVisualStyleBackColor = false;
            this.btnSendIcon.Click += new System.EventHandler(this.btnSendIcon_Click);
            // 
            // btnSendData
            // 
            this.btnSendData.BackColor = System.Drawing.Color.Red;
            this.btnSendData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendData.Location = new System.Drawing.Point(1348, 573);
            this.btnSendData.Name = "btnSendData";
            this.btnSendData.Size = new System.Drawing.Size(65, 42);
            this.btnSendData.TabIndex = 7;
            this.btnSendData.Text = ">";
            this.btnSendData.UseVisualStyleBackColor = false;
            this.btnSendData.Click += new System.EventHandler(this.btnSendData_Click);
            // 
            // pnlContainsIcon
            // 
            this.pnlContainsIcon.Location = new System.Drawing.Point(1031, 262);
            this.pnlContainsIcon.Name = "pnlContainsIcon";
            this.pnlContainsIcon.Size = new System.Drawing.Size(382, 313);
            this.pnlContainsIcon.TabIndex = 8;
            // 
            // txtTurnUser
            // 
            this.txtTurnUser.Enabled = false;
            this.txtTurnUser.Location = new System.Drawing.Point(1290, 28);
            this.txtTurnUser.Multiline = true;
            this.txtTurnUser.Name = "txtTurnUser";
            this.txtTurnUser.Size = new System.Drawing.Size(141, 94);
            this.txtTurnUser.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1345, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Lượt của";
            // 
            // btnOutRoom
            // 
            this.btnOutRoom.Location = new System.Drawing.Point(1159, 42);
            this.btnOutRoom.Name = "btnOutRoom";
            this.btnOutRoom.Size = new System.Drawing.Size(125, 56);
            this.btnOutRoom.TabIndex = 11;
            this.btnOutRoom.Text = "Thoát phòng";
            this.btnOutRoom.UseVisualStyleBackColor = true;
            this.btnOutRoom.Click += new System.EventHandler(this.btnOutRoom_Click);
            // 
            // avtCurrentPlayer
            // 
            this.avtCurrentPlayer.Location = new System.Drawing.Point(437, 28);
            this.avtCurrentPlayer.Name = "avtCurrentPlayer";
            this.avtCurrentPlayer.Size = new System.Drawing.Size(85, 71);
            this.avtCurrentPlayer.TabIndex = 12;
            this.avtCurrentPlayer.TabStop = false;
            // 
            // avtDifPlayer
            // 
            this.avtDifPlayer.Location = new System.Drawing.Point(935, 28);
            this.avtDifPlayer.Name = "avtDifPlayer";
            this.avtDifPlayer.Size = new System.Drawing.Size(85, 71);
            this.avtDifPlayer.TabIndex = 13;
            this.avtDifPlayer.TabStop = false;
            // 
            // lbCurrentPlayer
            // 
            this.lbCurrentPlayer.AutoSize = true;
            this.lbCurrentPlayer.Location = new System.Drawing.Point(451, 9);
            this.lbCurrentPlayer.Name = "lbCurrentPlayer";
            this.lbCurrentPlayer.Size = new System.Drawing.Size(0, 16);
            this.lbCurrentPlayer.TabIndex = 14;
            // 
            // lbDifPlayer
            // 
            this.lbDifPlayer.AutoSize = true;
            this.lbDifPlayer.Location = new System.Drawing.Point(941, 9);
            this.lbDifPlayer.Name = "lbDifPlayer";
            this.lbDifPlayer.Size = new System.Drawing.Size(0, 16);
            this.lbDifPlayer.TabIndex = 15;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LemonChiffon;
            this.ClientSize = new System.Drawing.Size(1443, 765);
            this.Controls.Add(this.lbDifPlayer);
            this.Controls.Add(this.lbCurrentPlayer);
            this.Controls.Add(this.avtDifPlayer);
            this.Controls.Add(this.avtCurrentPlayer);
            this.Controls.Add(this.btnOutRoom);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTurnUser);
            this.Controls.Add(this.pnlContainsIcon);
            this.Controls.Add(this.btnSendData);
            this.Controls.Add(this.btnSendIcon);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.listChat);
            this.Controls.Add(this.txtCountTime);
            this.Controls.Add(this.pnlContainPieces);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.avtCurrentPlayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.avtDifPlayer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlContainPieces;
        private System.Windows.Forms.TextBox txtCountTime;
        private System.Windows.Forms.RichTextBox listChat;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnSendIcon;
        private System.Windows.Forms.Button btnSendData;
        private System.Windows.Forms.Panel pnlContainsIcon;
        private System.Windows.Forms.TextBox txtTurnUser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnOutRoom;
        private System.Windows.Forms.PictureBox avtCurrentPlayer;
        private System.Windows.Forms.PictureBox avtDifPlayer;
        private System.Windows.Forms.Label lbCurrentPlayer;
        private System.Windows.Forms.Label lbDifPlayer;
    }
}

