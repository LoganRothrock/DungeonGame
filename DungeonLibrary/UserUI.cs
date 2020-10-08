using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class UserUI
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public List<UserUI> Boxes { get; set; }

        public UserUI()
        {

        }
        public UserUI(int width, int height)
        {
            Width = width;
            Height = height;  
        }
        public void Setup()
        {
            UserUI playerMenu = new UserUI(15,10);
            UserUI playerInv = new UserUI(15, 10);
            UserUI roomInfo = new UserUI(31, 10);
            UserUI BattleArea = new UserUI(40, 25);
            UserUI raceInfo = new UserUI(25, 10);
            List<UserUI> boxes = new List<UserUI>();
            boxes.Add(playerMenu);
            boxes.Add(playerInv);
            boxes.Add(roomInfo);
            boxes.Add(BattleArea);
            boxes.Add(raceInfo);
            Boxes = boxes;
        }
        public static void GenerateBattleScreen(List<UserUI> boxes)
        {
            UserUI.MakeBoxAtPosition(boxes[0], 0, 0);
            UserUI.MakeBoxAtPosition(boxes[1], 16, 0);
            UserUI.MakeBoxAtPosition(boxes[2], 0, 10);
            UserUI.MakeBoxAtPosition(boxes[3], 40, 0);

        }
        public string MakeBox(int width, int height)
        {
            string box = "";
            for (int i = 0; i <= Height; i++)
            {
                for (int j = 0; j <= Width; j++)
                {
                    if (i == 0 && j != 0 && j != Width)
                    {
                        box += "-";
                    }
                    else if (i == Height && j != 0 && j != Width)
                    {
                        box += "-";
                    }
                    else if (j == 0 || j == Width)
                    {
                        box += "|";
                    }
                    else
                    {
                        box += " ";
                    }

                }
                box += "\n";
            }
            return box;
        }
        public static void MakeBoxAtPosition(UserUI border, int startCol, int startRow)
        {
            Console.SetCursorPosition(startCol, startRow);
            string box = "";
            for (int i = 1; i <= border.Height; i++)
            {
                box = "";
                for (int j = 0; j <= border.Width; j++)
                {
                    if (i == 1 && j != 0 && j != border.Width)
                    {
                        box += "-";
                    }
                    else if (i == border.Height && j != 0 && j != border.Width)
                    {
                        box += "-";
                    }
                    else if (j == 0 || j == border.Width)
                    {
                        box += "|";
                    }
                    else
                    {
                        box += " ";
                    }

                }
                Console.Write(box);
                if (i != border.Height)
                {
                    Console.SetCursorPosition(startCol, i + startRow);
                }

            }
        }
        public static void TextFormatter(UserUI box, string menus, int startRow, int startCol, bool list)
        {
            Random rand = new Random();
            int spaceIndex = 0;
            int r1 = rand.Next(0, menus.Length);
            if (list)
            {
                //foreach (string menu in menus)
                //{
                //    if (menu.Length < box.Width)
                //    {
                //        Console.SetCursorPosition(startCol, startRow);
                //        Console.WriteLine(menu);
                //        startRow++;
                //    }
                //}
            }
            else
            {
                if (menus.Length > box.Width)
                {
                    string longText = menus;
                    while (longText.Length >= box.Width)
                    {
                        spaceIndex = longText.LastIndexOf(' ', (box.Width)) + 1;
                        Console.SetCursorPosition(startCol, startRow);
                        Console.WriteLine(longText.Substring(0, spaceIndex));
                        longText = longText.Remove(0, spaceIndex);
                        startRow++;
                    }
                    Console.SetCursorPosition(startCol, startRow);
                    Console.WriteLine(longText);
                }
                else
                {
                    Console.SetCursorPosition(startCol, startRow);
                    Console.WriteLine(menus[r1]);
                }
            }



        }
        public static void ClearBox(UserUI box, int startCol, int startRow)
        {
            string eraser = " ";
            for (int i = 0; i <= box.Height - 3; i++)
            {
                Console.SetCursorPosition(startCol, startRow);
                for (int j = 0; j <= box.Width - 2; j++)
                {
                    if (i == 0 && j != 0 && j != box.Width - 2)
                    {
                        Console.Write(eraser);
                    }
                    else if (i == box.Height - 3 && j != 0 && j != box.Width - 2)
                    {
                        Console.Write(eraser);
                    }
                    else if (j == 0 || j == box.Width - 2)
                    {
                        Console.Write(eraser);
                    }
                    else
                    {
                        Console.Write(eraser);
                    }

                }
                startRow++;
            }
        }
    }
}
