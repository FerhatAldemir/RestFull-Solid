using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Example.Entity.Entity;

namespace Example.DataAccessLayer
{
    public class DataContext : DbContext
    {
        DbSet<Vehicles> UserVehicle { get; set; }
        DbSet<User> User { get; set; }

        public DataContext()
        {

            this.Database.AutoTransactionsEnabled = true;
            this.ChangeTracker.LazyLoadingEnabled = false;
            this.ChangeTracker.AutoDetectChangesEnabled = true;
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
             
           

            optionsBuilder.UseSqlServer(Settings.Instance.ConnectionString);


        }
    }
}
