using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public sealed class Player : Character
    {
        //New classes in a DLL (Dynamic Link Library) default internal. Internal is NOT a keyword you 
        //have to type in. That is the default if you do NOT supply another modifier.

        //The sealed keyword indicates that a class cannot be used as a base class for other classes.
        //No more inheritance can occur.

        //fields
        private int _gold;
        //properties
        //Automatic property Syntax - allows us to create a shortened version of a public property with 
        //NO biz rules. The fields are created automatically at runtime. They have an open getter and setter.
        public int Gold { get { return _gold; } set {
                if (value < 0)
                {
                    _gold = 0;
                }
                else if (value > 1000)
                {
                    _gold = 1000;
                }
                else
                {
                    _gold = value;
                }
            } }
        public Race CharacterRace { get; set; }
        public Weapon EquippedWeapon { get; set; }
        public Equipment EquippedChestplate { get; set; }
        public Equipment EquippedHelmet { get; set; }
        public List<Item> Items { get; set; }
        public List<Equipment> Equipments { get; set; }
        public List<Weapon> Weapons { get; set; }
        public int Score { get; set; }
        public int Exp { get; set; }
        public int Lvl { get; set; }

        //ctors
        //Only going to make a FQCTOR....we do NOT want to allow anyone to make a player that does not have values 
        //for all of the properies
        public Player(string name, int hitChance, int block, int life, int maxLife, int strength, int defense,int evasion, int agility, Race characterRace, Weapon equippedWeapon)
        {
            MaxLife = maxLife;
            Life = life;
            Name = name;
            Block = block;
            HitChance = hitChance;
            Strength = strength;
            Defense = defense;
            Evasion = evasion;
            Agility = agility;
            CharacterRace = characterRace;
            EquippedWeapon = equippedWeapon;
            Gold = 0;
            Exp = 0;
            Lvl = 0;
            Score = 0;
            UsedTurn = false;
            Weapons = new List<Weapon>();
            Items = new List<Item>();
            Equipments = new List<Equipment>();
            equippedWeapon.IsEquipped = true;

            //We will modify the HitChance of a Player based on their race
            switch (CharacterRace)
            {
                case Race.Orc:
                    MaxLife += 10;
                    Life += 10;
                    Strength += 100;
                    break;
                case Race.Elf:
                    HitChance += 5;
                    Agility += 5;
                    break;
                case Race.Goblin:
                    Agility += 3;
                    break;
                case Race.Beastmen:
                    break;
                case Race.Dwarf:
                    MaxLife += 10;
                    Life += 10;
                    Defense += 100;
                    break;
                case Race.Human:
                    break;
                case Race.Wizard:
                    Life -= 5;
                    break;
                default:
                    break;
            }
        }
        public Player()
        {

        }

        //methods
        public override string ToString()
        {
            string description = "";
            switch (CharacterRace)
            {
                case Race.Orc:
                    description = "Orc";
                    break;
                case Race.Elf:
                    description = "Elf";
                    break;
                case Race.Goblin:
                    description = "Goblin";
                    break;
                case Race.Beastmen:
                    description = "Beastmen";
                    break;
                case Race.Dwarf:
                    description = "Dwarf";
                    break;
                case Race.Human:
                    description = "Human";
                    break;
                case Race.Wizard:
                    description = "Wizard";
                    break;

            }
            return string.Format("******** {0} ******\n|Life: {1} of {2}\n|Hit Chane: {3}%\n|Weapon:{4}\n|Strength: {5}\tDefense: {6}\n|Block: {7}\tEvasion: {8}\n|Agility: {9}\tRace: {10}\n|Lvl: {11}\tExp: {12}\n|Exp till next lvl: {13}",
                Name,
                Life,
                MaxLife,
                CalcHitChance(),
                EquippedWeapon.Name,
                Strength,
                Defense,
                Block,
                Evasion,
                Agility,
                description,
                Lvl,
                Exp,
                ((50 + (50 * Math.Pow(Lvl, 2)))-Exp));
        }

        //Overriding the CalcDamage in player to use their weapon's property of MinDamage and MaxDamage
        public override int CalcDamage()
        {
            //We dont't want to return 0
            //create a random object
            Random rand = new Random();
            //determine the damage
            int damage = rand.Next(EquippedWeapon.MinDamage + Strength, EquippedWeapon.MaxDamage + 1 + Strength);
            return damage;

            //return new Random().Next(EquippedWeapon.MinDamage, EquippedWeapon.MaxDamage +1);

        }
        public override int CalcHitChance()
        {
            return base.CalcHitChance() + (int)EquippedWeapon.BonusHitChance;
        }
        public void DetermineLevelUp(int startRow)
        {
            int lvlUps = 0;
            while (Exp >= (50 + (50 * Math.Pow(Lvl, 2))))
            {
                lvlUps++;
                Lvl++;
            }
            
            if (lvlUps > 0)
            {
                Console.SetCursorPosition(1, startRow);
                Console.WriteLine("{0} Leveled Up {1} time{2}\n|Hp: {3} + {4}  Strength: {5} + {6}\n|Defense: {7} + {8}",
                    Name,
                    lvlUps,
                    lvlUps > 1 ? "s" : "",
                    MaxLife,
                    (5 * lvlUps),
                    Strength,
                    (2 * lvlUps),
                    Defense,
                    (1 * lvlUps));
                LevelUpStats(lvlUps);
            }
        }
        private void LevelUpStats(int lvlups)
        {
            MaxLife += 4 * lvlups;
            Strength += 2 * lvlups;
            Intelligence += 2 * lvlups;
            Defense += 1 * lvlups;
        }
        public void AddItem(Item item)
        {
            Items.Add(item);
        }
        public void AddWeapon(Weapon weapon)
        {
            Weapons.Add(weapon);
        }
        public void AddEquipment(Equipment equipment)
        {
            Equipments.Add(equipment);
        }


        public void EquipEquipment(Player player, Equipment equipment)
        {
            //Checks to make sure the Equipment that the player wants to equip isn't already equipped
            if (!equipment.IsEquipped)
            {
                //Handles the "Unequip" portion
                if (equipment.Type == "Helmet" && player.EquippedHelmet != null)
                {
                    player.Strength -= (int)player.EquippedHelmet.BonusDamage;
                    player.Defense -= (int)player.EquippedHelmet.BonusDefense;
                    player.Evasion -= (int)player.EquippedHelmet.BonusEvasion;
                    player.EquippedHelmet.IsEquipped = false;
                    player.EquippedHelmet = null;
                }
                else if (equipment.Type == "ChestPlate" && player.EquippedChestplate != null)
                {
                    player.Strength -= (int)player.EquippedChestplate.BonusDamage;
                    player.Defense -= (int)player.EquippedChestplate.BonusDefense;
                    player.Evasion -= (int)player.EquippedChestplate.BonusEvasion;
                    player.EquippedChestplate.IsEquipped = false;
                    player.EquippedChestplate = null;
                }
                //Handles the "Equip" portion
                if (equipment.Type == "Helmet" && player.EquippedHelmet == null)
                {
                    equipment.IsEquipped = true;
                    player.EquippedHelmet = equipment;
                    player.Strength += (int)equipment.BonusDamage;
                    player.Defense += (int)equipment.BonusDefense;
                    player.Evasion += (int)equipment.BonusEvasion;
                }
                else if (equipment.Type == "ChestPlate" && player.EquippedChestplate == null)
                {
                    equipment.IsEquipped = true;
                    player.EquippedChestplate = equipment;
                    player.Strength += (int)equipment.BonusDamage;
                    player.Defense += (int)equipment.BonusDefense;
                    player.Evasion += (int)equipment.BonusEvasion;
                }

            }
        }
        public void EquipWeapon(Player player, Weapon weapon)
        {
            if (player.EquippedWeapon != weapon)
            {
                weapon.IsEquipped = true;
                player.EquippedWeapon = weapon;
            }
        }
    }
}
