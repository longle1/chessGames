namespace chessgames
{
    partial class mainInterface
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
            this.btnContainInfoUser = new System.Windows.Forms.Button();
            this.ptboxAvatar = new System.Windows.Forms.PictureBox();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnMakeFriend = new System.Windows.Forms.Button();
            this.btnRank = new System.Windows.Forms.Button();
            this.btnListFriend = new System.Windows.Forms.Button();
            this.rtbChat = new System.Windows.Forms.RichTextBox();
            this.txtSendMessage = new System.Windows.Forms.TextBox();
            this.btnSendIcon = new System.Windows.Forms.Button();
            this.btnSendMessage = new System.Windows.Forms.Button();
            this.dtGridContainListRooms = new System.Windows.Forms.DataGridView();
            this.btnCreateRoom = new System.Windows.Forms.Button();
            this.btnRandomRoom = new System.Windows.Forms.Button();
            this.lbUserName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbScore = new System.Windows.Forms.Label();
            this.pnlContainsIcon = new System.Windows.Forms.Panel();
            this.pnlListFriends = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.tbControls = new System.Windows.Forms.TabControl();
            this.tbFindUser = new System.Windows.Forms.TabPage();
            this.dtAllUsers = new System.Windows.Forms.DataGridView();
            this.btnFindUser = new System.Windows.Forms.Button();
            this.txtFindUser = new System.Windows.Forms.TextBox();
            this.tbFriends = new System.Windows.Forms.TabPage();
            this.dtListFriends = new System.Windows.Forms.DataGridView();
            this.tbAccept = new System.Windows.Forms.TabPage();
            this.dtAcceptFriend = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.ptboxAvatar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridContainListRooms)).BeginInit();
            this.pnlListFriends.SuspendLayout();
            this.tbControls.SuspendLayout();
            this.tbFindUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtAllUsers)).BeginInit();
            this.tbFriends.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtListFriends)).BeginInit();
            this.tbAccept.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtAcceptFriend)).BeginInit();
            this.SuspendLayout();
            // 
            // btnContainInfoUser
            // 
            this.btnContainInfoUser.Location = new System.Drawing.Point(881, 21);
            this.btnContainInfoUser.Name = "btnContainInfoUser";
            this.btnContainInfoUser.Size = new System.Drawing.Size(136, 51);
            this.btnContainInfoUser.TabIndex = 13;
            this.btnContainInfoUser.Text = "Xem thông tin";
            this.btnContainInfoUser.UseVisualStyleBackColor = true;
            this.btnContainInfoUser.Click += new System.EventHandler(this.btnContainInfoUser_Click);
            // 
            // ptboxAvatar
            // 
            this.ptboxAvatar.Location = new System.Drawing.Point(28, 12);
            this.ptboxAvatar.Name = "ptboxAvatar";
            this.ptboxAvatar.Size = new System.Drawing.Size(129, 117);
            this.ptboxAvatar.TabIndex = 12;
            this.ptboxAvatar.TabStop = false;
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(1032, 21);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(136, 51);
            this.btnLogout.TabIndex = 14;
            this.btnLogout.Text = "Đăng xuất";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnMakeFriend
            // 
            this.btnMakeFriend.Location = new System.Drawing.Point(1032, 78);
            this.btnMakeFriend.Name = "btnMakeFriend";
            this.btnMakeFriend.Size = new System.Drawing.Size(136, 51);
            this.btnMakeFriend.TabIndex = 16;
            this.btnMakeFriend.Text = "Kết bạn";
            this.btnMakeFriend.UseVisualStyleBackColor = true;
            this.btnMakeFriend.Click += new System.EventHandler(this.btnMakeFriend_Click);
            // 
            // btnRank
            // 
            this.btnRank.Location = new System.Drawing.Point(881, 78);
            this.btnRank.Name = "btnRank";
            this.btnRank.Size = new System.Drawing.Size(136, 51);
            this.btnRank.TabIndex = 15;
            this.btnRank.Text = "Bảng xếp hạng";
            this.btnRank.UseVisualStyleBackColor = true;
            this.btnRank.Click += new System.EventHandler(this.btnRank_Click);
            // 
            // btnListFriend
            // 
            this.btnListFriend.Location = new System.Drawing.Point(21, 164);
            this.btnListFriend.Name = "btnListFriend";
            this.btnListFriend.Size = new System.Drawing.Size(211, 40);
            this.btnListFriend.TabIndex = 17;
            this.btnListFriend.Text = "Danh sách bạn bè";
            this.btnListFriend.UseVisualStyleBackColor = true;
            this.btnListFriend.Click += new System.EventHandler(this.btnListFriend_Click);
            // 
            // rtbChat
            // 
            this.rtbChat.Location = new System.Drawing.Point(21, 210);
            this.rtbChat.Name = "rtbChat";
            this.rtbChat.Size = new System.Drawing.Size(324, 347);
            this.rtbChat.TabIndex = 18;
            this.rtbChat.Text = "";
            // 
            // txtSendMessage
            // 
            this.txtSendMessage.Location = new System.Drawing.Point(21, 554);
            this.txtSendMessage.Multiline = true;
            this.txtSendMessage.Name = "txtSendMessage";
            this.txtSendMessage.Size = new System.Drawing.Size(188, 31);
            this.txtSendMessage.TabIndex = 19;
            // 
            // btnSendIcon
            // 
            this.btnSendIcon.Location = new System.Drawing.Point(206, 554);
            this.btnSendIcon.Name = "btnSendIcon";
            this.btnSendIcon.Size = new System.Drawing.Size(71, 31);
            this.btnSendIcon.TabIndex = 20;
            this.btnSendIcon.Text = "...";
            this.btnSendIcon.UseVisualStyleBackColor = true;
            this.btnSendIcon.Click += new System.EventHandler(this.btnSendIcon_Click);
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.Location = new System.Drawing.Point(274, 554);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(71, 31);
            this.btnSendMessage.TabIndex = 21;
            this.btnSendMessage.Text = ">";
            this.btnSendMessage.UseVisualStyleBackColor = true;
            this.btnSendMessage.Click += new System.EventHandler(this.btnSendMessage_Click);
            // 
            // dtGridContainListRooms
            // 
            this.dtGridContainListRooms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGridContainListRooms.Location = new System.Drawing.Point(470, 164);
            this.dtGridContainListRooms.Name = "dtGridContainListRooms";
            this.dtGridContainListRooms.RowHeadersWidth = 51;
            this.dtGridContainListRooms.RowTemplate.Height = 24;
            this.dtGridContainListRooms.Size = new System.Drawing.Size(698, 375);
            this.dtGridContainListRooms.TabIndex = 22;
            this.dtGridContainListRooms.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGridContainListRooms_CellContentClick);
            // 
            // btnCreateRoom
            // 
            this.btnCreateRoom.Location = new System.Drawing.Point(1014, 545);
            this.btnCreateRoom.Name = "btnCreateRoom";
            this.btnCreateRoom.Size = new System.Drawing.Size(154, 40);
            this.btnCreateRoom.TabIndex = 24;
            this.btnCreateRoom.Text = "Tạo phòng";
            this.btnCreateRoom.UseVisualStyleBackColor = true;
            this.btnCreateRoom.Click += new System.EventHandler(this.btnCreateRoom_Click);
            // 
            // btnRandomRoom
            // 
            this.btnRandomRoom.Location = new System.Drawing.Point(854, 545);
            this.btnRandomRoom.Name = "btnRandomRoom";
            this.btnRandomRoom.Size = new System.Drawing.Size(154, 40);
            this.btnRandomRoom.TabIndex = 25;
            this.btnRandomRoom.Text = "Tham gia ngẫu nhiên";
            this.btnRandomRoom.UseVisualStyleBackColor = true;
            this.btnRandomRoom.Click += new System.EventHandler(this.btnRandomRoom_Click);
            // 
            // lbUserName
            // 
            this.lbUserName.AutoSize = true;
            this.lbUserName.Location = new System.Drawing.Point(165, 95);
            this.lbUserName.Name = "lbUserName";
            this.lbUserName.Size = new System.Drawing.Size(0, 16);
            this.lbUserName.TabIndex = 26;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(163, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 16);
            this.label2.TabIndex = 27;
            this.label2.Text = "Điểm:";
            // 
            // lbScore
            // 
            this.lbScore.AutoSize = true;
            this.lbScore.Location = new System.Drawing.Point(213, 113);
            this.lbScore.Name = "lbScore";
            this.lbScore.Size = new System.Drawing.Size(0, 16);
            this.lbScore.TabIndex = 28;
            // 
            // pnlContainsIcon
            // 
            this.pnlContainsIcon.Location = new System.Drawing.Point(21, 285);
            this.pnlContainsIcon.Name = "pnlContainsIcon";
            this.pnlContainsIcon.Size = new System.Drawing.Size(324, 272);
            this.pnlContainsIcon.TabIndex = 29;
            // 
            // pnlListFriends
            // 
            this.pnlListFriends.Controls.Add(this.btnExit);
            this.pnlListFriends.Controls.Add(this.tbControls);
            this.pnlListFriends.Location = new System.Drawing.Point(183, 36);
            this.pnlListFriends.Name = "pnlListFriends";
            this.pnlListFriends.Size = new System.Drawing.Size(866, 566);
            this.pnlListFriends.TabIndex = 30;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(813, 0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(53, 48);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "X";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // tbControls
            // 
            this.tbControls.Controls.Add(this.tbFindUser);
            this.tbControls.Controls.Add(this.tbFriends);
            this.tbControls.Controls.Add(this.tbAccept);
            this.tbControls.Location = new System.Drawing.Point(0, 54);
            this.tbControls.Name = "tbControls";
            this.tbControls.SelectedIndex = 0;
            this.tbControls.Size = new System.Drawing.Size(866, 512);
            this.tbControls.TabIndex = 1;
            // 
            // tbFindUser
            // 
            this.tbFindUser.Controls.Add(this.dtAllUsers);
            this.tbFindUser.Controls.Add(this.btnFindUser);
            this.tbFindUser.Controls.Add(this.txtFindUser);
            this.tbFindUser.Location = new System.Drawing.Point(4, 25);
            this.tbFindUser.Name = "tbFindUser";
            this.tbFindUser.Padding = new System.Windows.Forms.Padding(10);
            this.tbFindUser.Size = new System.Drawing.Size(858, 483);
            this.tbFindUser.TabIndex = 0;
            this.tbFindUser.Text = "Tìm kiếm";
            this.tbFindUser.UseVisualStyleBackColor = true;
            // 
            // dtAllUsers
            // 
            this.dtAllUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtAllUsers.Location = new System.Drawing.Point(76, 61);
            this.dtAllUsers.Name = "dtAllUsers";
            this.dtAllUsers.RowHeadersWidth = 51;
            this.dtAllUsers.RowTemplate.Height = 24;
            this.dtAllUsers.Size = new System.Drawing.Size(696, 419);
            this.dtAllUsers.TabIndex = 3;
            this.dtAllUsers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtAllUsers_CellContentClick);
            // 
            // btnFindUser
            // 
            this.btnFindUser.Location = new System.Drawing.Point(463, 20);
            this.btnFindUser.Name = "btnFindUser";
            this.btnFindUser.Size = new System.Drawing.Size(126, 23);
            this.btnFindUser.TabIndex = 2;
            this.btnFindUser.Text = "Tìm kiếm";
            this.btnFindUser.UseVisualStyleBackColor = true;
            this.btnFindUser.Click += new System.EventHandler(this.btnFindUser_Click);
            // 
            // txtFindUser
            // 
            this.txtFindUser.Location = new System.Drawing.Point(235, 20);
            this.txtFindUser.Name = "txtFindUser";
            this.txtFindUser.Size = new System.Drawing.Size(222, 22);
            this.txtFindUser.TabIndex = 1;
            // 
            // tbFriends
            // 
            this.tbFriends.Controls.Add(this.dtListFriends);
            this.tbFriends.Location = new System.Drawing.Point(4, 25);
            this.tbFriends.Name = "tbFriends";
            this.tbFriends.Padding = new System.Windows.Forms.Padding(3);
            this.tbFriends.Size = new System.Drawing.Size(858, 483);
            this.tbFriends.TabIndex = 1;
            this.tbFriends.Text = "Danh sách bạn bè";
            this.tbFriends.UseVisualStyleBackColor = true;
            // 
            // dtListFriends
            // 
            this.dtListFriends.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtListFriends.Location = new System.Drawing.Point(51, 14);
            this.dtListFriends.Name = "dtListFriends";
            this.dtListFriends.RowHeadersWidth = 51;
            this.dtListFriends.RowTemplate.Height = 24;
            this.dtListFriends.Size = new System.Drawing.Size(770, 469);
            this.dtListFriends.TabIndex = 0;
            this.dtListFriends.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtListFriends_CellContentClick);
            // 
            // tbAccept
            // 
            this.tbAccept.Controls.Add(this.dtAcceptFriend);
            this.tbAccept.Location = new System.Drawing.Point(4, 25);
            this.tbAccept.Name = "tbAccept";
            this.tbAccept.Padding = new System.Windows.Forms.Padding(3);
            this.tbAccept.Size = new System.Drawing.Size(858, 483);
            this.tbAccept.TabIndex = 2;
            this.tbAccept.Text = "Chấp nhận lời mời";
            this.tbAccept.UseVisualStyleBackColor = true;
            // 
            // dtAcceptFriend
            // 
            this.dtAcceptFriend.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtAcceptFriend.Location = new System.Drawing.Point(87, 41);
            this.dtAcceptFriend.Name = "dtAcceptFriend";
            this.dtAcceptFriend.RowHeadersWidth = 51;
            this.dtAcceptFriend.RowTemplate.Height = 24;
            this.dtAcceptFriend.Size = new System.Drawing.Size(688, 429);
            this.dtAcceptFriend.TabIndex = 0;
            this.dtAcceptFriend.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtAcceptFriend_CellContentClick);
            // 
            // mainInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1196, 662);
            this.Controls.Add(this.pnlListFriends);
            this.Controls.Add(this.pnlContainsIcon);
            this.Controls.Add(this.lbScore);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbUserName);
            this.Controls.Add(this.btnRandomRoom);
            this.Controls.Add(this.btnCreateRoom);
            this.Controls.Add(this.dtGridContainListRooms);
            this.Controls.Add(this.btnSendMessage);
            this.Controls.Add(this.btnSendIcon);
            this.Controls.Add(this.txtSendMessage);
            this.Controls.Add(this.rtbChat);
            this.Controls.Add(this.btnListFriend);
            this.Controls.Add(this.btnMakeFriend);
            this.Controls.Add(this.btnRank);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnContainInfoUser);
            this.Controls.Add(this.ptboxAvatar);
            this.Name = "mainInterface";
            this.Text = "mainInterface";
            this.Load += new System.EventHandler(this.mainInterface_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ptboxAvatar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridContainListRooms)).EndInit();
            this.pnlListFriends.ResumeLayout(false);
            this.tbControls.ResumeLayout(false);
            this.tbFindUser.ResumeLayout(false);
            this.tbFindUser.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtAllUsers)).EndInit();
            this.tbFriends.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtListFriends)).EndInit();
            this.tbAccept.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtAcceptFriend)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnContainInfoUser;
        private System.Windows.Forms.PictureBox ptboxAvatar;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnMakeFriend;
        private System.Windows.Forms.Button btnRank;
        private System.Windows.Forms.Button btnListFriend;
        private System.Windows.Forms.RichTextBox rtbChat;
        private System.Windows.Forms.TextBox txtSendMessage;
        private System.Windows.Forms.Button btnSendIcon;
        private System.Windows.Forms.Button btnSendMessage;
        private System.Windows.Forms.DataGridView dtGridContainListRooms;
        private System.Windows.Forms.Button btnCreateRoom;
        private System.Windows.Forms.Button btnRandomRoom;
        private System.Windows.Forms.Label lbUserName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbScore;
        private System.Windows.Forms.Panel pnlContainsIcon;
        private System.Windows.Forms.Panel pnlListFriends;
        private System.Windows.Forms.TabControl tbControls;
        private System.Windows.Forms.TabPage tbFindUser;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TabPage tbFriends;
        private System.Windows.Forms.TabPage tbAccept;
        private System.Windows.Forms.DataGridView dtAllUsers;
        private System.Windows.Forms.Button btnFindUser;
        private System.Windows.Forms.TextBox txtFindUser;
        private System.Windows.Forms.DataGridView dtListFriends;
        private System.Windows.Forms.DataGridView dtAcceptFriend;
    }
}