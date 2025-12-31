using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Policy;
using Newtonsoft.Json.Linq;

namespace bai6_lab4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnGetInfo_Click(object sender, EventArgs e)
        {
            string url = tbUrl.Text;
            string fullToken = tbToken.Text.Trim();

            if (string.IsNullOrWhiteSpace(url) || string.IsNullOrWhiteSpace(fullToken))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ URL và Token xác thực (từ Bài 5).", "Lỗi");
                return;
            }
            string tokenScheme = "Bearer";
            string accessToken;

            if (fullToken.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
            {
                accessToken = fullToken.Substring("Bearer ".Length).Trim();
            }
            else
            {
                accessToken = fullToken;
            }

            using (var client = new HttpClient())
            {
                try
                { 
                    client.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue(tokenScheme, accessToken);
                    rtbResult.Text = "Đang gửi yêu cầu GET thông tin người dùng...";
                    HttpResponseMessage response = await client.GetAsync(url);
                    string responseString = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        JToken userObject = JToken.Parse(responseString);

                        rtbResult.Text =
                            "Lấy thông tin thành công (HTTP 200 OK):\n\n" +
                            userObject.ToString(Newtonsoft.Json.Formatting.Indented);
                    }
                    else
                    {
                        rtbResult.Text =
                            "Lấy thông tin thất bại (Mã: " + (int)response.StatusCode + ")\n\n" +
                            "Chi tiết lỗi:\n" + responseString;
                    }
                }
                catch (Exception ex)
                {
                    rtbResult.Text = "Lỗi không xác định: " + ex.Message;
                }
            }
        }
    }
}
