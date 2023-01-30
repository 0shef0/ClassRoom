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
            if (student == null)
            {
/*                jurnal.Notify?.Invoke(jurnal, new JurnalEventArgs("student object is null", jurnal.Students.Count));*/
            }
            else
            { 
                jurnal.Students.Add(student);
/*                Notify?.Invoke(jurnal, new JurnalEventArgs("Added student", jurnal.Students.Count));*/
            }
        }
    }
}
