using Docs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Docs.Models.Jurnal;

namespace Docs.Methods.Repository
{
    public class SortObj
    {
        public static void SortStudents(Jurnal jurnal)
        {
            jurnal.Students.Sort();
            int i = 1;
            foreach (Student student in jurnal.Students)
            {
                student.Id = i;
                i++;
            }
        }
    }
}
