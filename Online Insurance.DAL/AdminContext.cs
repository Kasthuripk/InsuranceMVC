using System;
using System.Collections.Generic;
using System.Data.Entity;
using Online_Insurance.Entity;
using System.Text;
using System.Threading.Tasks;

namespace Online_Insurance.DAL
{
    public class AdminContext : DbContext
    {
        public AdminContext() : base("Connection")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>()
            .MapToStoredProcedures(); modelBuilder.Entity<User>()
           .MapToStoredProcedures();
        }
        public DbSet<Admin> Detail { get; set; }
        public DbSet<User> List { get; set; }
    }
}
