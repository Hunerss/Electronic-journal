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
        public string Grade_name { get; set; }
        public int Student_id { get; set; }
        public int Teacher_id { get; set; }
        public DateTime Creation_date { get; set; }
    }
}
