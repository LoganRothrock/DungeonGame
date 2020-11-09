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

        public static void DoAttack(Character attacker, Character defender, bool usedTurn, int row, bool runAway)
        {
            
            //get random number from 1-100 as our dice roll
            Random rand = new Random();
            int diceRoll = rand.Next(1, 101);
            System.Threading.Thread.Sleep(30);
            if (runAway == true)
            {
                //the attacker hit
                int damageDealt = attacker.CalcDamage() - defender.Defense;
                //Checks to make sure that damageDealt isn't negative
                if (damageDealt <= 0)
                {
                    //write the result out to the screen
                    Console.SetCursorPosition(46, row);
                    Console.WriteLine("Nice dodging! {0} missed all the attacks while {1} ran away!", attacker.Name, defender.Name);
                }
                else
                {
                    //write the result out to the screen
                    defender.Life -= damageDealt;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(46, row);
                    Console.WriteLine("{0} hit {1} for {2} damage, while {1} ran away!", attacker.Name, defender.Name, damageDealt);
                    Console.ResetColor();
                }
            }
            else if (diceRoll <= (attacker.CalcHitChance() - defender.CalcEvasion()) && usedTurn == false)
            {
                //the attacker hit
                int damageDealt = attacker.CalcDamage()-defender.Defense;
                //Checks to make sure that damageDealt isn't negative
                if (damageDealt <=0)
                {
                    //write the result out to the screen
                    Console.SetCursorPosition(46, row);
                    Console.WriteLine("{0} hit {1} for 0 damage!", attacker.Name, defender.Name);
                }
                else
                {
                    //write the result out to the screen
                    defender.Life -= damageDealt;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(46, row);
                    Console.WriteLine("{0} hit {1} for {2} damage!", attacker.Name, defender.Name, damageDealt);
                    Console.ResetColor();
                }

            }
            else if (diceRoll >= (attacker.CalcHitChance() - defender.CalcEvasion()))
            {
                Console.SetCursorPosition(46, row);
                Console.WriteLine("{0} missed!", attacker.Name);
            }
            attacker.UsedTurn = false;
        }   

            public static void DoBattle(Player player, Monster monster)
        {
            //checks players and monsters agility to determine who goes first
            if(player.Agility >= monster.Agility)
            {
                DoAttack(player, monster, player.UsedTurn, 5, false);
                //makes sure other party isn't dead
                if (monster.Life > 0)
                {
                    DoAttack(monster, player, monster.UsedTurn, 6, false);
                }
            }
            else if (player.Agility < monster.Agility)
            {
                DoAttack(monster, player, monster.UsedTurn, 5, false);
                //makes sure other party isn't dead
                if (player.Life > 0)
                {
                    DoAttack(player, monster, player.UsedTurn, 6, false);
                }
            }
            
        }

    }
}
