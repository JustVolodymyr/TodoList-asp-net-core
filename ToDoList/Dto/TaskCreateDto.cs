using System;
using System.ComponentModel.DataAnnotations;
using ToDoList.Domain.Enums;

namespace ToDoList.Dto
{
    public class TaskCreateDto
    {
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

        [Required]
        public int UserId { get; set; }
    }
}