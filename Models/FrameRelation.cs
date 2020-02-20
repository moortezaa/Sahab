using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sahab_Desktop.Models
{
    public class FrameRelation
    {
        public int Id { set; get; }
        public int? TaskId { get; set; }
        public Task Task { get; set; }
        public int? FrameId { get; set; }
        public Frame Frame { get; set; }
    }
}
