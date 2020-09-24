using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public sealed class Inventory
    {
        public List<Item> Items { get; set; }
        public List<Equipment> Equipments { get; set; }
        public List<Weapon> Weapons { get; set; }
        //List<Item> items
        //List<Weapon> weapons
        public Inventory(List<Equipment> equipment,List<Weapon> weapons,List<Item> items)
        {
            Weapons = weapons;
            Equipments = equipment;
            Items = items;
        }
        public Inventory()
        {

        }
        public string ShowItems()
        {
            string showItems = "";
            foreach (Item item in Items)
            {
                if (item.Count > 0)
                {
                    showItems += item.Name + "\n";
                }
            }
            return showItems;
        }
        public string ShowEquipment()
        {
            string showEquipment = "";
            foreach (Equipment equipment in Equipments)
            {
                showEquipment += equipment.Rarity + " " + equipment.Name + ": " + equipment.Description + "\n";
            }
            return showEquipment;
        }
        public string ShowWeapons()
        {
            string showWeapons = "";
            foreach (Weapon weapon in Weapons)
            {
                showWeapons += weapon.Name + ": " + weapon.Description + "\n";
            }
            return showWeapons;
        }
    }
}
