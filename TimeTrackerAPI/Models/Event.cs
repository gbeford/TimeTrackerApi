using System;

namespace TimeTrackerAPI.Models
{
    public class Event
    {
            public int EventID { get; set; }
            public string Description { get; set; }
            public bool Show { get; set; }
            public int SortOrder { get; set; }                 

    }
}
