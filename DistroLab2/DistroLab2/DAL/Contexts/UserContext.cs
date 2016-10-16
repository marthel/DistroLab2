using DistroLab2.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DistroLab2.DAL
{
    public class UserContext : IdentityDbContext<ApplicationUser>
    {
        public UserContext() : base("DefaultConnection")
        {

        }

        public static UserContext Create()
        {
            return new UserContext();
        }


        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Message> Messages { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            /*base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // IMPORTANT: we are mapping the entity User to the same table as the entity ApplicationUser
            modelBuilder.Entity<User>().ToTable("User");*/

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.Groups)
                .WithMany(u => u.User)
                .Map(m =>
                {
                    m.ToTable("UserGroup");
                    m.MapLeftKey("UserID");
                    m.MapRightKey("GroupID");

                });

            modelBuilder.Entity<ApplicationUser>()
               .HasMany(u => u.Messages)
               .WithMany(u => u.UserRecievers)
               .Map(m =>
               {
                   m.ToTable("UserMessage");
                   m.MapLeftKey("UserID");
                   m.MapRightKey("MessageID");

               });

            base.OnModelCreating(modelBuilder);
        }



    }
}