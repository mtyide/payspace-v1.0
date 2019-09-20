using Payspace.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Payspace.Models.Repository
{
    public static class ProgressiveRateLookup
    {
        public static int? GetRate(int income)
        {
            var factory = new PSContextFactory();
            using (var context = factory.Create())
            {
                var query = from item in context.ProgressiveRateLookup
                            where (income >= item.From && income <= item.To)
                            select item;

                return query.FirstOrDefault().Rate;
            }
        }
    }
}