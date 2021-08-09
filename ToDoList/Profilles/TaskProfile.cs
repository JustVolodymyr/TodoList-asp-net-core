using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ToDoList.Domain;
using ToDoList.Dto;

namespace ToDoList.Profilles
{
    public class TaskProfile : Profile
    {
        public TaskProfile()
        {
            CreateMap<Task, TaskReadDto>();
            CreateMap<TaskCreateDto, Task>();
            CreateMap<TaskUpdateDto, Task>();
            CreateMap<Task, TaskUpdateDto>();
        }
    }
}
