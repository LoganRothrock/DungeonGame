using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Item
    {
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
        public string Name { get; set; }
        public string Description { get; set; }
        public string Effect { get; set; }
        public int EffectStrength { get; set; }
        public int Count { get; set; }

        public Item(string name, string description, string effect, int effectStrength, int count)
        {
            Name = name;
            Description = description;
            Effect = effect;
            EffectStrength = effectStrength;
            Count = count;
            DetermineValue();
        }
        private void DetermineValue()
        {
            Value = EffectStrength;
        }
        public void AddItem(int add)
        {
            Count += add;
        }
        public static void UseItem(Item item, Player player, Monster monster)
        {
            if (item.Count > 0)
            {
                if (item.Effect == "HEAL")
                {
                    
                    player.Life += item.EffectStrength;
                    player.UsedTurn = true;
                    Console.WriteLine(player.Name + " restored " + item.EffectStrength + " health!");
                    Combat.DoAttack(monster, player, player.UsedTurn, 1, false);
                }
                else if (item.Effect == "DMG")
                {
                    Console.SetCursorPosition(46, 5);
                    Console.WriteLine("{0} dealt {1} dmg to {2}",player.Name,item.EffectStrength,monster.Name);
                    monster.Life -= item.EffectStrength;
                    player.UsedTurn = true;
                    if (monster.Life > 0)
                    {
                        Combat.DoAttack(monster, player, player.UsedTurn, 1, false);
                    }
                }
                else if (item.Effect == "BUFF")
                {
                    player.Strength += item.EffectStrength;
                }else if (item.Effect == "DEBUFF")
                {
                    monster.Strength -= item.EffectStrength;
                }
                item.Count -= 1;
            }
            else
            {
                Console.WriteLine("You can't use what you don't have!");
            }
        }
    }
    
}
