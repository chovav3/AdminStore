﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace storeAdmin.Models
{
    public class AllUserBuy
    {
        public int id { get; set; }
        public int price { get; set; }
        public int quantity { get; set; }
        public int cunsumerId { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string proName { get; set; }
        public string catName { get; set; }
        public string date { get; set; }
        public int OrderId { get; set; }
    }
}
