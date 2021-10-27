using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Practice.Interfaces
{
    interface IRoundService
    {
        int[] SelectTeamLocation(int team);
        IGamePiece SelectUnit(int[] location);
        IPower SelectPower(IGamePiece unit);
        IGamePiece SelectTarget(IPower selectedPower);
        void MoveUnit(IGamePiece unit);
        void PerformPower(IPower selectedPower);
    }
}
