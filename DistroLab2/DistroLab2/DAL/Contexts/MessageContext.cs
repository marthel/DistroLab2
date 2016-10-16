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
    public class MessageContext : DbContext
    {
        public MessageContext() : base("DefaultConnection")
        {
          //  Configuration.LazyLoadingEnabled = false;
          //  Configuration.ProxyCreationEnabled = false;
        }

        public static MessageContext Create()
        {
            return new MessageContext();
        }


        public DbSet<ApplicationUser> UserRecievers { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Group> GroupRecievers { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            /*base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // IMPORTANT: we are mapping the entity User to the same table as the entity ApplicationUser
            modelBuilder.Entity<User>().ToTable("User");*/

            modelBuilder.Entity<Message>()
                .HasMany(u => u.GroupRecievers)
                .WithMany(u => u.Messages)
                .Map(m =>
                {
                    m.ToTable("MessageGroup");
                    m.MapLeftKey("MessageID");
                    m.MapRightKey("GroupID");

                });

             modelBuilder.Entity<Message>()
                .HasMany(u => u.UserRecievers)
                .WithMany(u => u.Messages)
                .Map(m =>
                {
                    m.ToTable("MessageUsers");
                    m.MapLeftKey("MessageID");
                    m.MapRightKey("UserID");

                });

            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
            base.OnModelCreating(modelBuilder);
        }

       /* public DbQuery<T> Query<T>() where T : class
        {
            return Set<T>().AsNoTracking();
        }*/
    }
}