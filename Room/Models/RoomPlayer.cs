using System;
using System.Collections;
using System.Collections.Generic;

namespace Tasak.Api.Room.Models
{
    public class RoomPlayer : Player
    {
        public string ConnectionId { get; set; }
        public List<string> Answers { get; set; } = new List<string>();
    }
}