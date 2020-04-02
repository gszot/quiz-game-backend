using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tasak.Models
{
    public class Quiz
    {
        public int ID { get; set; }
        public int Teacher_ID { get; set; }
        public string Quiz_Title { get; set; }
        public string Quiz_type { get; set; }

        public Teacher Teacher { get; set; }
        public ICollection<Question> Questions { get; set; }
    }
}
