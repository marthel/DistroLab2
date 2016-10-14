using DistroLab2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace DistroLab2.DAL.Contexts
{
    public class MessageContext : DbContext
    {
        public MessageContext() : base("DefaultConnection")
        {
        }

        public DbSet<Message> Messages { get; set; }
        public DbSet<ApplicationUser> UserRecievers { get; set; }
        public DbSet<Group> GroupRecievers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}