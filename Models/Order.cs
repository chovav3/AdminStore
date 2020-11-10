using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace storeAdmin.Models
{
    public class Order
    {
        public int id { get; set; }
        public int customerId { get; set; }
        public string date { get; set; }
    }
}
