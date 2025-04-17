using PR3_Lab.Enums;
using System.ComponentModel.DataAnnotations;

namespace PR3_Lab.Models
{
    public class Job
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; } = string.Empty;

        public JobStatus Status { get; set; }
    }
}
