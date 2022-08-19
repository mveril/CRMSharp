using System;
using System.Collections.Generic;

namespace CRMSharp.Models
{
    public partial class Order
    {
        public int Id { get; set; }
        public int? ClientId { get; set; }
        public string TypePresta { get; set; } = null!;
        public string Designation { get; set; } = null!;
        public int NbDays { get; set; }
        public double UnitPrice { get; set; }
        public OrderState State { get; set; }
        public double? TotalExcludeTaxe { get; set; }
        public double? TotalWithTaxe { get; set; }

        public virtual Client? Client { get; set; }
    }
}
