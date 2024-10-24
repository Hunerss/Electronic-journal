using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electronic_journal.Classes.DataClasses
{
    public class Student : Person
    {
        public string Classname { get; set; }
        public int Age { get; set; }
        public int Parent_1_id { get; set; }
        public int Parent_2_id { get; set; }
    }
}
