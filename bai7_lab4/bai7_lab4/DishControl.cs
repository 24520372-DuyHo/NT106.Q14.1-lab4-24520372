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
using System.IO;

namespace bai7_lab4
{
    public delegate void DishDeletedEventHandler(object sender, string dishId);

    public delegate void DishSelectedEventHandler(object sender, Dish dish);

    public partial class DishControl : UserControl
    {
        public event DishDeletedEventHandler DishDeleted;
        public event DishSelectedEventHandler DishSelected;

        public Dish CurrentDish { get; private set; }

        public DishControl()
        {
            InitializeComponent();
            btnDelete.Click += BtnDelete_Click;
            this.Click += DishControl_Click;
            pnlContainer.Click += DishControl_Click;
        }

        /// <summary>
        /// Binds data from the Dish object to the controls.
        /// </summary>
        public void SetDishData(Dish dish)
        {
            CurrentDish = dish;
            this.Tag = dish.Id;

            lblName.Text = dish.Name;
            lblPrice.Text = $"Giá: {dish.Price.ToString("N0")} VNĐ";
            lblAddress.Text = $"Địa chỉ: {dish.Address}";
            lblContributor.Text = $"Đóng góp: {dish.ContributorName ?? "N/A"}";

            if (!string.IsNullOrEmpty(dish.ImageUrl))
            {
                LoadImageAsync(dish.ImageUrl);
            }
        }

        /// <summary>
        /// Loads the image asynchronously from the URL and displays it on the PictureBox.
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
                        picFoodImage.Image = Image.FromStream(ms);
                        picFoodImage.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                }
                catch (HttpRequestException)
                {
                    picFoodImage.Image = null;
                }
                catch (Exception)
                {
                    picFoodImage.Image = null;
                }
            }
        }

        public void ShowDeleteButton(bool show)
        {
            btnDelete.Visible = show;
        }

        private void DishControl_Click(object sender, EventArgs e)
        {
            DishSelected?.Invoke(this, CurrentDish);
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (CurrentDish == null) return;

            if (MessageBox.Show($"Bạn có chắc chắn muốn xóa món ăn '{CurrentDish.Name}'?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {

                DishDeleted?.Invoke(this, CurrentDish.Id);
            }
        }
    }
}