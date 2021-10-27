using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Practice.Interfaces
{
    interface IBuilding
    {

        int CoolDownTimer { get; set; }

        int ReduceCoolDownTimer(int thisMuch);

    }
}
