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
                    _minDamage = 1;
                }
            }
        }
        public int BonusHitChance { get; set; }
        public int MaxDamage { get; set; }
        public bool IsTwoHanded { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Weapon(int minDamage, int maxDamage,string name,int bonusHitChance, bool isTwoHanded,string description )
        {
            MaxDamage = maxDamage;
            MinDamage = minDamage;
            Name = name;
            IsTwoHanded = isTwoHanded;
            BonusHitChance = bonusHitChance;
            Description = description;
        }
        public override string ToString()
        {
            return string.Format("******** {0} ********\n{1}\n{2} - {3} dmg dealt", Name,Description,MinDamage,MaxDamage);
        }



    }
}
