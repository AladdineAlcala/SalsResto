using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalsResto.Data.Models;

namespace SalsResto.Data
{
    public class SalsApplicationDbContext : DbContext
    {

        public SalsApplicationDbContext(DbContextOptions options) :base(options)
        {
            
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Booking> Bookings { get; set; }

    }
}
