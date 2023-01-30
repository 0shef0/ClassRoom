using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Docs.Models;

namespace Docs.Methods
{
    public class FromJson
    {
        public static async void ConvertFromJson(string filename)
        {
            using (FileStream fs = new FileStream($"{filename}.json", FileMode.Open))
            {
                Jurnal obj = await JsonSerializer.DeserializeAsync<Jurnal>(fs);
                Console.WriteLine(obj.ToString());
            }
        }
    }
}
