namespace Ex4
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.MainText = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.SaveBtn = new System.Windows.Forms.ToolStripButton();
            this.SettingsBtn = new System.Windows.Forms.ToolStripDropDownButton();
            this.BgBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.redBgBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.blueBgBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.whiteBgBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.textColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blackTextColorBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.greenTextColorBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.fontSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FontSizeTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.fontStyleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.regularFont = new System.Windows.Forms.ToolStripMenuItem();
            this.baldFont = new System.Windows.Forms.ToolStripMenuItem();
            this.italicFont = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainText
            // 
            this.MainText.Font = new System.Drawing.Font("Berlin Sans FB", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainText.ForeColor = System.Drawing.Color.Black;
            this.MainText.Location = new System.Drawing.Point(14, 37);
            this.MainText.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MainText.Multiline = true;
            this.MainText.Name = "MainText";
            this.MainText.Size = new System.Drawing.Size(571, 372);
            this.MainText.TabIndex = 0;
            this.MainText.Text = "This is my starting text";
            this.MainText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SaveBtn,
            this.SettingsBtn});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(604, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // SaveBtn
            // 
            this.SaveBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.SaveBtn.Image = ((System.Drawing.Image)(resources.GetObject("SaveBtn.Image")));
            this.SaveBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(35, 22);
            this.SaveBtn.Text = "Save";
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // SettingsBtn
            // 
            this.SettingsBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.SettingsBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BgBtn,
            this.textColorToolStripMenuItem,
            this.fontSizeToolStripMenuItem,
            this.fontStyleToolStripMenuItem});
            this.SettingsBtn.Image = ((System.Drawing.Image)(resources.GetObject("SettingsBtn.Image")));
            this.SettingsBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SettingsBtn.Name = "SettingsBtn";
            this.SettingsBtn.Size = new System.Drawing.Size(62, 22);
            this.SettingsBtn.Text = "Settings";
            this.SettingsBtn.ToolTipText = "Settings";
            // 
            // BgBtn
            // 
            this.BgBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.redBgBtn,
            this.blueBgBtn,
            this.whiteBgBtn});
            this.BgBtn.Name = "BgBtn";
            this.BgBtn.Size = new System.Drawing.Size(180, 22);
            this.BgBtn.Text = "Bg color";
            // 
            // redBgBtn
            // 
            this.redBgBtn.Name = "redBgBtn";
            this.redBgBtn.Size = new System.Drawing.Size(105, 22);
            this.redBgBtn.Text = "Red";
            this.redBgBtn.Click += new System.EventHandler(this.redBgBtn_Click);
            // 
            // blueBgBtn
            // 
            this.blueBgBtn.Name = "blueBgBtn";
            this.blueBgBtn.Size = new System.Drawing.Size(105, 22);
            this.blueBgBtn.Text = "Blue";
            this.blueBgBtn.Click += new System.EventHandler(this.blueBgBtn_Click);
            // 
            // whiteBgBtn
            // 
            this.whiteBgBtn.Name = "whiteBgBtn";
            this.whiteBgBtn.Size = new System.Drawing.Size(105, 22);
            this.whiteBgBtn.Text = "White";
            this.whiteBgBtn.Click += new System.EventHandler(this.whiteBgBtn_Click);
            // 
            // textColorToolStripMenuItem
            // 
            this.textColorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.blackTextColorBtn,
            this.greenTextColorBtn});
            this.textColorToolStripMenuItem.Name = "textColorToolStripMenuItem";
            this.textColorToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.textColorToolStripMenuItem.Text = "Text color";
            // 
            // blackTextColorBtn
            // 
            this.blackTextColorBtn.Name = "blackTextColorBtn";
            this.blackTextColorBtn.Size = new System.Drawing.Size(105, 22);
            this.blackTextColorBtn.Text = "Black";
            this.blackTextColorBtn.Click += new System.EventHandler(this.blackTextColorBtn_Click);
            // 
            // greenTextColorBtn
            // 
            this.greenTextColorBtn.Name = "greenTextColorBtn";
            this.greenTextColorBtn.Size = new System.Drawing.Size(105, 22);
            this.greenTextColorBtn.Text = "Green";
            this.greenTextColorBtn.Click += new System.EventHandler(this.greenTextColorBtn_Click);
            // 
            // fontSizeToolStripMenuItem
            // 
            this.fontSizeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FontSizeTextBox});
            this.fontSizeToolStripMenuItem.Name = "fontSizeToolStripMenuItem";
            this.fontSizeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.fontSizeToolStripMenuItem.Text = "Font size";
            // 
            // FontSizeTextBox
            // 
            this.FontSizeTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FontSizeTextBox.Name = "FontSizeTextBox";
            this.FontSizeTextBox.Size = new System.Drawing.Size(100, 23);
            this.FontSizeTextBox.Text = "10";
            this.FontSizeTextBox.TextChanged += new System.EventHandler(this.FontSizeTextBox_TextChanged);
            // 
            // fontStyleToolStripMenuItem
            // 
            this.fontStyleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.regularFont,
            this.baldFont,
            this.italicFont});
            this.fontStyleToolStripMenuItem.Name = "fontStyleToolStripMenuItem";
            this.fontStyleToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.fontStyleToolStripMenuItem.Text = "Font style";
            // 
            // regularFont
            // 
            this.regularFont.Name = "regularFont";
            this.regularFont.Size = new System.Drawing.Size(180, 22);
            this.regularFont.Text = "Regular";
            this.regularFont.Click += new System.EventHandler(this.regularFont_Click);
            // 
            // baldFont
            // 
            this.baldFont.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.baldFont.Name = "baldFont";
            this.baldFont.Size = new System.Drawing.Size(180, 22);
            this.baldFont.Text = "Bold";
            this.baldFont.Click += new System.EventHandler(this.boldFont_Click);
            // 
            // italicFont
            // 
            this.italicFont.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.italicFont.Name = "italicFont";
            this.italicFont.Size = new System.Drawing.Size(180, 22);
            this.italicFont.Text = "Italic";
            this.italicFont.Click += new System.EventHandler(this.italicFont_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 449);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.MainText);
            this.Font = new System.Drawing.Font("SuperFrench", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Form1";
            this.Text = "Ex4";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox MainText;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton SaveBtn;
        private System.Windows.Forms.ToolStripDropDownButton SettingsBtn;
        private System.Windows.Forms.ToolStripMenuItem BgBtn;
        private System.Windows.Forms.ToolStripMenuItem redBgBtn;
        private System.Windows.Forms.ToolStripMenuItem blueBgBtn;
        private System.Windows.Forms.ToolStripMenuItem whiteBgBtn;
        private System.Windows.Forms.ToolStripMenuItem textColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blackTextColorBtn;
        private System.Windows.Forms.ToolStripMenuItem greenTextColorBtn;
        private System.Windows.Forms.ToolStripMenuItem fontSizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox FontSizeTextBox;
        private System.Windows.Forms.ToolStripMenuItem fontStyleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem regularFont;
        private System.Windows.Forms.ToolStripMenuItem baldFont;
        private System.Windows.Forms.ToolStripMenuItem italicFont;
    }
}

