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
        private AppDBContext _context = new AppDBContext();
        public MainForm()
        {
            InitializeComponent();


            StartDateTextBox.Text = CurrentDate.ToString("yyyy/MM/dd", new CultureInfo("fa-IR"));
            RefreshTaskView();

            MouseWheel += MainForm_MouseWheel;
            StartDateTextBox.KeyDown += Enter_KeyDown;
            dailyTaskViewVScrollBar.Maximum = dailyTaskViewer.Height;

            calendarView.DateSelect += CalendarView_DateSelect;
        }

        private void CalendarView_DateSelect(DateTime date)
        {
            CurrentDate = date;
            StartDateTextBox.Text = date.ToString("yyyy/MM/dd", new CultureInfo("fa-IR"));
            RefreshTaskView();
        }

        private void Enter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Show_Click(sender, new EventArgs());
            }
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
            dailyTaskViewer.CurrentDate = CurrentDate.Date;
            dailyTaskViewer.Tasks = currentDateTasks;
            dailyTaskViewer.Refresh();
        }

        private void DailyTaskViewVScrollBar_ValueChanged(object sender, EventArgs e)
        {
            double positionAspect = (double)dailyTaskViewVScrollBar.Value / (double)dailyTaskViewVScrollBar.Maximum;
            if (positionAspect > 0.99)
            {
                positionAspect = 1;
            }
            dailyTaskViewer.Top = (int)-(positionAspect * (dailyTaskViewer.Height - panel.Height));
        }

        private void Show_Click(object sender, EventArgs e)
        {
            CurrentDate = Utils.Utils.ParsePersianDateString(StartDateTextBox.Text);
            RefreshTaskView();
        }

        private void MainForm_ResizeEnd(object sender, EventArgs e)
        {
            dailyTaskViewer.Width = panel.Width;
            DailyTaskViewVScrollBar_ValueChanged(sender, e);
        }
    }
}
