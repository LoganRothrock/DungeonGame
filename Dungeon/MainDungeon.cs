using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonLibrary;
using DungeonMonster;
using DungeonItems;
namespace Dungeon
{
    class MainDungeon
    {
        private int monsterSpawn = 0;

        static void Main(string[] args)
        {

            UserUI setup = new UserUI();
            Player player = new Player();
            setup.Setup();
            Shop shop = new Shop();
            string[] playerShopActions = { "Browse", "Sell", "Leave" };
            string[] playerActions = { "Attack", "Inventory", "Run Away", "Player Info", "Monster Info", "Exit" };
            string[] pRace = Enum.GetNames(typeof(Race));
            string[] playerInvActions = { "Weapons", "Armor", "Items", "Exit" };
            Weapon longSword = new Weapon(1, 8, "Long Sword", 10, false, "A simple Sword");
            
            //UserUI.GenerateBattleScreen(setup.Boxes); //Used to test any modifications made to the sizes of the boxes
            Console.ReadLine();
            player = Menus.CharacterCreationMenu(pRace,setup.Boxes[4], player, longSword);
            player.AddWeapon(longSword);
            Console.Clear();
            Console.ReadLine();
            int score = 0;
            Inventory Inv = new Inventory();
            //Testing Objects
            Item recover = new Item("Potion", "Heals for 20 health", "HEAL", 20, 1);
            Item recoverTest = new Item("Potion", "Heals for 20 health", "HEAL", 20, 0);
            Item bomb = new Item("Bomb", "Deals 40 points of dmg", "DMG", 40, 2);
            player.AddItem(recover);
            player.AddItem(recoverTest);
            player.AddItem(bomb);
            Equipment Helmet = new Equipment("Helmet", "A helmet forged in some far off place", player);
            Equipment ChestPlate = new Equipment("ChestPlate", "A ChestPlate forged in some far off place", player);
            Equipment ChestPlate1 = new Equipment("ChestPlate1", "A ChestPlate forged in some far off place", player);
            player.AddEquipment(Helmet);
            player.AddEquipment(ChestPlate);
            player.AddEquipment(ChestPlate1);
            Weapon ShortBow = new Weapon("ShortBow", "A Simple Sword", player);
            Weapon Shortsword = new Weapon("Shortsword", "A Simple Sword", player);
            Weapon aRock = new Weapon("aRock", "A Simple Sword", player);
            player.AddWeapon(ShortBow);
            //player.AddWeapon(Shortsword);
            player.AddWeapon(aRock);
            //Actual battle area
            bool exit = false;
            int monstersToDefeat = 5;
            do
            {
                // TODO create a room
                exit = false;
                UserUI.GenerateBattleScreen(setup.Boxes);
                //3. TODO Create monster
                Rabbit r1 = new Rabbit("White Rabbit", 25, 25, 50, 20, 2, 10, 15, 10, 1000, "Thats no ordinary rabbit! Look at the bones...", true);
                //Console.WriteLine(r1);
                Rabbit r2 = new Rabbit();
                Monster[] monsters = { r1, r1, r2, r2, r2 };
                Random rand = new Random();
                do
                {
                    UserUI.ClearBox(setup.Boxes[2], 1, 22);
                    UserUI.TextFormatter(setup.Boxes[2], GetRoom(), 21, 1, false);
                    int randNbr = rand.Next(monsters.Length);
                    Monster monster = monsters[randNbr];
                    Menus.FightMenu(player, monster, playerActions, playerInvActions, setup);
                    Console.ReadLine();
                    
                    if (player.Life <= 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Game over.\a");
                        Console.WriteLine("Your score: " + player.Score);
                        Console.WriteLine("Thank you for playing my game!");
                        exit = true;

                    }

                } while (!exit && monstersToDefeat > player.Score);
                // WIP shop does not flow in game feel yet
                if (player.Life > 0)
                {
                    monstersToDefeat += player.Score * 2;
                    Console.Clear();
                    Console.WriteLine("You stumble upon a shop in this seemingly endless dungeon. Get Some rest and shop for gear: ENTER to continue");
                    player.Life = player.MaxLife;
                    player.Gold = 1000;
                    UserUI.GenerateShopScreen(setup.Boxes);
                    Console.ReadLine();
                    Menus.Shop(player, playerShopActions, playerInvActions, setup, score, shop);
                }

            } while (!exit);
            
        }
        private static string GetRoom()
        {
            //collection initialization sytax
            string[] rooms =
            {
                "You open the door to reveal a 10-foot-by-10-foot room with a floor studded with spikes",
                "You pull open the door and hear the scrape of its opening echo throughout what must be a massive room. Peering inside, you see a vast cavern",
                "You open the door to a scene of carnage. Two male humans, a male elf, and a female dwarf lie in drying pools of their blood.",
                "You open the door and before you is a dragon's hoard of treasure. Coins cover every inch of the room, and jeweled objects of precious metal jut up from the money like glittering islands in a sea of gold.",
                "The scent of earthy decay assaults your nose upon peering through the open door to this room. Smashed bookcases and their sundered contents litter the floor. Paper rots in mold-spotted heaps, and shattered wood grows white fungus.",


            };

            Random rand = new Random();
            int indexNbr = rand.Next(rooms.Length);
            string room = rooms[indexNbr];
            return room;
            //return rooms[new Random().Next(rooms.Length)];
        }

        public int MonsterCount()
        {
            return monsterSpawn++;
        }
    }
}
