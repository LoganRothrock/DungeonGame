using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonLibrary;

namespace DungeonMonster
{
    public class Rabbit : Monster
    {
        //Created a child monster, it will have at least one unique property

        //automatic property syntax

        //fields/properies
        public bool IsFluffy { get; set; }

        //ctors
        public Rabbit(string name, int life, int maxLife, int hitChance, int block, int minDamage, int maxDamage,int agility, int evasion, string description, bool isFluffy) : base(name, life, maxLife, hitChance, block, maxDamage, description, minDamage,evasion,agility)
        {
            IsFluffy = isFluffy;

        }

        //set some values for a basic monster of this type in the default ctor

        public Rabbit()
        {
            //Set some basic values
            MaxLife = 6;
            MaxDamage = 3;
            Name = "Baby Rabbit";
            Life = 6;
            HitChance = 20;
            Block = 20;
            MinDamage = 1;
            Description = "Its just a cute little bunny......Why even bother";
            IsFluffy = false;
        }

        //overrride the block to say if they are fluffy they will get a bonus of 50% to their block
        public override int CalcBlock()
        {
            int calculatedBlock = Block;
            if (IsFluffy)
            {
                calculatedBlock += calculatedBlock / 2;
            }
            return calculatedBlock;
        }

    }
}
