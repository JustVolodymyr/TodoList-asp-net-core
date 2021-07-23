using Microsoft.EntityFrameworkCore;
using System;
using ToDoList.Domain;

namespace ToDoList.Data
{
    public interface IAppDBContext : IDisposable
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Task> Tasks { get; set; }

        int SaveChanges();
    }
}
