using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chessgames
{
    public partial class FormInfoUser : Form
    {
        public FormInfoUser()
        {
            InitializeComponent();
        }
        private string preUserame;
        private string preEmail;
        private infoUser user;
        private string apiGetUser = "https://chessmates.onrender.com/api/v1/users/edit/";
        private string directoryImagePath;
        private string pathImage;
        private string preLinkAvatar;
        private bool checkModify;
        private void FormInfoUser_Load(object sender, EventArgs e)
        {
            txtDefeats.ReadOnly = true;
            txtEmail.ReadOnly = true;
            txtID.ReadOnly = true;
            txtUsername.ReadOnly = true;
            txtWins.ReadOnly = true;
        }
        public FormInfoUser(infoUser user, bool checkModify) : this()
        {
            try
            {
                directoryImagePath = Directory.GetParent(Application.StartupPath)?.Parent?.FullName + "\\Images";
                this.checkModify = checkModify;
                if (checkModify)
                {
                    btnChangeImage.Enabled = false;
                    btnSaveInfo.Enabled = false;
                }
                else
                {
                    btnChangeImage.Visible = false;
                    btnSaveInfo.Visible = false;
                    btnEditInfo.Visible = false;    
                }
                this.user = user;

                //hien thi hinh anh len giao dien
                ptboxAvatar.Image = Image.FromFile($"{directoryImagePath}\\" + user.linkAvatar);
                ptboxAvatar.SizeMode = PictureBoxSizeMode.Zoom;

                txtDefeats.Text = user.numberOfLosses.ToString();
                txtWins.Text = user.numberOfWins.ToString();
                txtUsername.Text = user.userName;
                txtEmail.Text = user.gmail;
                txtID.Text = user.id;
                preLinkAvatar = user.linkAvatar;
                //lưu lại thông tin trước đó
                preEmail = user.gmail;
                preUserame = user.userName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEditInfo_Click(object sender, EventArgs e)
        {
            txtUsername.ReadOnly = false;
            txtEmail.ReadOnly = false;

            btnEditInfo.Enabled = false;
            btnChangeImage.Enabled = true;
            btnSaveInfo.Enabled = true;
        }
        private void addImageIntoPath(string directoryPath, string fileImage)
        {

            using (FileStream stream = new FileStream(Path.Combine(directoryPath, fileImage), FileMode.Create))
            {
                byte[] imageData = File.ReadAllBytes(pathImage);

                stream.Write(imageData, 0, imageData.Length);
            }
        }
        private async void btnSaveInfo_Click(object sender, EventArgs e)
        {
            btnEditInfo.Enabled = true;
            btnSaveInfo.Enabled = false;
            btnChangeImage.Enabled = false;
            string apiPath = apiGetUser + user.id;
            //đưa user lên api để kiểm tra API có tồn tại hay không

            var data = new
            {
                userName = txtUsername.Text,
                gmail = txtEmail.Text,
                linkAvatar = user.linkAvatar,
                statusActive = "online"
            };
            //chuyển data về kiểu json
            string jsonData = JsonConvert.SerializeObject(data);
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.PutAsync(apiPath, new StringContent(jsonData, Encoding.UTF8, "application/json"));


            //lấy ra notify
            string responseData = await response.Content.ReadAsStringAsync();
            JObject objData = JObject.Parse(responseData);
            JToken tokenData = objData["notify"];

            if (response.StatusCode == System.Net.HttpStatusCode.Created)
            {
                //lấy dữ liệu thành công
                MessageBox.Show(tokenData.ToString());
                //them hinh anh vao trong kho luu tru va tien hanh xoa anh cu khoi kho luu tru

                if (user.linkAvatar != "defaultAvatar.jpg")
                    //khong tinh truong hop anh mac dinh va xoa hinh anh cu khoi kho luu tru
                    addImageIntoPath(directoryImagePath, user.linkAvatar);

                //cập nhật lại thông tin
                user.userName = txtUsername.Text;
                user.gmail = txtEmail.Text;
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                MessageBox.Show(tokenData.ToString());
                //cap nhat user ve lai gia tri ban dau
                txtUsername.Text = preUserame;
                txtEmail.Text = preEmail;

                ptboxAvatar.Image = Image.FromFile($"{directoryImagePath}\\" + preLinkAvatar);
                ptboxAvatar.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void btnChangeImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            if (openFileDialog.FileName == "") return;
            string[] paths = openFileDialog.FileName.Split('\\');
            preLinkAvatar = user.linkAvatar;
            user.linkAvatar = paths[paths.Length - 1];

            ptboxAvatar.Image = Image.FromFile(openFileDialog.FileName);
            ptboxAvatar.SizeMode = PictureBoxSizeMode.Zoom;
            pathImage = openFileDialog.FileName;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            if (checkModify)
            {
                mainInterface.showInter.Close();

                //tạo lại form mới
                mainInterface mainInter = new mainInterface(user);
                mainInter.Show();
            }
            else
                mainInterface.showInter.Show();
        }
    }
}
