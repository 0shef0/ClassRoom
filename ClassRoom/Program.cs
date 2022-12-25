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
            List<Jurnal.Student> students = new List<Jurnal.Student>();
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
                        if(students.Capacity == number)
                        {
                            Console.WriteLine("\nYou added " + number +
                                " of students. Please, delete someone to add another one");
                            break;
                        }
                        Console.WriteLine("\nEnter student name");
                        string? st_name = Console.ReadLine() ?? "Student";
                        Console.WriteLine("\nEnter student mark");
                        decimal st_mark = ToPositiveNumber("\nPlease enter student mark");
                        Console.WriteLine("\nEnter is student invalid (yes/no | y/n)");
                        bool st_invalid;
                        while (true)
                        {
                            string? invalid = Console.ReadLine();
                            if (invalid == "y" || invalid == "Y" || invalid == "yes" || invalid == "Yes") 
                            {
                                st_invalid = true;
                                break;
                            } else if (invalid == "n" || invalid == "N" || invalid == "no" || invalid == "No")
                            {
                                st_invalid = false;
                                break;
                            }
                            Console.WriteLine("\nPlease enter yes/no | y/n ");
                        }
                        Presence st_presence;
                        Console.WriteLine("\nEnter student presence:\n0 - Present\n1 - Absent\n2 - Sick");
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
                        students.Add(new Student(st_name, st_mark, st_invalid, st_presence, st_extraPoints));
                        break;
                    case 2:
                        if(students.Capacity == 0)
                        {
                            Console.WriteLine("\nThere is no students in yout jurnal");
                        } else
                        {
                            foreach(Student student in students)
                            {
                                Console.WriteLine(student);
                            }
                        }
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5: 
                        break;
                    case 0: 
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("\nThere is no function for this number\n");
                        break;
                }
            }
        }
        static decimal ToPositiveNumber(string message)
        {
            decimal res;
            while (true)
            {
                string? line = Console.ReadLine();
                try
                {
                    res = Convert.ToDecimal(line);
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