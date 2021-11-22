using System;
using System.Collections.Generic;

namespace UTS.Models
{
    public partial class Account
    {
        public int IdAccount { get; set; }
        public int? IdType { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string Phone { get; set; }
    }
}
