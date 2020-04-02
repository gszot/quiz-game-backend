using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tasak.Api.Room.Models;

namespace Tasak.Api.Room.Services
{
    public interface IRoomService
    {
        IDictionary<string, RoomModel> Rooms { get; set; }
    }
}
