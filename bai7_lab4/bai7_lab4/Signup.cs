using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;

namespace bai7_lab4
{
    public partial class Signup : Form
    {
        private const string SIGNUP_URL = "https://nt106.uitiot.vn/api/v1/user/signup";
        private readonly ApiHandler _apiHandler;
        public Signup(ApiHandler apiHandler)
        {
            InitializeComponent();

            _apiHandler = apiHandler;
            btnSubmit.Click += BtnSubmit_Click;
            btnClear.Click += BtnClear_Click;
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtEmail.Clear();
            txtFirstname.Clear();
            txtLastname.Clear();
            txtPhone.Clear();
            dtpBirthday.Value = DateTime.Now;
            rdoMale.Checked = true;
        }

        private async void BtnSubmit_Click(object sender, EventArgs e)
        {
       
            if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text) || string.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ các trường bắt buộc (Username, Password, Email).", "Lỗi");
                return;
            }

            if (dtpBirthday.Value.Date >= DateTime.Today.Date)
            {
                MessageBox.Show("Ngày sinh phải là một ngày trong quá khứ.", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                await PerformSignUpAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi hệ thống: {ex.Message}", "Lỗi");
            }
        }

        private async Task PerformSignUpAsync()
        {
            var dataToSend = new
            {
                username = txtUsername.Text,
                password = txtPassword.Text,
                email = txtEmail.Text,

                user_info = new
                {
                    firstname = txtFirstname.Text,
                    lastname = txtLastname.Text,
                    phone = txtPhone.Text,
                    sex = (rdoMale.Checked) ? "Male" : "Female",
                    date_of_birth = dtpBirthday.Value.ToString("yyyy-MM-dd")
                }
            };

            HttpClient client = _apiHandler.GetClient();
            string jsonContent = JsonConvert.SerializeObject(dataToSend);
            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            try
            {
                HttpResponseMessage response = await client.PostAsync(SIGNUP_URL, httpContent);
                string responseString = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Đăng ký tài khoản thành công! Vui lòng đăng nhập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    string errorMessage = $"Đăng ký thất bại. Mã trạng thái: {(int)response.StatusCode}";

                    try
                    {
                        JToken errorToken = JToken.Parse(responseString);

                        JToken detailToken = errorToken["detail"] ?? errorToken.Root;

                        if (detailToken is JArray)
                        {
                            var errorList = detailToken.ToObject<List<ApiErrorDetail>>();

                            if (errorList != null && errorList.Any())
                            {
                                errorMessage = errorList.First().GetDisplayMessage();
                            }
                            else
                            {
                                errorMessage = "Phản hồi lỗi là mảng rỗng hoặc không đúng cấu trúc chi tiết.";
                            }
                        }
                        else if (detailToken is JObject)
                        {
                            ErrorModel errorObject = detailToken.ToObject<ErrorModel>();
                            errorMessage = errorObject.Detail ?? "Lỗi đối tượng không xác định.";
                        }
                        else if (detailToken is JValue)
                        {
                            errorMessage = detailToken.ToString();
                        }
                        else
                        {
                            errorMessage = $"Phản hồi lỗi có cấu trúc không xác định: {responseString.Substring(0, Math.Min(responseString.Length, 50))}...";
                        }
                    }
                    catch (JsonException ex)
                    {
                        errorMessage = $"Lỗi hệ thống: Không thể đọc cấu trúc lỗi API. Chi tiết Json: {ex.Message} (Phản hồi không phải JSON tiêu chuẩn)";
                    }
                    catch (Exception ex)
                    {
                        errorMessage = $"Lỗi hệ thống không xác định trong quá trình xử lý lỗi: {ex.Message}";
                    }

                    MessageBox.Show($"Đăng ký thất bại. Lỗi: {errorMessage}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex) when (ex is HttpRequestException || ex is TaskCanceledException)
            {
                MessageBox.Show($"Lỗi kết nối: Không thể kết nối tới máy chủ API. Chi tiết: {ex.Message}", "Lỗi Mạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi hệ thống không xác định: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
