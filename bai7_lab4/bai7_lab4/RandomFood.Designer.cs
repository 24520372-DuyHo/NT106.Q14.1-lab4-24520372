using System.Drawing;
using System.Windows.Forms;

namespace bai7_lab4
{
    partial class RandomFood
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
            this.lblPopupTitle = new System.Windows.Forms.Label();
            this.lblDishName = new System.Windows.Forms.Label();
            this.picFoodImage = new System.Windows.Forms.PictureBox();
            this.lblPriceLabel = new System.Windows.Forms.Label();
            this.lblAddressLabel = new System.Windows.Forms.Label();
            this.lblPriceValue = new System.Windows.Forms.Label();
            this.lblAddressValue = new System.Windows.Forms.Label();
            this.lblDescriptionLabel = new System.Windows.Forms.Label();
            this.lblDescriptionValue = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picFoodImage)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPopupTitle
            // 
            this.lblPopupTitle.AutoSize = true;
            this.lblPopupTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPopupTitle.Location = new System.Drawing.Point(120, 15);
            this.lblPopupTitle.Name = "lblPopupTitle";
            this.lblPopupTitle.Size = new System.Drawing.Size(126, 28);
            this.lblPopupTitle.TabIndex = 0;
            this.lblPopupTitle.Text = "Bạn nên ăn gì?";
            // 
            // lblDishName
            // 
            this.lblDishName.AutoSize = true;
            this.lblDishName.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDishName.Location = new System.Drawing.Point(118, 45);
            this.lblDishName.Name = "lblDishName";
            this.lblDishName.Size = new System.Drawing.Size(72, 37);
            this.lblDishName.TabIndex = 1;
            this.lblDishName.Text = "Phở"; // Tên món ăn
            // 
            // picFoodImage
            // 
            this.picFoodImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picFoodImage.Location = new System.Drawing.Point(15, 20);
            this.picFoodImage.Name = "picFoodImage";
            this.picFoodImage.Size = new System.Drawing.Size(90, 90);
            this.picFoodImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picFoodImage.TabIndex = 2;
            this.picFoodImage.TabStop = false;
            // 
            // lblPriceLabel
            // 
            this.lblPriceLabel.AutoSize = true;
            this.lblPriceLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPriceLabel.Location = new System.Drawing.Point(120, 90);
            this.lblPriceLabel.Name = "lblPriceLabel";
            this.lblPriceLabel.Size = new System.Drawing.Size(35, 20);
            this.lblPriceLabel.TabIndex = 3;
            this.lblPriceLabel.Text = "Giá:";
            // 
            // lblAddressLabel
            // 
            this.lblAddressLabel.AutoSize = true;
            this.lblAddressLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddressLabel.Location = new System.Drawing.Point(120, 120);
            this.lblAddressLabel.Name = "lblAddressLabel";
            this.lblAddressLabel.Size = new System.Drawing.Size(60, 20);
            this.lblAddressLabel.TabIndex = 4;
            this.lblAddressLabel.Text = "Địa chỉ:";
            // 
            // lblPriceValue
            // 
            this.lblPriceValue.AutoSize = true;
            this.lblPriceValue.Location = new System.Drawing.Point(175, 90);
            this.lblPriceValue.Name = "lblPriceValue";
            this.lblPriceValue.Size = new System.Drawing.Size(52, 17);
            this.lblPriceValue.TabIndex = 5;
            this.lblPriceValue.Text = "40000";
            // 
            // lblAddressValue
            // 
            this.lblAddressValue.AutoSize = true;
            this.lblAddressValue.Location = new System.Drawing.Point(175, 120);
            this.lblAddressValue.Name = "lblAddressValue";
            this.lblAddressValue.Size = new System.Drawing.Size(91, 17);
            this.lblAddressValue.TabIndex = 6;
            this.lblAddressValue.Text = "345-ABC-DEF";
            // 
            // lblDescriptionLabel
            // 
            this.lblDescriptionLabel.AutoSize = true;
            this.lblDescriptionLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescriptionLabel.Location = new System.Drawing.Point(15, 150);
            this.lblDescriptionLabel.Name = "lblDescriptionLabel";
            this.lblDescriptionLabel.Size = new System.Drawing.Size(51, 20);
            this.lblDescriptionLabel.TabIndex = 7;
            this.lblDescriptionLabel.Text = "Mô tả:";
            // 
            // lblDescriptionValue
            // 
            this.lblDescriptionValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDescriptionValue.Location = new System.Drawing.Point(15, 175);
            this.lblDescriptionValue.Name = "lblDescriptionValue";
            this.lblDescriptionValue.Padding = new System.Windows.Forms.Padding(5);
            this.lblDescriptionValue.Size = new System.Drawing.Size(350, 70);
            this.lblDescriptionValue.TabIndex = 8;
            this.lblDescriptionValue.Text = "Chi tiết mô tả món ăn ngẫu nhiên sẽ được hiển thị tại đây.";
            // 
            // RandomFoodPopupForm
            // 
            this.ClientSize = new System.Drawing.Size(380, 260);
            this.Controls.Add(this.lblDescriptionValue);
            this.Controls.Add(this.lblDescriptionLabel);
            this.Controls.Add(this.lblAddressValue);
            this.Controls.Add(this.lblPriceValue);
            this.Controls.Add(this.lblAddressLabel);
            this.Controls.Add(this.lblPriceLabel);
            this.Controls.Add(this.picFoodImage);
            this.Controls.Add(this.lblDishName);
            this.Controls.Add(this.lblPopupTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RandomFoodPopupForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Món Ăn Ngẫu Nhiên";
            ((System.ComponentModel.ISupportInitialize)(this.picFoodImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPopupTitle;
        private System.Windows.Forms.Label lblDishName;
        private System.Windows.Forms.PictureBox picFoodImage;
        private System.Windows.Forms.Label lblPriceLabel;
        private System.Windows.Forms.Label lblAddressLabel;
        private System.Windows.Forms.Label lblPriceValue;
        private System.Windows.Forms.Label lblAddressValue;
        private System.Windows.Forms.Label lblDescriptionLabel;
        private System.Windows.Forms.Label lblDescriptionValue;
    }
}