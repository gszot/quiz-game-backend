using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tasak.Models
{
    public class Question
    {
        public int ID { get; set; }
        public int Quiz_ID { get; set; }
        public string Question_text { get; set; }
        public string Question_picture { get; set; }
        //public IFormFile Question_picture { get; set; }

        //public Quiz Quiz { get; set; }
        public ICollection<Answer> Answer { get; set; }
    }
}
