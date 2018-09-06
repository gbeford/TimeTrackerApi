using System;
namespace TimeTrackerAPI.Models
{
    public class Message
    {
        public int MessageID { get; set; }
        public string MessageText { get; set; }
        public bool Show { get; set; }
        public int  SortOrder { get; set; }
    }
}
