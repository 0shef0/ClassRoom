using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Docs.Methods;

namespace Docs
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

    public class Jurnal : IJurnal
    {
        public delegate void JurnalHandler(Jurnal jurnal, JurnalEventArgs e);
        public event JurnalHandler? Notify;

        private DateOnly date;
        private Teacher teacher;
        private List<Student> students = new List<Student>();
        private int maxNumOfStudents;

        public Jurnal(DateOnly date, Teacher teacher, int maxNumOfStudents)
        {
            Date = date;
            Teacher = teacher;
            MaxNumOfStudents = maxNumOfStudents;
        }

        public int MaxNumOfStudents { get; set; }

        public DateOnly Date { get; set; }

        public Teacher Teacher { get; set; }

        public List<Student>? Students { get { return students; } }

        public void AddStudent(Student student)
        {
            if (student == null)
            {
                Notify?.Invoke(this, new JurnalEventArgs("student object is null", students.Count));
            }
            else
            {
                students.Add(student);
                Notify?.Invoke(this, new JurnalEventArgs("Added student", students.Count));
            }
        }

        public string GetInformation()
        {
            string info = Teacher.ToString() + $"\nDate {Date}";
            foreach (Student student in students)
            {
                info += "\n" + student.ToString();
            }
            return info;
        }

        public void RemoveAllStudents()
        {
            students.Clear();
            Notify?.Invoke(this, new JurnalEventArgs("All students deleted", students.Count));
        }

        public void RemoveStudent(Student rm_student)
        {
            int resRemove = students.RemoveAll(student => student == rm_student);
            if (resRemove == 0)
            {
                Notify?.Invoke(this, new JurnalEventArgs("\nThere is no student like this", students.Count));
            }
            else
            {
                SortStudents();
                Notify?.Invoke(this, new JurnalEventArgs($"\nRemoved student {rm_student}", students.Count));
            }
        }

        public void SortStudents()
        {
            students.Sort();
            int i = 1;
            foreach (Student student in students)
            {
                student.Id = i;
                i++;
            }
        }
    }
}
