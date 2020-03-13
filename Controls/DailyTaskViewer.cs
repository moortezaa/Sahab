using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sahab_Desktop.Controls
{
    public partial class DailyTaskViewer : UserControl
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<Models.Task> Tasks { get; set; } = new List<Models.Task>();
        public DateTime Date { get; internal set; }

        private Label NowIndicatorLabel { get; set; }
        private const int TimeLabelWidth = 30;

        public DailyTaskViewer()
        {
            InitializeComponent();
            NowIndicatorLabel = nowIndicatorLabel;
            Height = 24 * 60;
            AddTimeLabels();
            NowIndicatorLabel.Left = 0;
            NowIndicatorLabel.Width = Width - TimeLabelWidth + 3;

            NowIndicatorLabel.Top = (int)DateTime.Now.Subtract(DateTime.Now.Date).TotalMinutes;
        }

        private void AddTimeLabels()
        {
            for (int i = 0; i < 24 * 4; i++)
            {
                if (i % 4 == 0)
                {
                    Label label = GenerateTimeLabel($"{i / 4}", 10f, i * 15);
                    Controls.Add(label);
                }
                else
                {
                    Label label = GenerateTimeLabel($"{i / 4}:{i % 4 * 15}", 5f, i * 15);
                    Controls.Add(label);
                }
            }
        }

        private Label GenerateTimeLabel(string text, float emSize, int top)
        {
            return new Label()
            {
                AutoSize = false,
                Width = TimeLabelWidth,
                Height = 15,
                TextAlign = ContentAlignment.TopRight,
                Text = text,
                Left = this.Width - TimeLabelWidth,
                Top = top,
                Font = new Font(Font.FontFamily, emSize)
            };
        }

        private void DailyTaskViewer_Load(object sender, EventArgs e)
        {
            Resize += DailyTaskViewer_Resize;
            DailyTaskViewer_Resize(sender, e);
            foreach (var task in Tasks)
            {
                AddSingleTaskView(task);
            }
        }

        public override void Refresh()
        {
            Controls.Clear();
            Controls.Add(NowIndicatorLabel);
            AddTimeLabels();

            DailyTaskViewer_Load(this, new EventArgs());
        }

        public void AddTask(Models.Task task)
        {
            Tasks.Add(task);
            AddSingleTaskView(task);
        }

        private void AddSingleTaskView(Models.Task task)
        {
            var taskView = new SingleDailyTaskView(Date)
            {
                Height = (int)task.EndTime.Subtract(task.StartTime).TotalMinutes,
                Width = this.Width - TimeLabelWidth,
                Top = (int)task.StartTime.Subtract(new DateTime(task.StartTime.Year, task.StartTime.Month, task.StartTime.Day, 0, 0, 0)).TotalMinutes,
                Task = task,
            };
            Controls.Add(taskView);
            ReColor();
            NowIndicatorLabel.BringToFront();
        }

        private void DailyTaskViewer_Resize(object sender, EventArgs e)
        {
            foreach (var control in Controls)
            {
                if (control.GetType() == typeof(SingleDailyTaskView))
                {
                    (control as SingleDailyTaskView).Width = Width - TimeLabelWidth;
                }
                else if (control.GetType() == typeof(Label))
                {
                    (control as Label).Left = this.Width - TimeLabelWidth;
                }
            }

            NowIndicatorLabel.Width = Width - TimeLabelWidth + 3;
            NowIndicatorLabel.Left = 0;
            NowIndicatorLabel.BringToFront();
        }

        private void ReColor()
        {
            List<Color> them = Utils.Utils.GetThem();
            var colorindex = 0;
            foreach (var control in Controls)
            {
                if (control.GetType() == typeof(SingleDailyTaskView))
                {
                    var color = them[colorindex % them.Count];
                    (control as SingleDailyTaskView).BackColor = color;
                    if (color.GetBrightness() < 0.5)
                    {
                        (control as SingleDailyTaskView).ForeColor = Color.White;
                    }
                    colorindex += 1;
                }
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            NowIndicatorLabel.Top = (int)DateTime.Now.Subtract(DateTime.Now.Date).TotalMinutes;
            NowIndicatorLabel.BringToFront();
        }
    }
}
