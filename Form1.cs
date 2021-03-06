using Sahab_Desktop.Controls;
using Sahab_Desktop.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sahab_Desktop
{
    public partial class MainForm : Form
    {
        private DateTime CurrentDate { get; set; } = DateTime.Now;
        private Week CurrentWeek { get; set; } = Week.SelectByDateBetween(DateTime.Now);
        private AppDBContext _context = new AppDBContext();
        private ShowingMode ShowingMode { get; set; } = ShowingMode.Daily;
        private bool CTRIsDown { get; set; } = false;
        public MainForm()
        {
            InitializeComponent();

            RefreshTaskView();

            MouseWheel += MainForm_MouseWheel;
            KeyDown += MainForm_KeyDown;
            KeyUp += MainForm_KeyUp;
            dailyTaskViewVScrollBar.Maximum = dailyTaskViewer.Height;

            calendarView.DateSelect += CalendarView_DateSelect;
            calendarView.WeekSelect += CalendarView_WeekSelect;

            weeklyTaskViewer.Week = CurrentWeek;
            dailyTaskViewer.Date = CurrentDate;

            using (var context = new AppDBContext())
            {
                var thems = context.Thems;
                foreach (var them in thems)
                {
                    var menuItem = new ToolStripMenuItem(them.Name);
                    menuItem.Click += MenuItem_Click;
                    var colors = them.Colors.Split(',').Select(s => ColorTranslator.FromHtml(s));
                    foreach (var color in colors)
                    {
                        var dropItem = new ToolStripMenuItem()
                        {
                            BackColor = color,
                            Enabled = false
                        };
                        menuItem.DropDownItems.Add(dropItem);
                    }
                    پوستهToolStripMenuItem.DropDownItems.Add(menuItem);
                }
            }

            taskViewsHeaderPanel.Controls.Add(dailyTaskViewer.getHeader());
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                CTRIsDown = false;
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                CTRIsDown = true;
            }
        }

        private void CalendarView_WeekSelect(Week week)
        {
            CurrentWeek = week;
            RefreshTaskView();
        }

        private void CalendarView_DateSelect(DateTime date)
        {
            CurrentDate = date;
            RefreshTaskView();
        }

        private void MainForm_MouseWheel(object sender, MouseEventArgs e)
        {
            if (CTRIsDown)
            {
                weeklyTaskViewer.ScrollHorizontaly(e.Delta);
            }
            else
            {
                int scrolval = dailyTaskViewVScrollBar.Value;
                scrolval -= e.Delta;
                if (scrolval > dailyTaskViewVScrollBar.Maximum)
                {
                    dailyTaskViewVScrollBar.Value = dailyTaskViewVScrollBar.Maximum;
                }
                else if (scrolval < dailyTaskViewVScrollBar.Minimum)
                {
                    dailyTaskViewVScrollBar.Value = dailyTaskViewVScrollBar.Minimum;
                }
                else
                {
                    dailyTaskViewVScrollBar.Value = scrolval;
                }
            }
        }

        private void اضافهکردنبرنامهToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TaskForm taskForm = new TaskForm();
            taskForm.Show(this);
        }

        private void TaskForm_OnTaskSubmited(Models.Task task)
        {
        }

        private void RefreshTaskView()
        {
            switch (ShowingMode)
            {
                case ShowingMode.Daily:
                    using (var context = new AppDBContext())
                    {
                        var tasks = context.Tasks.Where(t => t.StartDate.CompareTo(CurrentDate.Date) <= 0 && t.EndDate.CompareTo(CurrentDate.Date) >= 0);
                        List<Models.Task> currentDateTasks = new List<Models.Task>();
                        foreach (var task in tasks)
                        {
                            if (task.Dates != null)
                            {
                                if (task.Dates.Contains(CurrentDate.Date))
                                {
                                    currentDateTasks.Add(task);
                                }
                            }
                        }
                        dailyTaskViewer.Date = CurrentDate.Date;
                        dailyTaskViewer.Tasks = currentDateTasks;
                        dailyTaskViewer.Refresh();
                        taskViewsHeaderPanel.Controls.Clear();
                        taskViewsHeaderPanel.Controls.Add(dailyTaskViewer.getHeader());
                        taskViewsHeaderPanel.Refresh();
                    }
                    break;
                case ShowingMode.Weekly:
                    using (var context = new AppDBContext())
                    {
                        var tasks = context.Tasks.Where(t => t.StartDate.CompareTo(CurrentWeek.EndDate) <= 0 && t.EndDate.CompareTo(CurrentWeek.StartDate.Value) >= 0);
                        List<Models.Task> currentWeekTasks = new List<Models.Task>();
                        foreach (var task in tasks)
                        {
                            if (task.Dates != null)
                            {
                                if (task.Dates.Where(d => d.Date.CompareTo(CurrentWeek.StartDate) >= 0 && d.Date.CompareTo(CurrentWeek.EndDate) <= 0).Any())
                                {
                                    currentWeekTasks.Add(task);
                                }
                            }
                        }
                        weeklyTaskViewer.Week = CurrentWeek;
                        weeklyTaskViewer.Tasks = currentWeekTasks;
                        weeklyTaskViewer.Refresh();
                        taskViewsHeaderPanel.Controls.Clear();
                        taskViewsHeaderPanel.Controls.Add(weeklyTaskViewer.getHeader());
                        taskViewsHeaderPanel.Refresh();
                    }
                    break;
                case ShowingMode.Monthly:
                    break;
            }
        }

        private void DailyTaskViewVScrollBar_ValueChanged(object sender, EventArgs e)
        {
            double positionAspect = (double)dailyTaskViewVScrollBar.Value / (double)dailyTaskViewVScrollBar.Maximum;
            if (positionAspect > 0.99)
            {
                positionAspect = 1;
            }
            dailyTaskViewer.Top = (int)-(positionAspect * (dailyTaskViewer.Height - panel.Height));
            weeklyTaskViewer.Top = (int)-(positionAspect * (weeklyTaskViewer.Height - panel.Height));
        }

        private void MainForm_ResizeEnd(object sender, EventArgs e)
        {
            dailyTaskViewer.Width = panel.Width;
            DailyTaskViewVScrollBar_ValueChanged(sender, e);
        }

        private void روزToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dailyTaskViewer.Visible = true;
            weeklyTaskViewer.Visible = false;
            calendarView.Mode = CalendarMode.DaySelect;
            ShowingMode = ShowingMode.Daily;
        }

        private void هفتهToolStripMenuItem_Click(object sender, EventArgs e)
        {

            dailyTaskViewer.Visible = false;
            weeklyTaskViewer.Visible = true;
            ShowingMode = ShowingMode.Weekly;
            calendarView.Mode = CalendarMode.WeekSelect;
        }

        private void MenuItem_Click(object sender, EventArgs e)
        {
            using (var context = new AppDBContext())
            {
                var user = context.Users.First();
                user.ThemName = (sender as ToolStripMenuItem).Text;
                context.SaveChanges();
            }
            نمایشToolStripMenuItem.HideDropDown();
        }

        private void اصولوچهارچوبهاToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var doctrineAndFrameManagerForm = new DoctrineAndFrameManager();
            doctrineAndFrameManagerForm.Show(this);
        }

        private void همگامسازیاینترنتیToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var context = new AppDBContext())
            {
                var user = context.Users.First();
                if (user.UserName == "default")
                {
                    var linkAccountForm = new LinkAccountForm();
                    linkAccountForm.Show();
                }
                else
                {
                    var webSyncForm = new WebSyncForm(WebSyncForm.WebSyncType.Send);
                    webSyncForm.Show();
                }
            }
        }

        private void اتصالبهحسابToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var linkAccountForm = new LinkAccountForm();
            linkAccountForm.Show();
        }

        private void اولویتبندیشدهToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (اولویتبندیشدهToolStripMenuItem.Checked)
            {
                dailyTaskViewer.Prioritized = true;
                weeklyTaskViewer.Prioritized = true;
                switch (ShowingMode)
                {
                    case ShowingMode.Daily:
                        dailyTaskViewer.Refresh();
                        break;
                    case ShowingMode.Weekly:
                        weeklyTaskViewer.Refresh();
                        break;
                    case ShowingMode.Monthly:
                        break;
                    default:
                        break;
                }
            }
            else
            {
                dailyTaskViewer.Prioritized = false;
                weeklyTaskViewer.Prioritized = false;
                switch (ShowingMode)
                {
                    case ShowingMode.Daily:
                        dailyTaskViewer.Refresh();
                        break;
                    case ShowingMode.Weekly:
                        weeklyTaskViewer.Refresh();
                        break;
                    case ShowingMode.Monthly:
                        break;
                    default:
                        break;
                }
            }
        }

        private void بازیابیاینترنتیToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var context = new AppDBContext())
            {
                var user = context.Users.First();
                if (user.UserName == "default")
                {
                    var linkAccountForm = new LinkAccountForm();
                    linkAccountForm.Show();
                }
                else
                {
                    var webSyncForm = new WebSyncForm(WebSyncForm.WebSyncType.Get);
                    webSyncForm.Show();
                }
            }
        }

        private void پوستهToolStripMenuItem_DropDownClosed(object sender, EventArgs e)
        {
            switch (ShowingMode)
            {
                case ShowingMode.Daily:
                    dailyTaskViewer.Refresh();
                    break;
                case ShowingMode.Weekly:
                    weeklyTaskViewer.Refresh();
                    break;
                case ShowingMode.Monthly:
                    break;
                default:
                    break;
            }
        }
    }

    internal enum ShowingMode
    {
        Daily,
        Weekly,
        Monthly,
    }
}
