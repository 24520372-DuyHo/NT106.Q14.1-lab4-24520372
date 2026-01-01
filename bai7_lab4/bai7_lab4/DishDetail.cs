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

namespace bai7_lab4
{
    public partial class DishDetail : Form
    {
        private readonly Dish _currentDish;

        /// <summary>
        /// Constructor nhận đối tượng Dish từ MainForm.
        /// </summary>
        public DishDetail(Dish dish)
        {
            InitializeComponent();
            _currentDish = dish;
            this.Load += DishDetailForm_Load;
        }

        private void DishDetailForm_Load(object sender, EventArgs e)
        {
            if (_currentDish != null)
            {
                BindDishDetails(_currentDish);
            }
            else
            {
                MessageBox.Show("Không tìm thấy chi tiết món ăn.", "Lỗi");
                this.Close();
            }
        }

        private void BindDishDetails(Dish dish)
        {
            this.Text = dish.Name;
            lblDishName.Text = dish.Name;

            lblPriceValue.Text = dish.Price.ToString("N0") + " VNĐ";

            lblAddressValue.Text = dish.Address;
            txtDescription.Text = dish.Description;
            lblContributorValue.Text = dish.ContributorName ?? "N/A";

            if (!string.IsNullOrEmpty(dish.ImageUrl))
            {
                LoadImageAsync(dish.ImageUrl);
            }
        }

        /// <summary>
        /// Tải hình ảnh bất đồng bộ từ URL và hiển thị trên PictureBox.
        /// </summary>
        private async void LoadImageAsync(string imageUrl)
        {
            string encodedUrl = Uri.EscapeUriString(imageUrl);

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var imageBytes = await client.GetByteArrayAsync(encodedUrl);

                    using (var ms = new MemoryStream(imageBytes))
                    {
                        picDishImage.Image = Image.FromStream(ms);
                        picDishImage.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                }
                catch (HttpRequestException)
                {
                    picDishImage.Image = null;
                }
                catch (Exception)
                {
                    picDishImage.Image = null;
                }
            }
        }
    }
}