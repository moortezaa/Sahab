using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sahab_Desktop.Utils;

namespace Sahab_Desktop.Controls
{
    public partial class WeeklyTaskViewer : UserControl
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<Models.Task> Tasks { get; set; } = new List<Models.Task>();
        public Week Week { get; set; }
        public int DPM { get; set; } = 2;
        private Label nowIndicatorLabel;
        public WeeklyTaskViewer()
        {
            InitializeComponent();
            MinimumSize = new Size(Width, Height);
            nowIndicatorLabel = new Label()
            {
                Name = "Time",
                Width = 3,
                Height = label1.Height * 7 + 3,
                Top = label1.Top - theScroll.Height - 3,
                Left = (int)DateTime.Now.Subtract(DateTime.Now.Date).TotalMinutes * DPM,
                BackColor = Color.Red
            };
            tasksPanel.Controls.Add(nowIndicatorLabel);
            tasksPanel.Width = 24 * 60 * DPM;
            theScroll.Maximum = tasksPanel.Width;
            AddTimeTags();
        }

        private void AddTimeTags()
        {
            for (int i = 0; i < 24 * 4; i++)
            {
                if (i % 4 == 0)
                {
                    Label label = GenerateTimeLabel($"{i / 4}", 10f, i * 15 * DPM);
                    tasksPanel.Controls.Add(label);
                }
                else
                {
                    Label label = GenerateTimeLabel($"{i % 4 * 15}", 5f, i * 15 * DPM);
                    tasksPanel.Controls.Add(label);
                }
            }
        }

        private Label GenerateTimeLabel(string text, float emSize, int left)
        {
            return new Label()
            {
                Name = "Time",
                AutoSize = false,
                Width = 15 * DPM,
                Height = 15,
                TextAlign = ContentAlignment.TopRight,
                Text = text,
                Left = left,
                Top = 0,
                Font = new Font(Font.FontFamily, emSize)
            };
        }

        public override void Refresh()
        {
            RefreshTasks();
            ReColor();
            base.Refresh();
        }

        private void RefreshTasks()
        {
            tasksPanel.Controls.Clear();
            tasksPanel.Controls.Add(nowIndicatorLabel);
            AddTimeTags();

            if (Week!=null && Week.StartDate.HasValue)
            {
                var date = Week.StartDate.Value.AddDays(-1);
                var row = 0;
                do
                {
                    date = date.AddDays(1);
                    row += 1;
                    var dateTasks = Tasks.Where(t => t.Dates.Contains(date));
                    var rowLabel = (Label)panel1.Controls.Find($"label{row}", false)[0];
                    foreach (var dateTask in dateTasks)
                    {
                        var label = new Label()
                        {
                            Name = dateTask.Id.ToString() + "," + date.ToString(),
                            Text = dateTask.Title,
                            TextAlign = ContentAlignment.MiddleCenter,
                            Top = rowLabel.Top - theScroll.Height,
                            Left = (int)dateTask.StartTime.Subtract(new DateTime(dateTask.StartTime.Year, dateTask.StartTime.Month, dateTask.StartTime.Day, 0, 0, 0)).TotalMinutes * DPM,
                            Height = rowLabel.Height,
                            Width = (int)dateTask.EndTime.Subtract(dateTask.StartTime).TotalMinutes * DPM,
                            ContextMenuStrip = tasksMenuStrip,
                        };
                        tasksPanel.Controls.Add(label);
                    }
                } while (date != Week.EndDate); 
            }
            nowIndicatorLabel.BringToFront();
        }

        private void ReColor()
        {
            try
            {
                var them = Utils.Utils.GetThem();
                var colorindex = 0;
                foreach (Control control in tasksPanel.Controls)
                {
                    if (control.Name != "Time")
                    {
                        var color = them[colorindex % them.Count];
                        (control as Label).BackColor = color;
                        if (color.GetBrightness() < 0.5)
                        {
                            (control as Label).ForeColor = Color.White;
                        }
                        colorindex += 1;
                    }
                }
            }
            catch (Exception){}
        }

        private void WeeklyTaskViewer_Load(object sender, EventArgs e)
        {
            RefreshTasks();
            ReColor();
        }

        private void TheScroll_ValueChanged(object sender, EventArgs e)
        {
            double positionAspect = (double)theScroll.Value / (double)theScroll.Maximum;
            if (positionAspect > 0.99)
            {
                positionAspect = 1;
            }
            tasksPanel.Left = (int)-(positionAspect * (tasksPanel.Width - scrollPanel.Width));
        }

        private void حذفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var label = ((sender as ToolStripMenuItem).Owner as ContextMenuStrip).SourceControl as Label;
            GetTaskAndDateFromLabel(label, out var date, out var task);

            TaskManager.DoTaskRemovalOperation(task, date);
        }

        private static void GetTaskAndDateFromLabel(Label label, out DateTime date, out Models.Task task)
        {
            var id = label.Name.Split(',')[0];
            date = DateTime.Parse(label.Name.Split(',')[1]);
            using (var context = new AppDBContext())
            {
                task = context.Tasks.Single(t => t.Id.ToString() == id);
            }
        }

        private void ویرایشToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var label = ((sender as ToolStripMenuItem).Owner as ContextMenuStrip).SourceControl as Label;
            GetTaskAndDateFromLabel(label, out var date, out var task);

            TaskManager.DoTaskEditOperation(FindForm(), task, date);
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            nowIndicatorLabel.Left = (int)DateTime.Now.Subtract(DateTime.Now.Date).TotalMinutes * DPM;
        }
    }
}
