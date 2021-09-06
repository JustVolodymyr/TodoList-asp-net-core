using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Domain.Enums
{
    public enum TaskStatus
    {
        [Display(Name = "Не розпочато")]
        Created = 1,
        [Display(Name = "В ході виконання")]
        Active = 2,
        [Display(Name = "Виконано")]
        Done = 3
    }
}
