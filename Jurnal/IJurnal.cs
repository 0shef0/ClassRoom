using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docs
{
    internal interface IJurnal
    {
        public List<Student> Students { get; }

        public void AddStudent(Student student);

        public void RemoveStudent(Student student);

        public void SortStudents();

        public void RemoveAllStudents();

        public string GetInformation();
    }
}
