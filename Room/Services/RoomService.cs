using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tasak.Api.Room.Models;

namespace Tasak.Api.Room.Services
{
    public class RoomService : IRoomService
    {
        public RoomService()
        {
        }
        public IDictionary<string, RoomModel> Rooms { get; set; } = new Dictionary<string, RoomModel>();
    }
}
