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

        public DateTime EnrollDeadline { get; set; }

        public TaskDifficultyLevelEnum Level { get; set; }

        public TaskStatus status { get; set; }


        public User Users { get; set; }

        public int UserId { get; set; }
    }
}
