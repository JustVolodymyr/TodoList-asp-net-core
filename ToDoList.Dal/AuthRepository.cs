using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Data;
using ToDoList.Domain;

namespace ToDoList.Dal
{
    public class AuthRepository : IAuthRepository
    {
        private readonly IAppDBContext getDbContext;

        public AuthRepository(IAppDBContext getDbContext)
        {
            this.getDbContext = getDbContext;
        }

        public User GetByEmailAndPassword(string email, string password) {
            return getDbContext.Users.FirstOrDefault(p => p.Email == email
            && p.Password == password);
        }
        public User GetByEmail(string email)
        {
            return getDbContext.Users.FirstOrDefault(p => p.Email == email);
        }
    }
}
