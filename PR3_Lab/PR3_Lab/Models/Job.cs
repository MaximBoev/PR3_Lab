﻿using PR3_Lab.Enums;

namespace PR3_Lab.Models
{
    public class Job
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        
        public JobStatus Status { get; set; }
    }
}
