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
        public float BonusDamage { get; set; }
        public float BonusDefense { get; set; }
        public float BonusEvasion { get; set; }
        public float BonusBlock { get; set; }
        public string Rarity { get; set; }

        Random rand = new Random();
        public Equipment(string name, string description)
        {

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
            int modAmount = RandomInt(0, 101);
            bool dmg = true, def = true, ev = true, bl = true;
            for (int i = 0; i <= 3; i++)
            {
                if (modAmount > ((i*25)))
                {
                    bool modified = false;
                    do
                    {
                        int mod = RandomInt(0, 4);
                        if (mod == 0 && dmg == true)
                        {
                            BonusDamage += rand.Next(1,6);
                            dmg = false;
                            modified = true;
                        }
                        else if (mod == 1 && def == true)
                        {
                            BonusDefense += rand.Next(1,6);
                            def = false;
                            modified = true;
                        }
                        else if (mod == 2 && ev == true)
                        {
                            BonusEvasion += rand.Next(1,6);
                            ev = false;
                            modified = true;
                        }
                        else if (mod == 3 && bl == true)
                        {
                            BonusBlock += rand.Next(1,6);
                            bl = false;
                            modified = true;
                        }
                    } while (!modified);
                }
                
            }
        }
        private void DetermineRarity()
        {
            int rarity = RandomInt(0, 101);
            if (rarity <=40)
            {
                Rarity = "Common";
            }
            else if (rarity > 40 && rarity <= 65)
            {
                Rarity = "Uncommon";
                BonusDamage *= 1.25f;
                BonusDefense *= 1.25f;
                BonusEvasion *= 1.25f;
                BonusBlock *= 1.25f;
            }
            else if (rarity > 65 && rarity <= 80)
            {
                Rarity = "Rare";
                BonusDamage *= 1.5f;
                BonusDefense *= 1.5f;
                BonusEvasion *= 1.5f;
                BonusBlock *= 1.5f;
            }
            else if (rarity > 80 && rarity <= 90)
            {
                Rarity = "Epic";
                BonusDamage *= 1.75f;
                BonusDefense *= 1.75f;
                BonusEvasion *= 1.75f;
                BonusBlock *= 1.75f;
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
                BonusDamage *= 2.25f;
                BonusDefense *= 2.25f;
                BonusEvasion *= 2.25f;
                BonusBlock *= 2.25f;

            }
        }
        public static int RandomInt(int first, int last)
        {
            Random rand = new Random();
            return rand.Next(first, last);
        }

    }
}
