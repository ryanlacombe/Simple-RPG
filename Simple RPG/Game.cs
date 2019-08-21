using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_RPG
{
    class Game
    {
        string playerName = "";
        int playerHealth = 100;
        int playerMaxHealth = 100;
        int playerMana = 60;
        int playerManaMin = 0;
        int playerExp = 0;
        int playerLevel = 1;
        int playerExpMax = 40;
        int playerDamage = 10;
        int fireDamage = 15;
        int iceDamage = 20;
        int thunderDamage = 35;
        int healDamage = 50;
        public void Start()
        {

            Welcome();

            int monsterRemaining = 5;

            bool alive = true;

            while(alive && monsterRemaining > 0)
            {
                Console.WriteLine("There are " + monsterRemaining + " Carbuncles remaining.");
                alive = Encounter(20, 15);
                monsterRemaining--;
            }
            

            Console.ReadKey();
        }
        void Welcome()
        {
            //Welcome player & asks name
            Console.WriteLine("What is thy name? ");
            playerName = Console.ReadLine();
            Console.Write("Welcome, " + playerName + "! \n");
        }

        bool Encounter(int monsterHealth, int monsterDamage)
        {
            //Monster Encounter
            Console.WriteLine("");
            Console.WriteLine("A Carbuncle blocks your way!");

            string action = "";
            bool survived = true;
            while (playerHealth > 0 && monsterHealth > 0)
            {

                Console.WriteLine("What is thy action? (fight/spell/flee) ");
                action = Console.ReadLine();
                if (action == "fight" || action == "Fight")
                {
                    survived = Fight(ref monsterHealth, ref monsterDamage);
                    if (!survived)
                    {
                        return false;
                    }
                }
                
                else if (action == "spell" || action == "Spell")
                {
                    survived = Spell(ref monsterHealth, ref monsterDamage);
                    if(!survived)
                    {
                        return false;
                    }
                }
                else if (action == "flee" || action == "Flee")
                {
                    survived = Flee();
                    if(survived)
                    {
                        return true;
                    }
                }
            }
            return survived;
        }
        bool Fight(ref int monsterHealth, ref int monsterDamage)
        {
            //monster attacks
            Console.WriteLine("The Carbuncle strikes!");
            Console.WriteLine(playerName + " takes " + monsterDamage + " damage!");
            playerHealth = playerHealth - monsterDamage;
            Console.WriteLine(playerName + " has " + playerHealth + " life remaining!");
            if (playerHealth <= 0)
            {
                //player defeat
                Console.WriteLine(playerName + " has fallen! The world is ruled by Darkness!");
                return false;
            }
            //player attacks
            Console.WriteLine(playerName + " strikes!");
            Console.WriteLine("The Carbuncle takes " + playerDamage + " damage!");
            monsterHealth -= playerDamage;
            Console.WriteLine("The Carbuncle has " + monsterHealth + " life remaining!");
            if (monsterHealth <= 0)
            {
                //monster defeat
                Console.WriteLine("The Carbuncle has been defeated!");
                playerExp = playerExp + 10;
                Console.WriteLine(playerName + " has gained 10 experience!");
                if (playerExp == playerExpMax)
                {
                    Console.WriteLine(playerName + " leveled up!");
                    playerLevel = playerLevel + 1;
                    playerExp = 0;
                    Console.WriteLine(playerName + " is now level " + playerLevel + "!");
                }
                return true;
            }
            return true;
        }       

        bool Flee()
        {
            //escape
            Console.WriteLine(playerName + " managed to escape!");
            return true;
        }

        bool Spell(ref int monsterHealth, ref int monsterDamage)
        {
            //monster attacks
            Console.WriteLine("The Carbuncle strikes!");
            Console.WriteLine(playerName + " takes " + monsterDamage + " damage!");
            playerHealth = playerHealth - monsterDamage;
            Console.WriteLine(playerName + " has " + playerHealth + " life remaining!");
            if (playerHealth <= 0)

            {
                //player defeat
                Console.WriteLine(playerName + " has fallen! The world is ruled by Darkness!");
                return false;

            }
            //player chooses spell
            string spellAction = "";
            Console.WriteLine("Which spell do you cast? (fire/ice/thunder/heal)");
            spellAction = Console.ReadLine();
            //player uses spell
            if (spellAction == "fire" || spellAction == "Fire")
            {
                Console.WriteLine(playerName + " casts fire!");
                if (playerMana > playerManaMin)
                {
                    Console.WriteLine("The Carbuncle takes " + fireDamage + " damage!");
                    monsterHealth -= fireDamage;
                    Console.WriteLine("The Carbuncle has " + monsterHealth + " life remaining!");
                    playerMana = playerMana - 5;
                    if (monsterHealth <= 0)
                    {
                        //monster defeat
                        Console.WriteLine("The Carbuncle has been defeated!");
                        playerExp = playerExp + 10;
                        Console.WriteLine(playerName + " has gained 10 experience!");
                        if (playerExp == playerExpMax)
                        {
                            Console.WriteLine(playerName + " leveled up!");
                            playerLevel = playerLevel + 1;
                            playerExp = 0;
                            Console.WriteLine(playerName + " is now level " + playerLevel + "!");
                        }
                        return true;
                    }
                
                }
                else if (playerMana <= playerManaMin)
                {
                    Console.WriteLine("The spell fizzles!");
                }
            }
            else if (spellAction == "ice" || spellAction == "Ice")
            {
                Console.WriteLine(playerName + " casts ice!");
                if (playerMana > playerManaMin)
                {
                    Console.WriteLine("The Carbuncle takes " + iceDamage + " damage!");
                    monsterHealth -= iceDamage;
                    Console.WriteLine("The Carbuncle has " + monsterHealth + " life remaining!");
                    playerMana = playerMana - 10;
                    if (monsterHealth <= 0)
                    {
                        //monster defeat
                        Console.WriteLine("The Carbuncle has been defeated!");
                        playerExp = playerExp + 10;
                        Console.WriteLine(playerName + " has gained 10 experience!");
                        if (playerExp == playerExpMax)
                        {
                            Console.WriteLine(playerName + " leveled up!");
                            playerLevel = playerLevel + 1;
                            playerExp = 0;
                            Console.WriteLine(playerName + " is now level " + playerLevel + "!");
                        }
                        return true;
                    }
                }
                else if (playerMana <= playerManaMin)
                {
                    Console.WriteLine("The spell fizzles!");
                }
            }
            else if (spellAction == "thunder" || spellAction == "Thunder")
            {
                Console.WriteLine(playerName + " casts thunder!");
                if (playerMana > playerManaMin)
                {
                    Console.WriteLine("The Carbuncle takes " + thunderDamage + " damage!");
                    monsterHealth -= thunderDamage;
                    Console.WriteLine("The Carbuncle has " + monsterHealth + " life remaining!");
                    playerMana = playerMana - 15;
                    if (monsterHealth <= 0)
                    {
                        //monster defeat
                        Console.WriteLine("The Carbuncle has been defeated!");
                        playerExp = playerExp + 10;
                        Console.WriteLine(playerName + " has gained 10 experience!");
                        if (playerExp == playerExpMax)
                        {
                            Console.WriteLine(playerName + " leveled up!");
                            playerLevel = playerLevel + 1;
                            playerExp = 0;
                            Console.WriteLine(playerName + " is now level " + playerLevel + "!");
                        }
                        return true;
                    }
                }
                else if (playerMana <= playerManaMin)
                {
                    Console.WriteLine("The spell fizzles!");
                }
               
            } 
            else if (spellAction == "heal" || spellAction == "Heal")
            {
                Console.WriteLine(playerName + " casts heal!");
                if (playerHealth > 0 && playerHealth < playerMaxHealth)
                {
                    playerHealth = playerHealth + healDamage;
                    Console.WriteLine(playerName + " has restored " + healDamage + " health!");
                    Console.WriteLine(playerName + " now has " + playerHealth + " life reamining!");
                    playerMana = playerMana - 25;
                }
                else if (playerHealth <= 0 || playerHealth >= playerMaxHealth)
                {
                    Console.WriteLine(playerName + "'s spell fizzles!");
                    playerMana = playerMana - 25;
                }
            }         
            return true;
        }
    }
}
