using Payspace.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Payspace.Models.Types
{
    public class FlatRate : ITaxCalculationType
    {
        public override void Calculate(int income)
        {
            if (income < 0) { throw new PayspaceException("Income cannot be less than zero"); }

            var rate = Decimal.Divide(17.5M, 100);
            Result = Decimal.Multiply(Convert.ToDecimal(income), rate);
        }
    }
}