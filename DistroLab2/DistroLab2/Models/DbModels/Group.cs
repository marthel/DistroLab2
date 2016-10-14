using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DistroLab2.Models
{
    public class Group
    {
        [Key]
        public int GroupId { get; set; }
        public String Name { get; set; }

        public virtual ICollection<ApplicationUser> Users { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
        public Group()
        {
            Messages = new List<Message>();
            Users = new List<ApplicationUser>();
        }
    }
}