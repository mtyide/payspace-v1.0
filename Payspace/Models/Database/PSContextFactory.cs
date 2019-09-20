using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace Payspace.Models.Database
{
    public class PSContextFactory : IDbContextFactory<PSContext>
    {
        public PSContext Create()
        {
            return new PSContext();
        }
    }
}