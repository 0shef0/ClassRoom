using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docs.Methods
{
    public class ToPositiveNum
    {
        public static double ToPositiveNumber(string message)
        {
            double res;
            while (true)
            {
                string? line = Console.ReadLine();
                try
                {
                    res = Convert.ToDouble(line);
                    if (res < 0)
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
