using Docs.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Docs.Methods
{
    public class ToXML: IDisplay
    {
        public static void Display<T>(T obj)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(T));
            using (FileStream fs = new FileStream($"{obj.GetHashCode()}.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, obj);
            }
            Console.WriteLine("Data has been saved to XML file");
        }
    }
}
