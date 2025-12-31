using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Web.WebView2.WinForms;

namespace bai4_lab4
{
    public partial class DetailFilm : Form
    {
        private Movie _movie;
        public DetailFilm(Movie movie)
        {
            InitializeComponent();

            _movie = movie;

            this.Text = "Chi tiết phim: " + _movie.Title;
            lblTitle.Text = _movie.Title.ToUpper();
            LoadWebPage();
        }

        private async void LoadWebPage()
        {
            try
            {
                await webView.EnsureCoreWebView2Async(null);

                if (!string.IsNullOrEmpty(_movie.DetailUrl))
                {
                    webView.CoreWebView2.Navigate(_movie.DetailUrl);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải trình duyệt: " + ex.Message);
            }
        }

        private void btnBookTicket_Click(object sender, EventArgs e)
        {
            BookingForm bookingForm = new BookingForm(_movie);
            bookingForm.ShowDialog();
        }

    }
}
