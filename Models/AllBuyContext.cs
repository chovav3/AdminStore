using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace storeAdmin.Models
{
    public class AllBuyContext : DbContext
    {
        public AllBuyContext(DbContextOptions<AllBuyContext> options) : base(options)

        {

        }
        public DbSet<AllBuy> All { get; set; }
        //AllBuy
    }
}