using TimeTrackerAPI.Models;

public class StudentMessage
{
    public int StudentId { get; set; }
    public Student Student { get; set; }

    public int MessageId { get; set; }
    public Message Message { get; set; }
}
