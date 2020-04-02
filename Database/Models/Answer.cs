using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tasak.Models
{
    public class Answer
    {
        public int ID { get; set; }
        public int Question_ID { get; set; }
        public int Answer_nr { get; set; }
        public string Answer_text { get; set; }
        public int Answer_True { get; set; }

        //public Question Question { get; set; }
    }
}
