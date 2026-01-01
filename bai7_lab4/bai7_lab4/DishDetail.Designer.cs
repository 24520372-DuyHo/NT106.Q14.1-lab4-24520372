namespace bai7_lab4
{
    partial class DishDetail
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
            this.picDishImage = new System.Windows.Forms.PictureBox();
            this.lblPriceLabel = new System.Windows.Forms.Label();
            this.lblAddressLabel = new System.Windows.Forms.Label();
            this.lblContributorLabel = new System.Windows.Forms.Label();
            this.lblPriceValue = new System.Windows.Forms.Label();
            this.lblAddressValue = new System.Windows.Forms.Label();
            this.lblContributorValue = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescriptionLabel = new System.Windows.Forms.Label();
            this.lblDishName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picDishImage)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(120, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(188, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Chi tiết món ăn";
            // 
            // picDishImage
            // 
            this.picDishImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picDishImage.Location = new System.Drawing.Point(20, 60);
            this.picDishImage.Name = "picDishImage";
            this.picDishImage.Size = new System.Drawing.Size(120, 120);
            this.picDishImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picDishImage.TabIndex = 1;
            this.picDishImage.TabStop = false;
            // 
            // lblPriceLabel
            // 
            this.lblPriceLabel.AutoSize = true;
            this.lblPriceLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPriceLabel.Location = new System.Drawing.Point(155, 100);
            this.lblPriceLabel.Name = "lblPriceLabel";
            this.lblPriceLabel.Size = new System.Drawing.Size(27, 15);
            this.lblPriceLabel.TabIndex = 2;
            this.lblPriceLabel.Text = "Giá:";
            // 
            // lblAddressLabel
            // 
            this.lblAddressLabel.AutoSize = true;
            this.lblAddressLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddressLabel.Location = new System.Drawing.Point(155, 130);
            this.lblAddressLabel.Name = "lblAddressLabel";
            this.lblAddressLabel.Size = new System.Drawing.Size(48, 15);
            this.lblAddressLabel.TabIndex = 3;
            this.lblAddressLabel.Text = "Địa chỉ:";
            // 
            // lblContributorLabel
            // 
            this.lblContributorLabel.AutoSize = true;
            this.lblContributorLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContributorLabel.Location = new System.Drawing.Point(155, 160);
            this.lblContributorLabel.Name = "lblContributorLabel";
            this.lblContributorLabel.Size = new System.Drawing.Size(71, 15);
            this.lblContributorLabel.TabIndex = 4;
            this.lblContributorLabel.Text = "Đóng góp:";
            // 
            // lblPriceValue
            // 
            this.lblPriceValue.AutoSize = true;
            this.lblPriceValue.Location = new System.Drawing.Point(235, 100);
            this.lblPriceValue.Name = "lblPriceValue";
            this.lblPriceValue.Size = new System.Drawing.Size(46, 13);
            this.lblPriceValue.TabIndex = 5;
            this.lblPriceValue.Text = "40000";
            // 
            // lblAddressValue
            // 
            this.lblAddressValue.AutoSize = true;
            this.lblAddressValue.Location = new System.Drawing.Point(235, 130);
            this.lblAddressValue.Name = "lblAddressValue";
            this.lblAddressValue.Size = new System.Drawing.Size(84, 13);
            this.lblAddressValue.TabIndex = 6;
            this.lblAddressValue.Text = "345-ABC-DEF";
            // 
            // lblContributorValue
            // 
            this.lblContributorValue.AutoSize = true;
            this.lblContributorValue.Location = new System.Drawing.Point(235, 160);
            this.lblContributorValue.Name = "lblContributorValue";
            this.lblContributorValue.Size = new System.Drawing.Size(44, 13);
            this.lblContributorValue.TabIndex = 7;
            this.lblContributorValue.Text = "phatpt";
            // 
            // txtDescription
            // 
            this.txtDescription.BackColor = System.Drawing.SystemColors.Control;
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.Location = new System.Drawing.Point(20, 215);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size(350, 100);
            this.txtDescription.TabIndex = 8;
            this.txtDescription.Text = "Mô tả chi tiết...";
            // 
            // lblDescriptionLabel
            // 
            this.lblDescriptionLabel.AutoSize = true;
            this.lblDescriptionLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescriptionLabel.Location = new System.Drawing.Point(17, 197);
            this.lblDescriptionLabel.Name = "lblDescriptionLabel";
            this.lblDescriptionLabel.Size = new System.Drawing.Size(42, 15);
            this.lblDescriptionLabel.TabIndex = 9;
            this.lblDescriptionLabel.Text = "Mô tả:";
            // 
            // lblDishName
            // 
            this.lblDishName.AutoSize = true;
            this.lblDishName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDishName.Location = new System.Drawing.Point(154, 60);
            this.lblDishName.Name = "lblDishName";
            this.lblDishName.Size = new System.Drawing.Size(117, 21);
            this.lblDishName.TabIndex = 10;
            this.lblDishName.Text = "BÚN BÒ HUẾ";
            // 
            // DishDetailForm
            // 
            this.ClientSize = new System.Drawing.Size(390, 340);
            this.Controls.Add(this.lblDishName);
            this.Controls.Add(this.lblDescriptionLabel);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblContributorValue);
            this.Controls.Add(this.lblAddressValue);
            this.Controls.Add(this.lblPriceValue);
            this.Controls.Add(this.lblContributorLabel);
            this.Controls.Add(this.lblAddressLabel);
            this.Controls.Add(this.lblPriceLabel);
            this.Controls.Add(this.picDishImage);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DishDetailForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chi tiết món ăn";
            ((System.ComponentModel.ISupportInitialize)(this.picDishImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox picDishImage;
        private System.Windows.Forms.Label lblPriceLabel;
        private System.Windows.Forms.Label lblAddressLabel;
        private System.Windows.Forms.Label lblContributorLabel;
        private System.Windows.Forms.Label lblPriceValue;
        private System.Windows.Forms.Label lblAddressValue;
        private System.Windows.Forms.Label lblContributorValue;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescriptionLabel;
        private System.Windows.Forms.Label lblDishName;
    }
}