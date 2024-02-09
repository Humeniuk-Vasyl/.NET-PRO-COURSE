namespace Ex3
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            FileToolStrip = new ToolStrip();
            toolStripDropDownButton1 = new ToolStripDropDownButton();
            OpenMenuItem = new ToolStripMenuItem();
            CloseMenuItem = new ToolStripMenuItem();
            myOpen = new OpenFileDialog();
            showBox = new TextBox();
            FileToolStrip.SuspendLayout();
            SuspendLayout();
            // 
            // FileToolStrip
            // 
            FileToolStrip.Items.AddRange(new ToolStripItem[] { toolStripDropDownButton1 });
            FileToolStrip.Location = new Point(0, 0);
            FileToolStrip.Name = "FileToolStrip";
            FileToolStrip.Size = new Size(1038, 28);
            FileToolStrip.TabIndex = 1;
            FileToolStrip.Text = "FileToolStrip";
            // 
            // toolStripDropDownButton1
            // 
            toolStripDropDownButton1.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripDropDownButton1.DropDownItems.AddRange(new ToolStripItem[] { OpenMenuItem, CloseMenuItem });
            toolStripDropDownButton1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            toolStripDropDownButton1.Image = (Image)resources.GetObject("toolStripDropDownButton1.Image");
            toolStripDropDownButton1.ImageTransparentColor = Color.Magenta;
            toolStripDropDownButton1.Margin = new Padding(5, 1, 5, 2);
            toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            toolStripDropDownButton1.Padding = new Padding(10, 0, 0, 0);
            toolStripDropDownButton1.Size = new Size(57, 25);
            toolStripDropDownButton1.Text = "File";
            // 
            // OpenMenuItem
            // 
            OpenMenuItem.Name = "OpenMenuItem";
            OpenMenuItem.Size = new Size(180, 26);
            OpenMenuItem.Text = "Open";
            OpenMenuItem.Click += OpenMenuItem_Click;
            // 
            // CloseMenuItem
            // 
            CloseMenuItem.Name = "CloseMenuItem";
            CloseMenuItem.Size = new Size(180, 26);
            CloseMenuItem.Text = "Close";
            CloseMenuItem.Click += CloseMenuItem_Click;
            // 
            // myOpen
            // 
            myOpen.FileName = "myOpen";
            // 
            // showBox
            // 
            showBox.Location = new Point(12, 28);
            showBox.Multiline = true;
            showBox.Name = "showBox";
            showBox.ScrollBars = ScrollBars.Vertical;
            showBox.Size = new Size(1021, 563);
            showBox.TabIndex = 2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1038, 596);
            Controls.Add(showBox);
            Controls.Add(FileToolStrip);
            Name = "Form1";
            Text = "Reflector";
            FileToolStrip.ResumeLayout(false);
            FileToolStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip FileToolStrip;
        private ToolStripDropDownButton toolStripDropDownButton1;
        private ToolStripMenuItem OpenMenuItem;
        private ToolStripMenuItem CloseMenuItem;
        private OpenFileDialog myOpen;
        private TextBox showBox;
    }
}