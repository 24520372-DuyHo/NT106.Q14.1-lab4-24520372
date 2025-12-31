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
using System.Xml.Linq;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;

namespace bai5_lab4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.button1.Click += new System.EventHandler(this.btnLogin_Click);
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string url = textBox1.Text;
            string username = maskedTextBox1.Text;
            string password = maskedTextBox2.Text;
            RichTextBox rtbResult = richTextBox1;

            if (string.IsNullOrWhiteSpace(url) || string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ URL, Username và Password.", "Lỗi");
                return;
            }

            using (var client = new HttpClient())
            {
                try
                {
                    var content = new MultipartFormDataContent
                    {
                        { new StringContent(username), "username" },
                        { new StringContent(password), "password" }
                    };

                    rtbResult.Text = "Đang gửi yêu cầu đăng nhập tới API...";
                    HttpResponseMessage response = await client.PostAsync(url, content);
                    string responseString = await response.Content.ReadAsStringAsync();
                    JObject responseObject = JObject.Parse(responseString);

                    if (response.IsSuccessStatusCode)
                    {
                        string tokenType = responseObject["token_type"]?.ToString() ?? "N/A";
                        string accessToken = responseObject["access_token"]?.ToString() ?? "Token not found";

                        rtbResult.Text =
                            tokenType + "\n" +
                            accessToken + "\n\n" +
                            "Đăng nhập thành công \n";
                    }
                    else
                    {
                        string detail = responseObject["detail"]?.ToString() ?? response.ReasonPhrase;

                        rtbResult.Text =
                            "Đăng nhập thất bại (Mã: " + (int)response.StatusCode + ")\n\n" +
                            "Chi tiết lỗi (Detail):\n" + detail;
                    }
                }
                catch (HttpRequestException ex)
                {
                    rtbResult.Text = "Lỗi kết nối mạng: Không thể kết nối tới máy chủ.\nChi tiết: " + ex.Message;
                }
                catch (Newtonsoft.Json.JsonReaderException)
                {
                    rtbResult.Text = "Lỗi: Phản hồi từ server không phải định dạng JSON hợp lệ.";
                }
                catch (Exception ex)
                {
                    rtbResult.Text = "Đã xảy ra lỗi không xác định: " + ex.Message;
                }
            }
        }
    }
}
