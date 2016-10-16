using DistroLab2.Models;
using Microsoft.AspNet.Identity.EntityFramework;
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
          //  Configuration.LazyLoadingEnabled = false;
           // Configuration.ProxyCreationEnabled = false;
        }

        public static GroupContext Create()
        {
            return new GroupContext();
        }

        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Message> Messages { get; set; }    

         protected override void OnModelCreating(DbModelBuilder modelBuilder)
         {
             //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();


            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // IMPORTANT: we are mapping the entity User to the same table as the entity ApplicationUser
            //modelBuilder.Entity<User>().ToTable("User");


           modelBuilder.Entity<Group>()
                .HasMany(u => u.User)
                .WithMany(u => u.Groups)
                .Map(m =>
                {
                    m.ToTable("GroupUsers");
                    m.MapLeftKey("GroupID");
                    m.MapRightKey("UserID");
                    
                });
            modelBuilder.Entity<Group>()
                 .HasMany(u => u.Messages)
                 .WithMany(u => u.GroupRecievers)
                 .Map(m =>
                 {
                     m.ToTable("GroupMessage");
                     m.MapLeftKey("GroupID");
                     m.MapRightKey("MessageID");

                 });

            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
            base.OnModelCreating(modelBuilder);
        }
        /*
         public DbQuery<T> Query<T>() where T : class
         {
             return Set<T>().AsNoTracking();
         }*/
        /* protected override void OnModelCreating(DbModelBuilder modelBuilder)
         {
             modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
         }*/
    }
}