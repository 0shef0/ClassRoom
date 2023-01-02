using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jurnal
{
    public class Student
    {
        private int id;
        private string? name = "Student";
        private double mark;
        private bool invalid;
        private Presence presence;
        private int extraPoints;

        public Student() { }    
        public Student(string name, double mark, bool invalid, Presence presence, int extraPoints, int id) 
        {
            Name = name;
            Mark = mark;
            Invalid = invalid;
            Presence = presence;
            ExtraPoints = extraPoints;
            Id = id;
        }        

        public int Id { get; set; }

        public string? Name { 
            get { return name; }
            set 
            {
                if (value != ""
                    || value != null)
                {
                    name = value;
                }
            } 
        }

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

        public bool Invalid { get; private set; }

        public Presence Presence { get; private set; }

        public int ExtraPoints { get; set; }

        public string GetFinalMark()
        {
            if(Mark + ExtraPoints >= 12)
            {
                return "\n" + Name + " final mark is 12";
            } 
            else if (Mark + ExtraPoints <= 2) 
            {
                return "\n" + Name + " final mark is 2";
            } 
            else 
            {
                return "\n" + Name + " final mark is " + (Mark + ExtraPoints);
            }
        }
        override public string ToString()
        {
            return "\nStudent number: " + Id +
                "\nStudent name: " + Name +
                "\nStudent mark: " + Mark +
                "\nIs Student an invalid?: " + (Invalid ? "yes" : "no") +
                "\nIs Student present today?: he is " + Presence +
                "\nStudent's extra points: " + ExtraPoints;
        }
    }
}
