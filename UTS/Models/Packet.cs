using System;
using System.Collections.Generic;

namespace UTS.Models
{
    public partial class Packet
    {
        public Packet()
        {
            Order = new HashSet<Order>();
        }

        public int IdPacket { get; set; }
        public string PacketName { get; set; }
        public string PacketTime { get; set; }
        public string Price { get; set; }

        public ICollection<Order> Order { get; set; }
    }
}
