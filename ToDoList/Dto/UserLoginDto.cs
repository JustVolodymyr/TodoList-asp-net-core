using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Dto
{
    public class UserLoginDto
    {
        [Required]
        [EmailAddress(ErrorMessage = "Невірна адреса електронної пошти.")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "Поле {0} повинно мати мінімум {2} і максимум {1} символов.", MinimumLength = 5)]
        public string Password { get; set; }
    }
}
