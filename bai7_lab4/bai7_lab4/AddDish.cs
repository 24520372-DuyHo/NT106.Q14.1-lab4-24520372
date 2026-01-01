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
using Newtonsoft.Json;

namespace bai7_lab4
{
    public partial class AddDish : Form
    {
        private readonly ApiHandler _apiHandler;
        public AddDish(ApiHandler apiHandler)
        {
            InitializeComponent();
            _apiHandler = apiHandler;
            btnSubmit.Click += BtnSubmit_Click;
            btnClear.Click += BtnClear_Click;
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            txtPrice.Clear();
            txtAddress.Clear();
            txtImageUrl.Clear();
            txtDescription.Clear();
        }

        private async void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (!_apiHandler.IsLoggedIn)
            {
                MessageBox.Show("Vui lòng đăng nhập để thêm món ăn.", "Lỗi");
                return;
            }
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Vui lòng nhập Tên món ăn.", "Lỗi");
                return;
            }

            try
            {
                await PerformAddDishAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi hệ thống: {ex.Message}", "Lỗi");
            }
        }

        private async Task PerformAddDishAsync()
        {
            int priceValue;

            if (!int.TryParse(txtPrice.Text, out priceValue))
            {
                MessageBox.Show("Giá tiền phải là một số nguyên hợp lệ. Vui lòng kiểm tra lại.", "Lỗi Dữ Liệu");
                return;
            }

            var dataToSend = new
            {
                ten_mon_an = txtName.Text,
                gia = priceValue,
                dia_chi = txtAddress.Text,
                hinh_anh = txtImageUrl.Text,
                mo_ta = txtDescription.Text,
                user_id = _apiHandler.CurrentUser.Id,
                category_id = 1
            };

            bool success = false;

            try
            {
                success = await _apiHandler.AddDishAsync(dataToSend);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kết nối mạng hoặc hệ thống: {ex.Message}", "Lỗi");
                return;
            }

            if (success)
            {
                MessageBox.Show("Thêm món ăn thành công!", "Thành công");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show($"Thêm món ăn thất bại. Vui lòng kiểm tra lại dữ liệu nhập (ví dụ: thiếu trường bắt buộc).", "Lỗi API");
            }
        }
    }
}
