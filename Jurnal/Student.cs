using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docs
{
    public class Student: Human, IComparable<Student>
    {
        private int id = -1;
        private string name = "Student";
        private int age = -1;
        private double mark;
        private bool invalid;
        private Presence presence;
        private int extraPoints;

        public Student() { }    
        public Student(string name, double mark, bool invalid, Presence presence, int extraPoints, int id, int age) 
        {
            Name = name;
            Mark = mark;
            this.invalid = invalid;
            Presence = presence;
            ExtraPoints = extraPoints;
            Id = id;
            Age = age;
        }        

        public int Id { get; set; }

        public override string? Name { 
            get { return name; }
            set 
            {
                if (value != ""
                    && value != null)
                {
                    name = value;
                }
            } 
        }

        public override int Age { get; set; }

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

        public Presence Presence { get; private set; }

        public int ExtraPoints { get; set; }

        public int CompareTo(Student student)
        {
            if (student is null) throw new ArgumentException("Wrong parametr");
            Console.WriteLine("Sorting");
            return Name.CompareTo(student.Name);
        }

        public int GetFinalMark()
        {
            if(Mark + ExtraPoints >= 12)
            {
                return 12;
            } 
            else if (Mark + ExtraPoints <= 2) 
            {
                return 2;
            } 
            else 
            {
                return Convert.ToInt32(Mark) + ExtraPoints;
            }
        }

        static bool Atestated(int finalMark)
        {
            Predicate<int> isAtestated = (int finalMark) => finalMark > 6;
            return isAtestated(finalMark);
        }

        public Action<int> Atestation = delegate (int finalMark)
        {
            bool result = Atestated(finalMark);
            if (result)
            {
                Console.WriteLine("Atestated");
            }
            else
            {
                Console.WriteLine("Not enough points");
            }
        };

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
