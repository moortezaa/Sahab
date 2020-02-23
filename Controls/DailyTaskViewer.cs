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
        private const int TimeLabelWidth = 30;

        public DailyTaskViewer()
        {
            InitializeComponent();
            Height = 24 * 60;
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
            foreach (var task in Tasks)
            {
                AddSingleTaskView(task);
            }
        }

        public override void Refresh()
        {
            foreach (Control control in Controls)
            {
                if (control.GetType() == typeof(SingleTaskView))
                {
                    Controls.Remove(control);
                }
            }
            DailyTaskViewer_Load(this, new EventArgs());
        }

        public void AddTask(Models.Task task)
        {
            Tasks.Add(task);
            AddSingleTaskView(task);
        }

        private void AddSingleTaskView(Models.Task task)
        {
            var taskView = new SingleTaskView()
            {
                Height = (int)task.EndTime.Subtract(task.StartTime).TotalMinutes,
                Width = this.Width - TimeLabelWidth,
                Top = (int)task.StartTime.Subtract(new DateTime(task.StartTime.Year, task.StartTime.Month, task.StartTime.Day, 0, 0, 0)).TotalMinutes,
                Task = task,

            };
            Controls.Add(taskView);
            ReColor();
        }

        private void DailyTaskViewer_Resize(object sender, EventArgs e)
        {
            foreach (var control in Controls)
            {
                if (control.GetType() == typeof(SingleTaskView))
                {
                    (control as SingleTaskView).Width = Width - TimeLabelWidth;
                }
                else if (control.GetType() == typeof(Label))
                {
                    (control as Label).Left = this.Width - TimeLabelWidth;
                }
            }
        }

        private void ReColor()
        {
            var them = new List<Color>()
            {
                Color.AliceBlue,
                Color.LightGreen,
                Color.PaleVioletRed,
                Color.LightYellow,
                Color.MintCream,
            };
            var colorindex = 0;
            foreach (var control in Controls)
            {
                if (control.GetType() == typeof(SingleTaskView))
                {
                    (control as SingleTaskView).BackColor = them[colorindex % them.Count];
                    colorindex += 1;
                }
            }
        }
    }
}
