using SOLID_Practice.Dictionaries;
using SOLID_Practice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Practice.Interfaces
{
    interface IGameBoardController
    {
        public IDictionary<string, int[]> BoardSpaces { get; }

        List<IGamePiece> Pieces { get; set; }

        bool MoveTroop(int[] location, IGamePiece target);

        void DisplayBoard();
    }
}
