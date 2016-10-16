using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DistroLab2.DAL.Contexts;

namespace DistroLab2.Models
{
    public class Message
    {
        public Message()
        {
            UserRecievers = new List<ApplicationUser>();
            GroupRecievers = new List<Group>();
            Read = false;
        }

        [Key]
        public int MessageId { get; set; }
        public String Text { get; set; }


        [ScaffoldColumn(false)]
        public Boolean Read { get; set; }

        [ForeignKey("Sender")]
        public string SenderId { get; set; }
        public virtual ApplicationUser Sender { get; set; }
        public virtual ICollection<ApplicationUser> UserRecievers { get; set; }
        public virtual ICollection<Group> GroupRecievers { get; set; }


    }
}