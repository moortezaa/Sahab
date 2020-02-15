using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sahab_Desktop.Models
{
    class Task
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
    }
    public enum RepeatMethod
    {
        Daily = 1,
        Weekly = 2,
        Monthly = 3,
    }
    public enum TaskPriority
    {

    }
}
