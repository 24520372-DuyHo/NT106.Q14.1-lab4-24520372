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

namespace bai7_lab4
{
    public partial class Login : Form
    {
        private const string LOGIN_URL = "https://nt106.uitiot.vn/auth/token";
        private readonly ApiHandler _apiHandler;
        public Login(ApiHandler apiHandler)
        {
            InitializeComponent();
            _apiHandler = apiHandler;
            this.btnSubmit.Click += BtnSubmit_Click;
        }

        private async void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Vui lòng nhập Tên đăng nhập và Mật khẩu.", "Lỗi");
                return;
            }

            btnSubmit.Enabled = false;
            await PerformLoginAsync();
            btnSubmit.Enabled = true;
        }

        private async Task PerformLoginAsync()
        {
            HttpClient client = _apiHandler.GetClient();

            var loginData = new Dictionary<string, string>
            {
                { "username", txtUsername.Text },
                { "password", txtPassword.Text }
            };

            var httpContent = new FormUrlEncodedContent(loginData);

            try
            {
                HttpResponseMessage response = await client.PostAsync(LOGIN_URL, httpContent);
                string responseString = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    Token token = JsonConvert.DeserializeObject<Token>(responseString);

                    _apiHandler.SetToken(token.AccessToken, token.TokenType);

                    _apiHandler.CurrentUser = await _apiHandler.GetCurrentUserAsync();

                    if (_apiHandler.CurrentUser == null)
                    {
                        MessageBox.Show("Đăng nhập thành công nhưng không thể tải thông tin người dùng.", "Lỗi User Info");
                    }

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    string errorMessage = "Đăng nhập thất bại.";

                    try
                    {
                        JToken errorToken = JToken.Parse(responseString);

                        if (errorToken.Type == JTokenType.Object)
                        {
                            ErrorModel errorObject = errorToken.ToObject<ErrorModel>();
                            errorMessage = errorObject.Detail ?? errorMessage;
                        }
                        else
                        {
                            errorMessage = $"Lỗi API: {response.StatusCode}. Vui lòng kiểm tra lại Username/Password.";
                        }
                    }
                    catch (JsonException)
                    {
                        errorMessage = $"Lỗi hệ thống: Không thể đọc phản hồi lỗi từ API. Mã lỗi: {response.StatusCode}";
                    }

                    MessageBox.Show($"Đăng nhập thất bại. Lỗi: {errorMessage}", "Lỗi");
                }
            }
            catch (Exception ex) when (ex is HttpRequestException || ex is TaskCanceledException)
            {
                MessageBox.Show($"Lỗi kết nối: Không thể kết nối tới máy chủ API. Chi tiết: {ex.Message}", "Lỗi Mạng");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi hệ thống không xác định: {ex.Message}", "Lỗi");
            }
        }

    }
}
