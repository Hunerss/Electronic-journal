﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electronic_journal.Classes.DataClasses
{
    internal class Teacher : Person
    {
        public string Subject { get; set; }
        public string Class_name { get; set; }
        public int Classroom { get; set; }
        public int Age { get; set; }
    }
}
