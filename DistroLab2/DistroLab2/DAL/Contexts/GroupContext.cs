using DistroLab2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace DistroLab2.DAL.Contexts
{
    public class GroupContext : DbContext
    {
        public GroupContext() : base("DefaultConnection")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public static GroupContext Create()
        {
            return new GroupContext();
        }

        public virtual DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // IMPORTANT: we are mapping the entity User to the same table as the entity ApplicationUser
            modelBuilder.Entity<User>().ToTable("User");
        }

        public DbQuery<T> Query<T>() where T : class
        {
            return Set<T>().AsNoTracking();
        }
        /* protected override void OnModelCreating(DbModelBuilder modelBuilder)
         {
             modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
         }*/
    }
}