using Docs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Docs.Models.Jurnal;

namespace Docs.Methods.Repository
{
    public class RemoveAllObj
    {
        public static void RemoveAllStudents(Jurnal jurnal/*, JurnalHandler? Notify*/)
        {
            jurnal.Students.Clear();
/*            Notify?.Invoke(list, new JurnalEventArgs("All students deleted", list.Count));*/
        }
    }
}
