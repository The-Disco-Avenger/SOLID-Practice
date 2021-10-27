using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Practice.Interfaces
{
    interface IDisplayService
    {
        void WriteToConsole(string message);

        string WriteChoices(List<string> choices);
    }
}
