using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sahab_Desktop.Models
{
    public class DoctrineRelation
    {
        public int Id { set; get; }
        public int? TaskId { get; set; }
        public Task Task { get; set; }
        public int? DoctrineId { get; set; }
        public Doctrine Doctrine { get; set; }
    }
}
