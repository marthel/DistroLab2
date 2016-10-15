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
        [Key]
        public int MessageId { get; set; }
        public String Text { get; set; }
        public Boolean Read { get; set; }

        public string SenderId { get; set; }
        //public virtual ApplicationUser Sender { get; set; }
        public ICollection<User> UserRecievers { get; set; }
        public ICollection<Group> GroupRecievers { get; set; }

      /*  public Message()
        {
            UserRecievers = new List<ApplicationUser>();
            GroupRecievers = new List<Group>();
        }*/
    }
}