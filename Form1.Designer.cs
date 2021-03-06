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
            Sahab_Desktop.Controls.Week week1 = new Sahab_Desktop.Controls.Week();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.برنامهToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.اضافهکردنبرنامهToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.اصولوچهارچوبهاToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.نمایشToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.روزToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.هفتهToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.پوستهToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.اولویتبندیشدهToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.خدماتToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.همگامسازیاینترنتیToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.اتصالبهحسابToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.بازیابیاینترنتیToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel = new System.Windows.Forms.Panel();
            this.dailyTaskViewVScrollBar = new System.Windows.Forms.VScrollBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.taskViewsHeaderPanel = new System.Windows.Forms.Panel();
            this.weeklyTaskViewer = new Sahab_Desktop.Controls.WeeklyTaskViewer();
            this.dailyTaskViewer = new Sahab_Desktop.Controls.DailyTaskViewer();
            this.calendarView = new Sahab_Desktop.Controls.CalendarView();
            this.menuStrip1.SuspendLayout();
            this.panel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.برنامهToolStripMenuItem,
            this.نمایشToolStripMenuItem,
            this.خدماتToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1127, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // برنامهToolStripMenuItem
            // 
            this.برنامهToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.اضافهکردنبرنامهToolStripMenuItem,
            this.اصولوچهارچوبهاToolStripMenuItem});
            this.برنامهToolStripMenuItem.Name = "برنامهToolStripMenuItem";
            this.برنامهToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
            this.برنامهToolStripMenuItem.Text = "برنامه";
            // 
            // اضافهکردنبرنامهToolStripMenuItem
            // 
            this.اضافهکردنبرنامهToolStripMenuItem.Name = "اضافهکردنبرنامهToolStripMenuItem";
            this.اضافهکردنبرنامهToolStripMenuItem.Size = new System.Drawing.Size(221, 26);
            this.اضافهکردنبرنامهToolStripMenuItem.Text = "اضافه کردن برنامه";
            this.اضافهکردنبرنامهToolStripMenuItem.Click += new System.EventHandler(this.اضافهکردنبرنامهToolStripMenuItem_Click);
            // 
            // اصولوچهارچوبهاToolStripMenuItem
            // 
            this.اصولوچهارچوبهاToolStripMenuItem.Name = "اصولوچهارچوبهاToolStripMenuItem";
            this.اصولوچهارچوبهاToolStripMenuItem.Size = new System.Drawing.Size(221, 26);
            this.اصولوچهارچوبهاToolStripMenuItem.Text = "اصول و چهارچوب ها";
            this.اصولوچهارچوبهاToolStripMenuItem.Click += new System.EventHandler(this.اصولوچهارچوبهاToolStripMenuItem_Click);
            // 
            // نمایشToolStripMenuItem
            // 
            this.نمایشToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.روزToolStripMenuItem,
            this.هفتهToolStripMenuItem,
            this.toolStripMenuItem2,
            this.پوستهToolStripMenuItem,
            this.اولویتبندیشدهToolStripMenuItem});
            this.نمایشToolStripMenuItem.Name = "نمایشToolStripMenuItem";
            this.نمایشToolStripMenuItem.Size = new System.Drawing.Size(64, 24);
            this.نمایشToolStripMenuItem.Text = "نمایش";
            // 
            // روزToolStripMenuItem
            // 
            this.روزToolStripMenuItem.Name = "روزToolStripMenuItem";
            this.روزToolStripMenuItem.Size = new System.Drawing.Size(212, 26);
            this.روزToolStripMenuItem.Text = "روز";
            this.روزToolStripMenuItem.Click += new System.EventHandler(this.روزToolStripMenuItem_Click);
            // 
            // هفتهToolStripMenuItem
            // 
            this.هفتهToolStripMenuItem.Name = "هفتهToolStripMenuItem";
            this.هفتهToolStripMenuItem.Size = new System.Drawing.Size(212, 26);
            this.هفتهToolStripMenuItem.Text = "هفته";
            this.هفتهToolStripMenuItem.Click += new System.EventHandler(this.هفتهToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Enabled = false;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(212, 26);
            this.toolStripMenuItem2.Text = "____________________";
            this.toolStripMenuItem2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // پوستهToolStripMenuItem
            // 
            this.پوستهToolStripMenuItem.Name = "پوستهToolStripMenuItem";
            this.پوستهToolStripMenuItem.Size = new System.Drawing.Size(212, 26);
            this.پوستهToolStripMenuItem.Text = "پوسته";
            this.پوستهToolStripMenuItem.DropDownClosed += new System.EventHandler(this.پوستهToolStripMenuItem_DropDownClosed);
            // 
            // اولویتبندیشدهToolStripMenuItem
            // 
            this.اولویتبندیشدهToolStripMenuItem.CheckOnClick = true;
            this.اولویتبندیشدهToolStripMenuItem.Name = "اولویتبندیشدهToolStripMenuItem";
            this.اولویتبندیشدهToolStripMenuItem.Size = new System.Drawing.Size(212, 26);
            this.اولویتبندیشدهToolStripMenuItem.Text = "اولویت بندی شده";
            this.اولویتبندیشدهToolStripMenuItem.Click += new System.EventHandler(this.اولویتبندیشدهToolStripMenuItem_Click);
            // 
            // خدماتToolStripMenuItem
            // 
            this.خدماتToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.همگامسازیاینترنتیToolStripMenuItem,
            this.اتصالبهحسابToolStripMenuItem,
            this.بازیابیاینترنتیToolStripMenuItem});
            this.خدماتToolStripMenuItem.Name = "خدماتToolStripMenuItem";
            this.خدماتToolStripMenuItem.Size = new System.Drawing.Size(67, 24);
            this.خدماتToolStripMenuItem.Text = "خدمات";
            // 
            // همگامسازیاینترنتیToolStripMenuItem
            // 
            this.همگامسازیاینترنتیToolStripMenuItem.Name = "همگامسازیاینترنتیToolStripMenuItem";
            this.همگامسازیاینترنتیToolStripMenuItem.Size = new System.Drawing.Size(220, 26);
            this.همگامسازیاینترنتیToolStripMenuItem.Text = "همگام سازی اینترنتی";
            this.همگامسازیاینترنتیToolStripMenuItem.Click += new System.EventHandler(this.همگامسازیاینترنتیToolStripMenuItem_Click);
            // 
            // اتصالبهحسابToolStripMenuItem
            // 
            this.اتصالبهحسابToolStripMenuItem.Name = "اتصالبهحسابToolStripMenuItem";
            this.اتصالبهحسابToolStripMenuItem.Size = new System.Drawing.Size(220, 26);
            this.اتصالبهحسابToolStripMenuItem.Text = "اتصال به حساب";
            this.اتصالبهحسابToolStripMenuItem.Click += new System.EventHandler(this.اتصالبهحسابToolStripMenuItem_Click);
            // 
            // بازیابیاینترنتیToolStripMenuItem
            // 
            this.بازیابیاینترنتیToolStripMenuItem.Name = "بازیابیاینترنتیToolStripMenuItem";
            this.بازیابیاینترنتیToolStripMenuItem.Size = new System.Drawing.Size(220, 26);
            this.بازیابیاینترنتیToolStripMenuItem.Text = "بازیابی اینترنتی";
            this.بازیابیاینترنتیToolStripMenuItem.Click += new System.EventHandler(this.بازیابیاینترنتیToolStripMenuItem_Click);
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.Color.White;
            this.panel.Controls.Add(this.weeklyTaskViewer);
            this.panel.Controls.Add(this.dailyTaskViewer);
            this.panel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel.Location = new System.Drawing.Point(0, 84);
            this.panel.Margin = new System.Windows.Forms.Padding(4);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(1103, 365);
            this.panel.TabIndex = 3;
            // 
            // dailyTaskViewVScrollBar
            // 
            this.dailyTaskViewVScrollBar.Dock = System.Windows.Forms.DockStyle.Right;
            this.dailyTaskViewVScrollBar.Location = new System.Drawing.Point(1103, 0);
            this.dailyTaskViewVScrollBar.Name = "dailyTaskViewVScrollBar";
            this.dailyTaskViewVScrollBar.Size = new System.Drawing.Size(24, 449);
            this.dailyTaskViewVScrollBar.TabIndex = 5;
            this.dailyTaskViewVScrollBar.ValueChanged += new System.EventHandler(this.DailyTaskViewVScrollBar_ValueChanged);
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.calendarView);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1127, 420);
            this.panel1.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.taskViewsHeaderPanel);
            this.panel2.Controls.Add(this.panel);
            this.panel2.Controls.Add(this.dailyTaskViewVScrollBar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 448);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1127, 449);
            this.panel2.TabIndex = 8;
            // 
            // taskViewsHeaderPanel
            // 
            this.taskViewsHeaderPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.taskViewsHeaderPanel.Location = new System.Drawing.Point(0, 0);
            this.taskViewsHeaderPanel.Name = "taskViewsHeaderPanel";
            this.taskViewsHeaderPanel.Size = new System.Drawing.Size(1103, 84);
            this.taskViewsHeaderPanel.TabIndex = 6;
            // 
            // weeklyTaskViewer
            // 
            this.weeklyTaskViewer.BackColor = System.Drawing.Color.Gray;
            this.weeklyTaskViewer.DPM = 2;
            this.weeklyTaskViewer.Location = new System.Drawing.Point(0, 0);
            this.weeklyTaskViewer.Margin = new System.Windows.Forms.Padding(0);
            this.weeklyTaskViewer.MinimumSize = new System.Drawing.Size(1021, 631);
            this.weeklyTaskViewer.Name = "weeklyTaskViewer";
            this.weeklyTaskViewer.Prioritized = false;
            this.weeklyTaskViewer.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.weeklyTaskViewer.Size = new System.Drawing.Size(1103, 631);
            this.weeklyTaskViewer.TabIndex = 1;
            this.weeklyTaskViewer.Visible = false;
            this.weeklyTaskViewer.Week = null;
            // 
            // dailyTaskViewer
            // 
            this.dailyTaskViewer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dailyTaskViewer.Location = new System.Drawing.Point(0, 0);
            this.dailyTaskViewer.Margin = new System.Windows.Forms.Padding(0);
            this.dailyTaskViewer.Name = "dailyTaskViewer";
            this.dailyTaskViewer.Prioritized = false;
            this.dailyTaskViewer.Size = new System.Drawing.Size(1103, 1767);
            this.dailyTaskViewer.TabIndex = 0;
            // 
            // calendarView
            // 
            this.calendarView.BackColor = System.Drawing.Color.LightYellow;
            this.calendarView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.calendarView.Location = new System.Drawing.Point(0, 0);
            this.calendarView.Margin = new System.Windows.Forms.Padding(5);
            this.calendarView.Mode = Sahab_Desktop.Controls.CalendarMode.DaySelect;
            this.calendarView.Name = "calendarView";
            this.calendarView.SelectedDate = new System.DateTime(2020, 2, 23, 22, 33, 10, 994);
            week1.EndDate = new System.DateTime(2020, 3, 13, 0, 0, 0, 0);
            week1.StartDate = new System.DateTime(2020, 3, 7, 0, 0, 0, 0);
            this.calendarView.SelectedWeek = week1;
            this.calendarView.Size = new System.Drawing.Size(611, 415);
            this.calendarView.TabIndex = 6;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1127, 897);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "سحاب";
            this.ResizeEnd += new System.EventHandler(this.MainForm_ResizeEnd);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem برنامهToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem اضافهکردنبرنامهToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem نمایشToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem روزToolStripMenuItem;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.VScrollBar dailyTaskViewVScrollBar;
        private Controls.DailyTaskViewer dailyTaskViewer;
        private Controls.CalendarView calendarView;
        private System.Windows.Forms.ToolStripMenuItem هفتهToolStripMenuItem;
        private Controls.WeeklyTaskViewer weeklyTaskViewer;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem پوستهToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem اصولوچهارچوبهاToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem خدماتToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem همگامسازیاینترنتیToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripMenuItem اتصالبهحسابToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem اولویتبندیشدهToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem بازیابیاینترنتیToolStripMenuItem;
        private System.Windows.Forms.Panel taskViewsHeaderPanel;
    }
}

