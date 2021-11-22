using System;
using System.Collections.Generic;

namespace UTS.Models
{
    public partial class Table
    {
        public Table()
        {
            Order = new HashSet<Order>();
        }

        public int IdTable { get; set; }
        public int? IdOrder { get; set; }
        public DateTime? Start { get; set; }

        public Order IdOrderNavigation { get; set; }
        public ICollection<Order> Order { get; set; }
    }
}
