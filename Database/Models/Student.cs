using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tasak.Models;

namespace Tasak.Api.Database.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string Nick { get; set; }
        public int Pin { get; set; }
        public string Teacher_ID { get; set; }

        public Teacher Teacher { get; set; }
    }
}
