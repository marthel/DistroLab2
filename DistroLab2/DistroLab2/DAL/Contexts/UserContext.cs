﻿using DistroLab2.Models;
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
        //public DbSet<ApplicationUser> Users { get; set; }



    }
}