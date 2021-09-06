using System;
using System.ComponentModel.DataAnnotations;
using ToDoList.Domain.Enums;

namespace ToDoList.Dto
{
    public class TaskCreateDto
    {
        [Required(ErrorMessage = "��������� ��������� �����")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "������� ����� ������� ���� �� 2 �� 50 �������")]
        public string Name { get; set; }

        [MaxLength(300, ErrorMessage = "������� ����� ������� ���� �� ����� 300 �������")]
        public string Description { get; set; }

        [Required(ErrorMessage = "��������� ��������� ����")]
        [DataType(DataType.Date)]
        public DateTime? EnrollDeadline { get; set; }

        [Required(ErrorMessage = "��������� ������� ��������")]
        public TaskDifficultyImportanceEnum? Importance { get; set; }

        public TaskStatus Status { get; set; }

        [Required]
        public int UserId { get; set; }
    }
}