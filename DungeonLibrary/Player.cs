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

        //properties
        //Automatic property Syntax - allows us to create a shortened version of a public property with 
        //NO biz rules. The fields are created automatically at runtime. They have an open getter and setter.

        public Race CharacterRace { get; set; }
        public Weapon EquippedWeapon { get; set; }
        public Equipment EquippedChestplate { get; set; }
        public Equipment EquippedHelmet { get; set; }
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
            Exp = 0;
            Lvl = 0;
            UsedTurn = false;

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
            return string.Format("******** {0} ******\nLife: {1} of {2}\nHit Chane: {3}%\nWeapon:{4}\nStrength: {5}\tDefense: {6}\tBlock: {7}\nEvasion: {8}\tAgility {9}\nRace: {10}\nLvl: {11}\nExp: {12}\nExp till next lvl: {13}",
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
            return base.CalcHitChance() + EquippedWeapon.BonusHitChance;
        }
        public void DetermineLevelUp()
        {
            int lvlUps = 0;
            while (Exp >= (50 + (50 * Math.Pow(Lvl, 2))))
            {
                lvlUps++;
                Lvl++;
            }
            if (lvlUps > 0)
            {
                Console.WriteLine("{0} Leveled Up {1} time{2}\nHp: {3} + {4}\nStrength: {5} + {6}\nDefense: {7} + {8}",
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

    }
}
