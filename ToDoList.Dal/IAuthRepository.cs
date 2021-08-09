using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Data;
using ToDoList.Domain;

namespace ToDoList.Dal
{
    public interface IAuthRepository
    {
        public User GetByEmailAndPassword(string email, string password);

        public User GetByEmail(string email);
    }
}
