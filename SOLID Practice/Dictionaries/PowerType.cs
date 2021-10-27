using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Practice.Dictionaries
{
    static class PowerType
    {
        static public IDictionary<string, int> PowerTypes = new Dictionary<string, int>()
        {
            {"Action",1},
            {"Area Action",2},
            {"Summon",3}
        };
    }
}
