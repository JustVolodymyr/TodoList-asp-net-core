using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Dal;

namespace ToDoList.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository repository;

        public UserController(IUserRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        [Produces("application/json")]
        public ActionResult<IEnumerable<Task>> GetTasks()
        {
            var result = repository.GetAll();
            return Ok(result);
        }
    }
}
