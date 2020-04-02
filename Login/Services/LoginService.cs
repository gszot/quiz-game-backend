using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tasak.Api.Models;
using Tasak.Api.Room.Services;
using Tasak.Api.Room.Models;
using Microsoft.AspNetCore.SignalR;
using Tasak.Api.Room.Hubs;
using System.Diagnostics;

namespace Tasak.Api.Login.Services
{
    public class LoginService : ILoginService
    {
        private readonly IRoomService _roomService;
        public LoginService(IRoomService roomService)
        {
            _roomService = roomService;
        }
        public bool CheckTeacher(TeacherLogin teacher, IHubContext<RoomHub> hubContext)
        {
            //sprawdzić nauczyciela w bazie
            Debug.WriteLine("checkteacherprzed");
            var RoomId = "123456";
            hubContext.Groups.AddToGroupAsync(teacher.ConnectionId, RoomId);
            var new_room = new RoomModel { RoomId = RoomId , TeacherConnectionId = teacher.ConnectionId, HubContext = hubContext};
            new_room.StartRoom();
            _roomService.Rooms.Add(teacher.ConnectionId, new_room);
            Debug.WriteLine("checkteacherpo");
            return true;
        }

        public bool CheckStudent(StudentLogin student, IHubContext<RoomHub> hubContext)
        {
            //sprawdzić studenta w bazie
            //get RoomId by student.Pin
            Debug.WriteLine("checkstudentprzed");
            var RoomId = "123456";
            hubContext.Groups.AddToGroupAsync(student.ConnectionId, RoomId);
            var room = _roomService.Rooms.FirstOrDefault(x => x.Value.RoomId == RoomId && x.Value.CanJoin == true);
            room.Value.Players.Add(new RoomPlayer { ConnectionId = student.ConnectionId, Nick = student.Nick });
            Debug.WriteLine("checkstudentpo");
            return true;
        }
    }
}
