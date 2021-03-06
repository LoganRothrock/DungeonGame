﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Monster : Character
    {
        //fields

        private int _minDamage;

        //properties
        public int MaxDamage { get; set; }
        public string Description { get; set; }
        public int GoldDrop { get; set; }
        public int MinDamage
        {
            get { return _minDamage; }
            set
            {
                //can't be more than max damage and cannot be less than 1
                if (value > 0 && value <= MaxDamage)
                {
                    _minDamage = value;
                }
                else
                {
                    //tried to set a value outside of our range
                    _minDamage = 1;
                }
            }
        }

        //MINI-LAB
        //Create the default and FQCTOR for monster. Remeber the assignment order inside matters in this case
        public Monster(string name, int life, int maxLife, int hitChance, int block, int maxDamage, string description, int minDamage, int evasion, int agility, int goldDrop)
        {
            MaxDamage = maxDamage;
            MinDamage = minDamage;
            Description = description;
            Name = name;
            MaxLife = maxLife;
            Life = life;
            HitChance = hitChance;
            Block = block;
            Evasion = evasion;
            Agility = agility;
            UsedTurn = false;
            GoldDrop = goldDrop;
        }
        public Monster()
        {

        }


        //Method
        public override string ToString()
        {
            return string.Format("****** MONSTER ******\n|{0}\n|Life: {1} of {2}\n|Damage: {3} to {4}" +
                "\n|Block: {5}\tEvasion: {6}\n|Agility: {7}",
                Name,
                Life,
                MaxLife,
                MinDamage,
                MaxDamage,
                Block,
                Evasion,
                Agility);
        }
        public int GetStats()
        {
            return MaxLife + Evasion + Agility + MaxDamage + Block;
        }
        //We are overriding the CalcDamage() to use the properties of MinDamage and MaxDamage
        public override int CalcDamage()
        {
            Random rand = new Random();
            return rand.Next(MinDamage, MaxDamage + 1);
            //If we had a monster that had a min of 2 and a max of 8, if we passed MinDamage, MaxDamage
            //Then we would never be able to get back 8. This is because the MaxValue in the Next()
            //is exclusive.
        }




    }
}
