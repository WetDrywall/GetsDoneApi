﻿using System.ComponentModel.DataAnnotations;

namespace GetsDoneApi.Models
{
    public class SaveWorkflowAssignment
    {
        [Key]
        public int WFId { get; set; }
        public int AId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int AssignmentNumber { get; set; }
        public bool Completed { get; set; }
        public DateTime Deadline { get; set; }
    }
}
