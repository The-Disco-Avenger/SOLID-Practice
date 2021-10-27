using SOLID_Practice.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Practice.Models
{
    class Building : IBuilding, IGamePiece
    {
        public string Title { get; set; }
        public int PieceType { get; set; }
        public int MaxHealth { get; set; }
        public int CurrentHealth { get; set; }
        public int[] Location { get; set; }
        public List<IPower> Powers { get; set; }
        public int PointCost { get; set; }
        public int CoolDownTimer { get; set; }
        public int Defense { get; set; }
        public int Strength { get; set; }
        public int Team { get; set; }
        public bool Activated { get; set ; }

        public void AlterHealth(bool isDamage, int thisMuch)
        {
            if (isDamage)
            {
                CurrentHealth -= thisMuch;
            }
            else
            {
                CurrentHealth += thisMuch;
            }
        }

        public int ReduceCoolDownTimer(int thisMuch)
        {
            return CoolDownTimer -= thisMuch;
        }
    }
}
