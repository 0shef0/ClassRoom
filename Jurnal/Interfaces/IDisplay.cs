using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docs.Interfaces
{
    internal interface IDisplay
    {
        public static void Display<T>(T obj) { }
    }
}
