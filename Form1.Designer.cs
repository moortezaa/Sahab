namespace Sahab_Desktop
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.برنامهToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.اضافهکردنبرنامهToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.نمایشToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.روزToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StartDateLable = new System.Windows.Forms.Label();
            this.StartDateTextBox = new System.Windows.Forms.TextBox();
            this.panel = new System.Windows.Forms.Panel();
            this.Show = new System.Windows.Forms.Button();
            this.dailyTaskViewVScrollBar = new System.Windows.Forms.VScrollBar();
            this.dailyTaskViewer = new Sahab_Desktop.Controls.DailyTaskViewer();
            this.menuStrip1.SuspendLayout();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.برنامهToolStripMenuItem,
            this.نمایشToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // برنامهToolStripMenuItem
            // 
            this.برنامهToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.اضافهکردنبرنامهToolStripMenuItem});
            this.برنامهToolStripMenuItem.Name = "برنامهToolStripMenuItem";
            this.برنامهToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.برنامهToolStripMenuItem.Text = "برنامه";
            // 
            // اضافهکردنبرنامهToolStripMenuItem
            // 
            this.اضافهکردنبرنامهToolStripMenuItem.Name = "اضافهکردنبرنامهToolStripMenuItem";
            this.اضافهکردنبرنامهToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.اضافهکردنبرنامهToolStripMenuItem.Text = "اضافه کردن برنامه";
            this.اضافهکردنبرنامهToolStripMenuItem.Click += new System.EventHandler(this.اضافهکردنبرنامهToolStripMenuItem_Click);
            // 
            // نمایشToolStripMenuItem
            // 
            this.نمایشToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.روزToolStripMenuItem});
            this.نمایشToolStripMenuItem.Name = "نمایشToolStripMenuItem";
            this.نمایشToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.نمایشToolStripMenuItem.Text = "نمایش";
            // 
            // روزToolStripMenuItem
            // 
            this.روزToolStripMenuItem.Name = "روزToolStripMenuItem";
            this.روزToolStripMenuItem.Size = new System.Drawing.Size(89, 22);
            this.روزToolStripMenuItem.Text = "روز";
            // 
            // StartDateLable
            // 
            this.StartDateLable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.StartDateLable.AutoSize = true;
            this.StartDateLable.Location = new System.Drawing.Point(753, 38);
            this.StartDateLable.Name = "StartDateLable";
            this.StartDateLable.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartDateLable.Size = new System.Drawing.Size(35, 13);
            this.StartDateLable.TabIndex = 1;
            this.StartDateLable.Text = "تاریخ:";
            // 
            // StartDateTextBox
            // 
            this.StartDateTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.StartDateTextBox.Location = new System.Drawing.Point(647, 35);
            this.StartDateTextBox.Name = "StartDateTextBox";
            this.StartDateTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartDateTextBox.Size = new System.Drawing.Size(100, 20);
            this.StartDateTextBox.TabIndex = 1;
            // 
            // panel
            // 
            this.panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel.BackColor = System.Drawing.Color.White;
            this.panel.Controls.Add(this.dailyTaskViewer);
            this.panel.Location = new System.Drawing.Point(12, 61);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(753, 377);
            this.panel.TabIndex = 3;
            // 
            // Show
            // 
            this.Show.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Show.Location = new System.Drawing.Point(566, 33);
            this.Show.Name = "Show";
            this.Show.Size = new System.Drawing.Size(75, 23);
            this.Show.TabIndex = 2;
            this.Show.Text = "مشاهده";
            this.Show.UseVisualStyleBackColor = true;
            this.Show.Click += new System.EventHandler(this.Show_Click);
            // 
            // dailyTaskViewVScrollBar
            // 
            this.dailyTaskViewVScrollBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dailyTaskViewVScrollBar.Location = new System.Drawing.Point(768, 61);
            this.dailyTaskViewVScrollBar.Name = "dailyTaskViewVScrollBar";
            this.dailyTaskViewVScrollBar.Size = new System.Drawing.Size(23, 377);
            this.dailyTaskViewVScrollBar.TabIndex = 5;
            this.dailyTaskViewVScrollBar.ValueChanged += new System.EventHandler(this.DailyTaskViewVScrollBar_ValueChanged);
            // 
            // dailyTaskViewer
            // 
            this.dailyTaskViewer.Location = new System.Drawing.Point(0, 0);
            this.dailyTaskViewer.Name = "dailyTaskViewer";
            this.dailyTaskViewer.Size = new System.Drawing.Size(753, 1436);
            this.dailyTaskViewer.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dailyTaskViewVScrollBar);
            this.Controls.Add(this.Show);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.StartDateTextBox);
            this.Controls.Add(this.StartDateLable);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "سحاب";
            this.ResizeEnd += new System.EventHandler(this.MainForm_ResizeEnd);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem برنامهToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem اضافهکردنبرنامهToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem نمایشToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem روزToolStripMenuItem;
        private System.Windows.Forms.Label StartDateLable;
        private System.Windows.Forms.TextBox StartDateTextBox;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Button Show;
        private System.Windows.Forms.VScrollBar dailyTaskViewVScrollBar;
        private Controls.DailyTaskViewer dailyTaskViewer;
    }
}

