using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Payspace.Models.Types
{
    public class TaxCalculationResult
    {
        public int Id { get; set; }
        public Nullable<int> Result { get; set; }
        public string Code { get; set; }
        public Nullable<int> Income { get; set; }
    }
}