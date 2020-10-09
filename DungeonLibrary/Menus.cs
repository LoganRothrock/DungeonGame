using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Menus
    {
        //Handles the menus inside a battle
        public static void FightMenu(Player player, Monster monster, string[] actions)
        {
            int menuPosition = 0, startRow = 0;
            int count = 0;
            bool ctinue = true;
            do
            {
                startRow = 1;
                count = 0;
                foreach (string action in actions)
                {
                    Console.SetCursorPosition(1, startRow);
                    if (menuPosition == 0 && count == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(action);
                        Console.ResetColor();
                    }
                    else if (menuPosition == 1 && count == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(action);
                        Console.ResetColor();
                    }
                    else if (menuPosition == 2 && count == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(action);
                        Console.ResetColor();
                    }
                    else if (menuPosition == 3 && count == 3)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(action);
                        Console.ResetColor();
                    }
                    else if (menuPosition == 4 && count == 4)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(action);
                        Console.ResetColor();
                    }
                    else if (menuPosition == 5 && count == 5)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(action);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine(action);
                    }
                    count++;
                    startRow++;
                }
                ConsoleKey userInput = Console.ReadKey(true).Key;
                switch (userInput)
                {
                    case (ConsoleKey.DownArrow):
                        if (menuPosition < 5)
                        {
                            menuPosition++;
                        }
                            break;
                    case ConsoleKey.UpArrow:
                        if (menuPosition > 0)
                        {
                            menuPosition--;
                        }
                        break;
                    case ConsoleKey.Enter:
                        if (menuPosition == 0)
                        {
                            Combat.DoBattle(player,monster);
                            ctinue = false;
                            if (monster.Life <= 0)
                            {
                                //TODO Give player item from Monster drop pool
                                //the monster is dead
                                //You could put some logic here to have the player collect an item, get life back, or something similiar
                                Console.SetCursorPosition(1, 11);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write("\nYou killed {0}!\n", monster.Name);
                                Console.ResetColor();
                                player.Exp += monster.GetStats();
                                Console.SetCursorPosition(1, 11);
                                Console.Write(player.Name + " gained " + monster.GetStats() + " exp");
                                player.DetermineLevelUp();
                                Console.ReadKey();
                            }
                        }
                        else if (menuPosition == 1)
                        {

                        }
                        else if (menuPosition == 2)
                        {

                        }
                        else if (menuPosition == 3)
                        {

                        }
                        else if (menuPosition == 4)
                        {

                        }
                        else if (menuPosition == 5)
                        {

                        }
                        break;
                }
            } while (ctinue);

        }
        //Handles Character Creation
        public static Player CharacterCreationMenu(string[] races, UserUI raceInfo, Player player, Weapon weapon)
        {
            Console.WriteLine("Please enter your characters name");
            string playerName = Console.ReadLine();
            Console.WriteLine("\nPlease choose a race. Each race comes with different bonuses");
            bool ctinue = true, finish = false;
            Race pRace = Race.Human;
            do
            {
                Console.WriteLine();
                int menuPosition = 0, startRow = 0;
                int count = 0;
                UserUI.MakeBoxAtPosition(raceInfo, 20, 5);
                do
                {
                    startRow = 5;
                    count = 0;
                    foreach (string race in races)
                    {
                        Console.SetCursorPosition(1, startRow);
                        if (menuPosition == 0 && count == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine(race);
                            Console.ResetColor();
                            UserUI.TextFormatter(raceInfo, "Strong and muscular. Values strength above all else. Not a very bright race. +10 to Health, +5 to strength, -5 to Intelligence", 6, 21, false);
                        }
                        else if (menuPosition == 1 && count == 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine(race);
                            Console.ResetColor();
                            UserUI.TextFormatter(raceInfo, "Tall and proud humanoids. Fights quick and efficently. +5 to Evasion, +5 to Dexterity, -10 to Health, 6, 21, false", 6, 21, false);
                        }
                        else if (menuPosition == 2 && count == 2)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine(race);
                            Console.ResetColor();
                            UserUI.TextFormatter(raceInfo, "Small and agile these pesky creatures love to ambush and overwhelm prey with their numbers.  +5 to Evasion, +5 to Agility, -10 to Health", 6, 21, false);
                        }
                        else if (menuPosition == 3 && count == 3)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine(race);
                            Console.ResetColor();
                            UserUI.TextFormatter(raceInfo, "A demi-human with both humanoid and feral characteristics. Prefer to fight head on tooth and nail. +5 to strength, +5 to Agility, +10 to Health", 6, 21, false);
                        }
                        else if (menuPosition == 4 && count == 4)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine(race);
                            Console.ResetColor();
                            UserUI.TextFormatter(raceInfo, "Small sturdy individuals that excel in being on the front line and taking damage. Master craftsmen. +5 to Evasion, +5 to Defense, -5 Agility", 6, 21, false);
                        }
                        else if (menuPosition == 5 && count == 5)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine(race);
                            Console.ResetColor();
                            UserUI.TextFormatter(raceInfo, "A regular ole human. Good at all but not great at any one thing. +5 to health, +2 to everything", 6, 21, false);
                        }
                        else if (menuPosition == 6 && count == 6)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine(race);
                            Console.ResetColor();
                            UserUI.TextFormatter(raceInfo, "Masters of the arcance art. Prefer to launch fireballs at their problems. +10 to Intelligence, - 15 to health", 6, 21, false);
                        }
                        else
                        {
                            Console.WriteLine(race);
                        }
                        count++;
                        startRow++;
                    }
                    ConsoleKey userInput = Console.ReadKey(true).Key;
                    switch (userInput)
                    {
                        case (ConsoleKey.DownArrow):
                            if (menuPosition < 6)
                            {
                                menuPosition++;
                                UserUI.ClearBox(raceInfo, 21, 6);
                            }
                            break;
                        case ConsoleKey.UpArrow:
                            if (menuPosition > 0)
                            {
                                menuPosition--;
                                UserUI.ClearBox(raceInfo, 21, 6);
                            }
                            break;
                        case ConsoleKey.Enter:
                            if (menuPosition == 0)
                            {
                                pRace = Race.Orc;
                                player = new Player(playerName, 80, 25, 60, 60, 10, 5, 5, 5, pRace, weapon);
                                ctinue = false;
                            }
                            else if (menuPosition == 1)
                            {
                                pRace = Race.Elf;
                                player = new Player(playerName, 80, 25, 40, 40, 5, 5, 10, 5, pRace, weapon);
                                ctinue = false;
                            }
                            else if (menuPosition == 2)
                            {
                                pRace = Race.Goblin;
                                player = new Player(playerName, 80, 25, 40, 40, 5, 5, 10, 10, pRace, weapon);
                                ctinue = false;
                            }
                            else if (menuPosition == 3)
                            {
                                pRace = Race.Beastmen;
                                player = new Player(playerName, 80, 25, 60, 60, 10, 5, 5, 10, pRace, weapon);
                                ctinue = false;
                            }
                            else if (menuPosition == 4)
                            {
                                pRace = Race.Dwarf;
                                player = new Player(playerName, 80, 25, 50, 50, 5, 10, 10, 0, pRace, weapon);
                                ctinue = false;
                            }
                            else if (menuPosition == 5)
                            {
                                pRace = Race.Human;
                                player = new Player(playerName, 80, 25, 55, 55, 7, 7, 7, 7, pRace, weapon);
                                ctinue = false;
                            }
                            else if (menuPosition == 6)
                            {
                                pRace = Race.Wizard;
                                player = new Player(playerName, 80, 25, 35, 35, 5, 5, 5, 5, pRace, weapon);
                                ctinue = false;
                            }
                            break;
                    }
                } while (ctinue);
                Console.Clear();
                Console.WriteLine(player);
                Console.WriteLine("Is this information correct? YES or NO\n");
                string userAnswer = Console.ReadLine().ToUpper();
                switch (userAnswer)
                {
                    case "Y":
                    case "YES":
                        finish = true;
                        break;
                    case "N":
                    case "NO":
                        finish = true;
                        break;
                }
            } while (ctinue && !finish);
            return player;
            }

        }
    }

