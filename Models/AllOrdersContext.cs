using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace storeAdmin.Models
{
    public class AllOrdersContext : DbContext
    {
        public AllOrdersContext(DbContextOptions<AllOrdersContext> options) : base(options)

        {

        }
        public DbSet<AllOrders> All_Orders { get; set; }
    }
}