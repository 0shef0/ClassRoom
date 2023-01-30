using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docs.Interfaces
{
    public abstract class IHuman
    {
        public abstract string Name { get; set; }

        public abstract int Age { get; set; }

        public abstract bool Invalid { get; }

        override public abstract string ToString();
    }
}
