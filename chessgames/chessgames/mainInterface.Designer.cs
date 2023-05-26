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
            this.btnHistory = new System.Windows.Forms.Button();
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
            this.pnlContainsChild = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.pnlListFriends = new System.Windows.Forms.Panel();
            this.tbControls = new System.Windows.Forms.TabControl();
            this.tbFindUser = new System.Windows.Forms.TabPage();
            this.pnlChatOne = new System.Windows.Forms.Panel();
            this.dtAllUsers = new System.Windows.Forms.DataGridView();
            this.btnFindUser = new System.Windows.Forms.Button();
            this.txtFindUser = new System.Windows.Forms.TextBox();
            this.tbFriends = new System.Windows.Forms.TabPage();
            this.dtListFriends = new System.Windows.Forms.DataGridView();
            this.tbAccept = new System.Windows.Forms.TabPage();
            this.dtAcceptFriend = new System.Windows.Forms.DataGridView();
            this.pnlChildContainHistory = new System.Windows.Forms.Panel();
            this.pnlRanker = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbCurrentRank = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbYourRank = new System.Windows.Forms.Label();
            this.pnlYourLevel = new System.Windows.Forms.FlowLayoutPanel();
            this.dtGridRank = new System.Windows.Forms.DataGridView();
            this.pnlCreateRoom = new System.Windows.Forms.Panel();
            this.txtBetPoints = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAcceptCreateRoom = new System.Windows.Forms.Button();
            this.txtRoomName = new System.Windows.Forms.TextBox();
            this.dtGridViewHistory = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.ptboxAvatar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridContainListRooms)).BeginInit();
            this.pnlContainsChild.SuspendLayout();
            this.pnlListFriends.SuspendLayout();
            this.tbControls.SuspendLayout();
            this.tbFindUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtAllUsers)).BeginInit();
            this.tbFriends.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtListFriends)).BeginInit();
            this.tbAccept.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtAcceptFriend)).BeginInit();
            this.pnlChildContainHistory.SuspendLayout();
            this.pnlRanker.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridRank)).BeginInit();
            this.pnlCreateRoom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridViewHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // btnContainInfoUser
            // 
            this.btnContainInfoUser.Location = new System.Drawing.Point(1047, 12);
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
            this.btnLogout.Location = new System.Drawing.Point(1198, 12);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(136, 51);
            this.btnLogout.TabIndex = 14;
            this.btnLogout.Text = "Đăng xuất";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnMakeFriend
            // 
            this.btnMakeFriend.Location = new System.Drawing.Point(1198, 69);
            this.btnMakeFriend.Name = "btnMakeFriend";
            this.btnMakeFriend.Size = new System.Drawing.Size(136, 51);
            this.btnMakeFriend.TabIndex = 16;
            this.btnMakeFriend.Text = "Danh sách";
            this.btnMakeFriend.UseVisualStyleBackColor = true;
            this.btnMakeFriend.Click += new System.EventHandler(this.btnMakeFriend_Click);
            // 
            // btnRank
            // 
            this.btnRank.Location = new System.Drawing.Point(1047, 69);
            this.btnRank.Name = "btnRank";
            this.btnRank.Size = new System.Drawing.Size(136, 51);
            this.btnRank.TabIndex = 15;
            this.btnRank.Text = "Bảng xếp hạng";
            this.btnRank.UseVisualStyleBackColor = true;
            this.btnRank.Click += new System.EventHandler(this.btnRank_Click);
            // 
            // btnHistory
            // 
            this.btnHistory.Location = new System.Drawing.Point(21, 164);
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Size = new System.Drawing.Size(159, 40);
            this.btnHistory.TabIndex = 31;
            this.btnHistory.Text = "Lịch sử đấu";
            this.btnHistory.Click += new System.EventHandler(this.btnHistory_Click);
            // 
            // rtbChat
            // 
            this.rtbChat.Location = new System.Drawing.Point(21, 210);
            this.rtbChat.Name = "rtbChat";
            this.rtbChat.Size = new System.Drawing.Size(397, 347);
            this.rtbChat.TabIndex = 18;
            this.rtbChat.Text = "";
            // 
            // txtSendMessage
            // 
            this.txtSendMessage.Location = new System.Drawing.Point(21, 554);
            this.txtSendMessage.Multiline = true;
            this.txtSendMessage.Name = "txtSendMessage";
            this.txtSendMessage.Size = new System.Drawing.Size(255, 42);
            this.txtSendMessage.TabIndex = 19;
            // 
            // btnSendIcon
            // 
            this.btnSendIcon.Location = new System.Drawing.Point(282, 557);
            this.btnSendIcon.Name = "btnSendIcon";
            this.btnSendIcon.Size = new System.Drawing.Size(71, 31);
            this.btnSendIcon.TabIndex = 20;
            this.btnSendIcon.Text = "...";
            this.btnSendIcon.UseVisualStyleBackColor = true;
            this.btnSendIcon.Click += new System.EventHandler(this.btnSendIcon_Click);
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.Location = new System.Drawing.Point(347, 554);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(71, 36);
            this.btnSendMessage.TabIndex = 21;
            this.btnSendMessage.Text = ">";
            this.btnSendMessage.UseVisualStyleBackColor = true;
            this.btnSendMessage.Click += new System.EventHandler(this.btnSendMessage_Click);
            // 
            // dtGridContainListRooms
            // 
            this.dtGridContainListRooms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGridContainListRooms.Location = new System.Drawing.Point(484, 134);
            this.dtGridContainListRooms.Name = "dtGridContainListRooms";
            this.dtGridContainListRooms.RowHeadersWidth = 51;
            this.dtGridContainListRooms.RowTemplate.Height = 24;
            this.dtGridContainListRooms.Size = new System.Drawing.Size(850, 414);
            this.dtGridContainListRooms.TabIndex = 22;
            this.dtGridContainListRooms.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGridContainListRooms_CellContentClick);
            // 
            // btnCreateRoom
            // 
            this.btnCreateRoom.Location = new System.Drawing.Point(1180, 554);
            this.btnCreateRoom.Name = "btnCreateRoom";
            this.btnCreateRoom.Size = new System.Drawing.Size(154, 40);
            this.btnCreateRoom.TabIndex = 24;
            this.btnCreateRoom.Text = "Tạo phòng";
            this.btnCreateRoom.UseVisualStyleBackColor = true;
            this.btnCreateRoom.Click += new System.EventHandler(this.btnCreateRoom_Click);
            // 
            // btnRandomRoom
            // 
            this.btnRandomRoom.Location = new System.Drawing.Point(1020, 554);
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
            this.pnlContainsIcon.Size = new System.Drawing.Size(397, 272);
            this.pnlContainsIcon.TabIndex = 29;
            // 
            // pnlContainsChild
            // 
            this.pnlContainsChild.AutoSize = true;
            this.pnlContainsChild.BackColor = System.Drawing.Color.Transparent;
            this.pnlContainsChild.Controls.Add(this.btnExit);
            this.pnlContainsChild.Controls.Add(this.pnlChildContainHistory);
            this.pnlContainsChild.Location = new System.Drawing.Point(1, 2);
            this.pnlContainsChild.Name = "pnlContainsChild";
            this.pnlContainsChild.Size = new System.Drawing.Size(1362, 640);
            this.pnlContainsChild.TabIndex = 32;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(1306, 0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(53, 48);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "X";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click_1);
            // 
            // pnlListFriends
            // 
            this.pnlListFriends.Controls.Add(this.tbControls);
            this.pnlListFriends.Location = new System.Drawing.Point(249, 64);
            this.pnlListFriends.Name = "pnlListFriends";
            this.pnlListFriends.Size = new System.Drawing.Size(866, 566);
            this.pnlListFriends.TabIndex = 30;
            this.pnlListFriends.Visible = false;
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
            this.tbFindUser.Controls.Add(this.pnlChatOne);
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
            // pnlChatOne
            // 
            this.pnlChatOne.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.pnlChatOne.Location = new System.Drawing.Point(582, 36);
            this.pnlChatOne.Name = "pnlChatOne";
            this.pnlChatOne.Size = new System.Drawing.Size(753, 454);
            this.pnlChatOne.TabIndex = 4;
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
            this.dtAllUsers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtAllUsers_CellContentClick_1);
            // 
            // btnFindUser
            // 
            this.btnFindUser.Location = new System.Drawing.Point(463, 20);
            this.btnFindUser.Name = "btnFindUser";
            this.btnFindUser.Size = new System.Drawing.Size(126, 23);
            this.btnFindUser.TabIndex = 2;
            this.btnFindUser.Text = "Tìm kiếm";
            this.btnFindUser.UseVisualStyleBackColor = true;
            this.btnFindUser.Click += new System.EventHandler(this.btnFindUser_Click_1);
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
            this.dtListFriends.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtListFriends_CellContentClick_1);
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
            this.dtAcceptFriend.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtAcceptFriend_CellContentClick_1);
            // 
            // pnlChildContainHistory
            // 
            this.pnlChildContainHistory.Controls.Add(this.pnlRanker);
            this.pnlChildContainHistory.Controls.Add(this.pnlListFriends);
            this.pnlChildContainHistory.Controls.Add(this.pnlCreateRoom);
            this.pnlChildContainHistory.Controls.Add(this.dtGridViewHistory);
            this.pnlChildContainHistory.Location = new System.Drawing.Point(125, 10);
            this.pnlChildContainHistory.Name = "pnlChildContainHistory";
            this.pnlChildContainHistory.Size = new System.Drawing.Size(866, 552);
            this.pnlChildContainHistory.TabIndex = 5;
            // 
            // pnlRanker
            // 
            this.pnlRanker.Controls.Add(this.panel2);
            this.pnlRanker.Controls.Add(this.panel1);
            this.pnlRanker.Controls.Add(this.pnlYourLevel);
            this.pnlRanker.Controls.Add(this.dtGridRank);
            this.pnlRanker.Location = new System.Drawing.Point(287, 35);
            this.pnlRanker.Name = "pnlRanker";
            this.pnlRanker.Size = new System.Drawing.Size(576, 549);
            this.pnlRanker.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.IndianRed;
            this.panel2.Controls.Add(this.lbCurrentRank);
            this.panel2.Location = new System.Drawing.Point(292, 490);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(284, 59);
            this.panel2.TabIndex = 4;
            // 
            // lbCurrentRank
            // 
            this.lbCurrentRank.AutoSize = true;
            this.lbCurrentRank.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCurrentRank.Location = new System.Drawing.Point(17, 10);
            this.lbCurrentRank.Name = "lbCurrentRank";
            this.lbCurrentRank.Size = new System.Drawing.Size(0, 38);
            this.lbCurrentRank.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.lbYourRank);
            this.panel1.Location = new System.Drawing.Point(0, 490);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(293, 59);
            this.panel1.TabIndex = 3;
            // 
            // lbYourRank
            // 
            this.lbYourRank.AutoSize = true;
            this.lbYourRank.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbYourRank.Location = new System.Drawing.Point(17, 10);
            this.lbYourRank.Name = "lbYourRank";
            this.lbYourRank.Size = new System.Drawing.Size(232, 38);
            this.lbYourRank.TabIndex = 4;
            this.lbYourRank.Text = "Hạng của bạn";
            // 
            // pnlYourLevel
            // 
            this.pnlYourLevel.Location = new System.Drawing.Point(3, 490);
            this.pnlYourLevel.Name = "pnlYourLevel";
            this.pnlYourLevel.Size = new System.Drawing.Size(573, 59);
            this.pnlYourLevel.TabIndex = 2;
            // 
            // dtGridRank
            // 
            this.dtGridRank.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGridRank.Location = new System.Drawing.Point(3, 54);
            this.dtGridRank.Name = "dtGridRank";
            this.dtGridRank.RowHeadersWidth = 51;
            this.dtGridRank.RowTemplate.Height = 24;
            this.dtGridRank.Size = new System.Drawing.Size(573, 437);
            this.dtGridRank.TabIndex = 1;
            // 
            // pnlCreateRoom
            // 
            this.pnlCreateRoom.Controls.Add(this.txtBetPoints);
            this.pnlCreateRoom.Controls.Add(this.label3);
            this.pnlCreateRoom.Controls.Add(this.label1);
            this.pnlCreateRoom.Controls.Add(this.btnAcceptCreateRoom);
            this.pnlCreateRoom.Controls.Add(this.txtRoomName);
            this.pnlCreateRoom.Location = new System.Drawing.Point(93, 101);
            this.pnlCreateRoom.Name = "pnlCreateRoom";
            this.pnlCreateRoom.Size = new System.Drawing.Size(437, 241);
            this.pnlCreateRoom.TabIndex = 2;
            // 
            // txtBetPoints
            // 
            this.txtBetPoints.Location = new System.Drawing.Point(99, 117);
            this.txtBetPoints.Name = "txtBetPoints";
            this.txtBetPoints.Size = new System.Drawing.Size(245, 22);
            this.txtBetPoints.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(97, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Nhập điểm cược";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(97, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Nhập tên phòng";
            // 
            // btnAcceptCreateRoom
            // 
            this.btnAcceptCreateRoom.Location = new System.Drawing.Point(129, 172);
            this.btnAcceptCreateRoom.Name = "btnAcceptCreateRoom";
            this.btnAcceptCreateRoom.Size = new System.Drawing.Size(175, 41);
            this.btnAcceptCreateRoom.TabIndex = 6;
            this.btnAcceptCreateRoom.Text = "Tạo phòng";
            this.btnAcceptCreateRoom.UseVisualStyleBackColor = true;
            this.btnAcceptCreateRoom.Click += new System.EventHandler(this.btnAcceptCreateRoom_Click_1);
            // 
            // txtRoomName
            // 
            this.txtRoomName.Location = new System.Drawing.Point(99, 55);
            this.txtRoomName.Name = "txtRoomName";
            this.txtRoomName.Size = new System.Drawing.Size(245, 22);
            this.txtRoomName.TabIndex = 4;
            // 
            // dtGridViewHistory
            // 
            this.dtGridViewHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGridViewHistory.Location = new System.Drawing.Point(0, 61);
            this.dtGridViewHistory.Name = "dtGridViewHistory";
            this.dtGridViewHistory.RowHeadersWidth = 51;
            this.dtGridViewHistory.RowTemplate.Height = 24;
            this.dtGridViewHistory.Size = new System.Drawing.Size(866, 491);
            this.dtGridViewHistory.TabIndex = 1;
            // 
            // mainInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1360, 638);
            this.Controls.Add(this.pnlContainsChild);
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
            this.Controls.Add(this.btnHistory);
            this.Controls.Add(this.btnMakeFriend);
            this.Controls.Add(this.btnRank);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnContainInfoUser);
            this.Controls.Add(this.ptboxAvatar);
            this.Name = "mainInterface";
            this.Text = "mainInterface";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.mainInterface_FormClosed);
            this.Load += new System.EventHandler(this.mainInterface_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ptboxAvatar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridContainListRooms)).EndInit();
            this.pnlContainsChild.ResumeLayout(false);
            this.pnlListFriends.ResumeLayout(false);
            this.tbControls.ResumeLayout(false);
            this.tbFindUser.ResumeLayout(false);
            this.tbFindUser.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtAllUsers)).EndInit();
            this.tbFriends.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtListFriends)).EndInit();
            this.tbAccept.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtAcceptFriend)).EndInit();
            this.pnlChildContainHistory.ResumeLayout(false);
            this.pnlRanker.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridRank)).EndInit();
            this.pnlCreateRoom.ResumeLayout(false);
            this.pnlCreateRoom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridViewHistory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnContainInfoUser;
        private System.Windows.Forms.PictureBox ptboxAvatar;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnMakeFriend;
        private System.Windows.Forms.Button btnRank;
        private System.Windows.Forms.Button btnHistory;
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
        private System.Windows.Forms.Panel pnlContainsChild;
        private System.Windows.Forms.Panel pnlChildContainHistory;
        private System.Windows.Forms.Panel pnlCreateRoom;
        private System.Windows.Forms.TextBox txtBetPoints;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAcceptCreateRoom;
        private System.Windows.Forms.TextBox txtRoomName;
        private System.Windows.Forms.DataGridView dtGridViewHistory;
        private System.Windows.Forms.Panel pnlListFriends;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel pnlRanker;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbCurrentRank;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbYourRank;
        private System.Windows.Forms.FlowLayoutPanel pnlYourLevel;
        private System.Windows.Forms.DataGridView dtGridRank;
        private System.Windows.Forms.TabControl tbControls;
        private System.Windows.Forms.TabPage tbFindUser;
        private System.Windows.Forms.DataGridView dtAllUsers;
        private System.Windows.Forms.Button btnFindUser;
        private System.Windows.Forms.TextBox txtFindUser;
        private System.Windows.Forms.TabPage tbFriends;
        private System.Windows.Forms.DataGridView dtListFriends;
        private System.Windows.Forms.TabPage tbAccept;
        private System.Windows.Forms.DataGridView dtAcceptFriend;
        private System.Windows.Forms.Panel pnlChatOne;
    }
}