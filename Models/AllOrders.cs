using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace storeAdmin.Models
{
    public class AllOrders
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string cat { get; set; }
        public string product { get; set; }
        public int price { get; set; }
        public string date { get; set; }
    }
}
