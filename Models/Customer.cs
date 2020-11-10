using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace storeAdmin.Models
{
    public class Customer
    {
        public int id { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public string image { get; set; }
        public string phone { get; set; }
        public string callingcode { get; set; }
    }
}
