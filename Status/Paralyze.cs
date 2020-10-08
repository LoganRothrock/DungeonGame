using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonLibrary;
namespace StatusEffects
{
    public class Paralyze : Status
    {
        public string Effect { get; set; }
        public int EffectStrength { get; set; }

        public Paralyze(string name, string description, int duration, string effect, int effectStregth) : base(name, description, duration)
        {
            Effect = effect;
            EffectStrength = effectStregth;
        }
        public static void ApplyEffect(Character target)
        {
            
        }
    }
}
