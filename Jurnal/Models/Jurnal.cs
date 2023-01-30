using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Docs.Interfaces;
using static Docs.Methods.ToPositiveNum;

namespace Docs.Models
{
    public class JurnalEventArgs
    {
        public string Message { get; }

        public int Count { get; }

        public JurnalEventArgs(string message, int count)
        {
            Message = message;
            Count = count;
        }
    }

    public class Jurnal
    {
        public delegate void JurnalHandler(Jurnal jurnal, JurnalEventArgs e);
        public event JurnalHandler? Notify;
        public Jurnal()
        {

        }
        public Jurnal(DateOnly date, Teacher teacher, int maxNumOfStudents)
        {
            Date = date.ToString();
            Teacher = teacher;
            MaxNumOfStudents = maxNumOfStudents;
        }

        public int MaxNumOfStudents { get; set; }

        public string Date { get; set; }

        public Teacher Teacher { get; set; }

        public List<Student>? Students { get; set; } = new List<Student>();

        public override string ToString()
        {
            return "\nMaximum students: " + MaxNumOfStudents +
                "nDate: " + Date;
        }
    }
}
