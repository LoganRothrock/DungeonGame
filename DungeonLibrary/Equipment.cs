using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Equipment
    {
        private int _value;
        public int Value { get { return _value; } set {
                if (value < 0)
                {
                    value = 0;
                }
                else
                {
                    _value = value;
                }
            } }
        public string Name { get; set; }
        public string Description { get; set; }
        public float BonusDamage { get; set; }
        public float BonusDefense { get; set; }
        public float BonusEvasion { get; set; }
        public float BonusBlock { get; set; }
        public string Rarity { get; set; }
        public bool IsEquipped { get; set; }
        public string Type { get; set; }


        Random rand = new Random();
        public Equipment(string name, string description, Player player)
        {

            Name = name;
            Description = description;
            Modifiers(player);
            DetermineRarity();
            DetermineValue();
            IsEquipped = false;
            Type = Name;
        }

        public override string ToString()
        {
            
            return string.Format("**{0} {1}**\n|Bonus Damage: {2}\n|Bonus Defense: {3}\n|Bonus Evasion: {4}\n|Bonus Block: {5}\n|Value: {6}",
                Rarity,
                Name,
                BonusDamage,
                BonusDefense,
                BonusEvasion,
                BonusBlock,
                Value);
        }
        private void DetermineValue()
        {
            Value = (int)((BonusBlock + BonusDamage + BonusDefense + BonusEvasion) * 1.50);
        }
        private void Modifiers(Player player)
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
                            BonusDamage += rand.Next(1,(6 + player.Lvl));
                            dmg = false;
                            modified = true;
                        }
                        else if (mod == 1 && def == true)
                        {
                            BonusDefense += rand.Next(1, (6 + player.Lvl));
                            def = false;
                            modified = true;
                        }
                        else if (mod == 2 && ev == true)
                        {
                            BonusEvasion += rand.Next(1, (6 + player.Lvl));
                            ev = false;
                            modified = true;
                        }
                        else if (mod == 3 && bl == true)
                        {
                            BonusBlock += rand.Next(1, (6 + player.Lvl));
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
        //TODO Add specification to make sure the right equipment is being added
        public static void Equip(Player player, Equipment equipment)
        {
            if (!equipment.IsEquipped)
            {
                if (equipment.Type == "Helmet" && player.EquippedHelmet == null)
                {
                    equipment.IsEquipped = true;
                    player.Strength += (int)equipment.BonusDamage;
                    player.Defense += (int)equipment.BonusDefense;
                    player.Evasion += (int)equipment.BonusEvasion;
                }
                else if (equipment.Type == "ChestPlate" && player.EquippedChestplate == null)
                {
                    equipment.IsEquipped = true;
                    player.Strength += (int)equipment.BonusDamage;
                    player.Defense += (int)equipment.BonusDefense;
                    player.Evasion += (int)equipment.BonusEvasion;
                }

            }
            else
            {
                Console.WriteLine("You already have this item equipped!");
            }
        }

            //TODO Add equipment type to specify what type of equipment will be removed
            public static void UnEquip(Player player, Equipment equipment)
            {
            player.Strength -= (int)equipment.BonusDamage;
            player.Defense -= (int)equipment.BonusDefense;
            player.Evasion -= (int)equipment.BonusEvasion;
            equipment.IsEquipped = false;
            if (equipment.Type == "ChestPlate") {
                player.EquippedChestplate = null;
            }
            else if (equipment.Type == "Helmet")
            {
                player.EquippedHelmet = null;
            }
        }
    }
}
