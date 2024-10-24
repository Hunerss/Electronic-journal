using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electronic_journal.Classes.DataClasses
{
    public class Lesson
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Classname { get; set; }
        public int Classroom { get; set; }
        public int Teacher_id { get; set; }
        public int Lesson_hour { get; set; }
        public int Lesson_day { get; set; }
    }
}
