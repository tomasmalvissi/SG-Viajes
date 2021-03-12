using Microsoft.EntityFrameworkCore;
using SGVIAJES.DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGVIAJES.WEB.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Viaje> Viajes { get; set; }
    }
}
