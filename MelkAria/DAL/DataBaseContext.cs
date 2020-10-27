using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using MelkAria.Models;

namespace MelkAria.DAL
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext() : base("DataBaseContext")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            Database.SetInitializer(new CreateDatabaseIfNotExists<DataBaseContext>());
        }
        public DbSet<user> Users { get; set; }
        public DbSet<role> Roles { get; set; }
        //public DbSet<city> cities { get; set; }
        //public DbSet<melkstatus> melkstatuss { get; set; }

        public DbSet<rule> rules { get; set; }
        public DbSet<contactUs> contactUss { get; set; }
        public DbSet<aboutUs> aboutUss { get; set; }
        public DbSet<melk> melks { get; set; }
        public DbSet<photo> photos { get; set; }
        //public DbSet<schedule> schedules { get; set; }
        public DbSet<userFavorite> userFavorites { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<melk>()
            .HasRequired(c => c.user)
            .WithMany()
            .WillCascadeOnDelete(false);
        }

    }
}