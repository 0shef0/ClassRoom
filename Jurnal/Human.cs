using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docs
{
    public abstract class Human
    {
        private int name;
        private int age;
        private bool invalid;

        public abstract string Name { get; set; }

        public abstract int Age { get; set;}

        public abstract bool Invalid { get; }

        override public abstract string ToString();
    }
}
