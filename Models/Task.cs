using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sahab_Desktop.Models
{
    public class Task
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Location { get; set; }

        public string Peoples { get; set; }

        public string Description { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public string SpecialDates { get; set; }

        public string DaysOfWeek { get; set; }

        public RepeatMethod RepeatMethod { get; set; }
        public int ContinuousTimes { get; set; }
        public int DiscreteTimes { get; set; }

        [JsonIgnore]
        private readonly ObservableListSource<DoctrineRelation> doctrineRelations = new ObservableListSource<DoctrineRelation>();

        [JsonIgnore]
        private readonly ObservableListSource<FrameRelation> frameRelations = new ObservableListSource<FrameRelation>();

        public TaskPriority TaskPriority { get; set; }

        public ulong TaskPriorityScore { get; set; }

        private string ColorHex { get; set; }

        [JsonIgnore]
        [NotMapped]
        public Color? Color
        {
            get
            {
                if (string.IsNullOrEmpty(ColorHex))
                {
                    return null;
                }
                return ColorTranslator.FromHtml(ColorHex);
            }
            set
            {
                if (value.HasValue)
                {
                    ColorHex = ColorTranslator.ToHtml(value.Value);
                }
            }
        }

        [JsonIgnore]
        [NotMapped]
        public List<DateTime> Dates
        {
            get
            {
                var dates = new List<DateTime>();
                switch (RepeatMethod)
                {
                    case RepeatMethod.Daily:
                        var date = StartDate;
                        do
                        {
                            date = date.AddDays(DiscreteTimes);
                            for (int i = 1; i <= ContinuousTimes; i++)
                            {
                                date = date.AddDays(i);
                                dates.Add(date);
                            }
                        } while (date.CompareTo(EndDate) < 0);
                        dates.Add(StartDate);
                        break;
                    case RepeatMethod.Weekly:
                        var daysOfWeeks = DaysOfWeek.Split(',');
                        foreach (var dayOfWeekString in daysOfWeeks)
                        {
                            var dayOfWeek = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), dayOfWeekString);
                            date = StartDate;
                            while (date.DayOfWeek != dayOfWeek && date.CompareTo(EndDate) < 0)
                            {
                                date = date.AddDays(1);
                            }
                            do
                            {
                                dates.Add(date);
                                date = date.AddDays(7);
                            } while (date.CompareTo(EndDate) <= 0);
                        }
                        dates.Add(StartDate);
                        break;
                    case RepeatMethod.Monthly:
                        date = StartDate;
                        do
                        {
                            date = date.AddMonths(DiscreteTimes);
                            for (int i = 1; i <= 1; i++)
                            {
                                date = date.AddDays(i);
                                dates.Add(date);
                            }
                        } while (date.CompareTo(EndDate) < 0);
                        dates.Add(StartDate);
                        break;
                    default:
                        dates.Add(StartDate);
                        break;
                }
                if (!string.IsNullOrEmpty(SpecialDates))
                {
                    dates.AddRange(SpecialDates.Split(',').Select(s => DateTime.Parse(s)));
                }
                return dates;
            }
        }
    }
    public enum RepeatMethod
    {
        Daily = 1,
        Weekly = 2,
        Monthly = 3,
    }
    public enum TaskPriority
    {
        CompulsiveCompulsive = 1,
        CompulsiveNormal = 2,
        CompulsiveDaily = 3,
        NormalCompulsive = 4,
        NormalNormal = 5,
        NormalDaily = 6,
        VariableCompulsive = 7,
        VariableNormal = 8,
        VariableDaily = 9,
    }
}
