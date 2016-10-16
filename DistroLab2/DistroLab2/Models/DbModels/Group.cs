using DistroLab2.DAL.Contexts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DistroLab2.Models
{
    public class Group
    {
        public Group()
        {
            Messages = new List<Message>();
            User = new List<ApplicationUser>();
        }

        [Key]
        public int GroupId { get; set; }
        public String Name { get; set; }

        [ForeignKey("User")]
        public virtual string ApplicationUserID { get;set; }  
        public virtual ICollection<ApplicationUser> User { get; set; }
        public ICollection<Message> Messages { get; set; }

    }
}