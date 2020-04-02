using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Tasak.Api.Models;
using Tasak.Api.Room.Hubs;

namespace Tasak.Api.Login.Services
{
    public interface ILoginService
    {
        bool CheckTeacher(TeacherLogin teacher, IHubContext<RoomHub> hubContext);
        bool CheckStudent(StudentLogin student, IHubContext<RoomHub> hubContext);
    }
}
