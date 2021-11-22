using System;
using System.Collections.Generic;

namespace UTS.Models
{
    public partial class Order
    {
        public Order()
        {
            Table = new HashSet<Table>();
        }

        public int IdOrder { get; set; }
        public int? IdPacket { get; set; }
        public int? IdUser { get; set; }
        public int? IdStatus { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? ExpireDate { get; set; }
        public string CodePayment { get; set; }

        public Table IdPacket1 { get; set; }
        public Packet IdPacketNavigation { get; set; }
        public OrderStatus IdStatusNavigation { get; set; }
        public ICollection<Table> Table { get; set; }
    }
}
