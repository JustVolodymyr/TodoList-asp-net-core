using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToDoList.Domain;
using ToDoList.Domain.Enums;

namespace ToDoList.Dal
{
    public interface ITaskRepository 
    {
        Task Create(Task webinar);

        IList<Task> GetAll();

        Task GetById(int id);

        Task Update(Task webinar);

        Task UpdateStatus(int taskId, int userId, TaskStatus taskStatus);

        void Delete(int id);

        IList<Task> GetByDate(int typeSort, int id);
    }
}
