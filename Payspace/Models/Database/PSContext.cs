using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using Payspace.Models.Types;
using System.Data.Entity.Infrastructure;

namespace Payspace.Models.Database
{
    public class PSContext : DbContext
    {
        public PSContext() : base("name=PayspaceEntities") 
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<CodeTaxType> CodeTaxTypes { get; set; }
        public DbSet<ProgressiveRateLookup> ProgressiveRateLookup { get; set; }
        public DbSet<TaxCalculationResult> TaxCalculationResult { get; set; }
    }
}