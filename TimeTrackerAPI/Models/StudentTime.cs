using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeTrackerAPI.Models
{
    public class StudentTime
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentTimeID { get; set; }
        public int StudentId { get; set; }
        public int EventId { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public DateTime CreateDateTime { get; set; }
        public decimal TotalHrs { get; set; }
    }
}


