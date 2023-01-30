using Docs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Docs.Models.Jurnal;
using Docs.Methods.Repository;

namespace Docs.Methods.Repository
{
    public class RemoveObj
    {
        public static void RemoveStudent(Jurnal jurnal, Student student/*, JurnalHandler? Notify*/)
        {
            int resRemove = jurnal.Students.RemoveAll(elem => elem == student);
            if (resRemove == 0)
            {
/*                Notify?.Invoke(list, new JurnalEventArgs("\nThere is no student like this", list.Count));*/
            }
            else
            {
/*                Notify?.Invoke(list, new JurnalEventArgs($"\nRemoved student {student}", list.Count));*/
            }
        }
    }
}
