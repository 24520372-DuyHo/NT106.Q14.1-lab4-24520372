using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;
using Microsoft.Web.WebView2.WinForms;

namespace baitap3_lab4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeAsync();
        }

        private async void InitializeAsync()
        {
            await webView2.EnsureCoreWebView2Async();
        }

        private void txtURL_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            webView2.Reload();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtURL.Text))
            {
                webView2.CoreWebView2.Navigate(txtURL.Text);
            }
        }

        private void btnDownFiles_Click(object sender, EventArgs e)
        {
            using (WebClient client = new WebClient())
            {
                string url = txtURL.Text;
                if (string.IsNullOrEmpty(url))
                {
                    MessageBox.Show("Vui lòng nhập URL!");
                    return;
                }

                string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "page.html");
                try
                {
                    client.DownloadFile(url, filePath);
                    MessageBox.Show("HTML đã tải về Desktop: page.html");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải HTML: " + ex.Message);
                }
            }
        }

        private void btnDownResources_Click(object sender, EventArgs e)
        {
            string htmlFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "page.html");
            if (!File.Exists(htmlFile))
            {
                MessageBox.Show("Vui lòng tải HTML trước!");
                return;
            }

            string imgFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Images");
            Directory.CreateDirectory(imgFolder);

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.Load(htmlFile);

            var images = doc.DocumentNode.SelectNodes("//img[@src]");
            if (images == null)
            {
                MessageBox.Show("Không tìm thấy hình ảnh nào!");
                return;
            }

            using (WebClient client = new WebClient())
            {
                Uri baseUri = new Uri(txtURL.Text);

                foreach (var img in images)
                {
                    string src = img.GetAttributeValue("src", "");
                    if (!string.IsNullOrEmpty(src))
                    {
                        try
                        {
                            // Chuyển URL tương đối sang URL tuyệt đối
                            Uri imgUri = new Uri(baseUri, src);
                            string filename = Path.GetFileName(imgUri.LocalPath);

                            client.DownloadFile(imgUri.ToString(), Path.Combine(imgFolder, filename));
                        }
                        catch
                        {
                            // Bỏ qua nếu URL không hợp lệ
                        }
                    }
                }
            }

            MessageBox.Show("Tải xong tất cả hình ảnh vào folder Images trên Desktop!");
        }
    }
}
