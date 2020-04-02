using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tasak.Models;

namespace Tasak.Data
{
    public class DbInitializer
    {
        public static void Initialize(TasakContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Teachers.Any())
            {
                return;   // DB has been seeded
            }

            var teachers = new Teacher[]
            {
            new Teacher{ID=1, Teacher_login="login1", Paswd="qwerty", Teacher_first_name="Carson",Teacher_last_name="Alexander",Pin=1},
            new Teacher{ID=2, Teacher_login="login2", Paswd="asdfgh", Teacher_first_name="Meredith",Teacher_last_name="Alonso",Pin=2},
            new Teacher{ID=3, Teacher_login="login3", Paswd="zxcvbn", Teacher_first_name="Arturo", Teacher_last_name="Anand",Pin=3},
            new Teacher{ID=4, Teacher_login="login4", Paswd="uiopas", Teacher_first_name="Gytis",Teacher_last_name="Barzdukas",Pin=4},
            new Teacher{ID=5, Teacher_login="login5", Paswd="dfghjk", Teacher_first_name="Yan",Teacher_last_name="Li",Pin=5},
            new Teacher{ID=6, Teacher_login="login6", Paswd="lzxcvb", Teacher_first_name="Peggy",Teacher_last_name="Justice",Pin=6},
            new Teacher{ID=7, Teacher_login="login7", Paswd="nmqwer", Teacher_first_name="Laura",Teacher_last_name="Norman",Pin=7},
            new Teacher{ID=8, Teacher_login="login7", Paswd="tyuiop", Teacher_first_name="Nino",Teacher_last_name="Olivetto",Pin=8}
            };
            foreach (Teacher s in teachers)
            {
                context.Teachers.Add(s);
            }
            context.SaveChanges();

            var quizes = new Quiz[]
            {
            new Quiz{Teacher_ID=1,Quiz_Title="Chemistry",Quiz_type="type1"},
            new Quiz{Teacher_ID=2,Quiz_Title="Microeconomics",Quiz_type="type2"},
            new Quiz{Teacher_ID=3,Quiz_Title="Macroeconomics",Quiz_type="type3"},
            new Quiz{Teacher_ID=4,Quiz_Title="Calculus",Quiz_type="type4"},
            new Quiz{Teacher_ID=5,Quiz_Title="Trigonometry",Quiz_type="type5"},
            new Quiz{Teacher_ID=6,Quiz_Title="Composition",Quiz_type="type6"},
            new Quiz{Teacher_ID=7,Quiz_Title="Literature",Quiz_type="type7"}
            };
            foreach (Quiz c in quizes)
            {
                context.Quizes.Add(c);
            }
            context.SaveChanges();

            var questions = new Question[]
            {
            new Question{Quiz_ID=1,Question_text="Content1",Question_picture="link1"},
            new Question{Quiz_ID=1,Question_text="Content2",Question_picture="link1"},
            new Question{Quiz_ID=1,Question_text="Content3",Question_picture="link1"},
            new Question{Quiz_ID=2,Question_text="Content4",Question_picture="link1"},
            new Question{Quiz_ID=2,Question_text="Content5",Question_picture="link1"},
            new Question{Quiz_ID=2,Question_text="Content6",Question_picture="link1"},
            new Question{Quiz_ID=3,Question_text="Content7", Question_picture="link1"},
            new Question{Quiz_ID=4,Question_text="Content8", Question_picture="link1"},
            new Question{Quiz_ID=4,Question_text="Content9",Question_picture="link1"},
            new Question{Quiz_ID=5,Question_text="Content10",Question_picture="link1"},
            new Question{Quiz_ID=6,Question_text="Content11", Question_picture="link1"},
            new Question{Quiz_ID=7,Question_text="Content12",Question_picture="link1"},
            };
            foreach (Question e in questions)
            {
                context.Questions.Add(e);
            }
            context.SaveChanges();

            var answers = new Answer[]
           {
            new Answer{Question_ID=1,Answer_nr=1,Answer_text="Answer1.1"},
            new Answer{Question_ID=1,Answer_nr=2,Answer_text="Answer2.1"},
            new Answer{Question_ID=1,Answer_nr=3,Answer_text="Answer3.1"},
            new Answer{Question_ID=2,Answer_nr=1,Answer_text="Answer1.2"},
            new Answer{Question_ID=2,Answer_nr=2,Answer_text="Answer2.2"},
            new Answer{Question_ID=2,Answer_nr=3,Answer_text="Answer3.2"},
            new Answer{Question_ID=3,Answer_nr=1, Answer_text="Answer1.3"},
            new Answer{Question_ID=4,Answer_nr=1, Answer_text="Answer1.4"},
            new Answer{Question_ID=4,Answer_nr=2,Answer_text="Answer2.4"},
            new Answer{Question_ID=5,Answer_nr=1,Answer_text="Answer1.5"},
            new Answer{Question_ID=6,Answer_nr=1, Answer_text="Answer1.6"},
            new Answer{Question_ID=7,Answer_nr=1,Answer_text="Answer1.7"},
           };
            foreach (Answer e in answers)
            {
                context.Answers.Add(e);
            }
            context.SaveChanges();
        }
    }
}
