using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace TimeTrackerAPI.Models
{
    public class Message
    {
        public int MessageID { get; set; }
        public string MessageText { get; set; }
        public bool Show { get; set; }
        public int SortOrder { get; set; }

        private ICollection<StudentMessage> StudentMessages { get; set; }

        [NotMapped]
        public IEnumerable<Student> Students => StudentMessages.Select(s => s.Student);

        public Message()
        {
            StudentMessages = new List<StudentMessage>();
        }
    }
}
