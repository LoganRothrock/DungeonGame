using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Character
    {
        private int _life;

        public string Name { get; set; }
        public int MaxLife { get; set; }
        public int HitChance { get; set; }
        public int Block { get; set; }
        public int Strength { get; set; }
        public int Defense { get; set; }
        public int Intelligence { get; set; }
        public int Agility { get; set; }
        public int Evasion { get; set; }
        //UsedTurn is used for various status effects and item using
        public bool UsedTurn { get; set; }

        public int Life
        {
            get { return _life; }
            set {
                if (value <= MaxLife)
                {
                    _life = value;
                }
                else
                {
                    _life = MaxLife;
                }
            }
        }
        public virtual int CalcBlock()
        {
            return Block;
        }
        public virtual int CalcHitChance()
        {
            return HitChance;
        }
        public virtual int CalcDamage()
        {
            return 0;
        }
        public virtual int CalcEvasion()
        {
            return Evasion;
        }
        public virtual int CalcStrength()
        {
            return Strength;
        }
        public virtual int CalcDefense()
        {
            return Evasion;
        }
        public virtual int CalcIntelligence()
        {
            return Intelligence;
        }

    }
}
