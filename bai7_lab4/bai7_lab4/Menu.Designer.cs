namespace bai7_lab4
{
    partial class Menu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnRandomDish = new System.Windows.Forms.Button();
            this.btnAddNewDish = new System.Windows.Forms.Button();
            this.btnAllDishes = new System.Windows.Forms.Button();
            this.btnMyDishes = new System.Windows.Forms.Button();
            this.flowLayoutPanelDishes = new System.Windows.Forms.FlowLayoutPanel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnSignup = new System.Windows.Forms.Button();
            this.lblPageInfo = new System.Windows.Forms.Label();
            this.btnNextPage = new System.Windows.Forms.Button();
            this.btnPrevPage = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(267, 41);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "HÔM NAY ĂN GÌ?";
            // 
            // btnRandomDish
            // 
            this.btnRandomDish.BackColor = System.Drawing.Color.Gold;
            this.btnRandomDish.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRandomDish.Location = new System.Drawing.Point(350, 48);
            this.btnRandomDish.Name = "btnRandomDish";
            this.btnRandomDish.Size = new System.Drawing.Size(110, 35);
            this.btnRandomDish.TabIndex = 1;
            this.btnRandomDish.Text = "Ăn gì giờ?";
            this.btnRandomDish.UseVisualStyleBackColor = false;
            // 
            // btnAddNewDish
            // 
            this.btnAddNewDish.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNewDish.Location = new System.Drawing.Point(466, 48);
            this.btnAddNewDish.Name = "btnAddNewDish";
            this.btnAddNewDish.Size = new System.Drawing.Size(110, 35);
            this.btnAddNewDish.TabIndex = 2;
            this.btnAddNewDish.Text = "Thêm món ăn";
            this.btnAddNewDish.UseVisualStyleBackColor = true;
            // 
            // btnAllDishes
            // 
            this.btnAllDishes.Location = new System.Drawing.Point(18, 55);
            this.btnAllDishes.Name = "btnAllDishes";
            this.btnAllDishes.Size = new System.Drawing.Size(75, 30);
            this.btnAllDishes.TabIndex = 3;
            this.btnAllDishes.Text = "All";
            this.btnAllDishes.UseVisualStyleBackColor = true;
            // 
            // btnMyDishes
            // 
            this.btnMyDishes.Location = new System.Drawing.Point(99, 55);
            this.btnMyDishes.Name = "btnMyDishes";
            this.btnMyDishes.Size = new System.Drawing.Size(100, 30);
            this.btnMyDishes.TabIndex = 4;
            this.btnMyDishes.Text = "Tôi đóng góp";
            this.btnMyDishes.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanelDishes
            // 
            this.flowLayoutPanelDishes.AutoScroll = true;
            this.flowLayoutPanelDishes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanelDishes.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelDishes.Location = new System.Drawing.Point(18, 90);
            this.flowLayoutPanelDishes.Name = "flowLayoutPanelDishes";
            this.flowLayoutPanelDishes.Size = new System.Drawing.Size(558, 400);
            this.flowLayoutPanelDishes.TabIndex = 5;
            this.flowLayoutPanelDishes.WrapContents = false;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(15, 510);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(127, 16);
            this.lblStatus.TabIndex = 6;
            this.lblStatus.Text = "Unauthenticated";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(150, 505);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(80, 23);
            this.btnLogin.TabIndex = 7;
            this.btnLogin.Text = "Đăng nhập";
            this.btnLogin.UseVisualStyleBackColor = true;
            // 
            // btnSignup
            // 
            this.btnSignup.Location = new System.Drawing.Point(236, 505);
            this.btnSignup.Name = "btnSignup";
            this.btnSignup.Size = new System.Drawing.Size(80, 23);
            this.btnSignup.TabIndex = 8;
            this.btnSignup.Text = "Đăng ký";
            this.btnSignup.UseVisualStyleBackColor = true;
            // 
            // lblPageInfo
            // 
            this.lblPageInfo.AutoSize = true;
            this.lblPageInfo.Location = new System.Drawing.Point(470, 510);
            this.lblPageInfo.Name = "lblPageInfo";
            this.lblPageInfo.Size = new System.Drawing.Size(73, 16);
            this.lblPageInfo.TabIndex = 9;
            this.lblPageInfo.Text = "Page 1";
            // 
            // btnNextPage
            // 
            this.btnNextPage.Location = new System.Drawing.Point(550, 505);
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Size = new System.Drawing.Size(26, 23);
            this.btnNextPage.TabIndex = 10;
            this.btnNextPage.Text = ">";
            this.btnNextPage.UseVisualStyleBackColor = true;
            // 
            // btnPrevPage
            // 
            this.btnPrevPage.Location = new System.Drawing.Point(440, 505);
            this.btnPrevPage.Name = "btnPrevPage";
            this.btnPrevPage.Size = new System.Drawing.Size(26, 23);
            this.btnPrevPage.TabIndex = 11;
            this.btnPrevPage.Text = "<";
            this.btnPrevPage.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(603, 540);
            this.Controls.Add(this.btnPrevPage);
            this.Controls.Add(this.btnNextPage);
            this.Controls.Add(this.lblPageInfo);
            this.Controls.Add(this.btnSignup);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.flowLayoutPanelDishes);
            this.Controls.Add(this.btnMyDishes);
            this.Controls.Add(this.btnAllDishes);
            this.Controls.Add(this.btnAddNewDish);
            this.Controls.Add(this.btnRandomDish);
            this.Controls.Add(this.lblTitle);
            this.Name = "MainForm";
            this.Text = "HÔM NAY ĂN GÌ?";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnRandomDish;
        private System.Windows.Forms.Button btnAddNewDish;
        private System.Windows.Forms.Button btnAllDishes;
        private System.Windows.Forms.Button btnMyDishes;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelDishes;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnSignup;
        private System.Windows.Forms.Label lblPageInfo;
        private System.Windows.Forms.Button btnNextPage;
        private System.Windows.Forms.Button btnPrevPage;
    }
}