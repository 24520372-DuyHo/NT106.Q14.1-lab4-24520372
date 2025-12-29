namespace baitap3_lab4
{
    partial class Form1
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
            this.btnReload = new System.Windows.Forms.Button();
            this.btnDownFiles = new System.Windows.Forms.Button();
            this.btnDownResources = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.webView2 = new Microsoft.Web.WebView2.WinForms.WebView2();
            ((System.ComponentModel.ISupportInitialize)(this.webView2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnReload
            // 
            this.btnReload.Location = new System.Drawing.Point(893, 12);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(132, 38);
            this.btnReload.TabIndex = 0;
            this.btnReload.Text = "reload";
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // btnDownFiles
            // 
            this.btnDownFiles.Location = new System.Drawing.Point(672, 56);
            this.btnDownFiles.Name = "btnDownFiles";
            this.btnDownFiles.Size = new System.Drawing.Size(136, 42);
            this.btnDownFiles.TabIndex = 1;
            this.btnDownFiles.Text = "Down Files";
            this.btnDownFiles.UseVisualStyleBackColor = true;
            this.btnDownFiles.Click += new System.EventHandler(this.btnDownFiles_Click);
            // 
            // btnDownResources
            // 
            this.btnDownResources.Location = new System.Drawing.Point(828, 56);
            this.btnDownResources.Name = "btnDownResources";
            this.btnDownResources.Size = new System.Drawing.Size(197, 42);
            this.btnDownResources.TabIndex = 2;
            this.btnDownResources.Text = "Down Resources";
            this.btnDownResources.UseVisualStyleBackColor = true;
            this.btnDownResources.Click += new System.EventHandler(this.btnDownResources_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(12, 12);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(92, 38);
            this.btnLoad.TabIndex = 3;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(122, 12);
            this.txtURL.Multiline = true;
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(750, 38);
            this.txtURL.TabIndex = 4;
            this.txtURL.Text = "https://uit.edu.vn/";
            this.txtURL.TextChanged += new System.EventHandler(this.txtURL_TextChanged);
            // 
            // webView2
            // 
            this.webView2.AllowExternalDrop = true;
            this.webView2.CreationProperties = null;
            this.webView2.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webView2.Location = new System.Drawing.Point(12, 104);
            this.webView2.Name = "webView2";
            this.webView2.Size = new System.Drawing.Size(1013, 413);
            this.webView2.TabIndex = 5;
            this.webView2.ZoomFactor = 1D;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1037, 529);
            this.Controls.Add(this.webView2);
            this.Controls.Add(this.txtURL);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnDownResources);
            this.Controls.Add(this.btnDownFiles);
            this.Controls.Add(this.btnReload);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.webView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.Button btnDownFiles;
        private System.Windows.Forms.Button btnDownResources;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.TextBox txtURL;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView2;
    }
}

