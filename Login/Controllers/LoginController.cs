using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;
using System.Windows;
using Tasak.Api.Models;
using Tasak.Api.Login.Services;
using Tasak.Api.Room.Hubs;
using System.Diagnostics;

namespace Tasak.Api.Controllers
{
    [Route("login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        private readonly IHubContext<RoomHub> _hubContext;

        public LoginController(ILoginService loginService, IHubContext<RoomHub> hubContext)
        {
            _loginService = loginService ?? throw new ArgumentNullException(nameof(loginService));
            _hubContext = hubContext ?? throw new ArgumentNullException(nameof(hubContext));
        }

        [HttpGet]
        public IActionResult Asdas()
        {
            Debug.WriteLine("getted");
            return Ok(true);
        }
        // POST: /login/teacher
        [HttpPost("teacher")]
        public IActionResult Login(TeacherLogin teacher)
        {
            Debug.WriteLine("inloginteacher");
            return Ok(_loginService.CheckTeacher(teacher, _hubContext));
        }

        // POST: /login/student
        [HttpPost("student")]
        public IActionResult Login(StudentLogin student)
        {
            Debug.WriteLine("inloginstudent");
            return Ok(_loginService.CheckStudent(student, _hubContext));
        }
    }
}
