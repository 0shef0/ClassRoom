using Jurnal;


namespace ClassRoom
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isRunning = true;
            int number = 0;
            Console.WriteLine("Enter number of students\n");
            while (number <= 0)
            {
                number = Convert.ToInt32(ToPositiveNumber("\nPlease enter number of students"));
            }
            List<Student> students = new List<Student>();
            while(isRunning)
            {
                int? menu = null;
                Console.WriteLine("\n1 - Add object" +
                    "\n2 - display all objects" +
                    "\n3 - find object" +
                    "\n4 - delete object" +
                    "\n5 - demonstrate objects behavior" +
                    "\n0 - exit programm");
                Console.WriteLine("\nChoose item from the menu (enter from 0 to 5)\n");
                while (menu > 5 || menu == null)
                {
                    menu = Convert.ToInt32(ToPositiveNumber("\nPlease enter from 0 to 5"));
                }
                switch (menu)
                {
                    case 1:
                        if(students.Count == number)
                        {
                            Console.WriteLine("\nYou added " + number +
                                " of students. Please, delete someone to add another one");
                            break;
                        }
                        Console.WriteLine("\nEnter student name");
                        string? st_name = Console.ReadLine();
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
                            } else if (invalid == "n" 
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
                        switch(Convert.ToInt32(ToPositiveNumber("\nPlease enter from 0 to 2")))
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
                        students.Add(new Student(st_name, st_mark, st_invalid, st_presence, st_extraPoints, students.Count + 1));
                        break;
                    case 2:
                        if(students.Capacity == 0)
                        {
                            Console.WriteLine("\nThere is no students in yout jurnal");
                        } 
                        else
                        {
                            foreach(Student student in students)
                            {
                                Console.WriteLine(student);
                            }
                        }
                        break;
                    case 3:
                        if (students.Capacity == 0)
                        {
                            Console.WriteLine("\nThere is no students in yout jurnal");
                        }
                        else
                        {
                            Console.WriteLine("\nEnter which field you want to find student" +
                                "\n1 - Student name" +
                                "\n2 - Student mark");
                            int field = Convert.ToInt32(ToPositiveNumber("\nEnter 1 or 2"));
                            switch (field)
                            {
                                case 1:
                                    Console.WriteLine("\nEnter Student name");
                                    string? name = Console.ReadLine();
                                    List<Jurnal.Student> findName = students.FindAll(student => student.Name == name);
                                    if(findName.Count > 0)
                                    {
                                        foreach (Student student in findName)
                                        {
                                            Console.WriteLine(student);
                                        }
                                    } else
                                    {
                                        Console.WriteLine("\nThere no student with this name");
                                    }
                                    break;
                                case 2:
                                    Console.WriteLine("\nEnter Student mark");
                                    int mark = Convert.ToInt32(ToPositiveNumber("\nEnter student mark"));
                                    List<Jurnal.Student> findMark = students.FindAll(student => student.Mark == mark);
                                    if (findMark.Count > 0)
                                    {
                                        foreach (Student student in findMark)
                                        {
                                            Console.WriteLine(student);
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nThere no student with this mark");
                                    }
                                    break;
                                default:
                                    Console.WriteLine("\nThere is no option like that");
                                    break;
                            }
                        }
                        break;
                    case 4:
                        if (students.Capacity == 0)
                        {
                            Console.WriteLine("\nThere is no students in yout jurnal");
                        } 
                        else
                        {
                            Console.WriteLine("\nEnter wich parametr you want to remove student" +
                            "\n1 - by number" +
                            "\n2 - by extrapoints");
                            int field = Convert.ToInt32(ToPositiveNumber("\nEnter 1 or 2"));
                            switch (field)
                            {
                                case 1:
                                    Console.WriteLine("\nEnter number of srudent");
                                    int id = Convert.ToInt32(ToPositiveNumber("\nEnter number of student"));
                                    int resId = students.RemoveAll(student => student.Id == id);
                                    if (resId == 0)
                                    {
                                        Console.WriteLine("\nThere is no student with this number");
                                    } 
                                    else
                                    {
                                        int i = 1;
                                        foreach (Student student in students)
                                        {
                                            student.Id = i;
                                            i++;
                                        }
                                    }
                                    break;
                                case 2:
                                    Console.WriteLine("\nEnter number of srudent");
                                    int extraPoints = Convert.ToInt32(ToPositiveNumber("\nEnter number of student"));
                                    int resExtra = students.RemoveAll(student => student.ExtraPoints == extraPoints);
                                    if (resExtra == 0)
                                    {
                                        Console.WriteLine("\nThere is no student with this extra points");
                                    }
                                    else
                                    {
                                        int i = 1;
                                        foreach (Student student in students)
                                        {
                                            student.Id = i;
                                            i++;
                                        }
                                    }
                                    break;
                            }
                        }
                        break;
                    case 5:
                        if (students.Capacity == 0)
                        {
                            Console.WriteLine("\nThere is no students in yout jurnal");
                        }
                        else
                        {
                            foreach (Student student in students)
                            {
                                Console.WriteLine(student.GetFinalMark());
                            }
                        }
                        break;
                    case 0:
                        Console.WriteLine("\nBye");
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("\nThere is no function for this number");
                        break;
                }
            }
        }

        static double ToPositiveNumber(string message)
        {
            double res;
            while (true)
            {
                string? line = Console.ReadLine();
                try
                {
                    res = Convert.ToDouble(line);
                    if(res < 0)
                    {
                        throw new FormatException();
                    }
                    return res;
                }
                catch (FormatException)
                {
                    Console.WriteLine(message);
                }
            }
        }
    }
}