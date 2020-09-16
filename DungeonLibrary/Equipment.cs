using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Equipment
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double BonusDamage { get; set; }
        public double BonusDefense { get; set; }
        public double BonusEvasion { get; set; }
        public double BonusBlock { get; set; }
        public string Rarity { get; set; }

        public Equipment(string name, string description)
        {
            BonusBlock = 0.0;
            BonusDamage = 0.0;
            BonusDefense = 0.0;
            BonusEvasion = 0.0;
            Random rand = new Random();
            Name = name;
            Description = description;
            Modifiers();
            DetermineRarity();
        }
        public override string ToString()
        {
            
            return string.Format("*********{0} {1}**********\n{2}\nBonus Damage: {3}\nBonus Defense: {4}\nBonus Evasion: {5}\nBonus Block: {6}",
                Rarity,
                Name,
                Description,
                BonusDamage,
                BonusDefense,
                BonusEvasion,
                BonusBlock);
        }
        private void Modifiers()
        {
            Random rand = new Random();
            bool dmg = true, def = true, ev = true, bl = true;
            for (int i = 0; i <= 3; i++)
            {
                if (rand.Next(101) > ((i*25)))
                {
                    bool modified = false;
                    do
                    {
                        int mod = rand.Next(4);
                        if (mod == 0 && dmg == true)
                        {
                            BonusDamage += rand.Next(5);
                            dmg = false;
                            modified = true;
                        }
                        else if (mod == 1 && def == true)
                        {
                            BonusDefense += rand.Next(5);
                            def = false;
                            modified = true;
                        }
                        else if (mod == 2 && ev == true)
                        {
                            BonusEvasion += rand.Next(2);
                            ev = false;
                            modified = true;
                        }
                        else if (mod == 3 && bl == true)
                        {
                            BonusBlock += rand.Next(5);
                            bl = false;
                            modified = true;
                        }
                    } while (!modified);
                }
                
            }
        }
        private void DetermineRarity()
        {
            Random rand = new Random();
            int rarity = rand.Next(101);
            if (rarity <=40)
            {
                Rarity = "Common";
            }
            else if (rarity > 40 && rarity <= 65)
            {
                Rarity = "Uncommon";
                BonusDamage *= 1.25;
                BonusDefense *= 1.25;
                BonusEvasion *= 1.25;
                BonusBlock *= 1.25;
            }
            else if (rarity > 65 && rarity <= 80)
            {
                Rarity = "Rare";
                BonusDamage *= 1.5;
                BonusDefense *= 1.5;
                BonusEvasion *= 1.5;
                BonusBlock *= 1.5;
            }
            else if (rarity > 80 && rarity <= 90)
            {
                Rarity = "Epic";
                BonusDamage *= 1.75;
                BonusDefense *= 1.75;
                BonusEvasion *= 1.75;
                BonusBlock *= 1.75;
            }
            else if (rarity > 90 && rarity <= 97)
            {
                Rarity = "Legendary";
                BonusDamage *= 2;
                BonusDefense *= 2;
                BonusEvasion *= 2;
                BonusBlock *= 2;
            }
            else if (rarity > 97)
            {
                Rarity = "Mythical";
                BonusDamage *= 2.25;
                BonusDefense *= 2.25;
                BonusEvasion *= 2.25;
                BonusBlock *= 2.25;

            }
        }

    }
}
