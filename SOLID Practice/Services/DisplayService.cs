using SOLID_Practice.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Practice.Services
{
    class DisplayService :IDisplayService
    {
        public void WriteToConsole(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine(" ");
            //Console.WriteLine("".PadRight(94, '-'));
            //Console.WriteLine(" ");
        }
        
        public string WriteChoices(List<string> choices)
        {
            List<string> message = new List<string>();
            message.Add("Please Type one of the following ");
            for (int i = 0;i<choices.Count();i++)
            {
                message.Add("\""+choices[i]+"\"");
                if (i + 1! < choices.Count())
                {
                    message.Add(", ");
                }
            }
            WriteToConsole(String.Join(string.Empty,message.ToArray()));
            Console.WriteLine("".PadRight(94, '-'));
            return Console.ReadLine().ToLower();
        }
    }
}
