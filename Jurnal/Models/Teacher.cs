using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Docs.Interfaces;

namespace Docs
{
    public class Teacher : IHuman
    {
        public Teacher()
        { 
        
        }
        public Teacher(string name, int age, bool invalid, string lesson) 
        { 
            Name = name;
            Age = age;
            Invalid = invalid;
            Lesson = lesson;
        }
        

        public override string Name { get; set; }
        public override int Age { get; set; }
        public override bool Invalid { get; }
        public string Lesson { get; set; }

        public override string ToString()
        {
            return "\nTeacher name: " + Name+
                "\nTeacher age: " + Age +
                "\nTeacher lesson: " + Lesson +
                "\nIs teacher invalid? :" + (Invalid ? "yes" : "no");
        }
    }
}
