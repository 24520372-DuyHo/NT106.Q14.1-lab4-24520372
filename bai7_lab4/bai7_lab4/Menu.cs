using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bai7_lab4
{
    public partial class Menu : Form
    {
        private readonly ApiHandler _apiHandler;
        private User _currentUser;
        private bool _isViewingAllDishes = true;
        private int _currentPage = 1;
        private const int PageSize = 5;

        public Menu()
        {
            InitializeComponent();
            _apiHandler = new ApiHandler();

            this.Load += MainForm_Load;
            btnPrevPage.Click += btnPrevPage_Click;
            btnNextPage.Click += btnNextPage_Click;
            btnLogin.Click += btnLogin_Click;
            btnSignup.Click += btnSignup_Click;
            btnAddNewDish.Click += btnAddNewDish_Click;
            btnRandomDish.Click += btnRandomDish_Click;
            btnAllDishes.Click += btnAllDishes_Click;
            btnMyDishes.Click += btnMyDishes_Click;
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            if (_apiHandler.IsLoggedIn && _apiHandler.CurrentUser == null)
            {
                _currentUser = await _apiHandler.GetCurrentUserAsync();
                _apiHandler.CurrentUser = _currentUser;
            }
            else
            {
                _currentUser = _apiHandler.CurrentUser;
            }

            UpdateUI(_apiHandler.IsLoggedIn && _currentUser != null);

            await LoadDishes();
        }

        private void UpdateUI(bool isAuthenticated)
        {
            _currentUser = _apiHandler.CurrentUser;

            if (isAuthenticated && _currentUser != null)
            {
                lblStatus.Text = $"Welcome, {_currentUser.Username}";
                btnLogin.Text = "Đăng xuất";
                btnSignup.Visible = false;
                btnAddNewDish.Visible = true;
                btnMyDishes.Enabled = true;
            }
            else
            {
                lblStatus.Text = "Unauthenticated";
                btnLogin.Text = "Đăng nhập";
                btnSignup.Visible = true;
                btnAddNewDish.Visible = false;
                btnMyDishes.Enabled = false;
            }

            UpdatePagingControls(0);
        }

        private async Task LoadDishes()
        {
            var safeFont = this.Font ?? new Font("Arial", 10, FontStyle.Regular);

            flowLayoutPanelDishes.Controls.Clear();

            if (!_isViewingAllDishes && _apiHandler.IsLoggedIn && _apiHandler.CurrentUser == null)
            {
                _apiHandler.Logout();
                UpdateUI(false);
                MessageBox.Show("Phiên đăng nhập đã hết hạn. Vui lòng đăng nhập lại.", "Cảnh báo");
                return;
            }

            if (!_isViewingAllDishes && !_apiHandler.IsLoggedIn)
            {
                var lblLoginRequired = new Label { Text = "Vui lòng đăng nhập để xem món ăn bạn đóng góp.", AutoSize = true, Margin = new Padding(10) };
                flowLayoutPanelDishes.Controls.Add(lblLoginRequired);
                UpdatePagingControls(0);
                return;
            }

            List<Dish> dishes = await _apiHandler.GetDishesAsync(_isViewingAllDishes, _currentPage, PageSize);

            if (dishes == null || !dishes.Any())
            {
                var lblNoData = new Label { Text = "Không tìm thấy món ăn nào.", AutoSize = true, Margin = new Padding(10), Font = safeFont };
                flowLayoutPanelDishes.Controls.Add(lblNoData);
                UpdatePagingControls(0);
            }
            else
            {
                foreach (var dish in dishes)
                {
                    var dishControl = new DishControl();
                    dishControl.SetDishData(dish);

                    dishControl.DishSelected += DishControl_DishSelected;
                    dishControl.DishDeleted += DishControl_DishDeleted;

                    dishControl.ShowDeleteButton(!_isViewingAllDishes);
                    flowLayoutPanelDishes.Controls.Add(dishControl);
                }
                UpdatePagingControls(dishes.Count);
            }
        }


        private void DishControl_DishSelected(object sender, Dish dish)
        {
            using (var detailForm = new DishDetail(dish))
            {
                detailForm.ShowDialog();
            }
        }

        private async void DishControl_DishDeleted(object sender, string dishId)
        {
            var result = await _apiHandler.DeleteDishAsync(dishId);

            if (result)
            {
                MessageBox.Show("Xóa món ăn thành công!", "Thành công");
                await LoadDishes();
            }
            else
            {
                MessageBox.Show("Lỗi: Không thể xóa món ăn hoặc không có quyền.", "Lỗi Xóa");
            }
        }
        private void UpdatePagingControls(int currentDishCount)
        {
            lblPageInfo.Text = $"Page {_currentPage}";
            btnPrevPage.Enabled = _currentPage > 1;
            btnNextPage.Enabled = currentDishCount == PageSize;
        }

        private async void btnPrevPage_Click(object sender, EventArgs e)
        {
            if (_currentPage > 1)
            {
                _currentPage--;
                await LoadDishes();
            }
        }

        private async void btnNextPage_Click(object sender, EventArgs e)
        {
            _currentPage++;
            await LoadDishes();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            if (_currentUser != null)
            {
                _apiHandler.Logout();
                _currentUser = null;
                _isViewingAllDishes = true;
                _currentPage = 1;
                UpdateUI(false);
                await LoadDishes();
            }
            else
            {
                using (var loginForm = new Login(_apiHandler))
                {
                    if (loginForm.ShowDialog() == DialogResult.OK)
                    {
                        if (_apiHandler.IsLoggedIn)
                        {
                            _currentUser = await _apiHandler.GetCurrentUserAsync();
                            _apiHandler.CurrentUser = _currentUser;
                        }

                        UpdateUI(_currentUser != null);
                        await LoadDishes();
                    }
                }
            }
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            using (var signupForm = new Signup(_apiHandler))
            {
                signupForm.ShowDialog();
            }
        }

        private async void btnAddNewDish_Click(object sender, EventArgs e)
        {
            if (!_apiHandler.IsLoggedIn)
            {
                MessageBox.Show("Vui lòng đăng nhập để thêm món ăn.", "Yêu cầu đăng nhập");
                return;
            }

            using (var addDishForm = new AddDish(_apiHandler))
            {
                if (addDishForm.ShowDialog() == DialogResult.OK)
                {
                    _isViewingAllDishes = false;
                    _currentPage = 1;
                    await LoadDishes();
                }
            }
        }

        private async void btnRandomDish_Click(object sender, EventArgs e)
        {
            bool viewMine = !_isViewingAllDishes && _apiHandler.IsLoggedIn;

            if (viewMine && !_apiHandler.IsLoggedIn)
            {
                MessageBox.Show("Vui lòng đăng nhập để chọn món ăn ngẫu nhiên từ đóng góp của bạn.", "Yêu cầu đăng nhập");
                return;
            }

            Dish randomDish = await _apiHandler.GetRandomDishAsync(viewMine);

            if (randomDish != null)
            {
                using (var randomForm = new RandomFood(randomDish))
                {
                    randomForm.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy món ăn nào để chọn ngẫu nhiên.", "Thông báo");
            }
        }

        private async void btnAllDishes_Click(object sender, EventArgs e)
        {
            _isViewingAllDishes = true;
            _currentPage = 1;
            await LoadDishes();
        }

        private async void btnMyDishes_Click(object sender, EventArgs e)
        {
            if (!_apiHandler.IsLoggedIn)
            {
                MessageBox.Show("Vui lòng đăng nhập để xem món ăn bạn đóng góp.", "Yêu cầu đăng nhập");
                return;
            }
            _isViewingAllDishes = false;
            _currentPage = 1;
            await LoadDishes();
        }
    }
}