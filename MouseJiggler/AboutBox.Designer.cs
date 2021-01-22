
namespace ArkaneSystems.MouseJiggler
{
    sealed partial class AboutBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutBox));
            this.baseLayout = new System.Windows.Forms.TableLayoutPanel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.lbProductName = new System.Windows.Forms.Label();
            this.lbVersion = new System.Windows.Forms.Label();
            this.lbCopyright = new System.Windows.Forms.Label();
            this.lbCompanyName = new System.Windows.Forms.Label();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.cmdOk = new System.Windows.Forms.Button();
            this.baseLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // baseLayout
            // 
            this.baseLayout.ColumnCount = 2;
            this.baseLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.baseLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67F));
            this.baseLayout.Controls.Add(this.cmdOk, 1, 5);
            this.baseLayout.Controls.Add(this.pbLogo, 0, 0);
            this.baseLayout.Controls.Add(this.lbProductName, 1, 0);
            this.baseLayout.Controls.Add(this.lbVersion, 1, 1);
            this.baseLayout.Controls.Add(this.lbCopyright, 1, 2);
            this.baseLayout.Controls.Add(this.lbCompanyName, 1, 3);
            this.baseLayout.Controls.Add(this.tbDescription, 1, 4);
            this.baseLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.baseLayout.Location = new System.Drawing.Point(9, 9);
            this.baseLayout.Name = "baseLayout";
            this.baseLayout.RowCount = 6;
            this.baseLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.baseLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.baseLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.baseLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.baseLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.baseLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.baseLayout.Size = new System.Drawing.Size(416, 263);
            this.baseLayout.TabIndex = 0;
            // 
            // pbLogo
            // 
            this.pbLogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbLogo.Image")));
            this.pbLogo.Location = new System.Drawing.Point(3, 3);
            this.pbLogo.Name = "pbLogo";
            this.baseLayout.SetRowSpan(this.pbLogo, 6);
            this.pbLogo.Size = new System.Drawing.Size(131, 257);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // lbProductName
            // 
            this.lbProductName.AutoSize = true;
            this.lbProductName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbProductName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbProductName.Location = new System.Drawing.Point(143, 0);
            this.lbProductName.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.lbProductName.Name = "lbProductName";
            this.lbProductName.Size = new System.Drawing.Size(270, 26);
            this.lbProductName.TabIndex = 1;
            this.lbProductName.Text = "Product Name";
            this.lbProductName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbVersion
            // 
            this.lbVersion.AutoSize = true;
            this.lbVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbVersion.Location = new System.Drawing.Point(143, 26);
            this.lbVersion.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.lbVersion.Name = "lbVersion";
            this.lbVersion.Size = new System.Drawing.Size(270, 26);
            this.lbVersion.TabIndex = 2;
            this.lbVersion.Text = "Version";
            this.lbVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbCopyright
            // 
            this.lbCopyright.AutoSize = true;
            this.lbCopyright.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbCopyright.Location = new System.Drawing.Point(143, 52);
            this.lbCopyright.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.lbCopyright.Name = "lbCopyright";
            this.lbCopyright.Size = new System.Drawing.Size(270, 26);
            this.lbCopyright.TabIndex = 3;
            this.lbCopyright.Text = "Copyright";
            this.lbCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbCompanyName
            // 
            this.lbCompanyName.AutoSize = true;
            this.lbCompanyName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbCompanyName.Location = new System.Drawing.Point(143, 78);
            this.lbCompanyName.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.lbCompanyName.Name = "lbCompanyName";
            this.lbCompanyName.Size = new System.Drawing.Size(270, 26);
            this.lbCompanyName.TabIndex = 4;
            this.lbCompanyName.Text = "Company Name";
            this.lbCompanyName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbDescription
            // 
            this.tbDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbDescription.Location = new System.Drawing.Point(143, 107);
            this.tbDescription.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
            this.tbDescription.Multiline = true;
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.ReadOnly = true;
            this.tbDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbDescription.Size = new System.Drawing.Size(270, 125);
            this.tbDescription.TabIndex = 5;
            this.tbDescription.Text = "Description";
            // 
            // cmdOk
            // 
            this.cmdOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOk.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdOk.Location = new System.Drawing.Point(338, 238);
            this.cmdOk.Name = "cmdOk";
            this.cmdOk.Size = new System.Drawing.Size(75, 22);
            this.cmdOk.TabIndex = 0;
            this.cmdOk.Text = "&OK";
            this.cmdOk.UseVisualStyleBackColor = true;
            this.cmdOk.Click += new System.EventHandler(this.cmdOk_Click);
            // 
            // AboutBox
            // 
            this.AcceptButton = this.cmdOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdOk;
            this.ClientSize = new System.Drawing.Size(434, 281);
            this.Controls.Add(this.baseLayout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutBox";
            this.Padding = new System.Windows.Forms.Padding(9);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About...";
            this.baseLayout.ResumeLayout(false);
            this.baseLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel baseLayout;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Label lbProductName;
        private System.Windows.Forms.Label lbVersion;
        private System.Windows.Forms.Label lbCopyright;
        private System.Windows.Forms.Label lbCompanyName;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.Button cmdOk;
    }
}