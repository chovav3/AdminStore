using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace storeAdmin.Models
{
    public class AllBuyUserContext : DbContext
    {
        public AllBuyUserContext(DbContextOptions<AllBuyUserContext> options) : base(options)

        {

        }
        public DbSet<AllUserBuy> Buy { get; set; }
    }
}