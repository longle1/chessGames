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
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chessgames
{
    public partial class mainInterface : Form
    {
        #region apiPath
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
        #endregion

        #region infoUser
        private infoUser user;
        private string linkAvatar;
        private string ipAddress = "";
        private string difUsernameUser = "";
        #endregion

        #region variables
        public static mainInterface showInter = null;
        private string parentDirectory;
        private int iconNumbers = 29;
        private TcpClient client = null;
        private List<Button> buttonListIcons = new List<Button>();
        private Button oldButton = new Button()
        {
            Height = 0,
            Width = 0
        };
        private button btn = new button();
        private Thread rcvDataThread = null;
        private UserControlChatOne chat = null;
        private List<UserControlChatOne> listChats = new List<UserControlChatOne>();
        #endregion
        private enum setting
        {
            createRoom = 0,
            makeFriend = 1,
            acceptFriend = 2,
            joinRoom = 3,
            chatOne = 4,
            chatMulti = 5,
            logout = 6,
            unFriend = 7
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
        private void calLocationChildPanel(Panel parent, Panel child)
        {
            // Tính toán vị trí để đặt Panel con vào giữa Panel cha
            int childX = (parent.Width - child.Width) / 2;
            int childY = (parent.Height - child.Height) / 2;

            // Đặt vị trí cho Panel con
            child.Location = new Point(childX, childY);

            // Đặt Anchor để Panel con giữa trung tâm Panel cha khi Panel cha thay đổi kích thước
            child.Anchor = AnchorStyles.None;
            parent.Controls.Add(child);
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
        }
        private void loopChildPanel(Panel pnl)
        {
            pnlContainsChild.Show();
            foreach (Panel childPanel in pnlContainsChild.Controls.OfType<Panel>())
            {
                if (childPanel == pnl)
                    childPanel.Show();
                else
                    childPanel.Hide();
            }
        }

        private async Task<List<string>> getListFriends()
        {
            JToken tkData = await callApiUsingGetMethodID(apiGetUserId + user.id);
            infoUser info = JsonConvert.DeserializeObject<infoUser>(tkData.ToString());
            List<string> arraysUserName = new List<string>();
            foreach (listFriends lists in info.lists)
            {
                if (lists.status == "friend")
                {
                    List<string> listIds = lists.listID;
                    string id = listIds[0] == user.id ? listIds[1] : listIds[0];
                    JToken tkInfo = await callApiUsingGetMethodID(apiGetUserId + id);
                    infoUser difUser = JsonConvert.DeserializeObject<infoUser>(tkInfo.ToString());
                    if (difUser.statusActive == "online")
                        arraysUserName.Add(difUser.userName);
                }
            }
            return arraysUserName;
        }
        private static NetworkInterface GetWifiInterface()
        {
            NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();

            foreach (NetworkInterface networkInterface in interfaces)
            {
                if (networkInterface.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 &&
                    networkInterface.OperationalStatus == OperationalStatus.Up)
                {
                    return networkInterface;
                }
            }

            return null;
        }
        private static IPAddress GetWifiIPv4Address(NetworkInterface wifiInterface)
        {
            IPInterfaceProperties properties = wifiInterface.GetIPProperties();

            foreach (UnicastIPAddressInformation ip in properties.UnicastAddresses)
            {
                if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    return ip.Address;
                }
            }

            return null;
        }
        //=================================================================================================================================

        //============================================  HÀM KHỞI TẠO MẶC ĐỊNH =============================================================
        public mainInterface()
        {
            InitializeComponent();
            pnlContainsChild.AutoSize = false;
            pnlContainsChild.Hide();
            pnlContainsChild.Controls.Add(pnlChatOne);
            pnlChatOne.Hide();
            pnlChatOne.BringToFront();
            pnlChatOne.Dock = DockStyle.Left;
            calLocationChildPanel(pnlContainsChild, pnlListFriends);
            calLocationChildPanel(pnlContainsChild, pnlRanker);
            calLocationChildPanel(pnlContainsChild, pnlChildContainHistory);
            calLocationChildPanel(pnlContainsChild, pnlCreateRoom);

            CheckForIllegalCrossThreadCalls = false;
            pnlContainsIcon.Hide();
            rtbChat.ReadOnly = true;
            
        }
        public mainInterface(infoUser user) : this()
        {

            //lấy ra ipv4 bên trong máy
            NetworkInterface wifiInterface = GetWifiInterface();
            if (wifiInterface != null)
            {
                IPAddress ipv4 = GetWifiIPv4Address(wifiInterface);

                if (ipv4 != null)
                    ipAddress = ipv4.ToString();
            }

            client = new TcpClient();
            client.Connect(IPAddress.Parse(ipAddress), 8081);
            rcvDataThread = new Thread(new ThreadStart(rcvData));
            rcvDataThread.Start();

            parentDirectory = Directory.GetParent(Application.StartupPath)?.Parent?.FullName + "\\Images";
            this.user = user;
            lbUserName.Text = user.userName;
            lbScore.Text = user.point.ToString();
            ptboxAvatar.Image = Image.FromFile($"{parentDirectory}\\" + user.linkAvatar);
            ptboxAvatar.SizeMode = PictureBoxSizeMode.Zoom;
            showInter = this;
            pnlRanker.Hide();

            //gửi thông điệp login lên server
            string message = user.userName;
            sendData(message);

            displayListMatches();
        }
        //=================================================================================================================================

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
        public async Task<JToken> callApiUsingMethodPut(object data, string apiPath)
        {
            //gọi tới API 
            HttpClient client = new HttpClient();
            string dataJson = JsonConvert.SerializeObject(data);
            //tiến hành lấy ra _id thỏa mãn
            HttpResponseMessage response = await client.PutAsync(apiPath, new StringContent(dataJson, Encoding.UTF8, "application/json"));

            return JObject.Parse(await response.Content.ReadAsStringAsync())["data"];
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
            if (client != null)
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

                            Action myAction = () =>
                            {
                                createChatBetweenClientAndClient();
                            };

                            // Sử dụng phương thức Invoke để thực thi đoạn mã trên luồng giao diện người dùng
                            if (this.InvokeRequired)
                                this.Invoke(myAction);
                            else
                                myAction();
                            break;
                        case 3:
                            player.players = 2;
                            break;
                        case 4:
                            string[] lstMsg = listMsg[1].Split(':');
                            string difUsername = lstMsg[0].Substring(0, lstMsg[0].Length - 3);
                            foreach (UserControlChatOne userControlChatOne in listChats)
                            {
                                if (userControlChatOne.Tag.ToString().Contains(user.userName) && userControlChatOne.Tag.ToString().Contains(difUsername))
                                {
                                    chat = userControlChatOne;
                                    if (listMsg[1].Contains("(1)"))
                                        writeData(null, lstMsg[1], 1, lstMsg[0].Substring(0, lstMsg[0].Length - 3), chat.richTextBox);
                                    else
                                    {
                                        string imageData = lstMsg[1];
                                        byte[] convertedBytes = Convert.FromBase64String(imageData);
                                        // Chuyển đổi mảng byte thành hình ảnh
                                        using (MemoryStream stream1 = new MemoryStream(convertedBytes))
                                        {
                                            Image image = Image.FromStream(stream1);
                                            writeData(image, "", 2, lstMsg[0].Substring(0, lstMsg[0].Length - 3), chat.richTextBox);
                                        }
                                    }
                                    break;
                                }
                            }
                            break;
                        case 5:
                            string[] msg = listMsg[1].Split(':');
                            if (listMsg[1].Contains("(1)"))
                                writeData(null, msg[1], 1, msg[0].Substring(0, msg[0].Length - 3), rtbChat);
                            else
                            {
                                string imageData = msg[1];
                                byte[] convertedBytes = Convert.FromBase64String(imageData);
                                // Chuyển đổi mảng byte thành hình ảnh
                                using (MemoryStream stream1 = new MemoryStream(convertedBytes))
                                {
                                    Image image = Image.FromStream(stream1);
                                    writeData(image, "", 2, msg[0].Substring(0, msg[0].Length - 3), rtbChat);
                                }
                            }
                            break;
                        case 6: //xử lý log out
                                //lấy id nhận về 
                            string id = listMsg[1].Split(',')[1];
                            string username = listMsg[1].Split(',')[0];
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

                                //tiến hành xóa đi phòng chat của user này 
                                await getListFriends();
                                foreach(UserControlChatOne control in listChats)
                                {
                                    if(control.Tag.ToString().Contains(user.userName) &&  control.Tag.ToString().Contains(username)) {
                                        listChats.Remove(control);
                                        break;
                                    }
                                }
                            }
                            break;
                        case 7:
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
        private void writeData(Image image, string msg, int mode, string userName, RichTextBox rtb)
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
                            rtb.SelectionAlignment = HorizontalAlignment.Right;
                        else
                            rtb.SelectionAlignment = HorizontalAlignment.Left;
                        rtb.AppendText(userName + "\n" + msg + "\n");
                    });
                    this.Invoke(invoker);
                }
                else
                {
                    MethodInvoker invoker = new MethodInvoker(delegate
                    {
                        if (userName == user.userName)
                            rtb.SelectionAlignment = HorizontalAlignment.Right;
                        else
                            rtb.SelectionAlignment = HorizontalAlignment.Left;
                        rtb.AppendText(userName + '\n');
                        rtb.ReadOnly = false;
                        // Hiển thị hình ảnh trong giao diện người dùng
                        PictureBox pictureBox = new PictureBox();
                        pictureBox.Image = image; // Thay thế yourImage bằng hình ảnh bạn muốn hiển thị
                        pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
                        Bitmap bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
                        pictureBox.DrawToBitmap(bitmap, new Rectangle(0, 0, pictureBox.Width, pictureBox.Height));
                        Clipboard.SetImage(bitmap);
                        rtb.Paste();
                        rtb.ReadOnly = true;
                        rtb.AppendText("\n");
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

            writeData(Image.FromFile(path), "", 2, user.userName, rtbChat);
            rtbChat.ReadOnly = true;
            pnlContainsIcon.Hide();
            buttonListIcons.Clear();
        }
        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            string message = (int)setting.chatMulti + "*" + user.userName + "(1):" + txtSendMessage.Text;
            sendData(message);
            writeData(null, txtSendMessage.Text, 1, user.userName, rtbChat);
            txtSendMessage.Clear();
        }
        private void Chat_btnSendIconChatOne_click(object sender, EventArgs e)
        {
            if (chat != null)
            {
                if (chat.containsIcon.Visible)
                {
                    chat.containsIcon.Hide();
                    chat.listIcons.Clear();
                }
                else
                {
                    //xóa hết các phần tử bên trong panel
                    chat.containsIcon.Controls.Clear();
                    chat.containsIcon.Padding = new Padding(0);
                    chat.listIcons = new List<Button>();
                    for (int i = 0; i < iconNumbers; i++)
                    {
                        Button btnChatOne = null;
                        if (chat.listIcons.Count % 4 == 0)
                        {
                            if (chat.listIcons.Count != 0)
                                oldButton.Location = new Point(0, 30 + oldButton.Location.Y + 10);
                            btnChatOne = btn.createButton(oldButton, chat.containsIcon, Image.FromFile($"Resources\\{i + 1}.png"), Convert.ToString($"Resources\\{i + 1}.png"), true);
                            btnChatOne.Click += BtnChatOne_Click;
                        }
                        else
                        {
                            btnChatOne = btn.createButton(chat.listIcons[chat.listIcons.Count - 1], chat.containsIcon, Image.FromFile($"Resources\\{i + 1}.png"), Convert.ToString($"Resources\\{i + 1}.png"), true);
                            btnChatOne.Click += BtnChatOne_Click;
                        }
                        chat.listIcons.Add(btnChatOne);
                    }
                    oldButton.Location = new Point(0, 0);
                    chat.containsIcon.Show();
                }
            }
        }
        private void Chat_btnSendMsgChatOne_click(object sender, EventArgs e)
        {
            if (chat != null)
            {
                string message = chat.TextBox.Text.Trim();
                string msgSend = (int)setting.chatOne + "*" + user.userName + "(1):" + message + ":" + difUsernameUser;
                sendData(msgSend);
                writeData(null, message, 1, user.userName, chat.richTextBox);
                chat.TextBox.Clear();
            }
        }
        private void BtnChatOne_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string path = btn.Text;
            byte[] imageBytes = File.ReadAllBytes(path);
            string message = (int)setting.chatOne + "*" + user.userName + "(2):" + Convert.ToBase64String(imageBytes) + ":" + difUsernameUser;
            sendData(message);
            chat.richTextBox.ReadOnly = false;

            writeData(Image.FromFile(path), "", 2, user.userName, chat.richTextBox);
            chat.richTextBox.ReadOnly = true;
            chat.containsIcon.Hide();
            chat.listIcons.Clear();
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
            dtGridContainListRooms.Columns.Add("roomName", "Tên phòng");
            dtGridContainListRooms.Columns.Add("ownerRoom", "Chủ phòng");
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
                if (item.status.ToLower() != "finished")
                {
                    string[] rowData = new string[] { item._id, item.roomName, item.ownerRoom, item.count.ToString() + "/2", item.betPoints.ToString(), item.status };
                    dtGridContainListRooms.Rows.Add(rowData);
                }
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
                row.Resizable = DataGridViewTriState.False;
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
        public void displayListRank(List<infoUser> userLists)
        {

            //chứa danh sách điểm user từ cao đến thấp
            List<infoUser> sortList = userLists.OrderByDescending(user => user.point).ToList();
            int currentRank = 0;


            dtGridRank.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtGridRank.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //ngăn không cho người dùng kéo giãn
            foreach (DataGridViewColumn column in dtGridRank.Columns)
            {
                column.Resizable = DataGridViewTriState.False;
            }
            foreach (DataGridViewRow row in dtGridRank.Rows)
            {
                row.Resizable = DataGridViewTriState.False;
            }
            dtGridRank.Rows.Clear();
            dtGridRank.Columns.Clear();
            //xóa đi dòng cuối cùng trong dataGridView
            dtGridRank.AllowUserToAddRows = false;

            dtGridRank.Columns.Add("userName", "Tên người dùng");
            dtGridRank.Columns.Add("point", "Điểm");
            dtGridRank.Columns.Add("currentRank", "Hạng");

            dtGridRank.RowHeadersVisible = false;
            dtGridRank.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            if (userLists != null)
            {

                for (int index = 0; index < sortList.Count; index++)
                {
                    if (sortList[index].userName == user.userName)
                        currentRank = index + 1;
                    string[] rowData = new string[] { sortList[index].userName, sortList[index].point.ToString(), (index + 1).ToString() };
                    dtGridRank.Rows.Add(rowData);
                }
            }
            lbCurrentRank.Text = currentRank.ToString();
            dtGridRank.ReadOnly = true;
        }
        public async void displayListHistoryMatch(infoUser user)
        {
            dtGridViewHistory.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtGridViewHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //ngăn không cho người dùng kéo giãn
            foreach (DataGridViewColumn column in dtGridViewHistory.Columns)
            {
                column.Resizable = DataGridViewTriState.False;
            }
            foreach (DataGridViewRow row in dtGridViewHistory.Rows)
            {
                row.Resizable = DataGridViewTriState.False;
            }
            dtGridViewHistory.Rows.Clear();
            dtGridViewHistory.Columns.Clear();
            //xóa đi dòng cuối cùng trong dataGridView
            dtGridViewHistory.AllowUserToAddRows = false;

            dtGridViewHistory.Columns.Add("userName1", "Bạn");
            dtGridViewHistory.Columns.Add("userName2", "Người chơi");
            dtGridViewHistory.Columns.Add("result", "Kết quả");
            dtGridViewHistory.RowHeadersVisible = false;
            dtGridViewHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            if (user != null)
            {
                foreach (match item in user.matches)
                {
                    if (string.Equals(item.status, "finished"))
                    {
                        string myUsername = user.userName;
                        string myResult = item.players[0].user == user.id ? item.players[0].resultMatch : item.players[1].resultMatch;
                        string difId = item.players[0].user == user.id ? item.players[1].user : item.players[0].user;
                        JToken tkData = await callApiUsingGetMethodID(apiGetUserId + difId);
                        infoUser difUser = JsonConvert.DeserializeObject<infoUser>(tkData.ToString());
                        string[] rowData = new string[] { myUsername, difUser.userName, myResult };
                        dtGridViewHistory.Rows.Add(rowData);
                    }
                }
            }
            dtGridViewHistory.ReadOnly = true;
        }
        //==================================================================================================================================

        //========================================= HÀM DÙNG ĐỂ THAO TÁC VỚI SỰ KIỆN BẤM VÀO DATAGRIDVIEW ==================================
        private async void dtGridContainListRooms_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridView dataGridView = (DataGridView)sender;

                if (e.ColumnIndex == 6)
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
                            string idMatch = dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
                            //tiến hành lấy ra mã phòng khi click vào
                            JToken tkData = await callApiUsingMethodPut(new { option = "adduser", id = user.id }, apiAddUserIntoMatch + idMatch);
                            matches match = JsonConvert.DeserializeObject<matches>(tkData.ToString());

                            //tiến hành cập nhật lại danh sách phòng chơi
                            displayListMatches();


                            //lặp qua để kiếm ra id của đối phương
                            string id = "";
                            foreach (matchPlayer match1 in match.players)
                            {
                                if (match1.user != user.id)
                                {
                                    id = match1.user;
                                    break;
                                }
                            }

                            JToken userPlayer = await callApiUsingGetMethodID(apiGetUserId + id);

                            infoUser difUser = JsonConvert.DeserializeObject<infoUser>(userPlayer.ToString());
                            //gửi sự kiện tới server và cập nhật lại biến user.players lên 2 đơn vị
                            string message = (int)setting.joinRoom + "*" + difUser.userName;
                            sendData(message);
                            Form1 player = new Form1(idMatch, ipAddress, false, false, 1, match.betPoints, user.linkAvatar, user.point, user.userName, user.id);  //chủ phòng sẽ là cờ trắng
                            player.Show();
                            this.Hide();
                        }
                    }
                }
            }
        }
        private async void dtAllUsers_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
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
        private async void dtListFriends_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridView dataGridView = (DataGridView)sender;
                if (e.ColumnIndex == 3) //xem thông tin người chơi
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
                    pnlChatOne.Controls.Clear();
                    pnlChatOne.Show();
                    foreach (UserControlChatOne userControl in listChats)
                    {
                        if (userControl.Tag.ToString().Contains(user.userName) && userControl.Tag.ToString().Contains(dataGridView.Rows[e.RowIndex].Cells["userName"].Value.ToString()))
                        {
                            foreach (UserControl userControl1 in listChats)
                                userControl1.Hide();
                            chat = userControl;
                            difUsernameUser = dataGridView.Rows[e.RowIndex].Cells["userName"].Value.ToString();
                            pnlChatOne.Controls.Add(chat);
                            chat.Show();
                            break;
                        }
                    }
                }
                else if (e.ColumnIndex == 5)
                {
                    //gọi tới api danh sách đợi
                    JToken tkData = await callApiUsingMethodGet(apiGetAllListFriend);
                    List<listFriends> listFriends = JsonConvert.DeserializeObject<List<listFriends>>(tkData.ToString());
                    string id1 = user.id;
                    string id2 = dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
                    string difUsername = dataGridView.Rows[e.RowIndex].Cells["userName"].Value.ToString();
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

                        //xóa bạn bè thì cũng coi như mất luồng chat 
                        foreach(UserControlChatOne control in listChats)
                        {
                            if(control.Tag.ToString().Contains(user.userName) && control.Tag.ToString().Contains(difUsername))
                            {
                                listChats.Remove(control);
                                break;
                            }
                        }
                    }
                }
            }
        }
        private void Chat_btnCloseForm_click(object sender, EventArgs e)
        {
            pnlChatOne.Hide();
            pnlListFriends.Show();
        }
        private async void dtAcceptFriend_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
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

                        createChatBetweenClientAndClient();
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
            login.showFormAgain.Show();

            //xóa danh sách chat
            listChats.Clear();

            //tiến hành đóng form lại
            this.Close();
        }
        private async void btnRank_Click(object sender, EventArgs e)
        {

            JToken tkData = await callApiUsingMethodGet(apiGetAllUser);
            List<infoUser> users = JsonConvert.DeserializeObject<List<infoUser>>(tkData.ToString());
            displayListRank(users);

            loopChildPanel(pnlRanker);
        }
        private async void btnMakeFriend_Click(object sender, EventArgs e)
        {

            getListAllUser();

            List<infoUser> getFriends = new List<infoUser>();

            displayListFriends(await getListUser(getFriends, "friend"));
            getFriends.Clear();
            displayListWaitingAccept(await getListUser(getFriends, "waiting"));


            loopChildPanel(pnlListFriends);

            createChatBetweenClientAndClient();
        }
        private void btnRandomRoom_Click(object sender, EventArgs e)
        {

        }
        private async void btnFindUser_Click_1(object sender, EventArgs e)
        {
            //nếu người dùng bấm tìm kiếm thì hiển thị lại giao diện dtAllUsers
            string apiUrl = apiGetAllUser + txtFindUser.Text.Trim() != "" ? apiGetAllUser + "?userName=" + txtFindUser.Text.Trim() : "";
            JToken tokenData = await callApiUsingGetMethodID(apiUrl);
            List<infoUser> userLists = JsonConvert.DeserializeObject<List<infoUser>>(tokenData.ToString());
            //hiển thị danh sách user này lên datagridView
            displayListUsers(userLists);
        }
        private async void btnHistory_Click(object sender, EventArgs e)
        {
            JToken tkData = await callApiUsingGetMethodID(apiGetUserId + user.id);
            infoUser myUser = JsonConvert.DeserializeObject<infoUser>(tkData.ToString());
            displayListHistoryMatch(myUser);

            loopChildPanel(pnlChildContainHistory);
        }
        private void btnCreateRoom_Click(object sender, EventArgs e)
        {
            loopChildPanel(pnlCreateRoom);
        }
        private void btnExit_Click_1(object sender, EventArgs e)
        {
            pnlContainsChild.Hide();
        }
        private async void createChatBetweenClientAndClient()
        {
            //thêm tập hợp các bạn bè vào để chat
            List<string> listFriends = await getListFriends();
            foreach (string userName in listFriends)
            {
                bool check = false;
                if (userName != user.userName)
                {
                    for (int index = 0; index < listChats.Count; index++)
                    {
                        if (listChats[index].Tag.ToString().Contains(user.userName) && listChats[index].Tag.ToString().Contains(userName))
                        {
                            check = true;
                            break;
                        }
                    }
                    if (!check)
                    {
                        chat = new UserControlChatOne();
                        chat.Tag = $"{user.userName},{userName}";
                        chat.btnSendMsgChatOne_click += Chat_btnSendMsgChatOne_click;
                        chat.btnSendIconChatOne_click += Chat_btnSendIconChatOne_click;
                        chat.btnCloseForm_click += Chat_btnCloseForm_click;
                        chat.Dock = DockStyle.Bottom;
                        listChats.Add(chat);
                    }
                }
                check = false;
            }
            chat = null;
        }
        private async void btnAcceptCreateRoom_Click_1(object sender, EventArgs e)
        {
            if (string.Equals(txtRoomName.Text.Trim(), "") || string.Equals(txtBetPoints.Text.Trim(), ""))
            {
                MessageBox.Show("Thông tin nhập vào không được bỏ trống");
            }
            else
            {
                try
                {
                    int betPoint = int.Parse(txtBetPoints.Text.Trim());
                    if(betPoint ==  0)
                    {
                        MessageBox.Show("Vui lòng nhập điểm cược lớn hơn 0");
                        return;
                    }
                    if (betPoint > user.point)
                    {
                        MessageBox.Show("Bạn không đủ điểm để đặt mức cược này, vui lòng nhập điểm cược khác");
                        return;
                    }
                    HttpClient client = new HttpClient();
                    var data = new
                    {
                        id = user.id,
                        betPoints = betPoint,
                        roomName = txtRoomName.Text.Trim(),
                        ownerRoom = user.userName
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
                        Form1 admin = new Form1(match._id, ipAddress, true, true, 0, betPoint, user.linkAvatar, user.point, user.userName, user.id);  //chủ phòng sẽ là cờ trắng
                        admin.Show();
                    }
                    else
                    {
                        MessageBox.Show(objData["notify"].ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Điểm cược không hợp lệ, vui lòng nhập lại");
                }
            }
        }
        private void mainInterface_FormClosed(object sender, FormClosedEventArgs e)
        {
            ////tiến hành xóa doạn chat
            foreach (UserControlChatOne control in listChats)
            {
                control.Dispose();
            }
            listChats.Clear();
        }
        //==================================================================================================================================
    }
}
