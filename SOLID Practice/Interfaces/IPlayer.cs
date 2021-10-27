using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Practice.Interfaces
{
    interface IPlayer
    {
        int RoundCounter { get; set; }

        int MaxPointPool { get; set; }

        int CurrentPointPool { get; set; }

        void IncrementRoundCounter();

        int AlterPoints(int thisMany, bool spending);
    }
}
