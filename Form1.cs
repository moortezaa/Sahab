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
        private float RowHeight = 70f;
        public MainForm()
        {
            InitializeComponent();
            int rowCount = taskViewTableLayoutPanel.RowCount;
            taskViewTableLayoutPanel.Height = 0;
            for (int i = 0; i < rowCount; i++)
            {
                taskViewTableLayoutPanel.RowStyles[i] = new RowStyle(SizeType.Absolute, RowHeight);
                taskViewTableLayoutPanel.Height += (int)taskViewTableLayoutPanel.RowStyles[i].Height;

                var lable = new Label()
                {
                    Text = $"{i + 1}",
                    TextAlign = ContentAlignment.MiddleCenter
                };
                taskViewTableLayoutPanel.Controls.Add(lable, 0, i);
            }
            taskViewTableLayoutPanel.Height += (int)(RowHeight / 2);
            dailyTaskViewVScrollBar.Maximum = taskViewTableLayoutPanel.Height;
            StartDateTextBox.Text = CurrentDate.ToString("yyyy/MM/dd", new CultureInfo("fa-IR"));
            RefreshTaskView();

            MouseWheel += MainForm_MouseWheel;
            StartDateTextBox.KeyDown += Enter_KeyDown;
        }

        private void AddIndexToDailyTaskViewTable()
        {
            for (int i = 0; i < taskViewTableLayoutPanel.RowCount; i++)
            {
                taskViewTableLayoutPanel.RowStyles[i] = new RowStyle(SizeType.Absolute, RowHeight);

                var lable = new Label()
                {
                    Text = $"{i + 1}",
                    TextAlign = ContentAlignment.MiddleCenter
                };
                taskViewTableLayoutPanel.Controls.Add(lable, 0, i);
            }
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

        private void TaskForm_OnTaskSubmited(object sender, EventArgs e)
        {
            RefreshTaskView();
        }

        private void RefreshTaskView()
        {
            var tasks = _context.Tasks.Where(t => t.StartDate.CompareTo(CurrentDate.Date) == 0);
            var taskPerHours = new Dictionary<int, ListBox[]>();
            foreach (Control control in taskViewTableLayoutPanel.Controls)
            {
                if (taskViewTableLayoutPanel.GetColumn(control) != 0)
                {
                    taskViewTableLayoutPanel.Controls.Clear();
                    AddIndexToDailyTaskViewTable();
                }
            }
            foreach (var task in tasks)
            {
                for (int times = task.StartTime.Hour; times < task.EndTime.Hour; times++)
                {
                    if (taskPerHours.ContainsKey(times))
                    {
                        taskPerHours[times][0].Items.Add(task.Title);
                        taskPerHours[times][1].Items.Add(task.Peoples);
                        taskPerHours[times][2].Items.Add(task.Location);
                    }
                    else
                    {
                        var listBoxes = new ListBox[3];
                        var taskListBox = new ListBox()
                        {
                            Margin = new Padding(3),
                            Dock = DockStyle.Fill,
                            BorderStyle = BorderStyle.None,
                        };
                        taskListBox.Items.Add(task.Title);
                        taskListBox.MouseWheel += MainForm_MouseWheel;
                        listBoxes[0] = taskListBox;
                        var personListBox = new ListBox()
                        {
                            Margin = new Padding(3),
                            Dock = DockStyle.Fill,
                            BorderStyle = BorderStyle.None
                        };
                        personListBox.Items.Add(task.Peoples);
                        personListBox.MouseWheel += MainForm_MouseWheel;
                        listBoxes[1] = personListBox;
                        var locationListBox = new ListBox()
                        {
                            Margin = new Padding(3),
                            Dock = DockStyle.Fill,
                            BorderStyle = BorderStyle.None
                        };
                        locationListBox.Items.Add(task.Location);
                        locationListBox.MouseWheel += MainForm_MouseWheel;
                        listBoxes[2] = locationListBox;
                        taskPerHours.Add(times, listBoxes);
                    }
                }
            }
            foreach (var taskPerHour in taskPerHours)
            {
                taskViewTableLayoutPanel.Controls.Add(taskPerHour.Value[0], 1, taskPerHour.Key - 1);
                taskViewTableLayoutPanel.Controls.Add(taskPerHour.Value[1], 2, taskPerHour.Key - 1);
                taskViewTableLayoutPanel.Controls.Add(taskPerHour.Value[2], 3, taskPerHour.Key - 1);
            }
        }

        private void TaskViewTableLayoutPanel_Resize(object sender, EventArgs e)
        {
            dailyTaskViewVScrollBar.Maximum = taskViewTableLayoutPanel.Height;
        }

        private void DailyTaskViewVScrollBar_ValueChanged(object sender, EventArgs e)
        {
            double positionAspect = (double)dailyTaskViewVScrollBar.Value / (double)dailyTaskViewVScrollBar.Maximum;
            taskViewTableLayoutPanel.Top = (int)-(positionAspect * (taskViewTableLayoutPanel.Height - panel.Height));
        }

        private void Panel_Resize(object sender, EventArgs e)
        {
            taskViewTableLayoutPanel.Width = panel.Width;
        }

        private void Show_Click(object sender, EventArgs e)
        {
            CurrentDate = Utils.Utils.ParsePersianDateString(StartDateTextBox.Text);
            RefreshTaskView();
        }
    }
}
