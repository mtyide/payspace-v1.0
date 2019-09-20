using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Payspace.Models.Interfaces
{
    public class ITaxCalculationType
    {
        public decimal Result { get; set; }
        public virtual void Calculate(int income) { }
    }
}