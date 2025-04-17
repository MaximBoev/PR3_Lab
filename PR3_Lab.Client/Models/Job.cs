namespace PR3_Lab.Client.Models
{
    public class Job
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public JobStatus Status { get; set; }
    }

    public enum JobStatus
    {
        Open,
        InProgress,
        Completed
    }
}
