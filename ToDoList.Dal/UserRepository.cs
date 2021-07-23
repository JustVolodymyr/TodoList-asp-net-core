using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToDoList.Data;
using ToDoList.Domain;

namespace ToDoList.Dal
{
    public class UserRepository : IUserRepository
    {
        private readonly IAppDBContext getDbContext;

        public UserRepository(IAppDBContext getDbContext)
        {
            this.getDbContext = getDbContext;
        }

        //COMPLITE!!!!!!!!!!!!
        //public async Task<int> Add(Todo todo)
        public User Create(User user)
        {
             getDbContext.Users.AddAsync(user);
             getDbContext.SaveChanges();
             return user;
        }

        //COMPLITE!!!!!!!!!!!!
        //public async Task<List<Todo>> GetAll()
        public IList<User> GetAll()
        {
            return  getDbContext.Users.ToList();
        }

        //COMPLITE!!!!!!!!!!!!
        //public Task<Todo> Find(int Id)
        public User GetById(int id)
        {
            return getDbContext.Users.Find(id);
        }

        //COMPLITE!!!!!!!!!!!!
        public IList<Task> GetWithTasksById(int id)
        {
            return getDbContext.Tasks.AsNoTracking().Where(t => t.UserId == id).ToList();
        }


        public bool IsUserExists(string email)
        {
            return getDbContext.Users.Any(u => u.Email == email);
        }

        //COMPLITE!!!!!!!!!!!!
        //public async Task<bool> Update(int Id, Todo newTodo)
        public User Update(User user)
        {
            var result = getDbContext.Users.Update(user);
            getDbContext.SaveChanges();
            return result.Entity;
        }

        public void Delete(int id)
        {
            var user = new User { Id = id };
            getDbContext.Users.Remove(user);
            getDbContext.SaveChanges();
        }
    }
}
