using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ToDoList.Domain
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(150)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(150)]
        public string Email { get; set; }

        [Required]
        [MaxLength(150)]
        public string Password { get; set; }


        public ICollection<Task> Tasks { get; set; }

        public override string ToString()
        {
            return $"{Id} {FirstName} {LastName} {Email} ";
        }
    }
}
