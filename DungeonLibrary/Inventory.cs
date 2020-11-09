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
            int list = 1;
            foreach (Item item in Items)
            {
                if (item.Count > 0)
                {
                    showItems += list + ") " + item.Name + " carrying " + item.Count + "\n";
                    list++;
                }
            }
            showItems += list + ") EXIT";
            return showItems;
        }
        public string ShowEquipment()
        {
            string showEquipment = "";
            int list = 1;
            foreach (Equipment equipment in Equipments)
            {
                showEquipment += list + ") " + equipment.Rarity + " " + equipment.Name + ": " + equipment.Description + "\n";
                list++;
            }
            showEquipment += list + ") EXIT";
            return showEquipment;
        }
        public string ShowWeapons()
        {
            string showWeapons = "";
            int list = 1;
            foreach (Weapon weapon in Weapons)
            {
                showWeapons += list + ") " + weapon.Name + ": " + weapon.Description + "\n";
                list++;
            }
            showWeapons += list + ") EXIT";
            return showWeapons;
        }
    }
}
