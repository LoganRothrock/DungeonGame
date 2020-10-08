using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Menus
    {
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
                        }
                        break;
                }
            } while (ctinue);

        }
        public static void CharacterCreationMenu(string[] races, UserUI raceInfo, Player player)
        {
            Console.WriteLine("Please enter your characters name");
            string playerName = Console.ReadLine();
            Console.WriteLine("\nPlease choose a race. Each race comes with different bonuses");
            bool ctinue = false, finish = false;
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
                            UserUI.TextFormatter(raceInfo, race, 6, 21, false);
                        }
                        else if (menuPosition == 1 && count == 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine(race);
                            Console.ResetColor();
                            UserUI.TextFormatter(raceInfo, race, 6, 21, false);
                        }
                        else if (menuPosition == 2 && count == 2)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine(race);
                            Console.ResetColor();
                            UserUI.TextFormatter(raceInfo, "Small and agile these pesky creatures love to ambush and overwhelm prey with their numbers.  +5 to Evasion -10 to Health", 6, 21, false);
                        }
                        else if (menuPosition == 3 && count == 3)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine(race);
                            Console.ResetColor();
                            UserUI.TextFormatter(raceInfo, race, 6, 21, false);
                        }
                        else if (menuPosition == 4 && count == 4)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine(race);
                            Console.ResetColor();
                            UserUI.TextFormatter(raceInfo, race, 6, 21, false);
                        }
                        else if (menuPosition == 5 && count == 5)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine(race);
                            Console.ResetColor();
                            UserUI.TextFormatter(raceInfo, race, 6, 21, false);
                        }
                        else if (menuPosition == 6 && count == 6)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine(race);
                            Console.ResetColor();
                            UserUI.TextFormatter(raceInfo, race, 6, 21, false);
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

                            break;
                    }
                    UserUI.ClearBox(raceInfo, 21, 6);
                } while (!ctinue);
            } while (!ctinue && !finish);
            }

        }
    }

