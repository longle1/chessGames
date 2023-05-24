using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chessgames
{
    public partial class mainInterface : Form
    {
        private infoUser user;
        private string linkAvatar;
        public static mainInterface showInter = null;
        private string parentDirectory;
        private string apiGetListMatches = "https://chessmates.onrender.com/api/v1/matches";
        private string apiCreateRoom = "https://chessmates.onrender.com/api/v1/matches/add";
        private string apiGetUser = "https://chessmates.onrender.com/api/v1/users/edit/";
        private string apiGetAllUser = "https://chessmates.onrender.com/api/v1/users";
        private string apiGetUserId = "https://chessmates.onrender.com/api/v1/users/";
        private string apiMakeFriend = "https://chessmates.onrender.com/api/v1/listFriends/add";
        private string apiGetAllListFriend = "https://chessmates.onrender.com/api/v1/listFriends";
        private string apiUpdaStatusFriend = "https://chessmates.onrender.com/api/v1/listFriends/edit/";
        private string apiDeleteFriend = "https://chessmates.onrender.com/api/v1/listFriends/delete/";
        private string apiAddUserIntoMatch = "https://chessmates.onrender.com/api/v1/matches/edit/addOrSubUser/";
        TcpClient client = null;
        List<Button> buttonListIcons = new List<Button>();
        Button oldButton = new Button()
        {
            Height = 0,
            Width = 0
        };
        button btn = new button();
        Thread rcvDataThread = null;
        int iconNumbers = 29;
        string ipAddress = "172.20.41.112";
        private enum setting
        {
            createRoom = 0,
            makeFriend = 1,
            acceptFriend = 2,
            joinRoom = 3,
            chatOne = 4,
            chatMulti = 5,
            outRoom = 6,
            logout = 7,
            unFriend = 8
        }

        //============================================  CÁC HÀM XỬ LÝ RIÊNG BIỆT =========================================================
        private void mainInterface_Load(object sender, EventArgs e)
        {
            lbUserName.Text = user.userName;
            lbScore.Text = user.point.ToString();
            if (user.linkAvatar == "")
                user.linkAvatar = "defaultAvatar.jpg";
            ptboxAvatar.Image = Image.FromFile($"{parentDirectory}\\" + user.linkAvatar);
            ptboxAvatar.SizeMode = PictureBoxSizeMode.Zoom;
        }
        private async Task handleLogOutRoom()
        {
            apiGetUser += user.id;
            //cập nhật trạng thái thành offline
            var data = new
            {
                userName = user.userName,
                gmail = user.gmail,
                linkAvatar = user.linkAvatar == "defaultAvatar.jpg" ? "defaultAvatar.jpg" : user.linkAvatar,
                statusActive = "offline",
            };
            await callApiUsingMethodPut(data, apiGetUser);

            //gửi thông điệp logout lên server
            string message = (int)setting.logout + "*" + user.userName + "," + user.id;
            sendData(message);

            client = null;

            login.showFormAgain.Show();
            //tiến hành đóng form lại
            this.Close();
        }
        //=================================================================================================================================

        //============================================  HÀM KHỞI TẠO MẶC ĐỊNH =============================================================
        public mainInterface()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            pnlListFriends.Visible = false;
            pnlContainsIcon.Hide();
            rtbChat.ReadOnly = true;
            client = new TcpClient();
            client.Connect(System.Net.IPAddress.Parse(ipAddress), 8081);
            rcvDataThread = new Thread(new ThreadStart(rcvData));
            rcvDataThread.Start();
        }
        public mainInterface(infoUser user) : this()
        {
            parentDirectory = Directory.GetParent(Application.StartupPath)?.Parent?.FullName + "\\Images";
            this.user = user;
            lbUserName.Text = user.userName;
            lbScore.Text = user.point.ToString();
            ptboxAvatar.Image = Image.FromFile($"{parentDirectory}\\" + user.linkAvatar);
            ptboxAvatar.SizeMode = PictureBoxSizeMode.Zoom;
            showInter = this;

            //gửi thông điệp login lên server
            string message = user.userName;
            sendData(message);

            displayListMatches();
        }
        //==================================================================================================================================

        //============================================  HÀM DÙNG ĐỂ GỌI API ===============================================================
        public async Task<JToken> callApiUsingGetMethodID(string apiPath)
        {
            //làm mới lại danh sách khi có phần tử mới được thêm vào
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(apiPath);
            string jsonData = await response.Content.ReadAsStringAsync();
            JObject objData = JObject.Parse(jsonData);
            JToken tkData = objData["data"];

            return tkData;
        }
        public async Task<JToken> callApiUsingMethodGet(string apiPath)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(apiPath);
            JToken dataToken = null;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string responseData = await response.Content.ReadAsStringAsync();
                JObject jsonData = JObject.Parse(responseData);
                // Lấy giá trị của thuộc tính "data"
                dataToken = jsonData["data"];
                // Chuyển đổi sang đối tượng JSON
            }
            return dataToken;
        }
        public async Task callApiUsingMethodPost(object data, string apiPath)
        {
            //gọi tới API 
            HttpClient client = new HttpClient();
            var objData = JsonConvert.SerializeObject(data);
            await client.PostAsync(apiPath, new StringContent(objData, Encoding.UTF8, "application/json"));
        }
        public async Task callApiUsingMethodPut(object data, string apiPath)
        {
            //gọi tới API 
            HttpClient client = new HttpClient();
            string dataJson = JsonConvert.SerializeObject(data);
            //tiến hành lấy ra _id thỏa mãn
            await client.PutAsync(apiPath, new StringContent(dataJson, Encoding.UTF8, "application/json"));
        }
        //==================================================================================================================================

        //============================================  HÀM DÙNG ĐỂ LẤY RA DANH SÁCH NGƯỜI DÙNG ============================================
        public async void getListAllUser()
        {
            string apiPath = apiGetAllUser;
            JToken tokenData = await callApiUsingMethodGet(apiPath);
            List<infoUser> userLists = JsonConvert.DeserializeObject<List<infoUser>>(tokenData.ToString());
            foreach (infoUser item in userLists)
            {
                if (item.id == user.id)
                {
                    userLists.Remove(item);
                    break;
                }
            }
            //hiển thị danh sách tất cả user lên datagridView
            displayListUsers(userLists);
        }
        public async Task<List<infoUser>> getListUser(List<infoUser> lists, string status)
        {
            foreach (listFriends item in user.lists)
            {
                //tiến hành lấy ra listID
                List<string> listid = item.listID;
                string apiPath = "";
                if (status == "waiting")
                {
                    if (listid[0] != user.id)
                        apiPath = apiGetUserId + listid[0];
                    else
                        continue;
                }
                else if (status == "friend")
                {
                    string id = "";
                    foreach (string item1 in listid)
                        if (item1 != user.id) id = item1;
                    apiPath = apiGetUserId + id;
                }
                JToken tkData = await callApiUsingGetMethodID(apiPath);
                infoUser friend = JsonConvert.DeserializeObject<infoUser>(tkData.ToString());
                if (item.status.ToLower() == status)
                    lists.Add(friend);
            }
            return lists;
        }
        //==================================================================================================================================

        //============================================ CÁC HÀM DÙNG ĐỂ GỬI VÀ NHẬN DỮ LIỆU =================================================
        public void sendData(string msg)
        {
            if(client != null)
            {
                NetworkStream stream = client.GetStream();
                byte[] data = Encoding.UTF8.GetBytes(msg);
                stream.Write(data, 0, data.Length);
            }
        }
        public async void rcvData()
        {
            try
            {
                while (true)
                {
                    NetworkStream stream = client.GetStream();

                    byte[] data = new byte[1024 * 500];
                    int length = stream.Read(data, 0, data.Length);
                    if (length == 0) return;
                    string message = Encoding.UTF8.GetString(data, 0, length);
                    string[] listMsg = message.Split('*');
                    switch (int.Parse(listMsg[0]))
                    {
                        case 0:
                            //tiến hành cập nhật lại danh sách phòng chơi
                            displayListMatches();
                            break;
                        case 1:
                            JToken tkData = await callApiUsingGetMethodID(apiGetUserId + user.id);
                            this.user = JsonConvert.DeserializeObject<infoUser>(tkData.ToString());

                            //cập nhật lại danh sách tất cả user
                            getListAllUser();
                            List<infoUser> lists = new List<infoUser>();
                            displayListWaitingAccept(await getListUser(lists, "waiting"));
                            break;
                        case 2:
                            JToken tkData1 = await callApiUsingGetMethodID(apiGetUserId + user.id);
                            this.user = JsonConvert.DeserializeObject<infoUser>(tkData1.ToString());

                            //cập nhật lại danh sách tất cả user
                            getListAllUser();
                            List<infoUser> lists1 = new List<infoUser>();
                            displayListFriends(await getListUser(lists1, "friend"));
                            break;
                        case 5:
                            string[] msg = listMsg[1].Split(':');
                            if (listMsg[1].Contains("(1)"))
                                writeData(null, msg[1], 1, msg[0].Substring(0, msg[0].Length - 3));
                            else
                            {
                                string imageData = msg[1];
                                byte[] convertedBytes = Convert.FromBase64String(imageData);
                                // Chuyển đổi mảng byte thành hình ảnh
                                using (MemoryStream stream1 = new MemoryStream(convertedBytes))
                                {
                                    Image image = Image.FromStream(stream1);
                                    writeData(image, "", 2, msg[0].Substring(0, msg[0].Length - 3));
                                }
                            }
                            break;
                        case 7: //xử lý log out
                                //lấy id nhận về 
                            string id = listMsg[1].Split(',')[1];
                            //kiểm tra xem trong danh sách bạn bè xem có user này không
                            bool check = false;
                            foreach (listFriends item in user.lists)
                            {
                                if (item.status == "friend")
                                {
                                    if (item.listID.Contains(id))
                                    {
                                        check = true;
                                        break;
                                    }
                                }
                            }
                            if (check)
                            {
                                List<infoUser> lists3 = new List<infoUser>();
                                displayListFriends(await getListUser(lists3, "friend"));
                            }
                            break;
                        case 8:
                            //làm mới lại danh sách khi có phần tử mới được thêm vào
                            JToken tkData3 = await callApiUsingGetMethodID(apiGetUserId + user.id);
                            this.user = JsonConvert.DeserializeObject<infoUser>(tkData3.ToString());

                            //cập nhật lại danh sách tất cả user
                            getListAllUser();
                            List<infoUser> lists2 = new List<infoUser>();
                            displayListFriends(await getListUser(lists2, "friend"));
                            break;
                    }

                }
            }
            catch (Exception ex)
            {

            }
        }
        private void writeData(Image image, string msg, int mode, string userName)
        {
            try
            {

                if (mode == 1)
                {
                    if (msg.Trim() == "")
                        return;
                    MethodInvoker invoker = new MethodInvoker(delegate
                    {
                        if (userName == user.userName)
                            rtbChat.SelectionAlignment = HorizontalAlignment.Right;
                        else
                            rtbChat.SelectionAlignment = HorizontalAlignment.Left;
                        rtbChat.AppendText(userName + "\n" + msg + "\n");
                    });
                    this.Invoke(invoker);
                }
                else
                {
                    MethodInvoker invoker = new MethodInvoker(delegate
                    {
                        if (userName == user.userName)
                            rtbChat.SelectionAlignment = HorizontalAlignment.Right;
                        else
                            rtbChat.SelectionAlignment = HorizontalAlignment.Left;
                        rtbChat.AppendText(userName + '\n');
                        rtbChat.ReadOnly = false;
                        // Hiển thị hình ảnh trong giao diện người dùng
                        PictureBox pictureBox = new PictureBox();
                        pictureBox.Image = image; // Thay thế yourImage bằng hình ảnh bạn muốn hiển thị
                        pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
                        Bitmap bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
                        pictureBox.DrawToBitmap(bitmap, new Rectangle(0, 0, pictureBox.Width, pictureBox.Height));
                        Clipboard.SetImage(bitmap);
                        rtbChat.Paste();
                        rtbChat.ReadOnly = true;
                        rtbChat.AppendText("\n");
                    });
                    this.Invoke(invoker);
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void btnSendIcon_Click(object sender, EventArgs e)
        {
            if (pnlContainsIcon.Visible)
            {
                pnlContainsIcon.Hide();
                buttonListIcons.Clear();
            }
            else
            {
                //xóa hết các phần tử bên trong panel
                pnlContainsIcon.Controls.Clear();
                pnlContainsIcon.Padding = new Padding(0);
                buttonListIcons = new List<Button>();
                for (int i = 0; i < iconNumbers; i++)
                {
                    Button btn2 = null;
                    if (buttonListIcons.Count % 7 == 0)
                    {
                        if (buttonListIcons.Count != 0)
                            oldButton.Location = new Point(0, 30 + oldButton.Location.Y + 10);
                        btn2 = btn.createButton(oldButton, pnlContainsIcon, Image.FromFile($"Resources\\{i + 1}.png"), Convert.ToString($"Resources\\{i + 1}.png"), true);
                        btn2.Click += Btn2_Click; ;
                    }
                    else
                    {
                        btn2 = btn.createButton(buttonListIcons[buttonListIcons.Count - 1], pnlContainsIcon, Image.FromFile($"Resources\\{i + 1}.png"), Convert.ToString($"Resources\\{i + 1}.png"), true);
                        btn2.Click += Btn2_Click;
                    }
                    buttonListIcons.Add(btn2);
                }
                oldButton.Location = new Point(0, 0);
                pnlContainsIcon.Show();
            }
        }
        private void Btn2_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string path = btn.Text;
            byte[] imageBytes = File.ReadAllBytes(path);
            string message = (int)setting.chatMulti + "*" + user.userName + "(2):" + Convert.ToBase64String(imageBytes);
            sendData(message);
            rtbChat.ReadOnly = false;

            writeData(Image.FromFile(path), "", 2, user.userName);
            rtbChat.ReadOnly = true;
            pnlContainsIcon.Hide();
            buttonListIcons.Clear();
        }
        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            string message = (int)setting.chatMulti + "*" + user.userName + "(1):" + txtSendMessage.Text;
            sendData(message);
            writeData(null, txtSendMessage.Text, 1, user.userName);
            txtSendMessage.Clear();
        }
        //==================================================================================================================================

        //====================================CÁC HÀM DÙNG ĐỂ HIỂN THỊ DỮ LIỆU LÊN GIAO DIỆN DATAGRIDVIEW ==================================
        private async void displayListMatches()
        {
            //tạo ra đối tượng để căn giữa nội dung trong từng ô
            dtGridContainListRooms.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtGridContainListRooms.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //ngăn không cho người dùng kéo giãn
            foreach (DataGridViewColumn column in dtGridContainListRooms.Columns)
            {
                column.Resizable = DataGridViewTriState.False;
            }
            foreach (DataGridViewRow row in dtGridContainListRooms.Rows)
            {
                row.Resizable = DataGridViewTriState.False;
            }
            dtGridContainListRooms.Rows.Clear();
            dtGridContainListRooms.Columns.Clear();

            //xóa đi dòng cuối cùng trong dataGridView
            dtGridContainListRooms.AllowUserToAddRows = false;

            dtGridContainListRooms.Columns.Add("id", "Mã phòng");
            dtGridContainListRooms.Columns.Add("Count", "Số lượng");
            dtGridContainListRooms.Columns.Add("betPoint", "Điểm cược");
            dtGridContainListRooms.Columns.Add("status", "Trạng thái");
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.Name = "";
            buttonColumn.Text = "Tham gia";
            buttonColumn.UseColumnTextForButtonValue = true;
            dtGridContainListRooms.Columns.Add(buttonColumn);
            dtGridContainListRooms.RowHeadersVisible = false;
            dtGridContainListRooms.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            JToken dataToken = await callApiUsingMethodGet(apiGetListMatches);
            List<matches> list = JsonConvert.DeserializeObject<List<matches>>(dataToken.ToString());

            foreach (matches item in list)
            {
                string[] rowData = new string[] { item._id, item.count.ToString() + "/2", item.betPoints.ToString(), item.status };
                dtGridContainListRooms.Rows.Add(rowData);
            }
            dtGridContainListRooms.ReadOnly = true;
        }
        private void displayListUsers(List<infoUser> userLists)
        {
            dtAllUsers.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtAllUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //ngăn không cho người dùng kéo giãn
            foreach (DataGridViewColumn column in dtAllUsers.Columns)
            {
                column.Resizable = DataGridViewTriState.False;
            }
            foreach (DataGridViewRow row in dtAllUsers.Rows)
            {
                row.Resizable = DataGridViewTriState.False;
            }
            dtAllUsers.Rows.Clear();
            dtAllUsers.Columns.Clear();
            //xóa đi dòng cuối cùng trong dataGridView
            dtAllUsers.AllowUserToAddRows = false;

            dtAllUsers.Columns.Add("id", "ID");
            dtAllUsers.Columns.Add("userName", "Tên người dùng");
            DataGridViewButtonColumn buttonColumn1 = new DataGridViewButtonColumn();
            buttonColumn1.Name = "";
            buttonColumn1.Text = "Xem thông tin";
            buttonColumn1.UseColumnTextForButtonValue = true;
            DataGridViewButtonColumn buttonColumn2 = new DataGridViewButtonColumn();
            buttonColumn2.Name = "";
            buttonColumn2.Text = "Kết bạn";
            buttonColumn2.UseColumnTextForButtonValue = true;
            dtAllUsers.Columns.Add(buttonColumn1);
            dtAllUsers.Columns.Add(buttonColumn2);
            dtAllUsers.RowHeadersVisible = false;
            dtAllUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            foreach (infoUser item in userLists)
            {
                string[] rowData = new string[] { item.id, item.userName };
                dtAllUsers.Rows.Add(rowData);
            }

            //lặp qua từng dòng dữ liệu để kiểm tra xem có nên hiển thị nút kết bạn hay không
            for (int i = 0; i < userLists.Count; i++)
            {
                //lấy ra từng dòng dữ liệu
                DataGridViewCell cell = dtAllUsers.Rows[i].Cells[3];    //lấy ra cái nút kết bạn
                //lấy ra giá trị id của từng user
                string id = dtAllUsers.Rows[i].Cells[0].Value.ToString();
                bool check = false;
                //so sánh với từng user trong list "friend" or "waiting" của user
                for (int j = 0; j < user.lists.Count; j++)
                {
                    if (user.lists[j].listID.Contains(id))
                    {
                        check = true;
                        break;
                    }
                }
                if (check)
                {
                    cell.Style = new DataGridViewCellStyle { Padding = new Padding(500, 0, 0, 0) };
                    cell.ReadOnly = true;
                }
                else
                {
                    cell.Style = new DataGridViewCellStyle { Padding = new Padding(0, 0, 0, 0) };
                    cell.ReadOnly = false;
                }
            }

            dtAllUsers.ReadOnly = true;
        }
        public void displayListFriends(List<infoUser> userLists)
        {
            dtListFriends.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtListFriends.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //ngăn không cho người dùng kéo giãn
            foreach (DataGridViewColumn column in dtListFriends.Columns)
                column.Resizable = DataGridViewTriState.False;
            foreach (DataGridViewRow row in dtListFriends.Rows)
            {
                row.Resizable = DataGridViewTriState.False;
            }
            dtListFriends.Rows.Clear();
            dtListFriends.Columns.Clear();
            //xóa đi dòng cuối cùng trong dataGridView
            dtListFriends.AllowUserToAddRows = false;

            dtListFriends.Columns.Add("id", "ID");
            dtListFriends.Columns.Add("userName", "Tên người dùng");
            dtListFriends.Columns.Add("statusActive", "Trạng thái");
            DataGridViewButtonColumn buttonColumn1 = new DataGridViewButtonColumn();
            buttonColumn1.Name = "";
            buttonColumn1.Text = "Xem thông tin";
            buttonColumn1.UseColumnTextForButtonValue = true;
            DataGridViewButtonColumn buttonColumn2 = new DataGridViewButtonColumn();
            buttonColumn2.Name = "";
            buttonColumn2.Text = "Nhắn tin";
            buttonColumn2.UseColumnTextForButtonValue = true;
            DataGridViewButtonColumn buttonColumn3 = new DataGridViewButtonColumn();
            buttonColumn3.Name = "";
            buttonColumn3.Text = "Hủy kết bạn";
            buttonColumn3.UseColumnTextForButtonValue = true;
            dtListFriends.Columns.Add(buttonColumn1);
            dtListFriends.Columns.Add(buttonColumn2);
            dtListFriends.Columns.Add(buttonColumn3);
            dtListFriends.RowHeadersVisible = false;
            dtListFriends.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            if (userLists != null)
            {
                foreach (infoUser item in userLists)
                {
                    string[] rowData = new string[] { item.id, item.userName, item.statusActive };
                    dtListFriends.Rows.Add(rowData);
                }
            }
            //kiểm tra xem có nên hiện nút chat hay không
            for (int i = 0; i < userLists.Count; i++)
            {
                DataGridViewCell cell = dtListFriends.Rows[i].Cells[4];
                if (userLists[i].statusActive.ToLower() == "offline")
                {
                    cell.Style = new DataGridViewCellStyle { Padding = new Padding(500, 0, 0, 0) };
                    cell.ReadOnly = true;
                }
                else if (userLists[i].statusActive.ToLower() == "online")
                {
                    cell.Style = new DataGridViewCellStyle { Padding = new Padding(0, 0, 0, 0) };
                    cell.ReadOnly = false;
                }
            }
            dtListFriends.ReadOnly = true;
        }
        public void displayListWaitingAccept(List<infoUser> userLists)
        {
            dtAcceptFriend.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtAcceptFriend.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //ngăn không cho người dùng kéo giãn
            foreach (DataGridViewColumn column in dtAcceptFriend.Columns)
            {
                column.Resizable = DataGridViewTriState.False;
            }
            foreach (DataGridViewRow row in dtAcceptFriend.Rows)
            {
                row.Resizable = DataGridViewTriState.False;
            }
            dtAcceptFriend.Rows.Clear();
            dtAcceptFriend.Columns.Clear();
            //xóa đi dòng cuối cùng trong dataGridView
            dtAcceptFriend.AllowUserToAddRows = false;

            dtAcceptFriend.Columns.Add("id", "ID");
            dtAcceptFriend.Columns.Add("userName", "Tên người dùng");
            DataGridViewButtonColumn buttonColumn1 = new DataGridViewButtonColumn();
            buttonColumn1.Name = "";
            buttonColumn1.Text = "Chấp nhận";
            buttonColumn1.UseColumnTextForButtonValue = true;
            dtAcceptFriend.Columns.Add(buttonColumn1);
            dtAcceptFriend.RowHeadersVisible = false;
            dtAcceptFriend.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            if (userLists != null)
            {
                foreach (infoUser item in userLists)
                {
                    string[] rowData = new string[] { item.id, item.userName };
                    dtAcceptFriend.Rows.Add(rowData);
                }
            }
            dtAcceptFriend.ReadOnly = true;
        }
        //==================================================================================================================================

        //========================================= HÀM DÙNG ĐỂ THAO TÁC VỚI SỰ KIỆN BẤM VÀO DATAGRIDVIEW ==================================
        private async void dtGridContainListRooms_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridView dataGridView = (DataGridView)sender;

                if (e.ColumnIndex == 4)
                {
                    if (dataGridView.Rows[e.RowIndex].Cells["Count"].Value.ToString() == "2/2")
                    {
                        MessageBox.Show("Phòng đã đầy, vui lòng chọn phòng khác");
                        return;
                    }
                    else
                    {
                        if (user.point < int.Parse(dataGridView.Rows[e.RowIndex].Cells["betPoint"].Value.ToString()))
                        {
                            MessageBox.Show("Điểm của bạn không đủ để tham gia phòng chơi này");
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Tham gia thành công");
                            //tạo và tham gia vào phòng
                            this.Hide();
                            string idMatch = dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
                            //tiến hành lấy ra mã phòng khi click vào
                            await callApiUsingMethodPut(new { option = "adduser", id = user.id }, apiAddUserIntoMatch + idMatch);

                            //tiến hành cập nhật lại danh sách phòng chơi
                            displayListMatches();

                            Form1 player = new Form1(idMatch, 2000, 1000, false, false, 1, 3, user.linkAvatar, user.point, user.userName, user.id);  //chủ phòng sẽ là cờ trắng
                            player.Show();

                            
                            return;
                        }
                    }
                }
            }
        }
        private async void dtAllUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridView dataGridView = (DataGridView)sender;
                if (e.ColumnIndex == 2) //xem thông tin người chơi
                {
                    string apiPath = apiGetUserId + dataGridView.Rows[e.RowIndex].Cells["id"].Value.ToString();
                    JToken tkData = await callApiUsingGetMethodID(apiPath);
                    infoUser user = JsonConvert.DeserializeObject<infoUser>(tkData.ToString());

                    FormInfoUser infoUser = new FormInfoUser(user, false);
                    infoUser.Show();

                    this.Hide();
                }
                else if (e.ColumnIndex == 3) // kết bạn
                {
                    var data = new
                    {
                        id_user1 = user.id,
                        id_user2 = dataGridView.Rows[e.RowIndex].Cells["id"].Value.ToString()
                    };
                    await callApiUsingMethodPost(data, apiMakeFriend);

                    DataGridViewCell cell = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    cell.Style = new DataGridViewCellStyle { Padding = new Padding(500, 0, 0, 0) };
                    cell.ReadOnly = true;
                    dataGridView.Update();
                    //gửi sự kiện lên server để reload lại form
                    string message = (int)setting.makeFriend + "*" + dataGridView.Rows[e.RowIndex].Cells["userName"].Value.ToString();
                    sendData(message);
                }
            }
        }
        private async void dtListFriends_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridView dataGridView = (DataGridView)sender;
                if (e.ColumnIndex == 3) //sem thông tin người chơi
                {
                    string apiPath = apiGetUserId + dataGridView.Rows[e.RowIndex].Cells["id"].Value.ToString();
                    JToken tkData = await callApiUsingGetMethodID(apiPath);
                    infoUser user = JsonConvert.DeserializeObject<infoUser>(tkData.ToString());

                    FormInfoUser infoUser = new FormInfoUser(user, false);
                    infoUser.Show();

                    this.Hide();
                }
                else if (e.ColumnIndex == 4)
                {

                }
                else if (e.ColumnIndex == 5)
                {
                    //gọi tới api danh sách đợi
                    JToken tkData = await callApiUsingMethodGet(apiGetAllListFriend);
                    List<listFriends> listFriends = JsonConvert.DeserializeObject<List<listFriends>>(tkData.ToString());
                    string id1 = user.id;
                    string id2 = dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
                    string newId = "";
                    foreach (listFriends item in listFriends)
                    {
                        if (item.listID.Contains(id1) && item.listID.Contains(id2))
                        {
                            newId = item._id;
                            break;
                        }
                    }
                    if (newId != "")
                    {
                        //gọi tới API 
                        HttpClient client = new HttpClient();
                        string apiPath = apiDeleteFriend + newId;
                        //tiến hành lấy ra _id thỏa mãn
                        await client.DeleteAsync(apiPath);



                        //cập nhật lại danh sách
                        //làm mới lại danh sách khi có phần tử mới được thêm vào
                        string apiPath1 = apiGetUserId + user.id;
                        JToken tkData2 = await callApiUsingGetMethodID(apiPath1);
                        this.user = JsonConvert.DeserializeObject<infoUser>(tkData2.ToString());

                        //gửi sự kiện lên server để reload lại form
                        string message = (int)setting.acceptFriend + "*" + dataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
                        //xóa dòng đó khỏi dữ liệu
                        dataGridView.Rows.RemoveAt(e.RowIndex);
                        sendData(message);

                        //cập nhật lại danh sách tất cả người dùng
                        getListAllUser();
                    }
                }
            }
        }
        private async void dtAcceptFriend_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridView dataGridView = (DataGridView)sender;
                if (e.ColumnIndex == 2) // chấp nhận lời mời
                {
                    //gọi tới api danh sách đợi
                    JToken tkData = await callApiUsingMethodGet(apiGetAllListFriend);
                    List<listFriends> listFriends = JsonConvert.DeserializeObject<List<listFriends>>(tkData.ToString());
                    string id1 = user.id;
                    string id2 = dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
                    string newId = "";
                    foreach (listFriends item in listFriends)
                    {
                        if (item.listID.Contains(id1) && item.listID.Contains(id2))
                        {
                            newId = item._id;
                            break;
                        }
                    }

                    if (newId != "")
                    {
                        //chấp nhận kết bạn
                        string apiPath = apiUpdaStatusFriend + newId;
                        var data = new { };
                        await callApiUsingMethodPut(data, apiPath);

                        //gửi sự kiện lên server để reload lại form
                        string message = (int)setting.acceptFriend + "*" + dataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();

                        //xóa dòng đó khỏi dữ liệu
                        dataGridView.Rows.RemoveAt(e.RowIndex);

                        //cập nhật lại danh sách
                        //làm mới lại danh sách khi có phần tử mới được thêm vào
                        string apiPath1 = apiGetUserId + user.id;
                        JToken tkData2 = await callApiUsingGetMethodID(apiPath1);
                        this.user = JsonConvert.DeserializeObject<infoUser>(tkData2.ToString());


                        sendData(message);
                        //cập nhật lại danh sách bạn bè
                        List<infoUser> getFriends = new List<infoUser>();
                        displayListFriends(await getListUser(getFriends, "friend"));
                    }

                }
            }
        }
        //==================================================================================================================================

        //========================================= cÁC HÀM ĐỂ THỰC HIỆN CHỨC NĂNG TƯƠNG TÁC VỚI CÁC NÚT ===================================
        private void btnContainInfoUser_Click(object sender, EventArgs e)
        {
            //ẩn giao diện chính đi
            this.Hide();
            FormInfoUser info = new FormInfoUser(user, true);
            info.Show();
        }
        private async void btnLogout_Click(object sender, EventArgs e)
        {
            await handleLogOutRoom();
        }
        private void btnRank_Click(object sender, EventArgs e)
        {

        }
        private async void btnMakeFriend_Click(object sender, EventArgs e)
        {
            getListAllUser();

            List<infoUser> getFriends = new List<infoUser>();

            displayListFriends(await getListUser(getFriends, "friend"));
            getFriends.Clear();
            displayListWaitingAccept(await getListUser(getFriends, "waiting"));
            pnlListFriends.Visible = true;
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            pnlListFriends.Visible = false;
            txtFindUser.Clear();
        }
        private void btnListFriend_Click(object sender, EventArgs e)
        {

        }
        private void btnRandomRoom_Click(object sender, EventArgs e)
        {

        }
        private async void btnCreateRoom_Click(object sender, EventArgs e)
        {
            try
            {
                HttpClient client = new HttpClient();
                var data = new
                {
                    id = user.id
                };
                string jsonData = JsonConvert.SerializeObject(data);
                HttpResponseMessage response = await client.PostAsync(apiCreateRoom, new StringContent(jsonData, Encoding.UTF8, "application/json"));
                string dataJson = await response.Content.ReadAsStringAsync();
                JObject objData = JObject.Parse(dataJson);
                if (response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    MessageBox.Show(objData["notify"].ToString());
                    JToken dataRoom = objData["data"];
                    displayListMatches();
                    matches match = JsonConvert.DeserializeObject<matches>(dataRoom.ToString());
                    string message = (int)setting.createRoom + "*" + user.userName;
                    sendData(message);

                    //tạo và tham gia vào phòng
                    this.Hide();
                    Form1 admin = new Form1(match._id, 1000, 2000, true, true, 0, 3, user.linkAvatar, user.point, user.userName, user.id);  //chủ phòng sẽ là cờ trắng
                    admin.Show();
                }
                else
                {
                    MessageBox.Show(objData["notify"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private async void btnFindUser_Click(object sender, EventArgs e)
        {
            //nếu người dùng bấm tìm kiếm thì hiển thị lại giao diện dtAllUsers
            string apiUrl = apiGetAllUser + txtFindUser.Text.Trim() != "" ? apiGetAllUser + "?userName=" + txtFindUser.Text.Trim() : "";
            JToken tokenData = await callApiUsingGetMethodID(apiUrl);
            List<infoUser> userLists = JsonConvert.DeserializeObject<List<infoUser>>(tokenData.ToString());
            //hiển thị danh sách user này lên datagridView
            displayListUsers(userLists);
        }
        private async void mainInterface_FormClosed(object sender, FormClosedEventArgs e)
        {
            await handleLogOutRoom();
        }
        //==================================================================================================================================
    }
}
