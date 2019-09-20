using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Payspace;
using Payspace.Controllers;

namespace Payspace.Tests.Controllers
{
    [TestClass]
    public class TaxCalculatorControllerTest
    {
        [TestMethod]
        public void CalculateTax()
        {
            var controller = new TaxCalculatorController();
            var result = controller.CalculateTax(new TaxCalculatorController.TaxQuery { Code = "7441", Income = 8351 });

            Assert.IsNotNull(result);
            Assert.AreEqual(1252.65M, result);
            Assert.AreNotEqual(0M, result);
        }
    }
}
