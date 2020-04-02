using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tasak.Api.Room.Models
{
    public class Question
    {
        public string Text { get; set; }
        public ArraySegment<string> Answers { get; set; }
    }
}
