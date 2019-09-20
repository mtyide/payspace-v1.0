using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Payspace.Models.Types
{
    public class ProgressiveRateLookup
    {
        public int Id { get; set; }
        public Nullable<int> Rate { get; set; }
        public Nullable<int> From { get; set; }
        public Nullable<int> To { get; set; }
    }
}