using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Payspace.Models.Types
{
    public class PayspaceException : Exception
    {
        public PayspaceException(string message) { new Exception(message); }
    }
}