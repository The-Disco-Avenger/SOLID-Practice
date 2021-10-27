using SOLID_Practice.Interfaces;
using SOLID_Practice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Practice.Powers
{
    class SpawnFootSoldier : IPower
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int PointCost { get; set; }
        public int[] Location { get; set; }
        public IGamePiece Caster { get; set; }
        public int PowerType { get; set; }

        List<IPower> Powers = new List<IPower>();

    public SpawnFootSoldier(string title,int[] location, Interfaces.IGamePiece caster)
        {
            Title = title;
            Caster = caster;
            Location = location;
            Powers.Add(new Attack("Swing Sword", "swings there sword", 0, null, caster));
            PointCost = 0;
            PowerType = 3;
        }

        public IGamePiece Summon(int[] target, string name, IGameBoardController GameBoard)
        {
            return new Troop(name+" "+Title, 3, 5, target, Powers, PointCost, 1, 1, 2, Caster.Team);
        }

        public bool Action(IGamePiece target)
        {
            throw new NotImplementedException();
        }

        public bool areaAction(int[] location)
        {
            throw new NotImplementedException();
        }
    }
}
