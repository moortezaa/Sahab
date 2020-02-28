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
            this.هفتهToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.پوستهToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel = new System.Windows.Forms.Panel();
            this.weeklyTaskViewer = new Sahab_Desktop.Controls.WeeklyTaskViewer();
            this.dailyTaskViewer = new Sahab_Desktop.Controls.DailyTaskViewer();
            this.dailyTaskViewVScrollBar = new System.Windows.Forms.VScrollBar();
            this.calendarView = new Sahab_Desktop.Controls.CalendarView();
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
            this.روزToolStripMenuItem,
            this.هفتهToolStripMenuItem,
            this.toolStripMenuItem2,
            this.پوستهToolStripMenuItem});
            this.نمایشToolStripMenuItem.Name = "نمایشToolStripMenuItem";
            this.نمایشToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.نمایشToolStripMenuItem.Text = "نمایش";
            // 
            // روزToolStripMenuItem
            // 
            this.روزToolStripMenuItem.Name = "روزToolStripMenuItem";
            this.روزToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.روزToolStripMenuItem.Text = "روز";
            this.روزToolStripMenuItem.Click += new System.EventHandler(this.روزToolStripMenuItem_Click);
            // 
            // هفتهToolStripMenuItem
            // 
            this.هفتهToolStripMenuItem.Name = "هفتهToolStripMenuItem";
            this.هفتهToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.هفتهToolStripMenuItem.Text = "هفته";
            this.هفتهToolStripMenuItem.Click += new System.EventHandler(this.هفتهToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Enabled = false;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem2.Text = "____________________";
            this.toolStripMenuItem2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // پوستهToolStripMenuItem
            // 
            this.پوستهToolStripMenuItem.Name = "پوستهToolStripMenuItem";
            this.پوستهToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.پوستهToolStripMenuItem.Text = "پوسته";
            // 
            // panel
            // 
            this.panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel.BackColor = System.Drawing.Color.White;
            this.panel.Controls.Add(this.weeklyTaskViewer);
            this.panel.Controls.Add(this.dailyTaskViewer);
            this.panel.Location = new System.Drawing.Point(12, 375);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(753, 330);
            this.panel.TabIndex = 3;
            // 
            // weeklyTaskViewer
            // 
            this.weeklyTaskViewer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.weeklyTaskViewer.BackColor = System.Drawing.Color.Gray;
            this.weeklyTaskViewer.DPM = 2;
            this.weeklyTaskViewer.Location = new System.Drawing.Point(0, 0);
            this.weeklyTaskViewer.Name = "weeklyTaskViewer";
            this.weeklyTaskViewer.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.weeklyTaskViewer.Size = new System.Drawing.Size(753, 513);
            this.weeklyTaskViewer.TabIndex = 1;
            this.weeklyTaskViewer.Visible = false;
            // 
            // dailyTaskViewer
            // 
            this.dailyTaskViewer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dailyTaskViewer.Location = new System.Drawing.Point(0, 0);
            this.dailyTaskViewer.Name = "dailyTaskViewer";
            this.dailyTaskViewer.Size = new System.Drawing.Size(753, 1436);
            this.dailyTaskViewer.TabIndex = 0;
            // 
            // dailyTaskViewVScrollBar
            // 
            this.dailyTaskViewVScrollBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dailyTaskViewVScrollBar.Location = new System.Drawing.Point(768, 375);
            this.dailyTaskViewVScrollBar.Name = "dailyTaskViewVScrollBar";
            this.dailyTaskViewVScrollBar.Size = new System.Drawing.Size(23, 330);
            this.dailyTaskViewVScrollBar.TabIndex = 5;
            this.dailyTaskViewVScrollBar.ValueChanged += new System.EventHandler(this.DailyTaskViewVScrollBar_ValueChanged);
            // 
            // calendarView
            // 
            this.calendarView.BackColor = System.Drawing.Color.LightYellow;
            this.calendarView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.calendarView.Location = new System.Drawing.Point(12, 27);
            this.calendarView.Mode = Sahab_Desktop.Controls.CalendarMode.DaySelect;
            this.calendarView.Name = "calendarView";
            this.calendarView.SelectedDate = new System.DateTime(2020, 2, 23, 22, 33, 10, 994);
            this.calendarView.Size = new System.Drawing.Size(459, 338);
            this.calendarView.TabIndex = 6;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 717);
            this.Controls.Add(this.calendarView);
            this.Controls.Add(this.dailyTaskViewVScrollBar);
            this.Controls.Add(this.panel);
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
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.VScrollBar dailyTaskViewVScrollBar;
        private Controls.DailyTaskViewer dailyTaskViewer;
        private Controls.CalendarView calendarView;
        private System.Windows.Forms.ToolStripMenuItem هفتهToolStripMenuItem;
        private Controls.WeeklyTaskViewer weeklyTaskViewer;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem پوستهToolStripMenuItem;
    }
}

