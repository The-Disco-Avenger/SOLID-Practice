using SOLID_Practice.Controllers;
using SOLID_Practice.Dictionaries;
using SOLID_Practice.Interfaces;
using SOLID_Practice.Models;
using SOLID_Practice.Powers;
using SOLID_Practice.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SOLID_Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the SOLID Practice game!!");

            IDisplayService Display = new DisplayService();
            IGameBoardController GameBoard = new GameBoardController(Display);
            //may want to move from class injection of GameBoard and Display to Method injection to address GameBoard Pieces being added and removed. 
            IRoundService Round = new RoundService(GameBoard, Display);


            Player player1 = new Player("Dave the Great", GameBoard.BoardSpaces["location 2"], 1);

            Player player2 = new Player("Rachel the Grand", GameBoard.BoardSpaces["location 5"], 2);

            GameBoard.Pieces.Add(player1);
            GameBoard.Pieces.Add(player2);
            List<IGamePiece> players = GameBoard.Pieces.Where(x => x.PieceType == GamePieceType.GamePieceTypes["Player"]).ToList();
            foreach (Player player in players)
            {
                player.Powers = new List<IPower> { new SpawnFootSoldier("Foot Soldier", player.Location, player) };
                int[] leftOfPlayer = new int[] { player.Location[0], player.Location[1] - 1 };
                int[] rightOfPlayer = new int[] { player.Location[0], player.Location[1] + 1 };
                GameBoard.Pieces.Add(player.Powers.Where(x => x.Title.Equals("Foot Soldier")).First().Summon(leftOfPlayer, "1", GameBoard));
                GameBoard.Pieces.Add(player.Powers.Where(x => x.Title.Equals("Foot Soldier")).First().Summon(player.Location, "2", GameBoard));
                GameBoard.Pieces.Add(player.Powers.Where(x => x.Title.Equals("Foot Soldier")).First().Summon(rightOfPlayer, "3", GameBoard));
            }

            

            do
            {
                foreach (Player player in GameBoard.Pieces.Where(x => x.PieceType == GamePieceType.GamePieceTypes["Player"]).ToList())
                {
                    GameBoard.DisplayBoard();
                    if (GameBoard.Pieces.Where(x => x.Activated == false && x.Team == player.Team).Count() > 0)
                    {
                        Display.WriteToConsole(player.Title + " which location would you like to activate");
                        int[] location = Round.SelectTeamLocation(player.Team);

                        Display.WriteToConsole("please select a unit at the selected location");
                        IGamePiece selectedUnit = Round.SelectUnit(location);

                        Display.WriteToConsole("What would you like " + selectedUnit.Title + " to do?");
                        string selectedAction = Display.WriteChoices(new List<string> { "Perform", "Move", "Retire" });

                        switch (selectedAction)
                        {
                            case "perform":
                                Display.WriteToConsole("Which power would you like " + selectedUnit.Title + " to perform?");
                                IPower selectedPower = Round.SelectPower(selectedUnit);
                                Round.PerformPower(selectedPower);
                                break;

                            case "move":
                                Display.WriteToConsole("Where would you like " + selectedUnit.Title + " to move?");
                                Round.MoveUnit(selectedUnit);
                                break;

                            case "retire":
                                GameBoard.Pieces.Remove(selectedUnit);
                                break;
                        }
                        foreach (IGamePiece piece in GameBoard.Pieces)
                        {
                            if (piece.CurrentHealth <= 0)
                            {
                                GameBoard.Pieces.Remove(piece);
                            }
                        }
                    }
                }
                if (GameBoard.Pieces.Where(x => x.Activated == false).Count() < 1)
                {
                    foreach (IGamePiece piece in GameBoard.Pieces)
                    {
                        piece.Activated = false;
                    }
                }
            } while (players.Count() > 1);
            Display.WriteToConsole(players.First().Title + " you are the WINNER WOOOOOO!!!!!!!");
            Console.ReadLine();

        }
    }
}
