using SOLID_Practice.Interfaces;
using SOLID_Practice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Practice.Powers
{
    class Attack : IPower
    {
        public Interfaces.IGamePiece Caster { get; set; }
        public string Title { get ; set ; }
        public string Description { get ; set ; }
        public int PointCost { get ; set ; }
        public int[] Location { get ; set ; }
        public int PowerType { get; set; }

        public Attack(string title, string description, int pointCost,int[] location)
        {
            Title = title;
            Description = description;
            PointCost = pointCost;
            Location = location;
            PowerType = 1;

        }

        public bool Action (IGamePiece target)
        {
            Random die = new Random();
            int attackRoll = Caster.Strength + die.Next(1, 6);
            int defenseRoll = target.Defense + die.Next(1, 6);
            int damageRoll = Caster.Strength + die.Next(1, 3);
            if (attackRoll>defenseRoll)
            {
                target.AlterHealth(true,damageRoll);
                return true;
            }
            return false;

        }

        public bool areaAction(int[] location)
        {
            throw new NotImplementedException();
        }

        public IGamePiece Summon(int[] target, string name, IGameBoardController GameBoard)
        {
            throw new NotImplementedException();
        }
    }
}
