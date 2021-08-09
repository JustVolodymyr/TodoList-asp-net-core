using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ToDoList.Domain;
using ToDoList.Dto;

namespace ToDoList.Profilles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserCreateDto, User>();
            CreateMap<UserLoginDto, User>();
        }
    }
}
