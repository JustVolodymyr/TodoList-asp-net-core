using System;
using System.ComponentModel.DataAnnotations;
using ToDoList.Domain;
using ToDoList.Domain.Enums;

namespace ToDoList.Dto
{
    public class TaskReadDto
    {
        [Range(1, int.MaxValue)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(150)]
        public string Description { get; set; }

        public DateTime EnrollDeadline { get; set; }

        public TaskDifficultyImportanceEnum Importance { get; set; }

        public TaskStatus Status { get; set; }

        public int UserId { get; set; }
    }
}