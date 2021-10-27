using SOLID_Practice.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Practice.Models
{
    class Player : IPlayer, IGamePiece
    {
        public int RoundCounter { get; set; }
        public int MaxPointPool { get; set; }
        public int CurrentPointPool { get; set; }
        public List<IPower> Powers { get; set; }
        public string Title { get; set; }
        public int PieceType { get; set; }
        public int MaxHealth { get; set; }
        public int CurrentHealth { get; set; }
        public int[] Location { get; set; }
        public int Defense { get; set; }
        public int Team { get; set; }
        public int Strength { get ; set; }
        public bool Activated { get; set; }

        public Player(string title, int[] location, int team)
        {
            RoundCounter = 0;
            MaxPointPool = RoundCounter + 3;
            CurrentPointPool = MaxPointPool;
            Title = title;
            PieceType = 1;
            MaxHealth = 20;
            CurrentHealth = MaxHealth;
            Location = location;
            Defense = 3;
            Team = team;
        }


        public void IncrementRoundCounter()
        {
            RoundCounter++;
        }

        public int AlterPoints(int thisMany, bool spending)
        {
            if (spending)
            {
                return CurrentPointPool -= thisMany;
            }
            return CurrentPointPool += thisMany;
            
        }

        public void AlterHealth(bool isDamage, int thisMuch)
        {
            throw new NotImplementedException();
        }
    }
}
