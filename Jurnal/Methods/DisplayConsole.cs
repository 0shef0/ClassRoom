using Docs.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docs.Methods
{
    public class DisplayConsole: IDisplay
    {
        public static void Display<T>(T obj)
        {
            Console.WriteLine(obj.ToString());
        }
    }
}
