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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chessgames
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
            errorHideLabel.Hide();
            txtPassword.Text = "123@Long";
            btnLogin.Enabled = true;
            showFormAgain = this;   //gán form hiện tại cho 1 form
        }
        public Timer timer = null;
        public string apiUrlLogin = "https://chessmates.onrender.com/api/v1/auth/login";
        private string apiGetUser = "https://chessmates.onrender.com/api/v1/users/edit/";
        public int countLogin = 2;
        public int timeStart = 1;
        public int timeFinish = 60;
        public static login showFormAgain;

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (timeStart == timeFinish)
            {
                txtPassword.Enabled = true;
                txtUserName.Enabled = true;
                btnLogin.Enabled = true;
                timer.Stop();
                errorHideLabel.Text = "";
                errorHideLabel.Hide();
                countLogin = 2;
            }
            timeStart++;
        }
        private async void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text.Trim() == "" || txtPassword.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ username và password");
                return;
            }
            var data = new
            {
                userName = txtUserName.Text.Trim(),
                password = txtPassword.Text.Trim()
            };
            string dataJson = JsonConvert.SerializeObject(data);
            btnLogin.Enabled = false;
            HttpClient client = new HttpClient();
            // Gửi yêu cầu POST đến apiUrl với dữ liệu jsonData
            HttpResponseMessage response = await client.PostAsync(apiUrlLogin, new StringContent(dataJson, Encoding.UTF8, "application/json"));

            try
            {
                int statusCode = (int)response.StatusCode;
                //đọc nội dung phản hồi dưới dạng chuỗi json
                if (statusCode == 200)
                {
                    string responseData = await response.Content.ReadAsStringAsync();
                    // Phân tích chuỗi JSON
                    JObject jsonData = JObject.Parse(responseData);

                    // Lấy giá trị của thuộc tính "data"
                    JToken dataToken = jsonData["data"];
                    // Chuyển đổi sang đối tượng JSON
                    JObject dataObject = dataToken.ToObject<JObject>();
                    infoUser user = JsonConvert.DeserializeObject<infoUser>(dataObject.ToString());
                    MessageBox.Show(jsonData["notify"].ToString());

                    //cập nhật trạng thái thành hoạt động
                    string apiUser = apiGetUser + user.id;
                    var data1 = new
                    {
                        userName = user.userName,
                        gmail = user.gmail,
                        linkAvatar = user.linkAvatar,
                        statusActive = "online",
                    };
                    user.statusActive = "online";
                    string jsonData1 = JsonConvert.SerializeObject(data1);
                    HttpClient client1 = new HttpClient();
                    await client1.PutAsync(apiUser, new StringContent(jsonData1, Encoding.UTF8, "application/json"));

                    //tạo ra giao diện chính
                    mainInterface inter = new mainInterface(user);
                    inter.Show();
                    this.Hide();
                    btnLogin.Enabled = true;
                }
                if (statusCode == 401)
                {
                    if (countLogin == 0)
                    {
                        btnLogin.Enabled = true;
                        txtPassword.Enabled = false;
                        txtUserName.Enabled = false;
                        btnLogin.Enabled = false;
                        errorHideLabel.Text = "Vui lòng chờ 3 phút để thực hiện lại thao tác này";
                        timer = new Timer();
                        timer.Interval = 1000;
                        timer.Start();
                        timer.Tick += Timer_Tick;
                        return;
                    }
                    btnLogin.Enabled = true;
                    errorHideLabel.Show();
                    errorHideLabel.ForeColor = Color.Red;
                    errorHideLabel.Text = $"Bạn còn {countLogin} lần để đăng nhập";
                    countLogin--;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            register rgForm = new register();
            rgForm.Show();

            //ẩn form hiện tại
            Hide();
        }

        private void forgotPasswordLabel_Click(object sender, EventArgs e)
        {
            //click vào quên mật khẩu thì hiện form xác thực tài khoản
            authAccount auth = new authAccount();
            auth.Show();

            //ẩn form login đi 
            this.Hide();
        }
    }
}
