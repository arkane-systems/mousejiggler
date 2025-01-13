
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
            baseLayout = new System.Windows.Forms.TableLayoutPanel();
            cmdOk = new System.Windows.Forms.Button();
            pbLogo = new System.Windows.Forms.PictureBox();
            lbProductName = new System.Windows.Forms.Label();
            lbVersion = new System.Windows.Forms.Label();
            lbCopyright = new System.Windows.Forms.Label();
            lbCompanyName = new System.Windows.Forms.Label();
            tbDescription = new System.Windows.Forms.TextBox();
            baseLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbLogo).BeginInit();
            SuspendLayout();
            // 
            // baseLayout
            // 
            baseLayout.ColumnCount = 2;
            baseLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            baseLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67F));
            baseLayout.Controls.Add(cmdOk, 1, 5);
            baseLayout.Controls.Add(pbLogo, 0, 0);
            baseLayout.Controls.Add(lbProductName, 1, 0);
            baseLayout.Controls.Add(lbVersion, 1, 1);
            baseLayout.Controls.Add(lbCopyright, 1, 2);
            baseLayout.Controls.Add(lbCompanyName, 1, 3);
            baseLayout.Controls.Add(tbDescription, 1, 4);
            baseLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            baseLayout.Location = new System.Drawing.Point(10, 12);
            baseLayout.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            baseLayout.Name = "baseLayout";
            baseLayout.RowCount = 6;
            baseLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            baseLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            baseLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            baseLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            baseLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            baseLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            baseLayout.Size = new System.Drawing.Size(602, 351);
            baseLayout.TabIndex = 0;
            // 
            // cmdOk
            // 
            cmdOk.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            cmdOk.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            cmdOk.Location = new System.Drawing.Point(513, 319);
            cmdOk.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            cmdOk.Name = "cmdOk";
            cmdOk.Size = new System.Drawing.Size(86, 28);
            cmdOk.TabIndex = 0;
            cmdOk.Text = "&OK";
            cmdOk.UseVisualStyleBackColor = true;
            cmdOk.Click += cmdOk_Click;
            // 
            // pbLogo
            // 
            pbLogo.Dock = System.Windows.Forms.DockStyle.Fill;
            pbLogo.Image = (System.Drawing.Image)resources.GetObject("pbLogo.Image");
            pbLogo.Location = new System.Drawing.Point(3, 4);
            pbLogo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            pbLogo.Name = "pbLogo";
            baseLayout.SetRowSpan(pbLogo, 6);
            pbLogo.Size = new System.Drawing.Size(192, 343);
            pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pbLogo.TabIndex = 0;
            pbLogo.TabStop = false;
            // 
            // lbProductName
            // 
            lbProductName.AutoSize = true;
            lbProductName.Dock = System.Windows.Forms.DockStyle.Fill;
            lbProductName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lbProductName.Location = new System.Drawing.Point(205, 0);
            lbProductName.Margin = new System.Windows.Forms.Padding(7, 0, 3, 0);
            lbProductName.Name = "lbProductName";
            lbProductName.Size = new System.Drawing.Size(394, 35);
            lbProductName.TabIndex = 1;
            lbProductName.Text = "Product Name";
            lbProductName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbVersion
            // 
            lbVersion.AutoSize = true;
            lbVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            lbVersion.Location = new System.Drawing.Point(205, 35);
            lbVersion.Margin = new System.Windows.Forms.Padding(7, 0, 3, 0);
            lbVersion.Name = "lbVersion";
            lbVersion.Size = new System.Drawing.Size(394, 35);
            lbVersion.TabIndex = 2;
            lbVersion.Text = "Version";
            lbVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbCopyright
            // 
            lbCopyright.AutoSize = true;
            lbCopyright.Dock = System.Windows.Forms.DockStyle.Fill;
            lbCopyright.Location = new System.Drawing.Point(205, 70);
            lbCopyright.Margin = new System.Windows.Forms.Padding(7, 0, 3, 0);
            lbCopyright.Name = "lbCopyright";
            lbCopyright.Size = new System.Drawing.Size(394, 35);
            lbCopyright.TabIndex = 3;
            lbCopyright.Text = "Copyright";
            lbCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbCompanyName
            // 
            lbCompanyName.AutoSize = true;
            lbCompanyName.Dock = System.Windows.Forms.DockStyle.Fill;
            lbCompanyName.Location = new System.Drawing.Point(205, 105);
            lbCompanyName.Margin = new System.Windows.Forms.Padding(7, 0, 3, 0);
            lbCompanyName.Name = "lbCompanyName";
            lbCompanyName.Size = new System.Drawing.Size(394, 35);
            lbCompanyName.TabIndex = 4;
            lbCompanyName.Text = "Company Name";
            lbCompanyName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbDescription
            // 
            tbDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            tbDescription.Location = new System.Drawing.Point(205, 144);
            tbDescription.Margin = new System.Windows.Forms.Padding(7, 4, 3, 4);
            tbDescription.Multiline = true;
            tbDescription.Name = "tbDescription";
            tbDescription.ReadOnly = true;
            tbDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            tbDescription.Size = new System.Drawing.Size(394, 167);
            tbDescription.TabIndex = 5;
            tbDescription.Text = "Description";
            // 
            // AboutBox
            // 
            AcceptButton = cmdOk;
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            CancelButton = cmdOk;
            ClientSize = new System.Drawing.Size(622, 375);
            Controls.Add(baseLayout);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AboutBox";
            Padding = new System.Windows.Forms.Padding(10, 12, 10, 12);
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "About...";
            baseLayout.ResumeLayout(false);
            baseLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbLogo).EndInit();
            ResumeLayout(false);
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