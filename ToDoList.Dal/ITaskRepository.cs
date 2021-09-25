using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToDoList.Domain;

namespace ToDoList.Dal
{
    public interface ITaskRepository 
    {
        Task Create(Task webinar);

        IList<Task> GetAll();

        Task GetById(int id);

        Task Update(Task webinar);

        void Delete(int id);

        IList<Task> GetByDate(int typeSort, int id);
    }
}
