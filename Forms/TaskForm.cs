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
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sahab_Desktop
{
    public partial class TaskForm : Form
    {
        public event TaskSubmitEventHandler OnTaskSubmited;

        public delegate void TaskSubmitEventHandler(Models.Task task);

        public Models.Task Task { get; set; } = new Models.Task();

        AppDBContext _context;
        public List<Doctrine> Doctrines = new List<Doctrine>();
        public List<Frame> Frames = new List<Frame>();
        public RepeatMethod RepeatMethod { get; set; } = RepeatMethod.Daily;
        public DateTime? EndDate { get; set; } = null;
        public TaskPriority TaskPriority { get; set; }
        public ulong TaskPriorityScore { get; set; }
        public List<DayOfWeek> DayOfWeeks = new List<DayOfWeek>();
        private bool IsEditMode { set; get; } = false;
        public TaskForm()
        {
            InitializeComponent();
            SetWeeklyImageCheckBoxesImage();

            _context = new AppDBContext();

            StartDateTextBox.Text = DateTime.Now.ToString("yyyy/MM/dd", new CultureInfo("fa-IR"));

            RefreshDoctrineComboBox();

            RefreshFrameComboBox();

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
            HideWeeklyGroup();
        }

        private void SetWeeklyImageCheckBoxesImage()
        {
            fridayImageCheckBox.UnCheckedImage = Properties.Resources.friday_unchecked;
            fridayImageCheckBox.CheckedImage = Properties.Resources.friday_checked;
            fridayImageCheckBox.RefreshImages();
            fridayImageCheckBox.CheckedChange += FridayImageCheckBox_CheckedChange; ;
            ThursdayImageCheckBox.UnCheckedImage = Properties.Resources.thursday_unchecked;
            ThursdayImageCheckBox.CheckedImage = Properties.Resources.thursday_checked;
            ThursdayImageCheckBox.RefreshImages();
            ThursdayImageCheckBox.CheckedChange += ThursdayImageCheckBox_CheckedChange;
            wednesdayImageCheckBox.UnCheckedImage = Properties.Resources.wednesday_unchecked;
            wednesdayImageCheckBox.CheckedImage = Properties.Resources.wednesday_checked;
            wednesdayImageCheckBox.RefreshImages();
            wednesdayImageCheckBox.CheckedChange += WednesdayImageCheckBox_CheckedChange; ;
            tuesdayImageCheckBox.UnCheckedImage = Properties.Resources.tusday_unchecked;
            tuesdayImageCheckBox.CheckedImage = Properties.Resources.tusday_checked;
            tuesdayImageCheckBox.RefreshImages();
            tuesdayImageCheckBox.CheckedChange += TuesdayImageCheckBox_CheckedChange;
            mondayImageCheckBox.UnCheckedImage = Properties.Resources.monday_unchecked;
            mondayImageCheckBox.CheckedImage = Properties.Resources.monday_checked;
            mondayImageCheckBox.RefreshImages();
            mondayImageCheckBox.CheckedChange += MondayImageCheckBox_CheckedChange;
            sundayImageCheckBox.UnCheckedImage = Properties.Resources.sunday_unchecked;
            sundayImageCheckBox.CheckedImage = Properties.Resources.sunday_checked;
            sundayImageCheckBox.RefreshImages();
            sundayImageCheckBox.CheckedChange += SundayImageCheckBox_CheckedChange;
            saturdayImageCheckBox.UnCheckedImage = Properties.Resources.saturday_unchecked;
            saturdayImageCheckBox.CheckedImage = Properties.Resources.saturday_checked;
            saturdayImageCheckBox.RefreshImages();
            saturdayImageCheckBox.CheckedChange += SaturdayImageCheckBox_CheckedChange;
        }

        private void SaturdayImageCheckBox_CheckedChange(object sender, EventArgs e)
        {
            DayOfWeeks.Add(DayOfWeek.Saturday);
        }

        private void SundayImageCheckBox_CheckedChange(object sender, EventArgs e)
        {
            DayOfWeeks.Add(DayOfWeek.Sunday);
        }

        private void MondayImageCheckBox_CheckedChange(object sender, EventArgs e)
        {
            DayOfWeeks.Add(DayOfWeek.Monday);
        }

        private void TuesdayImageCheckBox_CheckedChange(object sender, EventArgs e)
        {
            DayOfWeeks.Add(DayOfWeek.Tuesday);
        }

        private void WednesdayImageCheckBox_CheckedChange(object sender, EventArgs e)
        {
            DayOfWeeks.Add(DayOfWeek.Wednesday);
        }

        private void ThursdayImageCheckBox_CheckedChange(object sender, EventArgs e)
        {
            DayOfWeeks.Add(DayOfWeek.Thursday);
        }

        private void FridayImageCheckBox_CheckedChange(object sender, EventArgs e)
        {
            DayOfWeeks.Add(DayOfWeek.Friday);
        }

        private void RefreshDoctrineComboBox()
        {
            DoctrinesComboBox.Items.AddRange(_context.Doctrines.ToArray());
            DoctrinesComboBox.Items.Add(new Doctrine() { Id = -1, Name = "اضافه کردن اصل جدید" });
            DoctrinesComboBox.DisplayMember = nameof(Doctrine.Name);
            DoctrinesComboBox.ValueMember = nameof(Doctrine.Id);
        }

        private void RefreshFrameComboBox()
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
                    RefreshFrameComboBox();
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
            bool valid = true;

            Task.Title = TitleTextBox.Text;
            Task.Location = LocationTextBox.Text;
            Task.Peoples = PeoplesTextBox.Text;
            Task.Description = DescriptionTextBox.Text;
            Task.StartTime = Utils.Utils.ParsePersianTimeString(StartTimeTextBox.Text);
            Task.StartDate = Utils.Utils.ParsePersianDateString(StartDateTextBox.Text);
            Task.EndTime = Utils.Utils.ParsePersianTimeString(EndTimeTextBox.Text);
            Task.EndDate = Utils.Utils.ParsePersianDateString(StartDateTextBox.Text);
            Task.TaskPriority = TaskPriority;
            Task.TaskPriorityScore = TaskPriorityScore;


            foreach (var frame in Frames)
            {
                _context.Frames.Attach(frame);
                var relation = new FrameRelation()
                {
                    Frame = frame,
                    Task = Task
                };
                _context.FrameRelations.Add(relation);
            }
            foreach (var doctrine in Doctrines)
            {
                _context.Doctrines.Attach(doctrine);
                var relation = new DoctrineRelation()
                {
                    Doctrine = doctrine,
                    Task = Task
                };
                _context.DoctrineRelations.Add(relation);
            }

            if (RepeatCheckBox.Checked)
            {
                Task.RepeatMethod = RepeatMethod;
                Task.ContinuousTimes = (int)ContinuousTimesNumeric.Value;
                Task.DiscreteTimes = (int)DiscreteTimesNumeric.Value;
                if (EndDate != null)
                {
                    Task.EndDate = EndDate.Value;
                }
                else
                {
                    EffectiveControllsOnEndDate_Changed(sender, e);
                    Task.EndDate = EndDate.Value;
                }
                if (specialDaysListBox.Items.Count != 0)
                {
                    Task.SpecialDates = string.Join(",", specialDaysListBox.Items);
                    foreach (string dateString in specialDaysListBox.Items)
                    {
                        DateTime date = Utils.Utils.ParsePersianDateString(dateString);
                        if (Task.EndDate.CompareTo(date) < 0)
                        {
                            Task.EndDate = date;
                        }
                        if (Task.StartDate.CompareTo(date) > 0)
                        {
                            Task.StartDate = date;
                        }
                    }
                }
                else if (Task.StartDate.CompareTo(Task.EndDate)==0)
                {
                    Task.RepeatMethod = 0;
                }
                if (WeeklyRadioButton.Checked)
                {
                    Task.DaysOfWeek = string.Join(",", DayOfWeeks);
                }
            }
            if (!IsEditMode)
            {
                _context.Tasks.Add(Task);
            }
            _context.SaveChanges();
            OnTaskSubmited?.Invoke(Task);
            DialogResult = DialogResult.OK;
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
                ContinuousTimesNumeric.Enabled = true;
                HideWeeklyGroup();
            }
        }

        private void HideWeeklyGroup()
        {
            weekDaysGroupBox.Visible = false;
            specialDaysGroupBox.Height += specialDaysGroupBox.Top - 35;
            specialDaysGroupBox.Top = 35;
        }

        private void WeeklyRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                RepeatMethod = RepeatMethod.Weekly;
                EffectiveControllsOnEndDate_Changed(sender, e);
                ContinuousTimesNumeric.Enabled = false;
                ShowWeeklyGroup();
            }
        }

        private void ShowWeeklyGroup()
        {
            weekDaysGroupBox.Visible = true;
            specialDaysGroupBox.Top += 61;
            specialDaysGroupBox.Height -= 61;
        }

        private void MonthlyRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                RepeatMethod = RepeatMethod.Monthly;
                EffectiveControllsOnEndDate_Changed(sender, e);
                ContinuousTimesNumeric.Enabled = false;
                HideWeeklyGroup();
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
                            EndDate = Utils.Utils.ParsePersianDateString(StartDateTextBox.Text).AddDays((double)(RepeatTimesNumeric.Value * (ContinuousTimesNumeric.Value + DiscreteTimesNumeric.Value)));
                            break;
                        case RepeatMethod.Weekly:
                            EndDate = Utils.Utils.ParsePersianDateString(StartDateTextBox.Text).AddDays((double)(RepeatTimesNumeric.Value * (ContinuousTimesNumeric.Value + DiscreteTimesNumeric.Value)) * 7);
                            break;
                        case RepeatMethod.Monthly:
                            EndDate = Utils.Utils.ParsePersianDateString(StartDateTextBox.Text).AddMonths((int)(RepeatTimesNumeric.Value * (ContinuousTimesNumeric.Value + DiscreteTimesNumeric.Value)));
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
                            EndDate = Utils.Utils.ParsePersianDateString(StartDateTextBox.Text).AddDays((double)PeriodNumeric.Value);
                            break;
                        case "هفته":
                            EndDate = Utils.Utils.ParsePersianDateString(StartDateTextBox.Text).AddDays((double)(PeriodNumeric.Value * 7));
                            break;
                        case "ماه":
                            EndDate = Utils.Utils.ParsePersianDateString(StartDateTextBox.Text).AddMonths((int)PeriodNumeric.Value);
                            break;
                        case "سال":
                            EndDate = Utils.Utils.ParsePersianDateString(StartDateTextBox.Text).AddYears((int)PeriodNumeric.Value);
                            break;
                    }
                }
            }
            else if (UpToDateRadioButton.Checked)
            {
                if (!string.IsNullOrEmpty(UpToDateTextBox.Text))
                {
                    try
                    {
                        EndDate = Utils.Utils.ParsePersianDateString(UpToDateTextBox.Text);
                    }
                    catch (Exception)
                    {
                        //ignore
                    }
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

        private void AdvancedCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as CheckBox).Checked)
            {
                advancedGroupBox.Enabled = true;
            }
            else
            {
                advancedGroupBox.Enabled = false;
            }
        }

        private void AddSpecialDayButton_Click(object sender, EventArgs e)
        {
            var specialDate = Utils.Utils.ParsePersianDateString(specialDateTextBox.Text);
            specialDateTextBox.Text = "";
            specialDaysListBox.Items.Add(specialDate.ToString("yyyy/MM/dd", new CultureInfo("fa-IR")));
        }

        private void TaskForm_Load(object sender, EventArgs e)
        {
            var task = _context.Tasks.SingleOrDefault(t => t.Id == Task.Id);
            if (task != null)
            {
                IsEditMode = true;
            }

            if (!string.IsNullOrEmpty(Task.Title))
            {
                TitleTextBox.Text = Task.Title;
                LocationTextBox.Text = Task.Location;
                PeoplesTextBox.Text = Task.Peoples;
                DescriptionTextBox.Text = Task.Description;
                StartTimeTextBox.Text = Task.StartTime.ToString("HH:mm", new CultureInfo("fa-IR"));
                EndTimeTextBox.Text = Task.EndTime.ToString("HH:mm", new CultureInfo("fa-IR"));
                StartDateTextBox.Text = Task.StartDate.ToString("yyyy/MM/dd", new CultureInfo("fa-IR"));
                if (Task.RepeatMethod != 0)
                {
                    switch (Task.RepeatMethod)
                    {
                        case RepeatMethod.Daily:
                            RepeatCheckBox.Checked = true;
                            DailyRadioButton.Checked = true;
                            break;
                        case RepeatMethod.Weekly:
                            RepeatCheckBox.Checked = true;
                            WeeklyRadioButton.Checked = true;
                            var daysOfWeeks = Task.DaysOfWeek.Split(',');
                            foreach (var dayOfWeekString in daysOfWeeks)
                            {
                                var dayOfWeek = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), dayOfWeekString);
                                switch (dayOfWeek)
                                {
                                    case DayOfWeek.Sunday:
                                        sundayImageCheckBox.Checked = true;
                                        break;
                                    case DayOfWeek.Monday:
                                        mondayImageCheckBox.Checked = true;
                                        break;
                                    case DayOfWeek.Tuesday:
                                        tuesdayImageCheckBox.Checked = true;
                                        break;
                                    case DayOfWeek.Wednesday:
                                        wednesdayImageCheckBox.Checked = true;
                                        break;
                                    case DayOfWeek.Thursday:
                                        ThursdayImageCheckBox.Checked = true;
                                        break;
                                    case DayOfWeek.Friday:
                                        fridayImageCheckBox.Checked = true;
                                        break;
                                    case DayOfWeek.Saturday:
                                        saturdayImageCheckBox.Checked = true;
                                        break;
                                }
                            }
                            break;
                        case RepeatMethod.Monthly:
                            RepeatCheckBox.Checked = true;
                            MonthlyRadioButton.Checked = true;
                            break;
                    }
                    if (Task.SpecialDates != null)
                    {
                        specialDaysListBox.Items.AddRange(Task.SpecialDates.Split(','));
                    }
                    ContinuousTimesNumeric.Value = Task.ContinuousTimes;
                    DiscreteTimesNumeric.Value = Task.DiscreteTimes;
                    UpToDateRadioButton.Checked = true;
                    UpToDateTextBox.Text = Task.EndDate.ToString("yyyy/MM/dd", new CultureInfo("fa-IR"));
                }
            }

            if (IsEditMode)
            {
                Task = task;
            }
            else
            {
                Task = new Models.Task();
            }
        }
    }
}
