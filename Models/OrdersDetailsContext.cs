using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace storeAdmin.Models
{
    public class OrdersDetailsContext : DbContext
    {
        public OrdersDetailsContext(DbContextOptions<OrdersDetailsContext> options) : base(options)

        {

        }
        public DbSet<OrderDetails> OrderDetails { get; set; }
    }
}
