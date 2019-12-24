using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace TimeTrackerAPI.Models
{
    public class Message
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MessageID { get; set; }
        [Required]
        public string MessageText { get; set; }

        public virtual ICollection<StudentMessage> StudentMessages { get; set; }

        public Message()
        {
            StudentMessages = new List<StudentMessage>();
        }
    }
}
