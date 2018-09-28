using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeTrackerAPI.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public DateTime LastLogin { get; set; }
        public string Name { get; set; }


    }
}
