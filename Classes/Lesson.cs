using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electronic_journal.Classes
{
    internal class Lesson
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Classroom { get; set; }
        public int Teacher_id { get; set; }
        public int Class_id { get; set; }
        public int Lesson_hour { get; set; }
    }
}
