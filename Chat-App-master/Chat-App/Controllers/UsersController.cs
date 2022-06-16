using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Chat_App.Data;
using Chat_App.Models;
using Chat_App.services;

namespace Chat_App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserService _service;

        public UsersController()
        {
            _service = new UserService();
        }

        [HttpGet]
        public IActionResult get()
        {
            return Json(_service.GetAll());
        }

        [HttpPost]
        public IActionResult LogIn([Bind("Id,Password")] User user)
        {
            if (ModelState.IsValid)
            {
                var t = _service.LogIn(user.Id, user.Password);
                if (!t)
                {
                    return NotFound();
                }
                return NoContent();
            }
            return BadRequest();
        }

        [HttpPost("{method}")]
        public IActionResult Register(string method, [Bind("Id,Password")] User user)
        {
            if (ModelState.IsValid)
            {
                var t = _service.Register(user.Id, user.Password);
                if (!t)
                {
                    return BadRequest();
                }
                return NoContent();
            }
            return BadRequest();
        }
    }
}
