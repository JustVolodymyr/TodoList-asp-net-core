using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using ToDoList.Dal;
using ToDoList.Data;
using ToDoList.Domain;
using ToDoList.Dtos;

namespace ToDoList.Api
{
    [Route("api/task")]
    [ApiController]
    public class TaskController : Controller
    {
        private readonly IMapper mapper;
        private readonly ITaskRepository repository;

        public TaskController(ITaskRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpGet]
        [Produces("application/json")]
        public ActionResult<IEnumerable<Task>> GetTasks()
        {
            var result = repository.GetAll();
            return Ok(mapper.Map<IEnumerable<TaskReadDto>>(result));
        }


        [HttpGet("{id}")]
        [Produces("application/json")]
        public ActionResult<TaskReadDto> GetCommandById(int id)
        {
            var commandItem = repository.GetById(id);
            return Ok(mapper.Map<TaskReadDto>(commandItem));
        }

        //POST api/commands
        [HttpPost]
        [Produces("application/json")]
        public IActionResult CreateCommand(TaskCreateDto taskCreateDto)
        {
            var result = mapper.Map<Task>(taskCreateDto);
            var task = repository.Create(result);
            return Ok(task);
        }


        [HttpPut("{id}")]
        public IActionResult Put(int id, TaskUpdateDto taskUpdateDto)
        {
            //task.Id = id;
            //var updateTask = repository.Update(task);
            //return Ok(updateTask);

            var updateTask = repository.GetById(id);
            mapper.Map(taskUpdateDto, updateTask);
            repository.Update(updateTask);
            return Ok(taskUpdateDto);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id)
        {
            repository.Delete(id);
            return Ok();
        }
    }
}
