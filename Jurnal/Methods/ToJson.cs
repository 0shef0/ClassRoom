using Docs.Interfaces;
using Docs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Docs.Methods
{
    public class ToJson: IDisplay
    {
        public static async void Display<T>(T obj)
        {
            using (FileStream fs = new FileStream($"{obj.GetHashCode()}.json", FileMode.OpenOrCreate))
            {
                await JsonSerializer.SerializeAsync<T>(fs, obj);
                Console.WriteLine("Data has been saved to JSON file");
            }
        }
    }
}
