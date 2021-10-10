using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToDoList.Data;
using ToDoList.Domain;
using ToDoList.Domain.Enums;

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

        public Task UpdateStatus(int userId, int taskId, TaskStatus taskStatus)
        {
            Task task = getDbContext.Tasks.FirstOrDefault(t => t.UserId == userId && t.Id == taskId);
            task.Status = taskStatus;
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

        public IList<Task> GetByDate(int typeSort, int id)
        {
            var task = getDbContext.Tasks.Where(t => t.UserId == id).ToList();
            switch (typeSort)
            {
                case 1:
                    break;
                case 2:
                    task = task.Where(t => t.EnrollDeadline.Value.Day == DateTime.Now.Day).ToList();
                    break;
                case 3:
                    task = task.Where(t => t.EnrollDeadline.Value.Day == DateTime.Now.Day + 1).ToList();
                    break;
                case 4:
                    DateTime startDayOfWeek = DateTime.Today.AddDays(1 - (int)(DateTime.Today.DayOfWeek));
                    DateTime endDayOfWeek = DateTime.Today.AddDays(7 - (int)DateTime.Today.DayOfWeek);
                    task = task.Where(x => x.EnrollDeadline >= startDayOfWeek && x.EnrollDeadline <= endDayOfWeek).ToList();
                    break;
            }
            return task;
        }
    }
}
