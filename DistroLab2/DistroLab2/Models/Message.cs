using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace DistroLab2.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }
        public String message { get; set; }
        public Boolean read { get; set; }

        public int SenderId { get; set; }
        public int ReciverId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}