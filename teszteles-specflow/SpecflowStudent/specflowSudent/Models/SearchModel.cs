using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SpecflowSudent.Widgets.SearchWidget;

namespace specflowSudent.Models
{
    public class SearchModel
    {
        public string FromCity { get; set; }
        public string ToCity { get; set; }
        public string ViaCity { get; set; }
        public Reductions? Reduction { get; set; }
        public SearchOptions? SearchOption { get; set; }
    }
}
