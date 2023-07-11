using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CarsMangment.Models;

namespace CarsMangment.Data
{
    public class CarsMangmentContext : DbContext
    {
        public CarsMangmentContext (DbContextOptions<CarsMangmentContext> options)
            : base(options)
        {
        }

        public DbSet<CarsMangment.Models.Car> Cars { get; set; } = default!;
        public DbSet<CarsMangment.Models.Driver> Drivers { get; set; } = default!;
        public DbSet<CarsMangment.Models.Customer> Customers { get; set; } = default!;

    }
}
