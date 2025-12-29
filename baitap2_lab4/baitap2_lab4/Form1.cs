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

namespace baitap2_lab4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            btnDownload.Enabled = !string.IsNullOrWhiteSpace(txtURL.Text);
            btnDownload.Click += btnDownload_Click;
        }

        private void txtURL_TextChanged(object sender, EventArgs e)
        {
            btnDownload.Enabled = !string.IsNullOrWhiteSpace(txtURL.Text);
        }

        private void txtFilePath_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            string url = txtURL.Text.Trim();
            string filePath = @"D:\UIT\uit.html"; // lưu file tại D:\UIT\index.html

            if (!url.StartsWith("http://") && !url.StartsWith("https://"))
                url = "http://" + url;

            try
            {
                // Tạo thư mục nếu chưa tồn tại
                string folder = Path.GetDirectoryName(filePath);
                if (!Directory.Exists(folder))
                    Directory.CreateDirectory(folder);

                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                using (WebClient client = new WebClient())
                {
                    client.DownloadFile(url, filePath);              
                    string html = File.ReadAllText(filePath);        
                    richTextBoxHTML.Text = html;                      
                }
            }
            catch (WebException webEx)
            {
                richTextBoxHTML.Text = "WebException: " + webEx.Message;
            }
            catch (Exception ex)
            {
                richTextBoxHTML.Text = "Exception: " + ex.Message;
            }
        }
    }
}
