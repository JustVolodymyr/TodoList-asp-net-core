using System.ComponentModel.DataAnnotations;

namespace ToDoList.Domain.Enums
{
    public enum TaskDifficultyImportanceEnum
	{
        [Display(Name = "В останню чергу")]
        Beginner = 1,
        [Display(Name = "Спокійно приступай")]
        Intermediate = 2,
        [Display(Name = "Негайно!!!")]
        Advanced = 3
    }
}
