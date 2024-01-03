using INTUS_Backend.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace INTUS_Backend.Repositories
{
    public class APPDBContext:DbContext
    {
        public APPDBContext(DbContextOptions<APPDBContext> options):base(options)
        {

        }
        public DbSet<Order>? Orders { get; set; }
        public DbSet<Window>? Windows { get; set; }
        public DbSet<SubElement>? SubElements { get; set; }
    }
}
