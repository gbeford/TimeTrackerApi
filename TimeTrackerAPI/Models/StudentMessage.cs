using TimeTrackerAPI.Models;

public class StudentMessage
{
    public int StudentId { get; set; }
    public virtual Student Student { get; set; }

    public int MessageId { get; set; }
    public virtual Message Message { get; set; }
}
