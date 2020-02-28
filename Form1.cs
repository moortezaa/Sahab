using Sahab_Desktop.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        public MainForm()
        {
            InitializeComponent();

            RefreshTaskView();

            MouseWheel += MainForm_MouseWheel;
            dailyTaskViewVScrollBar.Maximum = dailyTaskViewer.Height;

            calendarView.DateSelect += CalendarView_DateSelect;
            calendarView.WeekSelect += CalendarView_WeekSelect;

            weeklyTaskViewer.Week = CurrentWeek;
            dailyTaskViewer.Date = CurrentDate;
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

        private void اضافهکردنبرنامهToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TaskForm taskForm = new TaskForm();
            taskForm.OnTaskSubmited += TaskForm_OnTaskSubmited;
            taskForm.Show(this);
        }

        private void TaskForm_OnTaskSubmited(Models.Task task)
        {
            dailyTaskViewer.AddTask(task);
        }

        private void RefreshTaskView()
        {
            switch (ShowingMode)
            {
                case ShowingMode.Daily:
                    var tasks = _context.Tasks.Where(t => t.StartDate.CompareTo(CurrentDate.Date) <= 0 && t.EndDate.CompareTo(CurrentDate.Date) >= 0);
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
                    break;
                case ShowingMode.Weekly:
                    tasks = _context.Tasks.Where(t => t.StartDate.CompareTo(CurrentWeek.EndDate.Date) <= 0 && t.EndDate.CompareTo(CurrentWeek.StartDate.Date) >= 0);
                    List<Models.Task> currentWeekTasks = new List<Models.Task>();
                    foreach (var task in tasks)
                    {
                        if (task.Dates != null)
                        {
                            if (task.Dates.Where(d=>d.Date.CompareTo(CurrentWeek.StartDate)>=0&&d.Date.CompareTo(CurrentWeek.EndDate)<=0).Any())
                            {
                                currentWeekTasks.Add(task);
                            }
                        }
                    }
                    weeklyTaskViewer.Week = CurrentWeek;
                    weeklyTaskViewer.Tasks = currentWeekTasks;
                    weeklyTaskViewer.Refresh();
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
    }

    internal enum ShowingMode
    {
        Daily,
        Weekly,
        Monthly,
    }
}
