using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Practice.Dictionaries
{
    static class GamePieceType
    {
        static public IDictionary<string, int> GamePieceTypes = new Dictionary<string, int>()
        {
            {"Player",1},
            {"Building",2},
            {"Troop",2}
        };
    }
}
