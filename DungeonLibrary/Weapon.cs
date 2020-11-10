using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Weapon 
    {
        private int _minDamage;

        public int MinDamage
        {
            get { return _minDamage; }
            set
            {
                if (value > 0 && value <= MaxDamage)
                {
                    _minDamage = value;
                }
                else
                {
                    _minDamage = value;
                    MaxDamage += _minDamage;
                }
            }
        }
        private int _value;
        public int Value
        {
            get { return _value; }
            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                else
                {
                    _value = value;
                }
            }
        }
        public float BonusHitChance { get; set; }
        public int MaxDamage { get; set; }
        public string Rarity { get; set; }
        public bool IsTwoHanded { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsEquipped { get; set; }
        private static readonly Random rand= new Random();

        public Weapon(int minDamage, int maxDamage,string name,int bonusHitChance, bool isTwoHanded,string description )
        {
            MaxDamage = maxDamage;
            MinDamage = minDamage;
            Name = name;
            IsTwoHanded = isTwoHanded;
            BonusHitChance = bonusHitChance;
            Description = description;
        }

        public Weapon(string name, string description, Player player)
        {
            Name = name;
            Description = description;
            MaxDamage = 5;
            MinDamage = 1;
            Modifiers(player);
            DetermineRarity();
            DetermineValue();
        }
        public override string ToString()
        {
            return string.Format("**{0} {1}**\n|{2}\n|{3} - {4} dmg dealt\n|{5} Bonus hit Chance\n|{6} G",Rarity, Name,Description,MinDamage,MaxDamage, BonusHitChance, Value);
        }
        private void DetermineValue()
        {
            Value = (int)((MinDamage + MaxDamage + BonusHitChance) * 1.75);
        }
        private void Modifiers(Player player)
        {
            int modAmount = RandomInt(0, 101);
            bool dmg = true, bMD = true, bHC = true;
            for (
                int i = 0; i <= 3; i++)
            {
                if (modAmount > ((i * 25)))
                {
                    bool modified = false;
                    do
                    {
                        int mod = RandomInt(0, 2);
                        if (mod == 0 && dmg == true)
                        {
                            MinDamage += rand.Next(1, (5 + player.Lvl));
                            dmg = false;
                            modified = true;
                        }
                        else if (mod == 1 && bMD == true)
                        {
                            MaxDamage += rand.Next(1, (6 + player.Lvl));
                            bMD = false;
                            modified = true;
                        }
                        else if (mod == 2 && bHC == true)
                        {
                            BonusHitChance += rand.Next(1, 6);
                            bHC = false;
                            modified = true;
                        }
                    } while (!modified);
                }

            }
        }
        private void DetermineRarity()


        {
            int rarity = rand.Next(0, 101);
            if (rarity <= 40)
            {
                Rarity = "Common";
            }
            else if (rarity > 40 && rarity <= 65)
            {
                Rarity = "Uncommon";
                MaxDamage = (int)(MaxDamage * 1.25f);
                MinDamage *= (int)(MinDamage * 1.25f);
                BonusHitChance *= 1.25f;
            }
            else if (rarity > 65 && rarity <= 80)
            {
                Rarity = "Rare";
                MaxDamage = (int)(MaxDamage * 1.5f);
                MinDamage *= (int)(MinDamage * 1.5f);
                BonusHitChance *= 1.5f;
            }
            else if (rarity > 80 && rarity <= 90)
            {
                Rarity = "Epic";
                MaxDamage = (int)(MaxDamage * 1.75f);
                MinDamage *= (int)(MinDamage * 1.75f);
                BonusHitChance *= 1.75f;
            }
            else if (rarity > 90 && rarity <= 97)
            {
                Rarity = "Legendary";
                MaxDamage *= 2;
                MinDamage *= 2;
                BonusHitChance *= 2;
            }
            else if (rarity > 97)
            {
                Rarity = "Mythical";
                MaxDamage = (int)(MaxDamage * 2.25f);
                MinDamage *= (int)(MinDamage * 2.25f);
                BonusHitChance *= 2.25f;

            }
        }
        public static int RandomInt(int first, int last)
        {
            Random rand = new Random();
            return rand.Next(first, last);
        }



    }
}
