using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace storeAdmin.Models
{
    public class ProApi
    {
        public int id { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        public int amunt { get; set; }
        public int catId { get; set; }
        public string title { get; set; }
        public string date { get; set; }
        public string productContent { get; set; }
        public string image { get; set; }
    }
}
