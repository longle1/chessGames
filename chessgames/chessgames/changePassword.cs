using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chessgames
{
    public partial class changePassword : Form
    {
        public changePassword()
        {
            InitializeComponent();

        }
        private string apiResetPassword = "https://chessmates.onrender.com/api/v1/auth/resetPassword";
        private void displayError(errorRegister errors)
        {
            errorNewPassword.Text = "";
            errorNewPassword.ForeColor = Color.Red;


            if (errorNewPassword.Text == "")
                if (errors.password != null)
                    foreach (string error in errors.password)
                        errorNewPassword.Text += error + "\n";


        }
        private async void btnNext_Click(object sender, EventArgs e)
        {
            if (txtNewPassword.Text.Trim() == "") return;
            var data = new
            {
                password = txtNewPassword.Text.Trim()
            };
            
            string dataJson = JsonConvert.SerializeObject(data);
            HttpClient client = new HttpClient();
            // Gửi yêu cầu POST đến apiUrl với dữ liệu jsonData
            HttpResponseMessage response = await client.PostAsync(apiResetPassword, new StringContent(dataJson, Encoding.UTF8, "application/json"));

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                if(errorConfirmPassword.Text == "")
                {
                    MessageBox.Show("Đổi mật khẩu thành công");

                    this.Close();
                    login.showFormAgain.Show();
                }
            }
            else
            {
                string responseData = await response.Content.ReadAsStringAsync();
                // Phân tích chuỗi JSON
                JObject jsonData = JObject.Parse(responseData);

                // Lấy giá trị của thuộc tính "data"
                JToken dataToken = jsonData["messageErrors"];
                JObject dataObject = dataToken.ToObject<JObject>();
                errorRegister errors = JsonConvert.DeserializeObject<errorRegister>(dataObject.ToString());
                //hiển thị lỗi lên trên giao diện
                displayError(errors);
                if (string.Equals(txtConfirmPassword.Text, txtNewPassword.Text))
                    errorConfirmPassword.Text = "";
                else
                {
                    errorConfirmPassword.ForeColor = Color.Red;
                    errorConfirmPassword.Text = "Mật khẩu không khớp";
                }
            }
        }

        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            if (string.Equals(txtConfirmPassword.Text, txtNewPassword.Text))
                errorConfirmPassword.Text = "";
            else
            {
                errorConfirmPassword.ForeColor = Color.Red;
                errorConfirmPassword.Text = "Mật khẩu không khớp";
            }
        }
    }
}
