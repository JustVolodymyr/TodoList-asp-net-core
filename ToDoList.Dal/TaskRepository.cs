using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToDoList.Data;
using ToDoList.Domain;

namespace ToDoList.Dal
{
    public class TaskRepository : ITaskRepository
    {
        private readonly IAppDBContext getDbContext;

        public TaskRepository(IAppDBContext getDbContext)
        {
            this.getDbContext = getDbContext;
        }

        public Task Create(Task task)
        {
            getDbContext.Tasks.Add(task);
            getDbContext.SaveChanges();
            return task;
        }

        public IList<Task> GetAll()
        {
            return getDbContext.Tasks.ToList();
        }

        public Task GetById(int id) {
            return getDbContext.Tasks
            .FirstOrDefault(p => p.Id == id);
        }

        public Task Update(Task task)
        {
            var result = getDbContext.Tasks.Update(task);
            getDbContext.SaveChanges();
            return result.Entity;
        }

        public void Delete(int id)
        {
            var task = new Task { Id = id };
            getDbContext.Tasks.Remove(task);
            getDbContext.SaveChanges();
        }
    }
}
