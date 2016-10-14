using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DistroLab2.Models
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }
        public String Text { get; set; }
        public Boolean Read { get; set; }

        public string SenderId { get; set; }
        //public virtual ApplicationUser Sender { get; set; }
        
        public virtual ICollection<ApplicationUser> UserRecievers { get; set; }
        public virtual ICollection<Group> GroupRecievers { get; set; }
        public Message()
        {
            UserRecievers = new List<ApplicationUser>();
            GroupRecievers = new List<Group>();
        }
    }
}