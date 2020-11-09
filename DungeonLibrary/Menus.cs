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
    public static void FightMenu(Player player, Monster monster, string[] actions, string[] invActions, UserUI boxes)
        {
            UserUI.ClearBox(boxes.Boxes[3], 46, 1);
            UserUI.TextFormatter(boxes.Boxes[3], monster.Name, 1, 61, false);
            UserUI.TextFormatter(boxes.Boxes[3], monster.Description, 2, 46, false);
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
                Console.Write("|" + player.Gold + " Gold");
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
                        if (menuPosition == 0) //Regular Attack
                        {
                            UserUI.ClearBox(boxes.Boxes[3], 46, 1);
                            UserUI.ClearBox(boxes.Boxes[5], 1, 11);
                            UserUI.TextFormatter(boxes.Boxes[3], monster.Name, 1, 61, false);
                            UserUI.TextFormatter(boxes.Boxes[3], monster.Description, 2, 46, false);
                            Combat.DoBattle(player, monster);
                            ctinue = false;
                            if (monster.Life <= 0 || player.Life <= 0)
                            {
                                //TODO Give player item from Monster drop pool
                                //the monster is dead
                                //You could put some logic here to have the player collect an item, get life back, or something similiar
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.SetCursorPosition(46, 7);
                                Console.Write("You killed {0}!", monster.Name);
                                Console.ResetColor();
                                player.Exp += monster.GetStats();
                                Console.SetCursorPosition(1, 11);
                                Console.Write(player.Name + " gained " + monster.GetStats() + " exp");
                                player.Gold += monster.GoldDrop;
                                player.DetermineLevelUp(12);
                                Console.ReadKey();
                            }
                        }
                        else if (menuPosition == 1) //Player Inventory
                        {
                            UserUI.ClearBox(boxes.Boxes[5], 1, 11);
                            UserUI.TextFormatter(boxes.Boxes[3], monster.Name, 1, 61, false);
                            UserUI.TextFormatter(boxes.Boxes[3], monster.Description, 2, 46, false);
                            PlayerInvMenu(invActions, player, monster, boxes);
                            if (monster.Life <= 0 || player.Life <=0)
                            {
                                ctinue = false;
                                if (monster.Life <= 0)
                                {
                                    //TODO Give player item from Monster drop pool
                                    //the monster is dead
                                    //You could put some logic here to have the player collect an item, get life back, or something similiar
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.SetCursorPosition(46, 7);
                                    Console.Write("You killed {0}!", monster.Name);
                                    Console.ResetColor();
                                    player.Exp += monster.GetStats();
                                    Console.SetCursorPosition(1, 11);
                                    Console.Write(player.Name + " gained " + monster.GetStats() + " exp");
                                    player.DetermineLevelUp(12);
                                    player.Gold += monster.GoldDrop;
                                    Console.ReadKey();
                                }
                            }
                        }
                        else if (menuPosition == 2) //Run Away
                        {
                            ctinue = false;
                            Combat.DoAttack(monster, player, false, 5, true);
                            Console.ReadLine();
                        }
                        else if (menuPosition == 3) //Player Info
                        {
                            UserUI.ClearBox(boxes.Boxes[5], 1, 11);
                            Console.SetCursorPosition(1, 11);
                            Console.WriteLine(player);
                        }
                        else if (menuPosition == 4) //Monster Info
                        {
                            UserUI.ClearBox(boxes.Boxes[5], 1, 11);
                            Console.SetCursorPosition(1, 11);
                            Console.WriteLine(monster);
                        }
                        else if (menuPosition == 5) //Exit Game
                        {
                            bool exit = false;
                            UserUI.ClearBox(boxes.Boxes[5], 1, 11);
                            Console.SetCursorPosition(1, 11);
                            Console.WriteLine("Are You sure you want to quit?");
                            Console.SetCursorPosition(1, 12);
                            Console.WriteLine("This will end the game");
                            menuPosition = 0;
                            do
                            {
                                Console.SetCursorPosition(1, 13);
                                if (menuPosition == 0)
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.Write("YES");
                                    Console.ResetColor();
                                    Console.Write("                     ");
                                    Console.Write("NO");
                                }
                                else if (menuPosition == 1)
                                {
                                    Console.Write("YES");
                                    Console.Write("                     ");
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.Write("NO");
                                    Console.ResetColor();
                                }
                                userInput = Console.ReadKey(true).Key;
                                switch (userInput)
                                {
                                    case ConsoleKey.RightArrow:
                                        menuPosition = 1;
                                        break;
                                    case ConsoleKey.LeftArrow:
                                        menuPosition = 0;
                                        break;
                                    case ConsoleKey.Enter:
                                        if (menuPosition == 0)
                                        {
                                            exit = true;
                                            ctinue = false;
                                            player.Life = 0;
                                        }
                                        else
                                        {
                                            UserUI.ClearBox(boxes.Boxes[5], 1, 11);
                                            menuPosition = 0;
                                            exit = true;
                                        }
                                        break;
                                }
                            } while (!exit);

                        }
                        break;
                }
                Console.ResetColor();
                monster.Life = monster.MaxLife;
            } while (ctinue);

        }
    //Handles Character Creation
    public static Player CharacterCreationMenu(string[] races, UserUI raceInfo, Player player, Weapon weapon)
    {
            string playerName = "";
            bool ctinue = true;
            do
            {
                    bool nameConfirm = false;
                    do
                    {
                        Console.WriteLine("Please enter your characters name. Max length of 7 characters");
                        playerName = Console.ReadLine();
                        if (playerName.Length > 7)
                        {
                            Console.WriteLine("Invalid name. Name must not be longer than 7 characters.");
                        }
                        else
                        {
                            nameConfirm = true;
                            Console.Clear();
                        }

                    } while (!nameConfirm);
                    Console.WriteLine("\nPlease choose a race. Each race comes with different bonuses");
                    Race pRace = Race.Human;
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
                     
                        ctinue = false;
                        break;
                    case "N":
                    case "NO":
                        ctinue = true;
                        Console.Clear();
                        break;
                    default:
                        ctinue = false;
                        break;
                }
            } while (ctinue);
            
        return player;
    }
    //Handles the players Inventory
    public static void PlayerInvMenu(string[] invActions, Player player, Monster monster, UserUI boxes)
    {
        bool ctinue = true;
        int menuPosition = 0, startRow = 0;
        int count = 0;
        startRow = 1;
        count = 0;
        do
        {
            startRow = 1;
            count = 0;
            UserUI.ClearBox(boxes.Boxes[5], 1, 11);
            foreach (string action in invActions)
            {
                Console.SetCursorPosition(17, startRow);
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
                    if (menuPosition < 3)
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
                    if (menuPosition == 0) //Weapons
                    {
                        menuPosition = 0;
                        startRow = 0;
                        count = 0;
                        bool inCtinue = true;
                        int menuLength = player.Weapons.Count() - 1;
                        do
                        {
                            startRow = 1;
                            count = 0;
                            UserUI.ClearBox(boxes.Boxes[1], 17, 1);
                            UserUI.ClearBox(boxes.Boxes[5], 1, 11);
                            foreach (Weapon weapon in player.Weapons)
                            {
                                Console.SetCursorPosition(17, startRow);
                                if (menuPosition == 0 && count == 0 && menuPosition <= menuLength)
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine(weapon.Name);
                                    Console.ResetColor();
                                    Console.SetCursorPosition(1, 11);
                                    Console.WriteLine(weapon);
                                }
                                else if (menuPosition == 1 && count == 1 && menuPosition <= menuLength)
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine(weapon.Name);
                                    Console.ResetColor();
                                    Console.SetCursorPosition(1, 11);
                                    Console.WriteLine(weapon);
                                    }
                                else if (menuPosition == 2 && count == 2 && menuPosition <= menuLength)
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine(weapon.Name);
                                    Console.ResetColor();
                                    Console.SetCursorPosition(1, 11);
                                    Console.WriteLine(weapon);
                                    }
                                else if (menuPosition == 3 && count == 3 && menuPosition <= menuLength)
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine(weapon.Name);
                                    Console.ResetColor();
                                    Console.SetCursorPosition(1, 11);
                                    Console.WriteLine(weapon);
                                    }
                                else
                                {
                                    Console.WriteLine(weapon.Name);
                                }
                                count++;
                                startRow++;
                            }
                            userInput = Console.ReadKey(true).Key;
                            switch (userInput)
                            {
                                case (ConsoleKey.DownArrow):
                                    if (menuPosition < menuLength)
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
                                            bool exit = false;
                                            UserUI.ClearBox(boxes.Boxes[5], 1, 11);
                                            Console.SetCursorPosition(1, 11);
                                            UserUI.TextFormatter(boxes.Boxes[5], $"Would you like to equip {player.Weapons[0].Name}?", 11, 1, false);
                                            menuPosition = 0;
                                            do
                                            {
                                                Console.SetCursorPosition(1, 13);
                                                if (menuPosition == 0)
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                    Console.Write("YES");
                                                    Console.ResetColor();
                                                    Console.Write("                     ");
                                                    Console.Write("NO");
                                                }
                                                else if (menuPosition == 1)
                                                {
                                                    Console.Write("YES");
                                                    Console.Write("                     ");
                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                    Console.Write("NO");
                                                    Console.ResetColor();
                                                }
                                                userInput = Console.ReadKey(true).Key;
                                                switch (userInput)
                                                {
                                                    case ConsoleKey.RightArrow:
                                                        menuPosition = 1;
                                                        break;
                                                    case ConsoleKey.LeftArrow:
                                                        menuPosition = 0;
                                                        break;
                                                    case ConsoleKey.Enter:
                                                        if (menuPosition == 0)
                                                        {
                                                            if (player.Weapons[0].IsEquipped)
                                                            {
                                                                UserUI.TextFormatter(boxes.Boxes[5], $"You already have this {player.Weapons[0].Name} equipped!", 16, 1, false);
                                                                Console.ReadLine();
                                                            }
                                                            else
                                                            {
                                                                player.EquipWeapon(player, player.Weapons[0]);
                                                            }
                                                            exit = true;
                                                            ctinue = false;
                                                        }
                                                        else
                                                        {
                                                            UserUI.ClearBox(boxes.Boxes[5], 1, 11);
                                                            menuPosition = 0;
                                                            exit = true;
                                                        }
                                                        break;
                                                }
                                            } while (!exit);
                                        }
                                        else if (menuPosition == 1)
                                        {
                                            bool exit = false;
                                            UserUI.ClearBox(boxes.Boxes[5], 1, 11);
                                            Console.SetCursorPosition(1, 11);
                                            UserUI.TextFormatter(boxes.Boxes[5], $"Would you like to equip {player.Weapons[1].Name}?", 11, 1, false);
                                            menuPosition = 0;
                                            do
                                            {
                                                Console.SetCursorPosition(1, 13);
                                                if (menuPosition == 0)
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                    Console.Write("YES");
                                                    Console.ResetColor();
                                                    Console.Write("                     ");
                                                    Console.Write("NO");
                                                }
                                                else if (menuPosition == 1)
                                                {
                                                    Console.Write("YES");
                                                    Console.Write("                     ");
                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                    Console.Write("NO");
                                                    Console.ResetColor();
                                                }
                                                userInput = Console.ReadKey(true).Key;
                                                switch (userInput)
                                                {
                                                    case ConsoleKey.RightArrow:
                                                        menuPosition = 1;
                                                        break;
                                                    case ConsoleKey.LeftArrow:
                                                        menuPosition = 0;
                                                        break;
                                                    case ConsoleKey.Enter:
                                                        if (menuPosition == 0)
                                                        {
                                                            if (player.Weapons[1].IsEquipped)
                                                            {
                                                                UserUI.TextFormatter(boxes.Boxes[5], $"You already have this {player.Weapons[1].Name} equipped!", 16, 1, false);
                                                                Console.ReadLine();
                                                            }
                                                            else
                                                            {
                                                                player.EquipWeapon(player, player.Weapons[1]);
                                                            }
                                                            exit = true;
                                                            ctinue = false;
                                                        }
                                                        else
                                                        {
                                                            UserUI.ClearBox(boxes.Boxes[5], 1, 11);
                                                            menuPosition = 0;
                                                            exit = true;
                                                        }
                                                        break;
                                                }
                                            } while (!exit);
                                        }
                                        else if (menuPosition == 2)
                                        {
                                            bool exit = false;
                                            UserUI.ClearBox(boxes.Boxes[5], 1, 11);
                                            Console.SetCursorPosition(1, 11);
                                            UserUI.TextFormatter(boxes.Boxes[5], $"Would you like to equip {player.Weapons[2].Name}?", 11, 1, false);
                                            menuPosition = 0;
                                            do
                                            {
                                                Console.SetCursorPosition(1, 13);
                                                if (menuPosition == 0)
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                    Console.Write("YES");
                                                    Console.ResetColor();
                                                    Console.Write("                     ");
                                                    Console.Write("NO");
                                                }
                                                else if (menuPosition == 1)
                                                {
                                                    Console.Write("YES");
                                                    Console.Write("                     ");
                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                    Console.Write("NO");
                                                    Console.ResetColor();
                                                }
                                                userInput = Console.ReadKey(true).Key;
                                                switch (userInput)
                                                {
                                                    case ConsoleKey.RightArrow:
                                                        menuPosition = 1;
                                                        break;
                                                    case ConsoleKey.LeftArrow:
                                                        menuPosition = 0;
                                                        break;
                                                    case ConsoleKey.Enter:
                                                        if (menuPosition == 0)
                                                        {
                                                            if (player.Weapons[2].IsEquipped)
                                                            {
                                                                UserUI.TextFormatter(boxes.Boxes[5], $"You already have this {player.Weapons[2].Name} equipped!", 16, 1, false);
                                                                Console.ReadLine();
                                                            }
                                                            else
                                                            {
                                                                player.EquipWeapon(player, player.Weapons[2]);
                                                            }
                                                            exit = true;
                                                            ctinue = false;
                                                        }
                                                        else
                                                        {
                                                            UserUI.ClearBox(boxes.Boxes[5], 1, 11);
                                                            menuPosition = 0;
                                                            exit = true;
                                                        }
                                                        break;
                                                }
                                            } while (!exit);
                                        }
                                        else if (menuPosition == 3)
                                        {
                                            bool exit = false;
                                            UserUI.ClearBox(boxes.Boxes[5], 1, 11);
                                            Console.SetCursorPosition(1, 11);
                                            UserUI.TextFormatter(boxes.Boxes[5], $"Would you like to equip {player.Weapons[3].Name}?", 11, 1, false);
                                            menuPosition = 0;
                                            do
                                            {
                                                Console.SetCursorPosition(1, 13);
                                                if (menuPosition == 0)
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                    Console.Write("YES");
                                                    Console.ResetColor();
                                                    Console.Write("                     ");
                                                    Console.Write("NO");
                                                }
                                                else if (menuPosition == 1)
                                                {
                                                    Console.Write("YES");
                                                    Console.Write("                     ");
                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                    Console.Write("NO");
                                                    Console.ResetColor();
                                                }
                                                userInput = Console.ReadKey(true).Key;
                                                switch (userInput)
                                                {
                                                    case ConsoleKey.RightArrow:
                                                        menuPosition = 1;
                                                        break;
                                                    case ConsoleKey.LeftArrow:
                                                        menuPosition = 0;
                                                        break;
                                                    case ConsoleKey.Enter:
                                                        if (menuPosition == 0)
                                                        {
                                                            if (player.Weapons[3].IsEquipped)
                                                            {
                                                                UserUI.TextFormatter(boxes.Boxes[5], $"You already have this {player.Weapons[3].Name} equipped!", 16, 1, false);
                                                                Console.ReadLine();
                                                            }
                                                            else
                                                            {
                                                                player.EquipWeapon(player, player.Weapons[3]);
                                                            }
                                                            exit = true;
                                                            ctinue = false;
                                                        }
                                                        else
                                                        {
                                                            UserUI.ClearBox(boxes.Boxes[5], 1, 11);
                                                            menuPosition = 0;
                                                            exit = true;
                                                        }
                                                        break;
                                                }
                                            } while (!exit);
                                        }
                                        break;
                                case ConsoleKey.Escape:
                                    inCtinue = false;
                                    UserUI.ClearBox(boxes.Boxes[1], 17, 1);
                                    menuPosition = 0;
                                    break;
                            }


                        } while (inCtinue);
                    }
                    else if (menuPosition == 1) //Equipment
                    {
                        menuPosition = 0;
                        startRow = 0;
                        count = 0;
                        bool inCtinue = true;
                        int menuLength = player.Equipments.Count() - 1;
                        do
                        {
                            startRow = 1;
                            count = 0;
                            UserUI.ClearBox(boxes.Boxes[1], 17, 1);
                            UserUI.ClearBox(boxes.Boxes[5], 1, 11);
                           
                            foreach (Equipment equipment in player.Equipments)
                            {
                                Console.SetCursorPosition(17, startRow);
                                if (menuPosition == 0 && count == 0 && menuPosition <= menuLength)
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine(equipment.Name);
                                    Console.ResetColor();
                                    Console.SetCursorPosition(1, 11);
                                    Console.WriteLine(equipment);
                                    UserUI.TextFormatter(boxes.Boxes[5], equipment.Description, 16, 1, false);
                                }
                                else if (menuPosition == 1 && count == 1 && menuPosition <= menuLength)
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine(equipment.Name);
                                    Console.ResetColor();
                                    Console.SetCursorPosition(1, 11);
                                    Console.WriteLine(equipment);
                                    UserUI.TextFormatter(boxes.Boxes[5], equipment.Description, 16, 1, false);
                                }
                                else if (menuPosition == 2 && count == 2 && menuPosition <= menuLength)
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine(equipment.Name);
                                    Console.ResetColor();
                                    Console.SetCursorPosition(1, 11);
                                    Console.WriteLine(equipment);
                                    UserUI.TextFormatter(boxes.Boxes[5], equipment.Description, 16, 1, false);

                                }
                                else if (menuPosition == 3 && count == 3 && menuPosition <= menuLength)
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine(equipment.Name);
                                    Console.ResetColor();
                                    Console.SetCursorPosition(1, 11);
                                    Console.WriteLine(equipment);
                                    UserUI.TextFormatter(boxes.Boxes[5], equipment.Description, 16, 1, false);
                                }
                                else
                                {
                                    Console.WriteLine(equipment.Name);
                                }
                                count++;
                                startRow++;
                            }

                            userInput = Console.ReadKey(true).Key;
                            switch (userInput)
                            {
                                case (ConsoleKey.DownArrow):
                                    if (menuPosition < menuLength)
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
                                    if (menuPosition == 0) //Prompts the user if they want to equip item
                                    {
                                            bool exit = false;
                                            UserUI.ClearBox(boxes.Boxes[5], 1, 11);
                                            Console.SetCursorPosition(1, 11);
                                            Console.WriteLine($"Would you like to equip {player.Equipments[0].Name}?");
                                            menuPosition = 0;
                                            do
                                            {
                                                Console.SetCursorPosition(1, 13);
                                                if (menuPosition == 0)
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                    Console.Write("YES");
                                                    Console.ResetColor();
                                                    Console.Write("                     ");
                                                    Console.Write("NO");
                                                }
                                                else if (menuPosition == 1)
                                                {
                                                    Console.Write("YES");
                                                    Console.Write("                     ");
                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                    Console.Write("NO");
                                                    Console.ResetColor();
                                                }
                                                userInput = Console.ReadKey(true).Key;
                                                switch (userInput)
                                                {
                                                    case ConsoleKey.RightArrow:
                                                        menuPosition = 1;
                                                        break;
                                                    case ConsoleKey.LeftArrow:
                                                        menuPosition = 0;
                                                        break;
                                                    case ConsoleKey.Enter:
                                                        if (menuPosition == 0)
                                                        {
                                                            if (player.Equipments[0].IsEquipped)
                                                            {
                                                                UserUI.TextFormatter(boxes.Boxes[5], $"You already have this {player.Equipments[0].Name} equipped!", 16, 1, false);
                                                                Console.ReadLine();
                                                            }
                                                            else
                                                            {
                                                                player.EquipEquipment(player, player.Equipments[0]);
                                                            }
                                                            exit = true;
                                                            ctinue = false;
                                                        }
                                                        else
                                                        {
                                                            UserUI.ClearBox(boxes.Boxes[5], 1, 11);
                                                            menuPosition = 0;
                                                            exit = true;
                                                        }
                                                        break;
                                                }
                                            } while (!exit);
                                    }
                                    else if (menuPosition == 1)
                                    {
                                            bool exit = false;
                                            UserUI.ClearBox(boxes.Boxes[5], 1, 11);
                                            Console.SetCursorPosition(1, 11);
                                            Console.WriteLine($"Would you like to equip {player.Equipments[1].Name}?");
                                            menuPosition = 0;
                                            do
                                            {
                                                Console.SetCursorPosition(1, 13);
                                                if (menuPosition == 0)
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                    Console.Write("YES");
                                                    Console.ResetColor();
                                                    Console.Write("                     ");
                                                    Console.Write("NO");
                                                }
                                                else if (menuPosition == 1)
                                                {
                                                    Console.Write("YES");
                                                    Console.Write("                     ");
                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                    Console.Write("NO");
                                                    Console.ResetColor();
                                                }
                                                userInput = Console.ReadKey(true).Key;
                                                switch (userInput)
                                                {
                                                    case ConsoleKey.RightArrow:
                                                        menuPosition = 1;
                                                        break;
                                                    case ConsoleKey.LeftArrow:
                                                        menuPosition = 0;
                                                        break;
                                                    case ConsoleKey.Enter:
                                                        if (menuPosition == 0)
                                                        {
                                                            if (player.Equipments[1].IsEquipped)
                                                            {
                                                                UserUI.TextFormatter(boxes.Boxes[5], $"You already have this {player.Equipments[1].Name} equipped!", 16, 1, false);
                                                                Console.ReadLine();
                                                            }
                                                            else
                                                            {
                                                                player.EquipEquipment(player, player.Equipments[1]);
                                                            }
                                                            exit = true;
                                                            ctinue = false;
                                                            
                                                        }
                                                        else
                                                        {
                                                            UserUI.ClearBox(boxes.Boxes[5], 1, 11);
                                                            menuPosition = 0;
                                                            exit = true;
                                                        }
                                                        break;
                                                }
                                            } while (!exit);
                                        }
                                    else if (menuPosition == 2)
                                    {
                                            bool exit = false;
                                            UserUI.ClearBox(boxes.Boxes[5], 1, 11);
                                            Console.SetCursorPosition(1, 11);
                                            Console.WriteLine($"Would you like to equip {player.Equipments[2].Name}?");
                                            menuPosition = 0;
                                            do
                                            {
                                                Console.SetCursorPosition(1, 13);
                                                if (menuPosition == 0)
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                    Console.Write("YES");
                                                    Console.ResetColor();
                                                    Console.Write("                     ");
                                                    Console.Write("NO");
                                                }
                                                else if (menuPosition == 1)
                                                {
                                                    Console.Write("YES");
                                                    Console.Write("                     ");
                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                    Console.Write("NO");
                                                    Console.ResetColor();
                                                }
                                                userInput = Console.ReadKey(true).Key;
                                                switch (userInput)
                                                {
                                                    case ConsoleKey.RightArrow:
                                                        menuPosition = 1;
                                                        break;
                                                    case ConsoleKey.LeftArrow:
                                                        menuPosition = 0;
                                                        break;
                                                    case ConsoleKey.Enter:
                                                        if (menuPosition == 0)
                                                        {
                                                            if (player.Equipments[2].IsEquipped)
                                                            {
                                                                UserUI.TextFormatter(boxes.Boxes[5], $"You already have this {player.Equipments[2].Name} equipped!", 16, 1, false);
                                                                Console.ReadLine();
                                                            }
                                                            else
                                                            {
                                                                player.EquipEquipment(player, player.Equipments[2]);
                                                            }
                                                            exit = true;
                                                            ctinue = false;
                                                            
                                                        }
                                                        else
                                                        {
                                                            UserUI.ClearBox(boxes.Boxes[5], 1, 11);
                                                            menuPosition = 0;
                                                            exit = true;
                                                        }
                                                        break;
                                                }
                                            } while (!exit);
                                        }
                                    else if (menuPosition == 3)
                                    {
                                            bool exit = false;
                                            UserUI.ClearBox(boxes.Boxes[5], 1, 11);
                                            Console.SetCursorPosition(1, 11);
                                            Console.WriteLine($"Would you like to equip {player.Equipments[3].Name}?");
                                            menuPosition = 0;
                                            do
                                            {
                                                Console.SetCursorPosition(1, 13);
                                                if (menuPosition == 0)
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                    Console.Write("YES");
                                                    Console.ResetColor();
                                                    Console.Write("                     ");
                                                    Console.Write("NO");
                                                }
                                                else if (menuPosition == 1)
                                                {
                                                    Console.Write("YES");
                                                    Console.Write("                     ");
                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                    Console.Write("NO");
                                                    Console.ResetColor();
                                                }
                                                userInput = Console.ReadKey(true).Key;
                                                switch (userInput)
                                                {
                                                    case ConsoleKey.RightArrow:
                                                        menuPosition = 1;
                                                        break;
                                                    case ConsoleKey.LeftArrow:
                                                        menuPosition = 0;
                                                        break;
                                                    case ConsoleKey.Enter:
                                                        if (menuPosition == 0)
                                                        {

                                                            if (player.Equipments[3].IsEquipped)
                                                            {
                                                                UserUI.TextFormatter(boxes.Boxes[5], $"You already have this {player.Equipments[3].Name} equipped!", 16, 1, false);
                                                                Console.ReadLine();
                                                            }
                                                            else
                                                            {
                                                                player.EquipEquipment(player, player.Equipments[3]);
                                                            }
                                                            exit = true;
                                                            ctinue = false;
                                                            
                                                        }
                                                        else
                                                        {
                                                            UserUI.ClearBox(boxes.Boxes[5], 1, 11);
                                                            menuPosition = 0;
                                                            exit = true;
                                                        }
                                                        break;
                                                }
                                            } while (!exit);
                                        }
                                    break;
                                case ConsoleKey.Escape:
                                    inCtinue = false;
                                    menuPosition = 0;
                                    UserUI.ClearBox(boxes.Boxes[1], 17, 1);
                                    
                                    break;
                            }

                        } while (inCtinue);

                    }
                    else if (menuPosition == 2) //Items
                    {
                        { 
                            menuPosition = 0;
                            startRow = 0;
                            count = 0;
                            bool inCtinue = true;
                            int menuLength = player.Items.Count() - 1;
                            do
                            {
                                startRow = 1;
                                count = 0;
                                UserUI.ClearBox(boxes.Boxes[1], 17, 1);
                                UserUI.ClearBox(boxes.Boxes[5], 1, 11);
                                foreach (Item item in player.Items)
                                {
                                    Console.SetCursorPosition(17, startRow);
                                    if (menuPosition == 0 && count == 0 && menuPosition <= menuLength)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine(item.Name + " X " + item.Count);
                                        Console.ResetColor();
                                        UserUI.TextFormatter(boxes.Boxes[5], item.Description, 11, 1, false);
                                    }
                                    else if (menuPosition == 1 && count == 1 && menuPosition <= menuLength)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine(item.Name + " X " + item.Count);
                                        Console.ResetColor();
                                        UserUI.TextFormatter(boxes.Boxes[5], item.Description, 11, 1, false);
                                    }
                                    else if (menuPosition == 2 && count == 2 && menuPosition <= menuLength)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine(item.Name + " X " + item.Count);
                                        Console.ResetColor();
                                        UserUI.TextFormatter(boxes.Boxes[5], item.Description, 11, 1, false);
                                    }
                                    else if (menuPosition == 3 && count == 3 && menuPosition <= menuLength)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine(item.Name + " X " + item.Count);
                                        Console.ResetColor();
                                        UserUI.TextFormatter(boxes.Boxes[5], item.Description, 11, 1, false);
                                    }
                                    else
                                    {
                                        Console.WriteLine(item.Name + " X " + item.Count);
                                    }
                                    count++;
                                    startRow++;
                                }
                                userInput = Console.ReadKey(true).Key;
                                switch (userInput)
                                {
                                    case (ConsoleKey.DownArrow):
                                        if (menuPosition < menuLength)
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
                                            UserUI.ClearBox(boxes.Boxes[5], 1, 11);
                                        if (menuPosition == 0)
                                        {
                                                Console.SetCursorPosition(1, 11);
                                                Item.UseItem(player.Items[menuPosition], player, monster);
                                                inCtinue = false;
                                            }
                                        else if (menuPosition == 1)
                                        {
                                                Console.SetCursorPosition(1, 11);
                                                Item.UseItem(player.Items[menuPosition], player, monster);
                                                inCtinue = false;
                                            }
                                        else if (menuPosition == 2)
                                        {
                                                Console.SetCursorPosition(1, 11);
                                                Item.UseItem(player.Items[menuPosition], player, monster);
                                                inCtinue = false;
                                            }
                                        else if (menuPosition == 3)
                                        {
                                                Console.SetCursorPosition(1, 11);
                                                Item.UseItem(player.Items[menuPosition], player, monster);
                                                inCtinue = false;
                                                //UserUI.ClearBox(boxes.Boxes[3], 46, 1);
                                            }
                                        break;
                                    case ConsoleKey.Escape:
                                        inCtinue = false;
                                        menuPosition = 0;
                                        break;
                                }
                                 UserUI.ClearBox(boxes.Boxes[1], 17, 1);
                                    if (monster.Life <=0)
                                    {
                                        ctinue = false;
                                        inCtinue = false;
                                    }
                            } while (inCtinue);
                        }
                    }
                    else if (menuPosition == 3) //Exit
                    {
                        ctinue = false;
                        UserUI.ClearBox(boxes.Boxes[1], 17, 1);
                        menuPosition = 0;
                        break;
                    }
                    break;
                case ConsoleKey.Escape:
                    ctinue = false;
                    UserUI.ClearBox(boxes.Boxes[1], 17, 1);
                    menuPosition = 0;
                    break;
            }
        } while (ctinue);
    }
        //Handles the shop menus
        public static void Shop(Player player, string[] actions, string[] invActions, UserUI boxes, int score,Shop shop)
        {
            shop.GenerateProductsToSell();
            bool leaveShop = false;
            int menuPosition = 0, startRow = 1;
            int count = 0;
            bool ctinue = true;
            do
            {
                startRow = 2;
                count = 0;
                UserUI.ClearBox(boxes.Boxes[0], 1, 2);
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
                    else
                    {
                        Console.WriteLine(action);
                    }
                    count++;
                    startRow++;

                }
                Console.Write("|" + player.Gold + " Gold");
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
                        if (menuPosition == 0) //Browse Shop
                        {
                            startRow = 1;
                            count = 0;
                            do
                            {
                                ctinue = true;
                                startRow = 2;
                                count = 0;
                                UserUI.ClearBox(boxes.Boxes[5], 1, 11);
                                foreach (string action in invActions)
                                {
                                    Console.SetCursorPosition(17, startRow);
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
                                    else
                                    {
                                        Console.WriteLine(action);
                                    }
                                    count++;
                                    startRow++;
                                }
                                userInput = Console.ReadKey(true).Key;
                                switch (userInput)
                                {
                                    case ConsoleKey.DownArrow:
                                        if (menuPosition < 3)
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
                                        if (menuPosition == 0) //Weapons
                                        {
                                            menuPosition = 0;
                                            startRow = 0;
                                            count = 0;
                                            bool inCtinue = true;
                                            int menuLength = player.Weapons.Count() - 1;
                                            do
                                            {
                                                startRow = 1;
                                                count = 0;
                                                UserUI.ClearBox(boxes.Boxes[1], 17, 1);
                                                UserUI.ClearBox(boxes.Boxes[5], 1, 11);
                                                foreach (Weapon weapon in player.Weapons)
                                                {
                                                    Console.SetCursorPosition(17, startRow);
                                                    if (menuPosition == 0 && count == 0 && menuPosition <= menuLength)
                                                    {
                                                        Console.ForegroundColor = ConsoleColor.Green;
                                                        Console.WriteLine(weapon.Name);
                                                        Console.ResetColor();
                                                        Console.SetCursorPosition(1, 11);
                                                        Console.WriteLine(weapon);
                                                    }
                                                    else if (menuPosition == 1 && count == 1 && menuPosition <= menuLength)
                                                    {
                                                        Console.ForegroundColor = ConsoleColor.Green;
                                                        Console.WriteLine(weapon.Name);
                                                        Console.ResetColor();
                                                        Console.SetCursorPosition(1, 11);
                                                        Console.WriteLine(weapon);
                                                    }
                                                    else if (menuPosition == 2 && count == 2 && menuPosition <= menuLength)
                                                    {
                                                        Console.ForegroundColor = ConsoleColor.Green;
                                                        Console.WriteLine(weapon.Name);
                                                        Console.ResetColor();
                                                        Console.SetCursorPosition(1, 11);
                                                        Console.WriteLine(weapon);
                                                    }
                                                    else if (menuPosition == 3 && count == 3 && menuPosition <= menuLength)
                                                    {
                                                        Console.ForegroundColor = ConsoleColor.Green;
                                                        Console.WriteLine(weapon.Name);
                                                        Console.ResetColor();
                                                        Console.SetCursorPosition(1, 11);
                                                        Console.WriteLine(weapon);
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine(weapon.Name);
                                                    }
                                                    count++;
                                                    startRow++;
                                                }
                                                userInput = Console.ReadKey(true).Key;
                                                switch (userInput)
                                                {
                                                    case (ConsoleKey.DownArrow):
                                                        if (menuPosition < menuLength)
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
                                                    case ConsoleKey.Enter: //Prompts if the user wants to buy weapon
                                                        if (menuPosition == 0)
                                                        {
                                                            bool exit = false;
                                                            UserUI.ClearBox(boxes.Boxes[5], 1, 11);
                                                            Console.SetCursorPosition(1, 11);
                                                            UserUI.TextFormatter(boxes.Boxes[5], $"Would you like to equip {player.Weapons[0].Name}?", 11, 1, false);
                                                            menuPosition = 0;
                                                            do
                                                            {
                                                                Console.SetCursorPosition(1, 13);
                                                                if (menuPosition == 0)
                                                                {
                                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                                    Console.Write("YES");
                                                                    Console.ResetColor();
                                                                    Console.Write("                     ");
                                                                    Console.Write("NO");
                                                                }
                                                                else if (menuPosition == 1)
                                                                {
                                                                    Console.Write("YES");
                                                                    Console.Write("                     ");
                                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                                    Console.Write("NO");
                                                                    Console.ResetColor();
                                                                }
                                                                userInput = Console.ReadKey(true).Key;
                                                                switch (userInput)
                                                                {
                                                                    case ConsoleKey.RightArrow:
                                                                        menuPosition = 1;
                                                                        break;
                                                                    case ConsoleKey.LeftArrow:
                                                                        menuPosition = 0;
                                                                        break;
                                                                    case ConsoleKey.Enter:
                                                                        if (menuPosition == 0)
                                                                        {
                                                                            exit = true;
                                                                            ctinue = false;
                                                                        }
                                                                        else
                                                                        {
                                                                            UserUI.ClearBox(boxes.Boxes[5], 1, 11);
                                                                            menuPosition = 0;
                                                                            exit = true;
                                                                        }
                                                                        break;
                                                                }
                                                            } while (!exit);
                                                        }
                                                        break;
                                                    case ConsoleKey.Escape:
                                                        inCtinue = false;
                                                        UserUI.ClearBox(boxes.Boxes[1], 17, 1);
                                                        menuPosition = 0;
                                                        break;
                                                }


                                            } while (inCtinue);
                                        }
                                        else if (menuPosition == 1) //Equipment
                                        {
                                            menuPosition = 0;
                                            startRow = 0;
                                            count = 0;
                                            bool inCtinue = true;
                                            do
                                            {
                                                startRow = 2;
                                                count = 0;
                                                UserUI.ClearBox(boxes.Boxes[1], 17, 2);
                                                UserUI.ClearBox(boxes.Boxes[5], 1, 11);
                                                foreach (Equipment equipment in shop.EquipmentToSell)
                                                {
                                                    Console.SetCursorPosition(17, startRow);
                                                    if (menuPosition == 0 && count == 0)
                                                    {
                                                        Console.ForegroundColor = ConsoleColor.Green;
                                                        Console.WriteLine(equipment.Name);
                                                        Console.ResetColor();
                                                        Console.SetCursorPosition(1, 11);
                                                        Console.WriteLine(equipment);
                                                        UserUI.TextFormatter(boxes.Boxes[5], equipment.Description, 17, 1, false);
                                                    }
                                                    else if (menuPosition == 1 && count == 1)
                                                    {
                                                        Console.ForegroundColor = ConsoleColor.Green;
                                                        Console.WriteLine(equipment.Name);
                                                        Console.ResetColor();
                                                        Console.SetCursorPosition(1, 11);
                                                        Console.WriteLine(equipment);
                                                        UserUI.TextFormatter(boxes.Boxes[5], equipment.Description, 17, 1, false);
                                                    }
                                                    else if (menuPosition == 2 && count == 2)
                                                    {
                                                        Console.ForegroundColor = ConsoleColor.Green;
                                                        Console.WriteLine(equipment.Name);
                                                        Console.ResetColor();
                                                        Console.SetCursorPosition(1, 11);
                                                        Console.WriteLine(equipment);
                                                        UserUI.TextFormatter(boxes.Boxes[5], equipment.Description, 17, 1, false);

                                                    }
                                                    else if (menuPosition == 3 && count == 3)
                                                    {
                                                        Console.ForegroundColor = ConsoleColor.Green;
                                                        Console.WriteLine(equipment.Name);
                                                        Console.ResetColor();
                                                        Console.SetCursorPosition(1, 11);
                                                        Console.WriteLine(equipment);
                                                        UserUI.TextFormatter(boxes.Boxes[5], equipment.Description, 17, 1, false);
                                                    }
                                                    else if (menuPosition == 4 && count == 4)
                                                    {
                                                        Console.ForegroundColor = ConsoleColor.Green;
                                                        Console.WriteLine(equipment.Name);
                                                        Console.ResetColor();
                                                        Console.SetCursorPosition(1, 11);
                                                        Console.WriteLine(equipment);
                                                        UserUI.TextFormatter(boxes.Boxes[5], equipment.Description, 17, 1, false);
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine(equipment.Name);
                                                    }
                                                    count++;
                                                    startRow++;
                                                }

                                                userInput = Console.ReadKey(true).Key;
                                                switch (userInput)
                                                {
                                                    case (ConsoleKey.DownArrow):
                                                        if (menuPosition < 4)
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
                                                        if (menuPosition == 0) //Prompts the user if they want to buy item
                                                        {
                                                            bool exit = false;
                                                            UserUI.ClearBox(boxes.Boxes[5], 1, 11);
                                                            Console.SetCursorPosition(1, 11);
                                                            Console.WriteLine($"Would you like to buy {shop.EquipmentToSell[0].Name}?");
                                                            menuPosition = 0;
                                                            do
                                                            {
                                                                Console.SetCursorPosition(1, 13);
                                                                if (menuPosition == 0)
                                                                {
                                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                                    Console.Write("YES");
                                                                    Console.ResetColor();
                                                                    Console.Write("                     ");
                                                                    Console.Write("NO");
                                                                }
                                                                else if (menuPosition == 1)
                                                                {
                                                                    Console.Write("YES");
                                                                    Console.Write("                     ");
                                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                                    Console.Write("NO");
                                                                    Console.ResetColor();
                                                                }
                                                                userInput = Console.ReadKey(true).Key;
                                                                switch (userInput)
                                                                {
                                                                    case ConsoleKey.RightArrow:
                                                                        menuPosition = 1;
                                                                        break;
                                                                    case ConsoleKey.LeftArrow:
                                                                        menuPosition = 0;
                                                                        break;
                                                                    case ConsoleKey.Enter:
                                                                        if (menuPosition == 0 && player.Equipments.Count() < 4 && player.Gold > shop.EquipmentToSell[0].Value)
                                                                        {
                                                                            player.Gold -= shop.EquipmentToSell[0].Value;
                                                                            player.AddEquipment(shop.EquipmentToSell[0]);
                                                                            exit = true;
                                                                            ctinue = false;
                                                                            inCtinue = false;
                                                                        }
                                                                        else if(player.Gold < shop.EquipmentToSell[0].Value)
                                                                        {
                                                                            UserUI.TextFormatter(boxes.Boxes[5], "You do not have enough gold! Sell me something!", 16, 1, false);
                                                                        }
                                                                        else if (menuPosition == 0 && player.Equipments.Count() >= 4)
                                                                        {
                                                                            UserUI.TextFormatter(boxes.Boxes[5], "You do not have enough room in your bag! Sell me something!", 16, 1, false);
                                                                        }
                                                                        else
                                                                        {
                                                                            UserUI.ClearBox(boxes.Boxes[5], 1, 11);
                                                                            menuPosition = 0;
                                                                            exit = true;
                                                                        }
                                                                        break;
                                                                }
                                                            } while (!exit);
                                                        }
                                                        if (menuPosition == 1) //Prompts the user if they want to buy item
                                                        {
                                                            bool exit = false;
                                                            UserUI.ClearBox(boxes.Boxes[5], 1, 11);
                                                            Console.SetCursorPosition(1, 11);
                                                            Console.WriteLine($"Would you like to buy {shop.EquipmentToSell[1].Name}?");
                                                            menuPosition = 0;
                                                            do
                                                            {
                                                                Console.SetCursorPosition(1, 13);
                                                                if (menuPosition == 0)
                                                                {
                                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                                    Console.Write("YES");
                                                                    Console.ResetColor();
                                                                    Console.Write("                     ");
                                                                    Console.Write("NO");
                                                                }
                                                                else if (menuPosition == 1)
                                                                {
                                                                    Console.Write("YES");
                                                                    Console.Write("                     ");
                                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                                    Console.Write("NO");
                                                                    Console.ResetColor();
                                                                }
                                                                userInput = Console.ReadKey(true).Key;
                                                                switch (userInput)
                                                                {
                                                                    case ConsoleKey.RightArrow:
                                                                        menuPosition = 1;
                                                                        break;
                                                                    case ConsoleKey.LeftArrow:
                                                                        menuPosition = 0;
                                                                        break;
                                                                    case ConsoleKey.Enter:
                                                                        if (menuPosition == 0 && player.Equipments.Count() < 4 && player.Gold > shop.EquipmentToSell[1].Value)
                                                                        {
                                                                            player.Gold -= shop.EquipmentToSell[1].Value;
                                                                            player.AddEquipment(shop.EquipmentToSell[1]);
                                                                            exit = true;
                                                                            ctinue = false;
                                                                            inCtinue = false;
                                                                        }
                                                                        else if (player.Gold < shop.EquipmentToSell[1].Value)
                                                                        {
                                                                            UserUI.TextFormatter(boxes.Boxes[5], "You do not have enough gold! Sell me something!", 16, 1, false);
                                                                        }
                                                                        else if (menuPosition == 0 && player.Equipments.Count() >= 4)
                                                                        {
                                                                            UserUI.TextFormatter(boxes.Boxes[5], "You do not have enough room in your bag! Sell me something!", 16, 1, false);
                                                                        }
                                                                        else
                                                                        {
                                                                            UserUI.ClearBox(boxes.Boxes[5], 1, 11);
                                                                            menuPosition = 0;
                                                                            exit = true;
                                                                        }
                                                                        break;
                                                                }
                                                            } while (!exit);
                                                        }
                                                        if (menuPosition == 2) //Prompts the user if they want to buy item
                                                        {
                                                            bool exit = false;
                                                            UserUI.ClearBox(boxes.Boxes[5], 1, 11);
                                                            Console.SetCursorPosition(1, 11);
                                                            Console.WriteLine($"Would you like to buy {shop.EquipmentToSell[2].Name}?");
                                                            menuPosition = 0;
                                                            do
                                                            {
                                                                Console.SetCursorPosition(1, 13);
                                                                if (menuPosition == 0)
                                                                {
                                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                                    Console.Write("YES");
                                                                    Console.ResetColor();
                                                                    Console.Write("                     ");
                                                                    Console.Write("NO");
                                                                }
                                                                else if (menuPosition == 1)
                                                                {
                                                                    Console.Write("YES");
                                                                    Console.Write("                     ");
                                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                                    Console.Write("NO");
                                                                    Console.ResetColor();
                                                                }
                                                                userInput = Console.ReadKey(true).Key;
                                                                switch (userInput)
                                                                {
                                                                    case ConsoleKey.RightArrow:
                                                                        menuPosition = 1;
                                                                        break;
                                                                    case ConsoleKey.LeftArrow:
                                                                        menuPosition = 0;
                                                                        break;
                                                                    case ConsoleKey.Enter:
                                                                        if (menuPosition == 0 && player.Equipments.Count() < 4 && player.Gold > shop.EquipmentToSell[2].Value)
                                                                        {
                                                                            player.Gold -= shop.EquipmentToSell[2].Value;
                                                                            player.AddEquipment(shop.EquipmentToSell[2]);
                                                                            exit = true;
                                                                            ctinue = false;
                                                                            inCtinue = false;
                                                                        }
                                                                        else if (player.Gold < shop.EquipmentToSell[2].Value)
                                                                        {
                                                                            UserUI.TextFormatter(boxes.Boxes[5], "You do not have enough gold! Sell me something!", 16, 1, false);
                                                                        }
                                                                        else if (menuPosition == 0 && player.Equipments.Count() >= 4)
                                                                        {
                                                                            UserUI.TextFormatter(boxes.Boxes[5], "You do not have enough room in your bag! Sell me something!", 16, 1, false);
                                                                        }
                                                                        else
                                                                        {
                                                                            UserUI.ClearBox(boxes.Boxes[5], 1, 11);
                                                                            menuPosition = 0;
                                                                            exit = true;
                                                                        }
                                                                        break;
                                                                }
                                                                UserUI.ClearBox(boxes.Boxes[5], 1, 11);
                                                            } while (!exit);
                                                        }
                                                        if (menuPosition == 3) //Prompts the user if they want to buy item
                                                        {
                                                            bool exit = false;
                                                            UserUI.ClearBox(boxes.Boxes[5], 1, 11);
                                                            Console.SetCursorPosition(1, 11);
                                                            Console.WriteLine($"Would you like to buy {shop.EquipmentToSell[3].Name}?");
                                                            menuPosition = 0;
                                                            do
                                                            {
                                                                Console.SetCursorPosition(1, 13);
                                                                if (menuPosition == 0)
                                                                {
                                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                                    Console.Write("YES");
                                                                    Console.ResetColor();
                                                                    Console.Write("                     ");
                                                                    Console.Write("NO");
                                                                }
                                                                else if (menuPosition == 1)
                                                                {
                                                                    Console.Write("YES");
                                                                    Console.Write("                     ");
                                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                                    Console.Write("NO");
                                                                    Console.ResetColor();
                                                                }
                                                                userInput = Console.ReadKey(true).Key;
                                                                switch (userInput)
                                                                {
                                                                    case ConsoleKey.RightArrow:
                                                                        menuPosition = 1;
                                                                        break;
                                                                    case ConsoleKey.LeftArrow:
                                                                        menuPosition = 0;
                                                                        break;
                                                                    case ConsoleKey.Enter:
                                                                        if (menuPosition == 0 && player.Equipments.Count() < 4 && player.Gold > shop.EquipmentToSell[3].Value)
                                                                        {
                                                                            player.Gold -= shop.EquipmentToSell[3].Value;
                                                                            player.AddEquipment(shop.EquipmentToSell[3]);
                                                                            exit = true;
                                                                            ctinue = false;
                                                                            inCtinue = false;
                                                                        }
                                                                        else if (player.Gold < shop.EquipmentToSell[3].Value)
                                                                        {
                                                                            UserUI.TextFormatter(boxes.Boxes[5], "You do not have enough gold! Sell me something!", 16, 1, false);
                                                                        }
                                                                        else if (menuPosition == 0 && player.Equipments.Count() >= 4)
                                                                        {
                                                                            UserUI.TextFormatter(boxes.Boxes[5], "You do not have enough room in your bag! Sell me something!", 16, 1, false);
                                                                        }
                                                                        else
                                                                        {
                                                                            UserUI.ClearBox(boxes.Boxes[5], 1, 11);
                                                                            menuPosition = 0;
                                                                            exit = true;
                                                                        }
                                                                        break;
                                                                }
                                                            } while (!exit);
                                                        }
                                                        if (menuPosition == 3) //Prompts the user if they want to buy item
                                                        {
                                                            bool exit = false;
                                                            UserUI.ClearBox(boxes.Boxes[5], 1, 11);
                                                            Console.SetCursorPosition(1, 11);
                                                            Console.WriteLine($"Would you like to buy {shop.EquipmentToSell[4].Name}?");
                                                            menuPosition = 0;
                                                            do
                                                            {
                                                                Console.SetCursorPosition(1, 13);
                                                                if (menuPosition == 0)
                                                                {
                                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                                    Console.Write("YES");
                                                                    Console.ResetColor();
                                                                    Console.Write("                     ");
                                                                    Console.Write("NO");
                                                                }
                                                                else if (menuPosition == 1)
                                                                {
                                                                    Console.Write("YES");
                                                                    Console.Write("                     ");
                                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                                    Console.Write("NO");
                                                                    Console.ResetColor();
                                                                }
                                                                userInput = Console.ReadKey(true).Key;
                                                                switch (userInput)
                                                                {
                                                                    case ConsoleKey.RightArrow:
                                                                        menuPosition = 1;
                                                                        break;
                                                                    case ConsoleKey.LeftArrow:
                                                                        menuPosition = 0;
                                                                        break;
                                                                    case ConsoleKey.Enter:
                                                                        if (menuPosition == 0 && player.Equipments.Count() < 4 && player.Gold > shop.EquipmentToSell[4].Value)
                                                                        {
                                                                            player.Gold -= shop.EquipmentToSell[4].Value;
                                                                            player.AddEquipment(shop.EquipmentToSell[4]);
                                                                            exit = true;
                                                                            ctinue = false;
                                                                            inCtinue = false;
                                                                        }
                                                                        else if (player.Gold < shop.EquipmentToSell[4].Value)
                                                                        {
                                                                            UserUI.TextFormatter(boxes.Boxes[5], "You do not have enough gold! Sell me something!", 16, 1, false);
                                                                        }
                                                                        else if (menuPosition == 0 && player.Equipments.Count() >= 4)
                                                                        {
                                                                            UserUI.TextFormatter(boxes.Boxes[5], "You do not have enough room in your bag! Sell me something!", 16, 1, false);
                                                                        }
                                                                        else
                                                                        {
                                                                            UserUI.ClearBox(boxes.Boxes[5], 1, 11);
                                                                            menuPosition = 0;
                                                                            exit = true;
                                                                        }
                                                                        break;
                                                                }
                                                            } while (!exit);
                                                        }
                                                        break;
                                                    case ConsoleKey.Escape:
                                                        inCtinue = false;
                                                        menuPosition = 0;
                                                        UserUI.ClearBox(boxes.Boxes[1], 17, 1);

                                                        break;
                                                }

                                            } while (inCtinue);
                                            UserUI.ClearBox(boxes.Boxes[1], 17, 2);


                                        }
                                        else if (menuPosition == 2) //Items
                                        {
                                            {
                                                bool inCtinue = true;
                                                int menuLength = shop.ItemsToSell.Count() - 1;
                                                do
                                                {
                                                    startRow = 2;
                                                    count = 0;
                                                    UserUI.ClearBox(boxes.Boxes[1], 17, 2);
                                                    UserUI.ClearBox(boxes.Boxes[5], 1, 11);
                                                    foreach (Item item in shop.ItemsToSell)
                                                    {
                                                        Console.SetCursorPosition(17, startRow);
                                                        if (menuPosition == 0 && count == 0)
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.Green;
                                                            Console.WriteLine(item.Name + " X " + item.Count);
                                                            Console.ResetColor();
                                                            UserUI.TextFormatter(boxes.Boxes[5], item.Description, 11, 1, false);
                                                        }
                                                        else if (menuPosition == 1 && count == 1)
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.Green;
                                                            Console.WriteLine(item.Name + " X " + item.Count);
                                                            Console.ResetColor();
                                                            UserUI.TextFormatter(boxes.Boxes[5], item.Description, 11, 1, false);
                                                        }
                                                        else if (menuPosition == 2 && count == 2)
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.Green;
                                                            Console.WriteLine(item.Name + " X " + item.Count);
                                                            Console.ResetColor();
                                                            UserUI.TextFormatter(boxes.Boxes[5], item.Description, 11, 1, false);
                                                        }
                                                        else if (menuPosition == 3 && count == 3)
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.Green;
                                                            Console.WriteLine(item.Name + " X " + item.Count);
                                                            Console.ResetColor();
                                                            UserUI.TextFormatter(boxes.Boxes[5], item.Description, 11, 1, false);
                                                        }
                                                        else if (menuPosition == 4 && count == 4)
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.Green;
                                                            Console.WriteLine(item.Name + " X " + item.Count);
                                                            Console.ResetColor();
                                                            UserUI.TextFormatter(boxes.Boxes[5], item.Description, 11, 1, false);
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine(item.Name + " X " + item.Count);
                                                        }
                                                        count++;
                                                        startRow++;
                                                    }
                                                    userInput = Console.ReadKey(true).Key;
                                                    switch (userInput)
                                                    {
                                                        case (ConsoleKey.DownArrow):
                                                            if (menuPosition < 4)
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
                                                            UserUI.ClearBox(boxes.Boxes[5], 1, 11);
                                                            if (menuPosition == 0 && shop.ItemsToSell[0].Count > 0)
                                                            {
                                                                //Prompts the user if they want to buy item
                                                                
                                                                    bool exit = false;
                                                                    UserUI.ClearBox(boxes.Boxes[5], 1, 11);
                                                                    Console.SetCursorPosition(1, 11);
                                                                    Console.WriteLine($"Would you like to buy {shop.EquipmentToSell[0].Name}?");
                                                                    menuPosition = 0;
                                                                    do
                                                                    {
                                                                        Console.SetCursorPosition(1, 13);
                                                                        if (menuPosition == 0)
                                                                        {
                                                                            Console.ForegroundColor = ConsoleColor.Green;
                                                                            Console.Write("YES");
                                                                            Console.ResetColor();
                                                                            Console.Write("                     ");
                                                                            Console.Write("NO");
                                                                        }
                                                                        else if (menuPosition == 1)
                                                                        {
                                                                            Console.Write("YES");
                                                                            Console.Write("                     ");
                                                                            Console.ForegroundColor = ConsoleColor.Green;
                                                                            Console.Write("NO");
                                                                            Console.ResetColor();
                                                                        }
                                                                        userInput = Console.ReadKey(true).Key;
                                                                        switch (userInput)
                                                                        {
                                                                            case ConsoleKey.RightArrow:
                                                                                menuPosition = 1;
                                                                                break;
                                                                            case ConsoleKey.LeftArrow:
                                                                                menuPosition = 0;
                                                                                break;
                                                                            case ConsoleKey.Enter:
                                                                                if (menuPosition == 0 && player.Items.Count() < 4 && player.Gold > shop.ItemsToSell[0].Value && shop.ItemsToSell[0].Count > 0)
                                                                                {
                                                                                    player.Gold -= shop.ItemsToSell[0].Value;
                                                                                    player.AddItem(shop.ItemsToSell[0]);
                                                                                    exit = true;
                                                                                    ctinue = false;
                                                                                    inCtinue = false;
                                                                                    shop.ItemsToSell[0].Count -= 1;
                                                                                }
                                                                                else if (player.Gold < shop.ItemsToSell[0].Value)
                                                                                {
                                                                                    UserUI.TextFormatter(boxes.Boxes[5], "You do not have enough gold! Sell me something!", 16, 1, false);
                                                                                }
                                                                                else
                                                                                {
                                                                                    UserUI.ClearBox(boxes.Boxes[5], 1, 11);
                                                                                    menuPosition = 0;
                                                                                    exit = true;
                                                                                }
                                                                                break;
                                                                        }
                                                                    } while (!exit);
                                                                
                                                            }
                                                            else if (menuPosition == 1 && shop.ItemsToSell[1].Count > 0)
                                                            {
                                                                //Prompts the user if they want to buy item

                                                                bool exit = false;
                                                                UserUI.ClearBox(boxes.Boxes[5], 1, 11);
                                                                Console.SetCursorPosition(1, 11);
                                                                Console.WriteLine($"Would you like to buy {shop.ItemsToSell[1].Name}?");
                                                                menuPosition = 0;
                                                                do
                                                                {
                                                                    Console.SetCursorPosition(1, 13);
                                                                    if (menuPosition == 0)
                                                                    {
                                                                        Console.ForegroundColor = ConsoleColor.Green;
                                                                        Console.Write("YES");
                                                                        Console.ResetColor();
                                                                        Console.Write("                     ");
                                                                        Console.Write("NO");
                                                                    }
                                                                    else if (menuPosition == 1)
                                                                    {
                                                                        Console.Write("YES");
                                                                        Console.Write("                     ");
                                                                        Console.ForegroundColor = ConsoleColor.Green;
                                                                        Console.Write("NO");
                                                                        Console.ResetColor();
                                                                    }
                                                                    userInput = Console.ReadKey(true).Key;
                                                                    switch (userInput)
                                                                    {
                                                                        case ConsoleKey.RightArrow:
                                                                            menuPosition = 1;
                                                                            break;
                                                                        case ConsoleKey.LeftArrow:
                                                                            menuPosition = 0;
                                                                            break;
                                                                        case ConsoleKey.Enter:
                                                                            if (menuPosition == 0 && player.Items.Count() < 4 && player.Gold > shop.ItemsToSell[1].Value && shop.ItemsToSell[1].Count > 0)
                                                                            {
                                                                                player.Gold -= shop.ItemsToSell[1].Value;
                                                                                player.AddItem(shop.ItemsToSell[1]);
                                                                                exit = true;
                                                                                ctinue = false;
                                                                                inCtinue = false;
                                                                                shop.ItemsToSell[1].Count -= 1;
                                                                            }
                                                                            else if (player.Gold < shop.ItemsToSell[1].Value)
                                                                            {
                                                                                UserUI.TextFormatter(boxes.Boxes[5], "You do not have enough gold! Sell me something!", 16, 1, false);
                                                                            }
                                                                            else
                                                                            {
                                                                                UserUI.ClearBox(boxes.Boxes[5], 1, 11);
                                                                                menuPosition = 0;
                                                                                exit = true;
                                                                            }
                                                                            break;
                                                                    }
                                                                } while (!exit);
                                                            }
                                                            else if (menuPosition == 2 && shop.ItemsToSell[2].Count > 0)
                                                            {
                                                                //Prompts the user if they want to buy item

                                                                bool exit = false;
                                                                UserUI.ClearBox(boxes.Boxes[5], 1, 11);
                                                                Console.SetCursorPosition(1, 11);
                                                                Console.WriteLine($"Would you like to buy {shop.ItemsToSell[2].Name}?");
                                                                menuPosition = 0;
                                                                do
                                                                {
                                                                    Console.SetCursorPosition(1, 13);
                                                                    if (menuPosition == 0)
                                                                    {
                                                                        Console.ForegroundColor = ConsoleColor.Green;
                                                                        Console.Write("YES");
                                                                        Console.ResetColor();
                                                                        Console.Write("                     ");
                                                                        Console.Write("NO");
                                                                    }
                                                                    else if (menuPosition == 1)
                                                                    {
                                                                        Console.Write("YES");
                                                                        Console.Write("                     ");
                                                                        Console.ForegroundColor = ConsoleColor.Green;
                                                                        Console.Write("NO");
                                                                        Console.ResetColor();
                                                                    }
                                                                    userInput = Console.ReadKey(true).Key;
                                                                    switch (userInput)
                                                                    {
                                                                        case ConsoleKey.RightArrow:
                                                                            menuPosition = 1;
                                                                            break;
                                                                        case ConsoleKey.LeftArrow:
                                                                            menuPosition = 0;
                                                                            break;
                                                                        case ConsoleKey.Enter:
                                                                            if (menuPosition == 0 && player.Items.Count() < 4 && player.Gold > shop.ItemsToSell[2].Value && shop.ItemsToSell[2].Count > 0)
                                                                            {
                                                                                player.Gold -= shop.ItemsToSell[2].Value;
                                                                                player.AddItem(shop.ItemsToSell[2]);
                                                                                exit = true;
                                                                                ctinue = false;
                                                                                inCtinue = false;
                                                                                shop.ItemsToSell[2].Count -= 1;
                                                                            }
                                                                            else if (player.Gold < shop.ItemsToSell[2].Value)
                                                                            {
                                                                                UserUI.TextFormatter(boxes.Boxes[5], "You do not have enough gold! Sell me something!", 16, 1, false);
                                                                            }
                                                                            else
                                                                            {
                                                                                UserUI.ClearBox(boxes.Boxes[5], 1, 11);
                                                                                menuPosition = 0;
                                                                                exit = true;
                                                                            }
                                                                            break;
                                                                    }
                                                                } while (!exit);
                                                            }
                                                            else if (menuPosition == 3 && shop.ItemsToSell[3].Count > 0)
                                                            {
                                                                //Prompts the user if they want to buy item

                                                                bool exit = false;
                                                                UserUI.ClearBox(boxes.Boxes[5], 1, 11);
                                                                Console.SetCursorPosition(1, 11);
                                                                Console.WriteLine($"Would you like to buy {shop.ItemsToSell[3].Name}?");
                                                                menuPosition = 0;
                                                                do
                                                                {
                                                                    Console.SetCursorPosition(1, 13);
                                                                    if (menuPosition == 0)
                                                                    {
                                                                        Console.ForegroundColor = ConsoleColor.Green;
                                                                        Console.Write("YES");
                                                                        Console.ResetColor();
                                                                        Console.Write("                     ");
                                                                        Console.Write("NO");
                                                                    }
                                                                    else if (menuPosition == 1)
                                                                    {
                                                                        Console.Write("YES");
                                                                        Console.Write("                     ");
                                                                        Console.ForegroundColor = ConsoleColor.Green;
                                                                        Console.Write("NO");
                                                                        Console.ResetColor();
                                                                    }
                                                                    userInput = Console.ReadKey(true).Key;
                                                                    switch (userInput)
                                                                    {
                                                                        case ConsoleKey.RightArrow:
                                                                            menuPosition = 1;
                                                                            break;
                                                                        case ConsoleKey.LeftArrow:
                                                                            menuPosition = 0;
                                                                            break;
                                                                        case ConsoleKey.Enter:
                                                                            if (menuPosition == 0 && player.Items.Count() < 4 && player.Gold > shop.ItemsToSell[3].Value && shop.ItemsToSell[3].Count > 0)
                                                                            {
                                                                                player.Gold -= shop.ItemsToSell[3].Value;
                                                                                player.AddItem(shop.ItemsToSell[3]);
                                                                                exit = true;
                                                                                ctinue = false;
                                                                                inCtinue = false;
                                                                                shop.ItemsToSell[3].Count -= 1;
                                                                            }
                                                                            else if (player.Gold < shop.ItemsToSell[3].Value)
                                                                            {
                                                                                UserUI.TextFormatter(boxes.Boxes[5], "You do not have enough gold! Sell me something!", 16, 1, false);
                                                                            }
                                                                            else
                                                                            {
                                                                                UserUI.ClearBox(boxes.Boxes[5], 1, 11);
                                                                                menuPosition = 0;
                                                                                exit = true;
                                                                            }
                                                                            break;
                                                                    }
                                                                } while (!exit);
                                                            }
                                                            else if (menuPosition == 4 && shop.ItemsToSell[4].Count > 0)
                                                            {
                                                                //Prompts the user if they want to buy item

                                                                bool exit = false;
                                                                UserUI.ClearBox(boxes.Boxes[5], 1, 11);
                                                                Console.SetCursorPosition(1, 11);
                                                                Console.WriteLine($"Would you like to buy {shop.ItemsToSell[4].Name}?");
                                                                menuPosition = 0;
                                                                do
                                                                {
                                                                    Console.SetCursorPosition(1, 13);
                                                                    if (menuPosition == 0)
                                                                    {
                                                                        Console.ForegroundColor = ConsoleColor.Green;
                                                                        Console.Write("YES");
                                                                        Console.ResetColor();
                                                                        Console.Write("                     ");
                                                                        Console.Write("NO");
                                                                    }
                                                                    else if (menuPosition == 1)
                                                                    {
                                                                        Console.Write("YES");
                                                                        Console.Write("                     ");
                                                                        Console.ForegroundColor = ConsoleColor.Green;
                                                                        Console.Write("NO");
                                                                        Console.ResetColor();
                                                                    }
                                                                    userInput = Console.ReadKey(true).Key;
                                                                    switch (userInput)
                                                                    {
                                                                        case ConsoleKey.RightArrow:
                                                                            menuPosition = 1;
                                                                            break;
                                                                        case ConsoleKey.LeftArrow:
                                                                            menuPosition = 0;
                                                                            break;
                                                                        case ConsoleKey.Enter:
                                                                            if (menuPosition == 0 && player.Items.Count() < 4 && player.Gold > shop.ItemsToSell[4].Value && shop.ItemsToSell[4].Count > 0)
                                                                            {
                                                                                player.Gold -= shop.ItemsToSell[4].Value;
                                                                                player.AddItem(shop.ItemsToSell[4]);
                                                                                exit = true;
                                                                                ctinue = false;
                                                                                inCtinue = false;
                                                                                shop.ItemsToSell[4].Count -= 1;
                                                                            }
                                                                            else if (player.Gold < shop.ItemsToSell[4].Value)
                                                                            {
                                                                                UserUI.TextFormatter(boxes.Boxes[5], "You do not have enough gold! Sell me something!", 16, 1, false);
                                                                            }
                                                                            else
                                                                            {
                                                                                UserUI.ClearBox(boxes.Boxes[5], 1, 11);
                                                                                menuPosition = 0;
                                                                                exit = true;
                                                                            }
                                                                            break;
                                                                    }
                                                                } while (!exit);
                                                            }
                                                            else
                                                            {
                                                                UserUI.TextFormatter(boxes.Boxes[5], "I can't sell you what I don't have!", 16, 1, false);
                                                            }
                                                            break;
                                                        case ConsoleKey.Escape:
                                                            inCtinue = false;
                                                            menuPosition = 0;
                                                            break;
                                                    }
                                                } while (inCtinue);
                                            }
                                        }
                                        else if (menuPosition == 3) //Exit
                                        {
                                            ctinue = false;
                                            UserUI.ClearBox(boxes.Boxes[1], 17, 1);
                                            menuPosition = 0;
                                            break;
                                        }
                                        break;
                                    case ConsoleKey.Escape:
                                        ctinue = false;
                                        UserUI.ClearBox(boxes.Boxes[1], 17, 1);
                                        menuPosition = 0;
                                        break;
                                }
                            } while (ctinue);
                            UserUI.ClearBox(boxes.Boxes[1], 17, 2);
                        }
                        else if (menuPosition == 1) //Browse player inv to sell
                        {
                            UserUI.ClearBox(boxes.Boxes[5], 1, 11);
                        }
                        else if (menuPosition == 2) //Leave
                        {
                            bool exit = false;
                            UserUI.ClearBox(boxes.Boxes[5], 1, 11);
                            Console.SetCursorPosition(1, 11);
                            UserUI.TextFormatter(boxes.Boxes[6], "Are You sure you want to Leave?", 11, 1, false);
                            Console.SetCursorPosition(1, 12);
                            UserUI.TextFormatter(boxes.Boxes[6], $"You will get another shop after beating {score + 5} more monsters", 13, 1, false);
                            menuPosition = 0;
                            do
                            {
                                Console.SetCursorPosition(1, 16);
                                if (menuPosition == 0)
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.Write("YES");
                                    Console.ResetColor();
                                    Console.Write("                     ");
                                    Console.Write("NO");
                                }
                                else if (menuPosition == 1)
                                {
                                    Console.Write("YES");
                                    Console.Write("                     ");
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.Write("NO");
                                    Console.ResetColor();
                                }
                                userInput = Console.ReadKey(true).Key;
                                switch (userInput)
                                {
                                    case ConsoleKey.RightArrow:
                                        menuPosition = 1;
                                        break;
                                    case ConsoleKey.LeftArrow:
                                        menuPosition = 0;
                                        break;
                                    case ConsoleKey.Enter:
                                        if (menuPosition == 0)
                                        {
                                            exit = true;
                                            leaveShop = true;
                                            player.Life = 0;
                                        }
                                        else
                                        {
                                            UserUI.ClearBox(boxes.Boxes[5], 1, 11);
                                            menuPosition = 0;
                                            exit = true;
                                        }
                                        break;
                                }
                            } while (!exit);
                        }
                        break;

                }
            } while (!leaveShop);
        }
}
}