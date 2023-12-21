using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class ReservationContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //{
            //    IConfigurationRoot configuration = new ConfigurationBuilder()
            //              .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            //              .AddJsonFile("appsettings.json")
            //              .Build();
            //    optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

            optionsBuilder.UseSqlServer(@"Server=localhost,1433;Database=Reservation;User=SA;Password=Password;Trusted_Connection=False;Encrypt=false;");
        }

        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Business> Businesses { get; set; }
        public DbSet<Customer> Customers { get; set; }


    }
}
