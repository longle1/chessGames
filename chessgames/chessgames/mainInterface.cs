using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
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
        TcpClient client = null;

        private enum setting
        {
            createRoom = 0,
            makeFriend = 1,
            unfriend = 2,
            joinRoom = 3,
            chatOne = 4,
            chatMulti = 5,
            outRoom = 6
        }
        public mainInterface()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;


            client = new TcpClient();
            client.Connect(System.Net.IPAddress.Parse("172.20.30.81"), 8081);
            Thread rcvDataThread = new Thread(new ThreadStart(rcvData));
            rcvDataThread.Start();
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

            displayListMatches();
        }
        public void rcvData()
        {
            while (true)
            {
                NetworkStream stream = client.GetStream();

                byte[] data = new byte[1024];
                int length = stream.Read(data, 0, data.Length);
                string message = Encoding.UTF8.GetString(data, 0, length);

                writeData(message);
            }
        }
        private void btnSendIcon_Click(object sender, EventArgs e)
        {

        }
        public void writeData(string msg)
        {
            try
            {
                MethodInvoker invoker = new MethodInvoker(delegate { rtbChat.Text += msg + Environment.NewLine; });
                this.Invoke(invoker);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ghi dữ liệu thất bại, vui lòng thực hiện lại");
            }
        }
        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            NetworkStream stream = client.GetStream();
            string message = (int)setting.chatMulti + "***" + user.userName + ": " + txtSendMessage.Text;
            byte[] data = Encoding.UTF8.GetBytes(message);
            stream.Write(data, 0, data.Length);

            writeData("me: " + txtSendMessage.Text);
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

        private void btnLogout_Click(object sender, EventArgs e)
        {
            //tiến hành đóng form lại
            this.Close();

            login.showFormAgain.Show();
        }

        private void btnRank_Click(object sender, EventArgs e)
        {

        }

        private void btnMakeFriend_Click(object sender, EventArgs e)
        {

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

    }
}
