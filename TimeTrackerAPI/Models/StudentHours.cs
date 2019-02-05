using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeTrackerAPI.Models
{
    public class StudentHours
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Hours { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndtDate { get; set; }

    }
}
