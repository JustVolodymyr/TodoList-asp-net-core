using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using ToDoList.Dal;
using ToDoList.Data;
using ToDoList.Domain;
using ToDoList.Domain.Enums;
using ToDoList.Dto;

namespace ToDoList.Api
{
    [Authorize]
    public class TaskController : Controller
    {
        private readonly IMapper mapper;
        private readonly IUserRepository userRepository;
        private readonly ITaskRepository taskRepository;

        public TaskController(ITaskRepository taskRepository, IUserRepository userRepository, IMapper mapper)
        {
            this.taskRepository = taskRepository;
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TaskReadDto>> List()
        {
            var userId = HttpContext.User.Identity.Name;
            var tasks = userRepository.GetWithTasksById(Convert.ToInt32(userId));
            var result = mapper.Map<List<TaskReadDto>>(tasks);
            return View(result);
        }

        [HttpPost]
        public ActionResult<IEnumerable<TaskReadDto>> ListSelect(int typeSelect)
        {
            var userId = HttpContext.User.Identity.Name;
            var tasks = taskRepository.GetByDate(typeSelect, Convert.ToInt32(userId));
            var result = mapper.Map<List<TaskReadDto>>(tasks);
            return View("_ViewAll", result);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var task = taskRepository.GetById(id);
            var result = mapper.Map<TaskReadDto>(task);
            return View(result);
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddTask(TaskCreateDto taskCreateDto)
        {
            if (ModelState.IsValid)
            {
                var maptaskCreateDto = mapper.Map<Task>(taskCreateDto);
                var userId = HttpContext.User.Identity.Name;
                maptaskCreateDto.UserId = Convert.ToInt32(userId);

                var result = taskRepository.Create(maptaskCreateDto);
                return Json(new { isValid = true, html = Helper.Helper.RenderRazorViewToString(this, "_ViewAll", List()) });
            }
            else return Json(new { isValid = false, html = Helper.Helper.RenderRazorViewToString(this, "Add", taskCreateDto) });
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var task = taskRepository.GetById(id);
            return View(task);
        }

        public IActionResult EditTask(Task taskUpdateDto)
        {
            if (ModelState.IsValid)
            {
                var updateTask = taskRepository.Update(taskUpdateDto);
                return Json(new { isValid = true, html = Helper.Helper.RenderRazorViewToString(this, "_ViewAll", List()) });
            }
            else return Json(new { isValid = false, html = Helper.Helper.RenderRazorViewToString(this, "Edit", taskUpdateDto) });
        }

        [HttpPost]
        public IActionResult EditStatus(int id, TaskStatus taskStatus)
        {
            var userId = HttpContext.User.Identity.Name;
            var task = taskRepository.UpdateStatus(Convert.ToInt32(userId), id, taskStatus);
            return View(task);
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var task = taskRepository.GetById(id);
            return View(mapper.Map<TaskReadDto>(task));
        }

        public IActionResult DeleteTask(int id)
        {
            taskRepository.Delete(id);
            return RedirectToAction("List");
        }
    }
}
