using System;
using System.ComponentModel.DataAnnotations;
using ToDoList.Domain.Enums;

namespace ToDoList.Dto
{
    public class TaskCreateDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public DateTime EnrollDeadline { get; set; }

        public TaskDifficultyImportanceEnum Level { get; set; }

        [Required]
        public TaskStatus status { get; set; }

        [Required]
        public int UserId { get; set; }
    }
}