using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToDoList.Domain;

namespace ToDoList.Dal
{
    public interface IUserRepository
    {
        User GetById(int id);

        public IList<Task> GetWithTasksById(int id);

        User Create(User user);

        IList<User> GetAll();

        User Update(User user);

        public void Delete(int id);

        bool IsUserExists(string email);
    }
}
