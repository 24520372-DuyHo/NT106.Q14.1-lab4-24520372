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
    public partial class RandomFood : Form
    {
        private readonly Dish _randomDish;
        public RandomFood(Dish dish)
        {
            InitializeComponent();
            _randomDish = dish;
            this.Load += RandomFood_Load;
        }

        private void RandomFood_Load(object sender, EventArgs e)
        {
            if (_randomDish != null)
            {
                BindFoodData(_randomDish);
            }
            else
            {
                lblDishName.Text = "Không tìm thấy món ăn ngẫu nhiên!";
            }
        }

        private void BindFoodData(Dish food)
        {
            this.Text = $"Ăn {food.Name} đi!";
            lblDishName.Text = food.Name;
            lblPriceValue.Text = food.Price.ToString("N0") + " VNĐ";
            lblAddressValue.Text = food.Address;
            lblDescriptionValue.Text = food.Description;

            if (!string.IsNullOrEmpty(food.ImageUrl))
            {
                LoadImageAsync(food.ImageUrl);
            }
        }

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
    }
}
