﻿using Payspace.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Payspace.Models.Types
{
    public class FlatValue : ITaxCalculationType
    {
        public override void Calculate(int income)
        {
            if (income < 0) { throw new PayspaceException("Income cannot be less than zero"); }

            var value = 10000;
            if (income < 200000)
            {
                var rate = Decimal.Divide(5, 100);
                Result = Decimal.Multiply(Convert.ToDecimal(income), rate);
            }
            else { Result = Decimal.Subtract(income, value); }
        }
    }
}