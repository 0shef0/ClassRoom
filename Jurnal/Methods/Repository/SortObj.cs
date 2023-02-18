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
        public static void SortStudents(Jurnal jurnal, int field)
        {
            switch (field)
            {
                case 0:
                    jurnal.Students = jurnal.Students.OrderBy(stud => stud.Id).ToList<Student>();
                    break;
                case 1:
                    jurnal.Students = jurnal.Students.OrderBy(stud => stud.Name).ToList<Student>();
                    return;
                case 2:
                    jurnal.Students = jurnal.Students.OrderBy(stud => stud.Age).ToList<Student>();
                    return;
                case 3:
                    jurnal.Students = jurnal.Students.OrderBy(stud => stud.Mark).ToList<Student>();
                    return;
            }
            int i = 1;
            foreach (Student student in jurnal.Students)
            {
                student.Id = i;
                i++;
            }
        }
    }
}
