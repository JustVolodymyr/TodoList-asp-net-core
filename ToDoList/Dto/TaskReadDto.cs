using System;
using System.ComponentModel.DataAnnotations;
using ToDoList.Domain;
using ToDoList.Domain.Enums;

namespace ToDoList.Dtos
{
    public class TaskReadDto
    {
        [Range(1, int.MaxValue)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public DateTime EnrollDeadline { get; set; }

        public TaskDifficultyLevelEnum Level { get; set; }

        public TaskStatus status { get; set; }

        public int UserId { get; set; }
    }
}