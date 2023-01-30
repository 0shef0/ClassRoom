using Docs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Docs.Methods
{
    public class FromXML
    {
        public static void ConvertFromXML(string filename)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(Jurnal));
            using (FileStream fs = new FileStream($"{filename}.xml", FileMode.Open))
            {
                Jurnal obj = formatter.Deserialize(fs) as Jurnal;
                Console.WriteLine(obj.ToString());
            }
        }
    }
}
