using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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


        public RepeatMethod RepeatMethod { get; set; }
        public int ContinuousTimes { get; set; }
        public int DiscreteTimes { get; set; }

        private readonly ObservableListSource<DoctrineRelation> doctrineRelations = new ObservableListSource<DoctrineRelation>();

        private readonly ObservableListSource<FrameRelation> frameRelations = new ObservableListSource<FrameRelation>();

        public TaskPriority TaskPriority { get; set; }

        public ulong TaskPriorityScore { get; set; }
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
