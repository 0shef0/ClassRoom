using Docs;
using static Docs.Methods.ToPositiveNum;
using static Docs.Menu;
using Docs.Models;

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
            DateOnly date;
            while (true)
            {
                Console.WriteLine("Enter date using format \"dd.mm.yyyy\"");
                string str_date = Console.ReadLine();
                if(DateOnly.TryParse(str_date, out date) == true)
                {
                    break;
                }
            }

            Console.WriteLine("Enter your name\n");
            string name = Console.ReadLine();
            Console.WriteLine("Enter your age\n");
            int age = 0;
            while (age < 21 || age > 60) 
            {
                age = Convert.ToInt32(ToPositiveNumber("\nPlease your age (only from 21 to 60)"));
                if(age < 21 || age > 60)
                {
                    Console.WriteLine("\nPlease your age (only from 21 to 60)");
                }
            }
            Console.WriteLine("Enter are you invalid\n");
            bool t_invalid;
            while (true)
            {
                string? invalid = Console.ReadLine();
                if (invalid == "y"
                    || invalid == "Y"
                    || invalid == "yes"
                    || invalid == "Yes")
                {
                    t_invalid = true;
                    break;
                }
                else if (invalid == "n"
                    || invalid == "N"
                    || invalid == "no"
                    || invalid == "No")
                {
                    t_invalid = false;
                    break;
                }
                Console.WriteLine("\nPlease enter yes/no | y/n ");
            }
            Console.WriteLine("Enter your lesson\n");
            string lesson = Console.ReadLine();
            Jurnal jurnal = new Jurnal(date, new Teacher(name, age, t_invalid, lesson), number);
            jurnal.Notify += DisplayMessage;
            while (isRunning)
            {
                int menu = OptionChoice();
                switch (menu)
                {
                    case 1:
                        AddStudent(jurnal);
                        break;
                    case 2:
                        ShowAllStudents(jurnal);
                        break;
                    case 3:
                        SortStudents(jurnal);
                        break;
                    case 4:
                        FindStudent(jurnal);
                        break;
                    case 5:
                        RemoveStudent(jurnal);
                        break;
                    case 6:
                        RemoveAllStudents(jurnal);
                        break;
                    case 7:
                        ChangeNumOfStudents(jurnal);
                        break;
                    case 8:
                        ChangeStudentParams(jurnal);
                        break;
                    case 9:
                        ChangeTeacherParams(jurnal);
                        break;
                    case 10:
                        Serialise(jurnal);
                        break;
                    case 11:
                        Deserialise(jurnal);
                        break;
                    case 0:
                        Exit(out isRunning);
                        break;
                    default:
                        Console.WriteLine("There is no option like that");
                        break;
                }
            }
        }
        static void DisplayMessage(Jurnal jurnal, JurnalEventArgs e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine($"Now, you have {jurnal.Students.Count} of students");
        }
    }
}