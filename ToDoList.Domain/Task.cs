using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ToDoList.Domain.Enums;

namespace ToDoList.Domain
{
    public class Task
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(300)]
        public string Description { get; set; }

        public DateTime EnrollDeadline { get; set; }

        public TaskDifficultyImportanceEnum Importance { get; set; }

        public TaskStatus Status { get; set; }


        public User Users { get; set; }

        public int UserId { get; set; }
    }
}
