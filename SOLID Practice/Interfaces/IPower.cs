using SOLID_Practice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Practice.Interfaces
{
    interface IPower
    {
        string Title { get; set; }

        string Description { get; set; }
        int PowerType { get; set; }

        int PointCost { get; set; }

        int[] Location { get; set; }

        IGamePiece Caster { get; set; }
        bool Action(IGamePiece target);
        bool areaAction(int[] location);
        IGamePiece Summon(int[] target, string name, IGameBoardController GameBoard);

    }
}
