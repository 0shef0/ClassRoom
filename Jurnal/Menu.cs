using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Docs.Interfaces;
using Docs.Methods;
using Docs.Methods.Repository;
using Docs.Models;
using static Docs.Methods.ToPositiveNum;

namespace Docs
{
    public static class Menu
    {
        public static void ChangeNumOfStudents(Jurnal jurnal)
        {
            Console.WriteLine("Enter maximun number of students you want to set");
            int number = 0;
            while (number <= jurnal.Students.Count)
            {
                number = Convert.ToInt32(ToPositiveNumber("Enter maximun number of students you want to set"));
            }
            jurnal.MaxNumOfStudents = number;
        }

        public static int OptionChoice()
        {
            int menu = -1;
            Console.WriteLine("\n1 - Add object" +
                "\n2 - display all objects" +
                "\n3 - sort objects" +
                "\n4 - find object" +
                "\n5 - delete object" +
                "\n6 - delete all objects" +
                "\n7 - change maximum number of students" +
                "\n8 - change student" +
                "\n9 - change teacher" +
                "\n10 - serialise" +
                "\n11 - deserialise" +
                "\n0 - exit programm");
            Console.WriteLine("\nChoose item from the menu (enter from 0 to 10)\n");
            while (menu > 10 || menu < 0)
            {
                menu = Convert.ToInt32(ToPositiveNumber("\nPlease enter from 0 to 10"));
            }
            return menu;
        }

        public static void AddStudent(Jurnal jurnal)
        {
            if (jurnal.Students.Count == jurnal.MaxNumOfStudents)
            {
                Console.WriteLine($"\nYou added {jurnal.MaxNumOfStudents} students. Please, delete someone to add another one or incrase maximum number of students");
                return;
            }
            Console.WriteLine("\nEnter student name");
            string? st_name = Console.ReadLine();
            Console.WriteLine("Enter your age\n");
            int st_age = 0;
            while (st_age < 6 || st_age > 18)
            {
                st_age = Convert.ToInt32(ToPositiveNumber("\nPlease your age (only from 6 to 18)"));
                if (st_age < 6 || st_age > 8)
                {
                    Console.WriteLine("\nPlease your age (only from 6 to 18)");
                }
            }
            Console.WriteLine("\nEnter student mark");
            double st_mark = ToPositiveNumber("\nPlease enter student mark");
            Console.WriteLine("\nEnter is student invalid (yes/no | y/n)");
            bool st_invalid;
            while (true)
            {
                string? invalid = Console.ReadLine();
                if (invalid == "y"
                    || invalid == "Y"
                    || invalid == "yes"
                    || invalid == "Yes")
                {
                    st_invalid = true;
                    break;
                }
                else if (invalid == "n"
                    || invalid == "N"
                    || invalid == "no"
                    || invalid == "No")
                {
                    st_invalid = false;
                    break;
                }
                Console.WriteLine("\nPlease enter yes/no | y/n ");
            }
            Presence st_presence;
            Console.WriteLine("\nEnter student presence:" +
                "\n0 - Present" +
                "\n1 - Absent" +
                "\n2 - Sick");
            switch (Convert.ToInt32(ToPositiveNumber("\nPlease enter from 0 to 2")))
            {
                case 0:
                    st_presence = Presence.Present;
                    break;
                case 1:
                    st_presence = Presence.Absent;
                    break;
                case 2:
                    st_presence = Presence.Sick;
                    break;
                default:
                    st_presence = Presence.Absent;
                    break;
            }
            Console.WriteLine("\nEnter student extra points");
            int st_extraPoints = Convert.ToInt32(ToPositiveNumber("\nPlease enter student extra points"));
            AddObj.AddStudent(jurnal, new Student(st_name, st_mark, st_invalid, st_presence, st_extraPoints, jurnal.Students.Count + 1, st_age));
        }

        public static IEnumerable<Student> FindStudent(Jurnal jurnal)
        {
            List<Student> find = new List<Student>();
            if (jurnal.Students is null || jurnal.Students.Count == 0)
            {
                Console.WriteLine("\nThere is no students in yout jurnal");
                return find;
            }
            else
            {
                Console.WriteLine("\nEnter which field you want to use" +
                    "\n1 - Student number" +
                    "\n2 - Student name" +
                    "\n3 - Student age" +
                    "\n4 - Student mark" +
                    "\n5 - Is student invalid" +
                    "\n6 - Student presence");
                int field = Convert.ToInt32(ToPositiveNumber("\nEnter 1 or 6"));
                switch (field)
                {
                    case 1:
                        Console.WriteLine("\nEnter Student number");
                        int number = Convert.ToInt32(ToPositiveNumber("\nEnter student number"));
                        return from stud in jurnal.Students
                               where stud.Id.Equals(number)
                               select stud;
                    case 2:
                        Console.WriteLine("\nEnter Student age");
                        int age = Convert.ToInt32(ToPositiveNumber("\nEnter student age"));
                        return from stud in jurnal.Students
                               where stud.Age.Equals(age)
                               select stud;
                    case 3:
                        Console.WriteLine("\nEnter Student name");
                        string? name = Console.ReadLine();
                        return from stud in jurnal.Students
                               where stud.Name.Equals(name)
                               select stud;
                    case 4:
                        Console.WriteLine("\nEnter Student mark");
                        int mark = Convert.ToInt32(ToPositiveNumber("\nEnter student mark"));
                        return from stud in jurnal.Students
                               where stud.Mark.Equals(mark)
                               select stud;
                    case 5:
                        Console.WriteLine("\nEnter is Student invalid");
                        bool st_invalid = false;
                        while (true)
                        {
                            string? invalid = Console.ReadLine();
                            if (invalid == "y"
                                || invalid == "Y"
                                || invalid == "yes"
                                || invalid == "Yes")
                            {
                                st_invalid = true;
                                break;
                            }
                            else if (invalid == "n"
                                || invalid == "N"
                                || invalid == "no"
                                || invalid == "No")
                            {
                                st_invalid = false;
                                break;
                            }
                            Console.WriteLine("\nPlease enter yes/no | y/n ");
                        }   
                        return from stud in jurnal.Students
                               where stud.Invalid.Equals(st_invalid)
                               select stud;
                    case 6:
                        Presence presence;
                        Console.WriteLine("\nEnter student presence:" +
                            "\n0 - Present" +
                            "\n1 - Absent" +
                            "\n2 - Sick");
                        int choice = 4;
                        while (choice > 3)
                        {
                            choice = Convert.ToInt32(ToPositiveNumber("\nPlease enter from 0 to 2"));
                        }
                        switch (choice)
                        {
                            case 0:
                                presence = Presence.Present;
                                break;
                            case 1:
                                presence = Presence.Absent;
                                break;
                            case 2:
                                presence = Presence.Sick;
                                break;
                            default:
                                presence = Presence.Absent;
                                break;
                        }
                        return from stud in jurnal.Students
                               where stud.Presence.Equals(presence)
                               select stud;
                    default:
                        return find;
                }
            }
        }

        public static void RemoveStudent(Jurnal jurnal)
        {
            if (jurnal.Students is null || jurnal.Students.Count == 0)
            {
                Console.WriteLine("\nThere is no students in yout jurnal");
            }
            IEnumerable<Student> students = FindStudent(jurnal);
            if(students.Count() != 0)
            {
                RemoveObj.RemoveStudent(jurnal, students.First());
                SortObj.SortStudents(jurnal, 0);
            } else
            {
                Console.WriteLine("\nThere is no student like that");
            }          
        }

        public static void RemoveAllStudents(Jurnal jurnal)
        {
            RemoveAllObj.RemoveAllStudents(jurnal);
        }

        public static void SortStudents(Jurnal jurnal)
        {
            Console.WriteLine("\nEnter sorting options:" +
                            "\n0 - Id" +
                            "\n1 - Name" +
                            "\n2 - Age" +
                            "\n3 - Mark");
            int choice = 4;
            while (choice > 3)
            {
                choice = Convert.ToInt32(ToPositiveNumber("\nPlease enter from 0 to 2"));
            }
            SortObj.SortStudents(jurnal, choice);
        }

        public static void ChangeStudentParams(Jurnal jurnal)
        {
            Console.WriteLine("Choose which student you want to edit (enter it's number)");
            int number = Convert.ToInt32(ToPositiveNumber("\nEnter student extra points")) - 1;
            if (jurnal.Students is null || number >= jurnal.Students.Count)
            {
                Console.WriteLine($"There is only {jurnal.Students.Count} students");
                return;
            }
            Console.WriteLine("\nEnter which field you want to change" +
                    "\n1 - Student extrapoints" +
                    "\n2 - Student name" +
                    "\n3 - Student age" +
                    "\n4 - Student mark");
            int field = Convert.ToInt32(ToPositiveNumber("\nEnter 1 or 4"));
            switch (field)
            {
                case 1:
                    Console.WriteLine("\nEnter Student extra points");
                    int extraPoints = Convert.ToInt32(ToPositiveNumber("\nEnter student extra points"));
                    jurnal.Students[number].ExtraPoints = extraPoints;
                    break;
                case 2:
                    Console.WriteLine("\nEnter Student name");
                    string? name = Console.ReadLine();
                    jurnal.Students[number].Name = name;
                    break;
                case 3:
                    Console.WriteLine("\nEnter Student age");
                    int age = 0;
                    while (age < 6 || age > 18)
                    {
                        age = Convert.ToInt32(ToPositiveNumber("\nPlease your age (only from 6 to 18)"));
                        if (age < 6 || age > 8)
                        {
                            Console.WriteLine("\nPlease your age (only from 6 to 18)");
                        }
                    }
                    jurnal.Students[number].Age = age;
                    break;
                case 4:
                    Console.WriteLine("\nEnter Student mark");
                    int mark = Convert.ToInt32(ToPositiveNumber("\nEnter student mark"));
                    jurnal.Students[number].Mark = mark;
                    break;
                default:
                    Console.WriteLine("\nThere is no option like that");
                    return;
            }
            SortObj.SortStudents(jurnal, 0);
        }

        public static void ChangeTeacherParams(Jurnal jurnal)
        {
            Console.WriteLine("\nEnter which field you want to change" +
                    "\n1 - Your name" +
                    "\n2 - Your age");
            int field = Convert.ToInt32(ToPositiveNumber("\nEnter 1 or 2"));
            switch (field)
            {
                case 1:
                    Console.WriteLine("\nEnter Your name");
                    string? name = Console.ReadLine();
                    jurnal.Teacher.Name = name;
                    break;
                case 2:
                    Console.WriteLine("\nEnter Your age");
                    int age = 0;
                    while (age < 21 || age > 60)
                    {
                        age = Convert.ToInt32(ToPositiveNumber("\nPlease your age (only from 21 to 60)"));
                        if (age < 21 || age > 60)
                        {
                            Console.WriteLine("\nPlease your age (only from 21 to 60)");
                        }
                    }
                    jurnal.Teacher.Age = age;
                    break;
            }
        }

        public static void ShowAllStudents(Jurnal jurnal)
        {
            if (jurnal.Students is null || jurnal.Students.Count == 0)
            {
                Console.WriteLine("\nThere is no students in yout jurnal");
            }
            else
            {
                foreach (Student student in jurnal.Students)
                {
                    DisplayConsole.Display(student);
                }
            }
        }

        public static void Serialise(Jurnal jurnal)
        {
            Console.WriteLine("Select type of serialisation" +
                "\n1 - JSON" +
                "\n2 - XML");
            int select = -1;
            while (select < 0 || select > 2)
            {
                select = Convert.ToInt32(ToPositiveNumber("\nEnter from 1 or 2"));
            }
            if (select == 1)
            {
                ToJson.Display(jurnal);
            }
            else
            {
                ToXML.Display(jurnal);
            }
        }

        public static void Deserialise(Jurnal jurnal)
        {
            Console.WriteLine("Select type of serialisation" +
                "\n1 - JSON" +
                "\n2 - XML");
            int select = -1;
            while (select < 0 || select > 2)
            {
                select = Convert.ToInt32(ToPositiveNumber("\nEnter from 1 or 2"));
            }
            if (select == 1)
            {
                FromJson.ConvertFromJson(Convert.ToString(jurnal.GetHashCode()));
            }
            else
            {
                FromXML.ConvertFromXML(Convert.ToString(jurnal.GetHashCode()));
            }
        }

        public static void Exit(out bool isRunning)
        {
            Console.WriteLine("Bye");
            isRunning = false;
        }
    }
}
