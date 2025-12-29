using System;                  
using System.Collections.Generic;
using System.IO;              
using System.Linq;
using System.Net;              
using System.Net.Http;
using System.Security.Policy;
using System.Text;             
using System.Threading.Tasks;  
using System.Windows.Forms;    

namespace baitap1_lab4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Khởi tạo trạng thái ban đầu
            btnGet.Enabled = !string.IsNullOrWhiteSpace(txtURL.Text);
            btnGet.Click += btnGet_Click; // Gán sự kiện
        }
        private string getHTML(string szURL)
        {
            // Create a request for the URL.
            WebRequest request = WebRequest.Create(szURL);
            // Get the response.
            WebResponse response = request.GetResponse();
            // Get the stream containing content returned by the server.
            Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            // Close the response.
            response.Close();
            return responseFromServer;
        }

        /// <summary>
        /// Sự kiện bấm nút GET — chạy bất đồng bộ để UI không bị treo.
        /// </summary>
        private async void btnGet_Click(object sender, EventArgs e)
        {
            // Lấy URL từ TextBox
            string url = txtURL.Text.Trim();

            // Kiểm tra nếu URL trống
            if (string.IsNullOrEmpty(url))
            {
                richTextBoxHTML.Text = "Vui lòng nhập URL!";
                return;
            }

            // Hiển thị trạng thái đang tải dữ liệu
            richTextBoxHTML.Text = "Đang tải dữ liệu...\n";

            // Gọi hàm GetHTML trong Task để tránh block UI
            string html = await Task.Run(() => getHTML(url));

            // Hiển thị kết quả hoặc thông báo lỗi trực tiếp vào RichTextBox
            richTextBoxHTML.Text = html;
        }

        private void txtURL_TextChanged(object sender, EventArgs e)
        {
            btnGet.Enabled = !string.IsNullOrWhiteSpace(txtURL.Text);
        }
    }
}
