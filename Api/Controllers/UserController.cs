﻿using Example.BussinesLayer.Abstract;
using Example.CORE.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class UserController : ControllerBase
    {
        public IUserService UserService { get; }

        public UserController(IUserService userService)
        {
            UserService = userService;
        }
        [HttpGet("{UserName}/{Password}")]
        public ServiceResult<object> GetToken(string UserName, string Password) => UserService.GetToken(UserName, Password);


        [HttpPost("{UserName}/{Password}")]
        public IActionResult AddUser(string UserName, string Password) => Ok(UserService.Add(new Example.Entity.Entity.User { UserName = UserName, Password = Password }));
         
    }
}
