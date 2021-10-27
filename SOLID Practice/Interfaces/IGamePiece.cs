using SOLID_Practice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Practice.Interfaces
{
    interface IGamePiece
    {
        string Title { get; set; }

        int PieceType { get; set; }

        int MaxHealth { get; set; }

        int CurrentHealth { get; set; }

        int Defense { get; set; }
        public int Strength { get; set; }

        int[] Location { get; set; }

        int Team { get; set; }
        bool Activated { get; set; }

        List<IPower> Powers { get; set; }

        void AlterHealth(bool isDamage, int thisMuch);
    }
}
