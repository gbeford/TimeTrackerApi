using System;
namespace TimeTrackerAPI.Models
{
    public class User
    {

        public int UserID { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public DateTime LastLogin { get; set; }
        public string Name { get; set; }


    }
}
