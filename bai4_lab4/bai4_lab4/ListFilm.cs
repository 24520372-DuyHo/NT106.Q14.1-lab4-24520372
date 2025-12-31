using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;
using Newtonsoft.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace bai4_lab4
{
    public partial class ListFilm : Form
    {
        public ListFilm()
        {
            InitializeComponent();
        }

        private async void ListFilm_Load(object sender, EventArgs e)
        {
            await CrawlDataAuto();
        }

        private async Task CrawlDataAuto()
        {
            string url = "https://betacinemas.vn/phim.htm";
            flpMovies.Controls.Clear();
            HtmlAgilityPack.HtmlDocument doc = await Task.Run(() =>
            {
                HtmlWeb web = new HtmlWeb();
                return web.Load(url);
            });

            var movieNodes = doc.DocumentNode.SelectNodes("//div[contains(@class, 'col-lg-4')]");

            if (movieNodes == null || movieNodes.Count == 0)
            {
                MessageBox.Show("Không lấy được dữ liệu phim");
                return;
            }

            progressBar1.Maximum = movieNodes.Count;
            progressBar1.Value = 0;
            List<Movie> movieList = new List<Movie>();

            foreach (var node in movieNodes)
            {
                Movie movie = new Movie();

                await Task.Run(() =>
                {
                    var titleNode = node.SelectSingleNode(".//h3/a") ?? node.SelectSingleNode(".//div[@class='film-name']/a");
                    if (titleNode != null) movie.Title = WebUtility.HtmlDecode(titleNode.InnerText.Trim());
                    var imgNode = node.SelectSingleNode(".//img");
                    if (imgNode != null) movie.ImageUrl = imgNode.GetAttributeValue("src", "");

                    if (titleNode != null)
                    {
                        string href = titleNode.GetAttributeValue("href", "");
                        if (!href.StartsWith("http"))
                        {
                            movie.DetailUrl = "https://betacinemas.vn" + href;
                        }
                        else
                        {
                            movie.DetailUrl = href;
                        }
                    }
                });

                movieList.Add(movie);

                GenerateMovieControl(movie);
                progressBar1.Value++;
            }
            SaveMoviesToJson(movieList);
        }

        private void GenerateMovieControl(Movie movie)
        {
            Panel pnl = new Panel();
            pnl.Size = new Size(200, 320);
            pnl.BorderStyle = BorderStyle.FixedSingle;
            pnl.Margin = new Padding(10);

            PictureBox pb = new PictureBox();
            pb.Size = new Size(180, 230);
            pb.Location = new Point(10, 10);
            pb.SizeMode = PictureBoxSizeMode.StretchImage;

            if (!string.IsNullOrEmpty(movie.ImageUrl))
            {
                pb.LoadAsync(movie.ImageUrl);
            }

            pb.Cursor = Cursors.Hand;
            pb.Click += (s, e) => ShowMovieDetail(movie);

            Label lbl = new Label();
            lbl.Text = movie.Title;
            lbl.Location = new Point(10, 250);
            lbl.Size = new Size(180, 60);
            lbl.Font = new Font("Arial", 10, FontStyle.Bold);
            lbl.TextAlign = ContentAlignment.TopCenter;

            pnl.Controls.Add(pb);
            pnl.Controls.Add(lbl);

            flpMovies.Controls.Add(pnl);
        }

        private void SaveMoviesToJson(List<Movie> movies)
        {
            try
            {
                string json = JsonConvert.SerializeObject(movies, Formatting.Indented);
                File.WriteAllText("movies.json", json);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu file: " + ex.Message);
            }
        }

        private void ShowMovieDetail(Movie movie)
        {
            DetailFilm webForm = new DetailFilm(movie);
            webForm.Show();
        }
    }
}
