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
        private int _maxDamage;
        private string _name;
        private bool _isTwoHanded;

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

        public int MaxDamage
        {
            get { return _maxDamage; }
            set { _maxDamage = value; }
        }
        
        private string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private bool IsTwoHanded
        {
            get { return _isTwoHanded; }
            set { _isTwoHanded = value; }
        }

        public Weapon(int minDamage, int maxDamage,string name, bool isTwoHanded )
        {
            MaxDamage = maxDamage;
            MinDamage = minDamage;
            Name = name;
            IsTwoHanded = isTwoHanded;
        }

        
    }
}
