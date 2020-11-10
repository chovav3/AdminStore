using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace storeAdmin.Models
{
    public class CatApiContext : DbContext
    {
        public CatApiContext(DbContextOptions<CatApiContext> options) : base(options)

        {

        }
        public DbSet<CatApi> Categories { get; set; }
    }
}