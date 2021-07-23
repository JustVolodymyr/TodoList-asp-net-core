using ToDoList.Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace ToDoList.Data
{
    public class AppDBContext : DbContext , IAppDBContext
    {
        //private readonly DbContextOptions options;

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
            //this.options = options;
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
