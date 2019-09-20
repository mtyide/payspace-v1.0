using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Payspace.Models.Types;
using Payspace.Models.Database;
using Newtonsoft.Json;

namespace Payspace.Controllers
{
    public class TaxCalculatorController : ApiController
    {
        [HttpPost]
        /// <summary>
        /// This method posts income and code to calculate tax
        /// </summary>
        /// <param name="income"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public decimal CalculateTax(TaxQuery query)
        {
            try
            {
                var getType = Payspace.Models.Repository.CodeTaxTypes.GetTaxType(query.Code);
                decimal tax = 0;
                switch (getType)
                {
                    case "Progressive": tax = CalculateProgressiveTax(query.Income); break;
                    case "Flat Value": tax = CalculateFlatValue(query.Income); break;
                    case "Flat rate": tax = CalculateFlatRate(query.Income); break;
                    default: tax = 0; break;
                }
                if (tax > 0) { SaveChanges(query.Income, query.Code, tax); }

                return tax;
            }
            catch { return 0; }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        #region Helper Classes
        public class TaxQuery
        {
            public TaxQuery() { }
            public int Income { get; set; }
            public string Code { get; set; }
        }
        #endregion

        #region Helper Methods
        private decimal CalculateFlatRate(int income)
        {
            var tax = new FlatRate();
            tax.Calculate(income);
            return tax.Result;
        }

        private decimal CalculateFlatValue(int income)
        {
            var tax = new FlatValue();
            tax.Calculate(income);
            return tax.Result;
        }

        private decimal CalculateProgressiveTax(int income)
        {
            var tax = new Progressive();
            tax.Calculate(income);
            return tax.Result;
        }

        private void SaveChanges(int income, string code, decimal tax)
        {
            var result = Convert.ToInt32(tax);
            var factory = new PSContextFactory();
            using (var context = factory.Create())
            {
                context.TaxCalculationResult.Add(new TaxCalculationResult
                {
                    Code = code,
                    Income = income,
                    Result = result
                });

                context.SaveChanges();
            }
        }
        #endregion
    }
}