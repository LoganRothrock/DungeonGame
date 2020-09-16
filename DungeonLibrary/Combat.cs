using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Combat
    {
        //This class will not have fields, properies, or any custom constructors. It is just a 
        //"warehouse" for different methods

        public static void DoAttack(Character attacker, Character defender)
        {
            //get random number from 1-100 as our dice roll
            Random rand = new Random();
            int diceRoll = rand.Next(1, 101);
            System.Threading.Thread.Sleep(30);
            if (diceRoll <= (attacker.CalcHitChance() - defender.CalcEvasion()))
            {
                //the attacker hit
                int damageDealt = attacker.CalcDamage()-defender.Defense;
                //Checks to make sure that damageDealt isn't negative
                if (damageDealt <=0)
                {
                    //write the result out to the screen
                    Console.WriteLine("{0} hit {1} for 0 damage!", attacker.Name, defender.Name);
                }
                else
                {
                    //write the result out to the screen
                    defender.Life -= damageDealt;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("{0} hit {1} for {2} damage!", attacker.Name, defender.Name, damageDealt);
                    Console.ResetColor();
                }

            }
            else
            {
                Console.WriteLine("{0} missed!", attacker.Name);
            }

        }

        public static void DoBattle(Player player, Monster monster)
        {
            //checks players and monsters agility to determine who goes first
            if(player.Agility >= monster.Agility)
            {
                DoAttack(player, monster);
                //makes sure other party isn't dead
                if (monster.Life > 0)
                {
                    DoAttack(monster, player);
                }
            }
            else if (player.Agility < monster.Agility)
            {
                DoAttack(monster, player);
                //makes sure other party isn't dead
                if (player.Life > 0)
                {
                    DoAttack(player, monster);
                }
            }


            
        }

    }
}
