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

        [Required(ErrorMessage = "Необхідно заповнити назву")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Довжина рядка повинна бути від 2 до 50 символів")]
        public string Name { get; set; }

        [MaxLength(300, ErrorMessage = "Довжина рядка повинна бути не більше 300 символів")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Необхідно встановти дату")]
        [DataType(DataType.Date)]
        public DateTime? EnrollDeadline { get; set; }

        [Required(ErrorMessage = "Необхідно вибрати валивість")]
        public TaskDifficultyImportanceEnum? Importance { get; set; }

        public TaskStatus Status { get; set; }


        public User Users { get; set; }

        public int UserId { get; set; }
    }
}
