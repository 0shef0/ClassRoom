using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Docs.Interfaces;

namespace Docs.Models
{
    public class Student : IHuman, IComparable<Student>
    {

        private string name;
        private double mark;
        public Student() { }
        public Student(string _name, double _mark, bool _invalid, Presence _presence, int _extraPoints, int _id, int _age)
        {
            Name = _name;
            Mark = _mark;
            Invalid = _invalid;
            Presence = _presence;
            ExtraPoints = _extraPoints;
            Id = _id;
            Age = _age;
        }

        public int Id { get; set; } = -1;

        public override string? Name
        {
            get { return name; }
            set
            {
                if (value != null && value != "")
                {
                    name = value;
                } else
                {
                    name = "Student";
                }
            }
        }

        public override int Age { get; set; } = -1;

        public double Mark
        {
            get { return mark; }
            set
            {
                if (value <= 2)
                {
                    mark = 2;
                }
                else if (value >= 12)
                {
                    mark = 12;
                }
                else
                {
                    mark = value;
                }
            }
        }

        public override bool Invalid { get; }

        public Presence Presence { get; set; }

        public int ExtraPoints { get; set; }

        public int CompareTo(Student student)
        {
            if (student is null) throw new ArgumentException("Wrong parametr");
            Console.WriteLine("Sorting");
            return Name.CompareTo(student.Name);
        }

        override public string ToString()
        {
            return "\nStudent number: " + Id +
                "\nStudent name: " + Name +
                "\nStudent age:" + Age +
                "\nStudent mark: " + Mark +
                "\nIs Student an invalid?: " + (Invalid ? "yes" : "no") +
                "\nIs Student present today?: he is " + Presence +
                "\nStudent's extra points: " + ExtraPoints;
        }
    }
}
