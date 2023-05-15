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
    public partial class authAccount : Form
    {
        public authAccount()
        {
            InitializeComponent();
        }
        private string apiAuthAccount = "https://chessmates.onrender.com/api/v1/auth/forgotPassword";
        private async void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtAuthEmail.Text.Trim() == "" || txtAuthUserName.Text.Trim() == "")
                    return;
                string userName = txtAuthUserName.Text.Trim();
                string gmail = txtAuthEmail.Text.Trim();
                var data = new
                {
                    userName,
                    gmail
                };

                string dataJson = JsonConvert.SerializeObject(data);
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.PostAsync(apiAuthAccount, new StringContent(dataJson, Encoding.UTF8, "application/json"));

                string responseData = await response.Content.ReadAsStringAsync();
                JObject jsonData = JObject.Parse(responseData);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    MessageBox.Show(jsonData["notify"].ToString());
                    //chuyển qua form nhập mã xác thực
                    inputToken token = new inputToken(userName, gmail);
                    token.Show();

                    this.Close();
                }
                else
                    MessageBox.Show(jsonData["notify"].ToString());
            }
            catch(Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi, vui lòng thực hiện lại");

            }
        }
    }
}
