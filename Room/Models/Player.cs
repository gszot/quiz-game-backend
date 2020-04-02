using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tasak.Api.Room.Models
{
    public class Player
    {
        public string Nick { get; set; }
        public int Score { get; set; } = 0;
    }
}
