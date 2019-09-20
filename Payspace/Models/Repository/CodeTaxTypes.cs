using Payspace.Models.Database;
using Payspace.Models.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Payspace.Models.Repository
{
    public static class CodeTaxTypes
    {
        public static string GetTaxType(string code)
        {
            var factory = new PSContextFactory();
            using (var context = factory.Create())
            {
                var query = from item in context.CodeTaxTypes
                            where (item.Code.Equals(code))
                            select item;

                return query.FirstOrDefault().Type;
            }
        }
    }
}