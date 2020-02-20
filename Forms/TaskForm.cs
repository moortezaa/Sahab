using Sahab_Desktop.Forms;
using Sahab_Desktop.Models;
using Sahab_Desktop.Utils;
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
    public partial class TaskForm : Form
    {
        public event EventHandler OnTaskSubmited;
        AppDBContext _context;
        public List<Doctrine> Doctrines = new List<Doctrine>();
        public List<Frame> Frames = new List<Frame>();
        public RepeatMethod RepeatMethod { get; set; } = RepeatMethod.Daily;
        public DateTime EndDate { get; set; }
        public TaskPriority TaskPriority { get; set; }
        public ulong TaskPriorityScore { get; set; }
        public TaskForm()
        {
            InitializeComponent();
            _context = new AppDBContext();

            RefreshDoctrineComboBox();

            RefreshFramComboBox();

            PeriodComboBox.Items.AddRange(new object[]
                {
                    "لطفا انتخاب کنید",
                    "روز",
                    "هفته",
                    "ماه",
                    "سال",
                });
            TaskPriorityComboBox.Items.AddRange(new object[]
            {
                "لطفا انتخاب کنید",
                "ضروری ضروری",
                "ضروری عادی",
                "ضروری روزمره",
                "عادی ضروری",
                "عادی عادی",
                "عادی روزمره",
                "متغییر ضروری",
                "متغییر عادی",
                "متغییر روزمره",
            });
        }

        private void RefreshDoctrineComboBox()
        {
            DoctrinesComboBox.Items.AddRange(_context.Doctrines.ToArray());
            DoctrinesComboBox.Items.Add(new Doctrine() { Id = -1, Name = "اضافه کردن اصل جدید" });
            DoctrinesComboBox.DisplayMember = nameof(Doctrine.Name);
            DoctrinesComboBox.ValueMember = nameof(Doctrine.Id);
        }

        private void RefreshFramComboBox()
        {
            FramesComboBox.Items.Clear();
            FramesComboBox.Items.AddRange(_context.Frames.ToArray());
            FramesComboBox.Items.Add(new Frame() { Id = -1, Name = "اضافه کردن چهرچوب جدید" });
            FramesComboBox.DisplayMember = nameof(Frame.Name);
            FramesComboBox.ValueMember = nameof(Frame.Id);
        }

        private void FramesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((Frame)((ComboBox)sender).SelectedItem).Id == -1)
            {
                var frameForm = new FrameForm();
                if (frameForm.ShowDialog() == DialogResult.OK)
                {
                    RefreshFramComboBox();
                }
            }
        }

        private void DoctrineComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((Doctrine)((ComboBox)sender).SelectedItem).Id == -1)
            {
                var doctrineForm = new DoctrineForm();
                if (doctrineForm.ShowDialog() == DialogResult.OK)
                {
                    RefreshDoctrineComboBox();
                }
            }
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {

            var task = new Models.Task()
            {
                Title = TitleTextBox.Text,
                Location = LocationTextBox.Text,
                Peoples = PeaoplesTextBox.Text,
                Description = DescriptionTextBox.Text,
                StartTime = Utils.Utils.ParsePersianTimeString(StartTimeTextBox.Text),
                StartDate =Utils.Utils.ParsePersianDateString(StartDateTextBox.Text),
                EndTime = Utils.Utils.ParsePersianTimeString(EndTimeTextBox.Text),
                EndDate = Utils.Utils.ParsePersianDateString(StartDateTextBox.Text),
                TaskPriority = TaskPriority,
                TaskPriorityScore = TaskPriorityScore
            };
            foreach (var frame in Frames)
            {
                _context.Frames.Attach(frame);
                var relation = new FrameRelation()
                {
                    Frame = frame,
                    Task = task
                };
                _context.FrameRelations.Add(relation);
            }
            foreach (var doctrine in Doctrines)
            {
                _context.Doctrines.Attach(doctrine);
                var relation = new DoctrineRelation()
                {
                    Doctrine = doctrine,
                    Task = task
                };
                _context.DoctrineRelations.Add(relation);
            }

            if (RepeatCheckBox.Checked)
            {
                task.RepeatMethod = RepeatMethod;
                task.ContinuousTimes = (int)ContinuousTimesNumeric.Value;
                task.DiscreteTimes = (int)DiscreteTimesNumeric.Value;
                task.EndDate = EndDate;
            }

            _context.Tasks.Add(task);
            _context.SaveChanges();
            OnTaskSubmited?.Invoke(sender, new EventArgs());
            Close();
        }

        private void FrameButton_Click(object sender, EventArgs e)
        {
            FramesListBox.Items.Add(((Frame)FramesComboBox.SelectedItem).Name);
            Frames.Add((Frame)FramesComboBox.SelectedItem);
            TaskPriorityComboBox_SelectedIndexChanged(sender, e);
        }

        private void DoctrineButton_Click(object sender, EventArgs e)
        {
            DoctrinesListBox.Items.Add(((Doctrine)DoctrinesComboBox.SelectedItem).Name);
            Doctrines.Add((Doctrine)DoctrinesComboBox.SelectedItem);
            TaskPriorityComboBox_SelectedIndexChanged(sender, e);
        }

        private void RepeatCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!(sender as CheckBox).Checked)
            {
                RepeatGroupBox.Enabled = false;
            }
            else
            {
                RepeatGroupBox.Enabled = true;
            }
        }

        private void DailyRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                RepeatMethod = RepeatMethod.Daily;
                EffectiveControllsOnEndDate_Changed(sender, e);
            }
        }

        private void WeeklyRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                RepeatMethod = RepeatMethod.Weekly;
                EffectiveControllsOnEndDate_Changed(sender, e);
            }
        }

        private void MonthlyRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                RepeatMethod = RepeatMethod.Monthly;
                EffectiveControllsOnEndDate_Changed(sender, e);
            }
        }

        private void EffectiveControllsOnEndDate_Changed(object sender, EventArgs e)
        {
            if (RepeatTimesRadioButton.Checked)
            {
                if (StartDateTextBox.Text != null)
                {
                    switch (RepeatMethod)
                    {
                        case RepeatMethod.Daily:
                            EndDate =DateTime.ParseExact(StartDateTextBox.Text,"yyyy/MM/dd",new CultureInfo("fa-IR")).ToUniversalTime().ToUniversalTime().ToLocalTime().AddDays((double)(RepeatTimesNumeric.Value * (ContinuousTimesNumeric.Value + DiscreteTimesNumeric.Value)));
                            break;
                        case RepeatMethod.Weekly:
                            EndDate =DateTime.ParseExact(StartDateTextBox.Text,"yyyy/MM/dd",new CultureInfo("fa-IR")).ToUniversalTime().ToLocalTime().AddDays((double)(RepeatTimesNumeric.Value * (ContinuousTimesNumeric.Value + DiscreteTimesNumeric.Value)) * 7);
                            break;
                        case RepeatMethod.Monthly:
                            EndDate =DateTime.ParseExact(StartDateTextBox.Text,"yyyy/MM/dd",new CultureInfo("fa-IR")).ToUniversalTime().ToLocalTime().AddMonths((int)(RepeatTimesNumeric.Value * (ContinuousTimesNumeric.Value + DiscreteTimesNumeric.Value)));
                            break;
                    }
                }
            }
            else if (PeriodRadioButton.Checked)
            {

                if (StartDateTextBox.Text != null && PeriodComboBox.SelectedItem != null)
                {
                    var period = PeriodComboBox.SelectedItem.ToString();
                    switch (period)
                    {
                        case "روز":
                            EndDate =DateTime.ParseExact(StartDateTextBox.Text,"yyyy/MM/dd",new CultureInfo("fa-IR")).ToUniversalTime().ToLocalTime().AddDays((double)PeriodNumeric.Value);
                            break;
                        case "هفته":
                            EndDate =DateTime.ParseExact(StartDateTextBox.Text,"yyyy/MM/dd",new CultureInfo("fa-IR")).ToUniversalTime().ToLocalTime().AddDays((double)(PeriodNumeric.Value * 7));
                            break;
                        case "ماه":
                            EndDate =DateTime.ParseExact(StartDateTextBox.Text,"yyyy/MM/dd",new CultureInfo("fa-IR")).ToUniversalTime().ToLocalTime().AddMonths((int)PeriodNumeric.Value);
                            break;
                        case "سال":
                            EndDate =DateTime.ParseExact(StartDateTextBox.Text,"yyyy/MM/dd",new CultureInfo("fa-IR")).ToUniversalTime().ToLocalTime().AddYears((int)PeriodNumeric.Value);
                            break;
                    }
                }
            }
            else if (UpToDateRadioButton.Checked)
            {
                if (string.IsNullOrEmpty(UpToDateTextBox.Text))
                {
                    EndDate = DateTime.Parse(UpToDateTextBox.Text);
                }
            }
        }

        private void TaskPriorityComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var taskPeriorityString = string.Empty;
            if (TaskPriorityComboBox.SelectedItem != null)
            {
                taskPeriorityString = (string)TaskPriorityComboBox.SelectedItem;
            }
            switch (taskPeriorityString)
            {
                case "ضروری ضروری":
                    TaskPriority = TaskPriority.CompulsiveCompulsive;
                    break;
                case "ضروری عادی":
                    TaskPriority = TaskPriority.CompulsiveNormal;
                    break;
                case "ضروری روزمره":
                    TaskPriority = TaskPriority.CompulsiveDaily;
                    break;
                case "عادی ضروری":
                    TaskPriority = TaskPriority.NormalCompulsive;
                    break;
                case "عادی عادی":
                    TaskPriority = TaskPriority.NormalNormal;
                    break;
                case "عادی روزمره":
                    TaskPriority = TaskPriority.NormalDaily;
                    break;
                case "متغییر ضروری":
                    TaskPriority = TaskPriority.VariableCompulsive;
                    break;
                case "متغییر عادی":
                    TaskPriority = TaskPriority.VariableNormal;
                    break;
                case "متغییر روزمره":
                    TaskPriority = TaskPriority.VariableDaily;
                    break;
                default:
                    TaskPriority = TaskPriority.NormalNormal;
                    break;
            }
            TaskPriorityScore = TaskPriorityEffectCalculator.CalculatePeriorityScore(Doctrines, Frames, TaskPriority);
            PriorityScoreLable.Text = TaskPriorityScore.ToString();
            PriorityScoreLable.ForeColor = Color.Red;
        }
    }
}
