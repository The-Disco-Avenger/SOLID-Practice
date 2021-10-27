using SOLID_Practice.Dictionaries;
using SOLID_Practice.Interfaces;
using SOLID_Practice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Practice.Controllers
{
    class GameBoardController : IGameBoardController
    {
        public IDictionary<string, int[]> BoardSpaces
        {
            get
            {
                return new Dictionary<string, int[]>()
                {
                    { "location 1", new int[] { 1, 1 } },
                    { "location 2", new int[] { 1, 2 } },
                    { "location 3", new int[] { 1, 3 } },
                    { "location 4", new int[] { 2, 1 } },
                    { "location 5", new int[] { 2, 2 } },
                    { "location 6", new int[] { 2, 3 } },
                };
            }
        }
        public List<Interfaces.IGamePiece> Pieces { get; set; }
        public IDisplayService Display { get; set; }

        public GameBoardController(IDisplayService display)
        {
            Pieces = new List<Interfaces.IGamePiece>();
            Display = display;
        }

        public void DisplayBoard()
        {
            List<Interfaces.IGamePiece> location1 = Pieces.Where(x => x.Location.SequenceEqual(BoardSpaces["location 1"])).ToList();
            List<Interfaces.IGamePiece> location2 = Pieces.Where(x => x.Location.SequenceEqual(BoardSpaces["location 2"])).ToList();
            List<Interfaces.IGamePiece> location3 = Pieces.Where(x => x.Location.SequenceEqual(BoardSpaces["location 3"])).ToList();
            List<Interfaces.IGamePiece> location4 = Pieces.Where(x => x.Location.SequenceEqual(BoardSpaces["location 4"])).ToList();
            List<Interfaces.IGamePiece> location5 = Pieces.Where(x => x.Location.SequenceEqual(BoardSpaces["location 5"])).ToList();
            List<Interfaces.IGamePiece> location6 = Pieces.Where(x => x.Location.SequenceEqual(BoardSpaces["location 6"])).ToList();


            List<string>[] topSide = new List<string>[6] { new List<string>(), new List<string>(), new List<string>(), new List<string>(), new List<string>(), new List<string>() };
            List<string>[] bottomSide = new List<string>[6] { new List<string>(), new List<string>(), new List<string>(), new List<string>(), new List<string>(), new List<string>() };
            foreach (List<string> row in topSide)
            {
                row.Add("|");
                if (location1.Count() > 0)
                {
                    Interfaces.IGamePiece piece1 = location1.First();
                    location1.Remove(piece1);
                    row.Add((piece1.Title + "| Team " + piece1.Team.ToString()).PadRight(30));
                }
                else
                {
                    row.Add("".PadRight(30));
                }
                row.Add("|");
                if (location2.Count() > 0)
                {
                    Interfaces.IGamePiece piece2 = location2.First();
                    location2.Remove(piece2);
                    row.Add((piece2.Title + "| Team " + piece2.Team.ToString()).PadRight(30));
                }
                else
                {
                    row.Add("".PadRight(30));
                }
                row.Add("|");
                if (location3.Count() > 0)
                {
                    Interfaces.IGamePiece piece3 = location3.First();
                    location3.Remove(piece3);
                    row.Add((piece3.Title + "| Team " + piece3.Team.ToString()).PadRight(30));
                }
                else
                {
                    row.Add("".PadRight(30));
                }
                row.Add("|");
            }
            foreach (List<string> row in bottomSide)
            {
                row.Add("|");
                if (location4.Count() > 0)
                {
                    Interfaces.IGamePiece piece1 = location4.First();
                    location4.Remove(piece1);
                    row.Add((piece1.Title + "| Team " + piece1.Team.ToString()).PadRight(30));
                }
                else
                {
                    row.Add("".PadRight(30));
                }
                row.Add("|");
                if (location5.Count() > 0)
                {
                    Interfaces.IGamePiece piece2 = location5.First();
                    location5.Remove(piece2);
                    row.Add((piece2.Title + "| Team " + piece2.Team.ToString()).PadRight(30));
                }
                else
                {
                    row.Add("".PadRight(30));
                }
                row.Add("|");
                if (location6.Count() > 0)
                {
                    Interfaces.IGamePiece piece3 = location6.First();
                    location6.Remove(piece3);
                    row.Add((piece3.Title + "| Team " + piece3.Team.ToString()).PadRight(30));
                }
                else
                {
                    row.Add("".PadRight(30));
                }
                row.Add("|");
            }
            Console.WriteLine("".PadLeft(94, '-'));
            foreach (List<string> row in topSide)
            {
                Console.WriteLine(String.Join("", row.ToArray()));
            }
            Console.WriteLine("".PadLeft(94, '-'));
            foreach (List<string> row in bottomSide)
            {
                Console.WriteLine(String.Join("", row.ToArray()));
            }
            Console.WriteLine("".PadLeft(94, '-'));



        }

        public bool MoveTroop(int[] location, IGamePiece target)
        {
            bool isMoved = false;
            var locationName = BoardSpaces.Where(x => x.Value.SequenceEqual(location)).Select(x => x.Key).First();
            List<int[]> teamLocations = Pieces.Where(x => x.Team == target.Team).Select(x => x.Location).OrderBy(x => x[1]).Distinct().ToList();
            if (teamLocations.Where(x=>x.SequenceEqual(location)).ToList().Count > 0 && (location[0] > 0 && location[0] < 3) && (location[1] > 0 && location[1] < 4))
            {
                if ((target.Location[0] + 1 == location[0] || target.Location[0] - 1 == location[0] || target.Location[0] == location[0]) || (target.Location[1] + 1 == location[1] || target.Location[1] - 1 == location[1] || target.Location[1] == location[1]))
                {
                        target.Location = location;
                        Display.WriteToConsole(target.Title + " was moved to "+locationName);
                        isMoved = true;
                }
                else
                {
                    Display.WriteToConsole(target.Title + " cannot move to " + locationName + " it is more than one space away.");
                }
            }
            return isMoved;
        }
    }
}
