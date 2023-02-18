using Docs.Models;
using static Docs.Models.Jurnal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docs.Methods.Repository
{
    public class AddObj
    {
        public static void AddStudent(Jurnal jurnal, Student student)
        {
                jurnal.Students.Add(student);
        }
    }
}