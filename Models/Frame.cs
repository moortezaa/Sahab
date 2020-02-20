using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sahab_Desktop.Models
{
    public class Frame
    {
        public int Id { get; set; }
        public int Score { get; set; }
        public string Name { get; set; }

        private readonly ObservableListSource<FrameRelation> frameRelations = new ObservableListSource<FrameRelation>();
    }
}
