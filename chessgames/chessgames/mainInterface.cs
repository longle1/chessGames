using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

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
        TcpClient client = null;
        List<Button> buttonListIcons = new List<Button>();
        Button oldButton = new Button()
        {
            Height = 0,
            Width = 0
        };
        button btn = new button();
        int iconNumbers = 29;
        private enum setting
        {
            createRoom = 0,
            makeFriend = 1,
            unfriend = 2,
            joinRoom = 3,
            chatOne = 4,
            chatMulti = 5,
            outRoom = 6,
            logout = 7
        }
        public mainInterface()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            pnlListFriends.Visible = false;
            pnlContainsIcon.Hide();
            rtbChat.ReadOnly = true;
            client = new TcpClient();
            client.Connect(System.Net.IPAddress.Parse("172.20.30.81"), 8081);
            Thread rcvDataThread = new Thread(new ThreadStart(rcvData));
            rcvDataThread.Start();
        }
        public void sendData(string msg)
        {
            NetworkStream stream = client.GetStream();
            byte[] data = Encoding.UTF8.GetBytes(msg);
            stream.Write(data, 0, data.Length); 
        }
        public mainInterface(infoUser user) : this()
        {
            parentDirectory = Directory.GetParent(Application.StartupPath)?.Parent?.FullName + "\\Images";
            this.user = user;
            lbUserName.Text = user.userName;
            lbScore.Text = user.point.ToString();
            if (user.linkAvatar == "")
                user.linkAvatar = "defaultAvatar.jpg";
            ptboxAvatar.Image = Image.FromFile($"{parentDirectory}\\" + user.linkAvatar);
            ptboxAvatar.SizeMode = PictureBoxSizeMode.Zoom;
            showInter = this;

            //gửi thông điệp login lên server
            string message = user.userName;
            sendData(message);

            displayListMatches();
        }
        public void rcvData()
        {
            while (true)
            {
                NetworkStream stream = client.GetStream();

                byte[] data = new byte[1024 * 500];
                int length = stream.Read(data, 0, data.Length);
                string message = Encoding.UTF8.GetString(data, 0, length);
                string[] listMsg = message.Split('*');
                switch (int.Parse(listMsg[0]))
                {
                    case 5:
                        string[] msg = listMsg[1].Split(':');
                        if (listMsg[1].Contains("(1)"))
                        {
                            writeData(null, msg[1], 1, msg[0].Substring(0, msg[0].Length - 3));
                        }
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
                }

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
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(apiGetListMatches);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string responseData = await response.Content.ReadAsStringAsync();
                JObject jsonData = JObject.Parse(responseData);
                // Lấy giá trị của thuộc tính "data"
                JToken dataToken = jsonData["data"];
                // Chuyển đổi sang đối tượng JSON
                List<matches> list = JsonConvert.DeserializeObject<List<matches>>(dataToken.ToString());

                foreach (matches item in list)
                {
                    string[] rowData = new string[] { item._id, item.count.ToString() + "/2", item.betPoints.ToString(), item.status };
                    dtGridContainListRooms.Rows.Add(rowData);
                }
                dtGridContainListRooms.ReadOnly = true;

            }
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
                string[] rowData = new string[] { item.id, item.userName};
                dtAllUsers.Rows.Add(rowData);
            }
            dtAllUsers.ReadOnly = true;
        }
        public void displayListFriends(List<infoUser> userLists)
        {
            dtListFriends.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtListFriends.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //ngăn không cho người dùng kéo giãn
            foreach (DataGridViewColumn column in dtListFriends.Columns)
            {
                column.Resizable = DataGridViewTriState.False;
            }
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
            foreach (infoUser item in userLists)
            {
                string[] rowData = new string[] { item.id, item.userName };
                dtListFriends.Rows.Add(rowData);
            }
            dtListFriends.ReadOnly = true;
        }
        private void dtGridContainListRooms_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
                            return;
                        }
                    }
                }
            }
        }


        private void btnContainInfoUser_Click(object sender, EventArgs e)
        {
            //ẩn giao diện chính đi
            this.Hide();
            FormInfoUser info = new FormInfoUser(user);
            info.Show();
        }

        private async void btnLogout_Click(object sender, EventArgs e)
        {
            apiGetUser += user.id;
            //cập nhật trạng thái thành offline
            var data = new
            {
                userName = user.userName,
                gmail = user.gmail,
                linkAvatar = user.linkAvatar == "defaultAvatar.jpg" ? "" : user.linkAvatar,
                statusActive = "offline",
            };


            //gửi thông điệp logout lên server
            string message = (int)setting.logout + "*" + user.userName;
            sendData(message);


            string jsonData = JsonConvert.SerializeObject(data);
            HttpClient client = new HttpClient();
            await client.PutAsync(apiGetUser, new StringContent(jsonData, Encoding.UTF8, "application/json"));
            login.showFormAgain.Show();
            //tiến hành đóng form lại
            this.Close();
        }

        private void btnRank_Click(object sender, EventArgs e)
        {

        }

        private async void btnMakeFriend_Click(object sender, EventArgs e)
        {

            //gọi api để hiển thị danh sách người dùng
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(apiGetAllUser);
            string jsonData = await response.Content.ReadAsStringAsync();
            if(response.StatusCode == HttpStatusCode.OK)
            {
                JObject objData = JObject.Parse(jsonData);
                JToken tokenData = objData["data"];
                List<infoUser> userLists = JsonConvert.DeserializeObject<List<infoUser>>(tokenData.ToString());

                //hiển thị danh sách user này lên datagridView
                displayListUsers(userLists);
                List<infoUser> getFriends = new List<infoUser>();
                foreach (listFriends item in user.lists)
                {
                    //tiến hành lấy ra listID
                    List<string> listid = item.listID;
                    if (item.status.ToLower() != "waiting")
                    {
                        string id = "";
                        foreach (string id1 in listid)
                        {
                            if (id1 != user.id) id = id1;
                        }
                        string apiPath = apiGetUserId + id;
                        HttpClient client1 = new HttpClient();
                        HttpResponseMessage response1 = await client1.GetAsync(apiPath);
                        string jsonObject = await response1.Content.ReadAsStringAsync();
                        JObject objData1 = JObject.Parse(jsonObject);
                        JToken tkData = objData1["data"];
                        infoUser friend = JsonConvert.DeserializeObject<infoUser>(tkData.ToString());
                        getFriends.Add(friend);
                    }
                }
                displayListFriends(getFriends);
            }

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
                    displayListMatches();

                    //tạo và tham gia vào phòng
                    this.Hide();
                    Form1 admin = new Form1(user.userName, 1000, 2000, true, true, 0);  //chủ phòng sẽ là cờ trắng
                    admin.Show();

                }
                else
                {
                    MessageBox.Show(objData["notify"].ToString());
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void mainInterface_Load(object sender, EventArgs e)
        {
            lbUserName.Text = user.userName;
            lbScore.Text = user.point.ToString();
            if (user.linkAvatar == "")
                user.linkAvatar = "defaultAvatar.jpg";
            ptboxAvatar.Image = Image.FromFile($"{parentDirectory}\\" + user.linkAvatar);
            ptboxAvatar.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private async void btnFindUser_Click(object sender, EventArgs e)
        {
            //nếu người dùng bấm tìm kiếm thì hiển thị lại giao diện dtAllUsers
            string apiUrl = apiGetAllUser + txtFindUser.Text.Trim() != "" ? apiGetAllUser + "?userName=" + txtFindUser.Text.Trim() : "";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(apiUrl);
            string jsonData = await response.Content.ReadAsStringAsync();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                JObject objData = JObject.Parse(jsonData);
                JToken tokenData = objData["data"];
                List<infoUser> userLists = JsonConvert.DeserializeObject<List<infoUser>>(tokenData.ToString());

                //hiển thị danh sách user này lên datagridView
                displayListUsers(userLists);
            }
        }
    }
}
