using System;
using System.Collections.Generic;

namespace CRMSharp.Models
{
    public partial class Order
    {
        public int Id { get; set; }
        public int? Clientid { get; set; }
        public string Typepresta { get; set; } = null!;
        public string Designation { get; set; } = null!;
        public int Nbdays { get; set; }
        public double Unitprice { get; set; }
        public OrderState State { get; set; }
        public double? Totalexcludetaxe { get; set; }
        public double? Totalwithtaxe { get; set; }

        public virtual Client? Client { get; set; }
    }
}
