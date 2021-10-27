using SOLID_Practice.Dictionaries;
using SOLID_Practice.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Practice.Services
{
    class RoundService : IRoundService
    {
        public IGameBoardController GameBoard { get; set; }
        public IDisplayService Display { get; set; }
        public RoundService(IGameBoardController gameboard, IDisplayService display)
        {
            GameBoard = gameboard;
            Display = display;
        }
        public int[] SelectTeamLocation(int team)
        {
            List<string> choices = new List<string>();
            foreach (KeyValuePair<string, int[]> boardspace in GameBoard.BoardSpaces)
            {
                var piecesAtLocation = GameBoard.Pieces.Where(x => x.Team == team && x.Location.SequenceEqual(boardspace.Value)).ToList();
                if (piecesAtLocation.Count() > 0)
                {
                    choices.Add(boardspace.Key);
                }
            }
            do
            {
                string action = Display.WriteChoices(choices);
                if (choices.Contains(action))
                {
                    int[] selectedLocation;
                    switch (action)
                    {
                        case "location 1":
                            return selectedLocation = new int[] { 1, 1 };

                        case "location 2":
                            return selectedLocation = new int[] { 1, 2 };

                        case "location 3":
                            return selectedLocation = new int[] { 1, 3 };

                        case "location 4":
                            return selectedLocation = new int[] { 2, 1 };

                        case "location 5":
                            return selectedLocation = new int[] { 2, 2 };

                        case "location 6":
                            return selectedLocation = new int[] { 2, 3 };
                    }
                }
            } while (true);
        }
        public IGamePiece SelectUnit(int[] location)
        {
            List<IGamePiece> locationUnits = GameBoard.Pieces.Where(x => x.Location[0] == location[0] && x.Location[1] == location[1] && x.Activated == false).ToList();
            List<string> choices = new List<string>();
            foreach (IGamePiece piece in locationUnits)
            {
                choices.Add(piece.Title + " Current Health: " + piece.CurrentHealth);
            }
            do
            {
                string action = Display.WriteChoices(choices);
                foreach (string choice in choices)
                {
                    if (choice.Contains(action, StringComparison.OrdinalIgnoreCase))
                    {
                        foreach (IGamePiece piece in locationUnits)
                        {
                            if (piece.Title.Equals(action, StringComparison.OrdinalIgnoreCase))
                            {
                                return piece;
                            }
                        }
                    }
                }
            } while (true);
        }
        public IPower SelectPower(IGamePiece unit)
        {
            List<IPower> unitPowers = unit.Powers;
            List<string> choices = new List<string>();
            foreach (IPower power in unitPowers)
            {
                choices.Add(power.Title);
            }
            do
            {
                string action = Display.WriteChoices(choices);
                foreach (string choice in choices)
                {
                    if (choice.Contains(action, StringComparison.OrdinalIgnoreCase))
                    {
                        foreach (IPower power in unitPowers)
                        {
                            if (power.Title.Equals(action, StringComparison.OrdinalIgnoreCase))
                            {
                                return power;
                            }
                        }
                    }
                }
            } while (true);
        }

        public void MoveUnit(IGamePiece unit)
        {
            bool isMoved = false;
            do
            {
                int[] moveToLocation = SelectTeamLocation(unit.Team);
                isMoved = GameBoard.MoveTroop(moveToLocation, unit);
                if (!isMoved)
                {
                    Display.WriteToConsole("Invlaid move selected please select again.");
                }
            } while (!isMoved);
        }

        public IGamePiece SelectTarget(IPower selectedPower)
        {
            int[] targetLocation = SelectTeamLocation(GameBoard.Pieces.Where(x => x.Team != selectedPower.Caster.Team).Select(x => x.Team).Distinct().FirstOrDefault());
            List<IGamePiece> possibleTargets = GameBoard.Pieces.Where(x => x.Location.SequenceEqual(targetLocation)).ToList();
            List<string> choices = new List<string>();
            foreach (IGamePiece piece in possibleTargets)
            {
                if (piece.PieceType != 1 || possibleTargets.Where(x => x.PieceType != 1).Count() < 1)
                {
                    choices.Add(piece.Title);
                }
            }
            do
            {
                string action = Display.WriteChoices(choices);
                foreach (string choice in choices)
                {
                    if (choice.Contains(action, StringComparison.OrdinalIgnoreCase))
                    {
                        foreach (IGamePiece piece in possibleTargets)
                        {
                            if (piece.Title.Equals(action, StringComparison.OrdinalIgnoreCase))
                            {
                                return piece;
                            }
                        }
                    }
                }
            } while (true);

        }
        public void PerformPower(IPower selectedPower)
        {
            IGamePiece target;
            bool hit;
            switch (selectedPower.PowerType)
            {
                case 1:
                    {
                        target = SelectTarget(selectedPower);
                        hit = selectedPower.Action(target);
                        if (hit)
                        {
                            Display.WriteToConsole(selectedPower.Caster.Title + " " + selectedPower.Description + " damaging " + target.Title);
                            break;
                        }
                        Display.WriteToConsole(selectedPower.Caster.Title + " " + selectedPower.Description + " missing " + target.Title);
                        break;
                    }
                case 2:
                    {
                        break;
                    }
                case 3:
                    {
                        int[] location = SelectTeamLocation(selectedPower.Caster.Team);
                        Display.WriteToConsole("Name your creation");
                        string name = Console.ReadLine();
                        IGamePiece summon = selectedPower.Summon(location, name, GameBoard);
                        Display.WriteToConsole("you summoned " + summon.Title + " to " + GameBoard.BoardSpaces.Where(x => x.Value.SequenceEqual(summon.Location)).Select(x => x.Key).FirstOrDefault());
                        GameBoard.Pieces.Add(summon);
                        break;
                    }
            }
        }
    }
}
