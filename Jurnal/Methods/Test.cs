using Docs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docs.Methods
{
    public class Test
    {
        static bool Atestated(int finalMark)
        {
            Predicate<int> isAtestated = (finalMark) => finalMark > 6;
            return isAtestated(finalMark);
        }

        public Action<Student> Atestation = delegate (Student student)
        {
            bool result = Atestated(Convert.ToInt32(student.Mark) + student.ExtraPoints);
            if (result)
            {
                Console.WriteLine("Atestated");
            }
            else
            {
                Console.WriteLine("Not enough points");
            }
        };
    }
}
