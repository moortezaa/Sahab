using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace Sahab_Desktop.Controls
{
    public partial class CalendarView : UserControl
    {
        public event DateSelectEventHandler DateSelect;
        public delegate void DateSelectEventHandler(DateTime date);

        public event WeekSelectEventHandler WeekSelect;
        public delegate void WeekSelectEventHandler(Week week);

        private event ModeChange ModeChanged;
        private delegate void ModeChange(CalendarMode mode);
        private CalendarMode mode { get; set; } = CalendarMode.DaySelect;
        public CalendarMode Mode
        {
            get
            {
                return mode;
            }
            set
            {
                mode = value;
                ModeChanged?.Invoke(value);
            }
        }
        public DateTime SelectedDate { get; set; } = DateTime.Now;
        public Week SelectedWeek { get; set; } = Week.SelectByDateBetween(DateTime.Now);
        private int FirstDayOfMonthLableNumber { get; set; }
        private DateTime FirstDate { get; set; }
        private DateTime FirstDateOfMonth { get; set; }
        private Label SelectedLabel { get; set; }

        public CalendarView()
        {
            InitializeComponent();
            ModeChanged += CalendarView_ModeChanged;
            RefreshSize();
            yearTextBox.Text = SelectedDate.ToString("yyyy", new CultureInfo("fa-IR"));
            monthTextBox.Text = SelectedDate.ToString("MM", new CultureInfo("fa-IR"));
            RefreshDates();

            for (int i = 1; i <= 42; i++)
            {
                var label = Controls.Find($"label{i}", false)[0];
                label.Click += Label_Click;
            }
        }

        private void CalendarView_ModeChanged(CalendarMode mode)
        {
            Label_Click(SelectedLabel, new EventArgs());
        }

        private void Label_Click(object sender, EventArgs e)
        {
            SelectedLabel = sender as Label;
            if (mode == CalendarMode.DaySelect)
            {
                SelectDate(sender as Label);
                SelectSelectedDateLabel();
            }
            else if (mode == CalendarMode.WeekSelect)
            {
                SelectWeek(sender as Label);
                SelectSelectedWeekLabels();
            }
        }

        private void SelectSelectedWeekLabels()
        {
            if (SelectedLabel == null)
            {
                Label label = GetSelectedLableBySelectedDate();
                SelectedLabel = label;
            }
            DeSelectLabels();
            DeSelectWeek();
            var weekSelector = new Label
            {
                Name = "weekSelector",
                Width = Width - 10,
                Left = 5,
                Height = SelectedLabel.Height + 4,
                Top = SelectedLabel.Top - 2,
                BackColor = Color.LightGreen,
                BorderStyle = BorderStyle.FixedSingle,
            };
            Controls.Add(weekSelector);
        }

        private void DeSelectWeek()
        {
            foreach (Control control in Controls)
            {
                if (control.Name == "weekSelector")
                {
                    Controls.Remove(control);
                }
            }
        }

        private void SelectWeek(Label label)
        {
            var dateString = $"{yearTextBox.Text}/{monthTextBox.Text}/{label.Text}";
            SelectedDate = Utils.Utils.ParsePersianDateString(dateString);
            SelectedWeek = Week.SelectByDateBetween(SelectedDate);
            WeekSelect?.Invoke(SelectedWeek);
        }

        private void SelectDate(Label label)
        {
            var dateString = $"{yearTextBox.Text}/{monthTextBox.Text}/{label.Text}";
            SelectedDate = Utils.Utils.ParsePersianDateString(dateString);
            DateSelect?.Invoke(SelectedDate);
        }

        private void SelectSelectedDateLabel()
        {
            DeSelectWeek();
            DeSelectLabels();
            if (SelectedLabel == null)
            {
                Label label = GetSelectedLableBySelectedDate();
                SelectedLabel = label;
            }
            SelectedLabel.BorderStyle = BorderStyle.FixedSingle;
            SelectedLabel.BackColor = Color.LightGreen;
        }

        private Label GetSelectedLableBySelectedDate()
        {
            string labelName = $"label{FirstDayOfMonthLableNumber - 1 + int.Parse(SelectedDate.ToString("dd", new CultureInfo("fa-IR")))}";
            var label = (Label)Controls.Find(labelName, false)[0];
            return label;
        }

        private void DeSelectLabels()
        {
            foreach (var control in Controls)
            {
                if (control.GetType() == typeof(Label))
                {
                    (control as Label).BackColor = saturdayLable.BackColor;
                    (control as Label).BorderStyle = saturdayLable.BorderStyle;
                }
            }
        }

        private void RefreshDates()
        {
            FirstDateOfMonth = Utils.Utils.ParsePersianDateString($"{SelectedDate.ToString("yyyy/MM", new CultureInfo("fa-IR"))}/01");
            var firstDayOfMonthDayOfTheWeek = FirstDateOfMonth.DayOfWeek;
            switch (firstDayOfMonthDayOfTheWeek)
            {
                case DayOfWeek.Sunday:
                    FirstDayOfMonthLableNumber = 2;
                    FirstDate = FirstDateOfMonth.AddDays(-1);
                    break;
                case DayOfWeek.Monday:
                    FirstDayOfMonthLableNumber = 3;
                    FirstDate = FirstDateOfMonth.AddDays(-2);
                    break;
                case DayOfWeek.Tuesday:
                    FirstDayOfMonthLableNumber = 4;
                    FirstDate = FirstDateOfMonth.AddDays(-3);
                    break;
                case DayOfWeek.Wednesday:
                    FirstDayOfMonthLableNumber = 5;
                    FirstDate = FirstDateOfMonth.AddDays(-4);
                    break;
                case DayOfWeek.Thursday:
                    FirstDayOfMonthLableNumber = 6;
                    FirstDate = FirstDateOfMonth.AddDays(-5);
                    break;
                case DayOfWeek.Friday:
                    FirstDayOfMonthLableNumber = 7;
                    FirstDate = FirstDateOfMonth.AddDays(-6);
                    break;
                case DayOfWeek.Saturday:
                    FirstDayOfMonthLableNumber = 1;
                    FirstDate = FirstDateOfMonth.AddDays(0);
                    break;
            }
            for (int i = 1; i <= 42; i++)
            {
                var label = Controls.Find($"label{i}", false)[0];
                var dayString = FirstDate.AddDays(i - 1).ToString("dd", new CultureInfo("fa-IR"));
                if ((i <= 7 && int.Parse(dayString) > 7) || (i > 28 && int.Parse(dayString) < 23))
                {
                    label.Enabled = false;
                }
                else
                {
                    label.Enabled = true;
                }
                label.Text = dayString;
            }
            if (mode == CalendarMode.DaySelect)
            {
                SelectSelectedDateLabel();
            }
            else
            {
                DeSelectLabels();
            }
        }

        private void RefreshSize()
        {
            var one = Width / 8;
            var distance = one;
            fridayLabel.Left = distance - (fridayLabel.Width / 2);
            label7.Left = distance - (label7.Width / 2);
            label14.Left = distance - (label14.Width / 2);
            label21.Left = distance - (label21.Width / 2);
            label28.Left = distance - (label28.Width / 2);
            label35.Left = distance - (label35.Width / 2);
            label42.Left = distance - (label42.Width / 2);
            distance += one;
            thursdayLable.Left = distance - (thursdayLable.Width / 2);
            label6.Left = distance - (label6.Width / 2);
            label13.Left = distance - (label13.Width / 2);
            label20.Left = distance - (label20.Width / 2);
            label27.Left = distance - (label27.Width / 2);
            label34.Left = distance - (label34.Width / 2);
            label41.Left = distance - (label41.Width / 2);
            distance += one;
            wednesdayLable.Left = distance - (wednesdayLable.Width / 2);
            label5.Left = distance - (label5.Width / 2);
            label12.Left = distance - (label12.Width / 2);
            label19.Left = distance - (label19.Width / 2);
            label26.Left = distance - (label26.Width / 2);
            label33.Left = distance - (label33.Width / 2);
            label40.Left = distance - (label40.Width / 2);
            distance += one;
            tuesdayLable.Left = distance - (tuesdayLable.Width / 2);
            label4.Left = distance - (label4.Width / 2);
            label11.Left = distance - (label11.Width / 2);
            label18.Left = distance - (label18.Width / 2);
            label25.Left = distance - (label25.Width / 2);
            label32.Left = distance - (label32.Width / 2);
            label39.Left = distance - (label39.Width / 2);
            distance += one;
            mondayLable.Left = distance - (mondayLable.Width / 2);
            label3.Left = distance - (label3.Width / 2);
            label10.Left = distance - (label10.Width / 2);
            label17.Left = distance - (label17.Width / 2);
            label24.Left = distance - (label24.Width / 2);
            label31.Left = distance - (label31.Width / 2);
            label38.Left = distance - (label38.Width / 2);
            distance += one;
            sundayLable.Left = distance - (sundayLable.Width / 2);
            label2.Left = distance - (label2.Width / 2);
            label9.Left = distance - (label9.Width / 2);
            label16.Left = distance - (label16.Width / 2);
            label23.Left = distance - (label23.Width / 2);
            label30.Left = distance - (label30.Width / 2);
            label37.Left = distance - (label37.Width / 2);
            distance += one;
            saturdayLable.Left = distance - (saturdayLable.Width / 2);
            label1.Left = distance - (label1.Width / 2);
            label8.Left = distance - (label8.Width / 2);
            label15.Left = distance - (label15.Width / 2);
            label22.Left = distance - (label22.Width / 2);
            label29.Left = distance - (label29.Width / 2);
            label36.Left = distance - (label36.Width / 2);
        }

        private void CalendarView_Resize(object sender, EventArgs e)
        {
            RefreshSize();
        }

        private void YearTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(monthTextBox.Text) && SelectedLabel != null)
            {
                SelectDate(SelectedLabel);
                RefreshDates();
            }
        }

        private void MonthTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(yearTextBox.Text) && SelectedLabel != null)
            {
                SelectDate(SelectedLabel);
                RefreshDates();
            }
        }

        private void IncreaseYearButton_Click(object sender, EventArgs e)
        {
            yearTextBox.Text = (int.Parse(yearTextBox.Text) + 1).ToString();
        }

        private void DecreaseYearButton_Click(object sender, EventArgs e)
        {
            yearTextBox.Text = (int.Parse(yearTextBox.Text) - 1).ToString();
        }

        private void IncreaseMonthButton_Click(object sender, EventArgs e)
        {
            int month = int.Parse(monthTextBox.Text);
            month += 1;
            if (month > 12)
            {
                month = 12;
            }
            monthTextBox.Text = month.ToString();
        }

        private void DecreaseMonthButton_Click(object sender, EventArgs e)
        {
            int month = int.Parse(monthTextBox.Text);
            month -= 1;
            if (month < 1)
            {
                month = 1;
            }
            monthTextBox.Text = month.ToString();
        }
    }

    public enum CalendarMode
    {
        DaySelect,
        WeekSelect,
        MonthSelect,
    }

    public class Week
    {
        private DateTime? startDate;
        public DateTime? StartDate
        {
            get
            {
                return startDate;
            }
            set
            {
                if (value.HasValue)
                {
                    startDate = value.Value.Date;
                }
                else
                {
                    startDate = value;
                }
            }
        }
        private DateTime endDate;
        public DateTime EndDate
        {
            get
            {
                return endDate;
            }
            set
            {
                endDate = value.Date;
            }
        }

        public static Week SelectByDateBetween(DateTime date)
        {
            while (date.DayOfWeek != DayOfWeek.Friday)
            {
                date = date.AddDays(1);
            }
            var week = new Week()
            {
                EndDate = date,
                StartDate = date.AddDays(-6)
            };
            return week;
        }
    }
}
