using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Tasak.Api.Database.Models;

namespace Tasak.Models
{
    public class Teacher
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        public string Teacher_login { get; set; }
        public string Paswd { get; set; }
        public string Teacher_first_name { get; set; }
        public string Teacher_last_name { get; set; }
        public int Pin { get; set; }

        public ICollection<Quiz> Quiz { get; set; }
        public ICollection<Student> Student { get; set; }
    }
}
