using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace storeAdmin.Models
{
    public class ProApiContext : DbContext
    {
        public ProApiContext(DbContextOptions<ProApiContext> options) : base(options)

        {

        }
        public DbSet<ProApi> Products { get; set; }
    }
}