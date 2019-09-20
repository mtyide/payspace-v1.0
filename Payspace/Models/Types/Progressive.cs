using Payspace.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Payspace.Models.Types
{
    public class Progressive : ITaxCalculationType
    {
        public override void Calculate(int income)
        {
            if (income < 0) { throw new PayspaceException("Income cannot be less than zero"); }
            var rate = Payspace.Models.Repository.ProgressiveRateLookup.GetRate(income);
            if (rate.HasValue)
            {
                var result = Decimal.Divide(rate.Value, 100);
                Result = Decimal.Multiply(Convert.ToDecimal(income), result);
            }
            else { throw new PayspaceException("Income out of range"); }
        }
    }
}