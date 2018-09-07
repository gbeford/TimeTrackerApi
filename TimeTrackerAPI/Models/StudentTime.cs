using System;


namespace TimeTrackerAPI.Models
{
    public class StudentTime
    {
        public int StudentTimeID { get; set; }
        public int StudentId { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public DateTime CreateDateTime { get; set; }
        public decimal TotalHrs { get; set; }
    }
}


