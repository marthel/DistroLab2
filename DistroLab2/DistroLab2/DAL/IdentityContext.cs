using DistroLab2.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DistroLab2.DAL
{
    public class IdentityContext : IdentityDbContext<ApplicationUser>
    {
        public IdentityContext() 
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static IdentityContext Create()
        {
            return new IdentityContext();
        }
        public DbSet<Message> Messages { get; set; }
    }
}