using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electronic_journal.Classes.DataClasses
{
    public class Grade
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Mark { get; set; }
        public int Weight { get; set; }
        public int Student_id { get; set; }
        public string Classname { get; set; }
        public string Student_name { get; set; }
        public int Teacher_id { get; set; }
        public int Creation_date { get; set; }
    }
}
