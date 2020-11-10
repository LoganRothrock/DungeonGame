using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Shop
    {
        public List<Weapon> WeaponsToSell { get; set; }
        public List<Equipment> EquipmentToSell { get; set; }
        public List<Item> ItemsToSell { get; set; }
        public bool HasProduct { get; set; }

        public Shop()
        {
            HasProduct = false;
        }
        public void GenerateProductsToSell(Player player)
        {
            if (HasProduct)
            {
                WeaponsToSell.Clear();
                EquipmentToSell.Clear();
                ItemsToSell.Clear();
            }
            HasProduct = true;
            Equipment e1 = new Equipment("Test Name", "Test Description", player);
            Equipment e2 = new Equipment("Test Name", "Test Description", player);
            Equipment e3 = new Equipment("Test Name", "Test Description", player);
            Equipment e4 = new Equipment("Test Name", "Test Description", player);
            Equipment e5 = new Equipment("Test Name", "Test Description", player);
            List<Equipment> equipment = new List<Equipment>
            {
                e1,
                e2,
                e3,
                e4,
                e5
            };
            EquipmentToSell = equipment;

            Item i1 = new Item("Small Potion", "Restores 10 hp","HEAL", 10, RandomInt(1,5));
            Item i2 = new Item("Potion", "Restores 30 hp", "HEAL", 30, RandomInt(1, 5));
            Item i3 = new Item("Big Potion", "Restores 50 hp", "HEAL", 50, RandomInt(1, 5));
            Item i4 = new Item("Firecracker", "Deals 10 dmp to the enemy", "DMG", 10, RandomInt(1, 5));
            Item i5 = new Item("Bomb", "Deals 30 dmp to the enemy", "DMG", 30, RandomInt(1, 5));
            List<Item> item = new List<Item>
            {
                i1,
                i2,
                i3,
                i4,
                i5
            };
            ItemsToSell = item;

            Weapon w1 = new Weapon("ShortBow", "A Simple Sword", player);
            Weapon w2 = new Weapon("Shortsword", "A Simple Sword", player);
            Weapon w3 = new Weapon("aRock", "A Simple Sword", player);
            Weapon w4 = new Weapon("ShortBow", "A Simple Sword", player);
            Weapon w5 = new Weapon("Shortsword", "A Simple Sword", player);
            List<Weapon> weapons = new List<Weapon>
            {
                w1,
                w2,
                w3,
                w4,
                w5
            };
            WeaponsToSell = weapons;
        }
        public static int RandomInt(int first, int last)
        {
            Random rand = new Random();
            return rand.Next(first, last);
        }
    }
}
