using System;
using System.Collections.Generic;

namespace UTS.Models
{
    public partial class OrderStatus
    {
        public OrderStatus()
        {
            Order = new HashSet<Order>();
        }

        public int IdStatus { get; set; }
        public string StatusName { get; set; }

        public ICollection<Order> Order { get; set; }
    }
}
