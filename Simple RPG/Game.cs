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
        int playerMana = 100;
        int playerExp = 0;
        public void Start()
        {

            Welcome();

            int monsterRemaining = 5;

            bool alive = true;

            while(alive && monsterRemaining > 0)
            {
                Console.WriteLine("There are " + monsterRemaining + " Carbuncles remaining.");
                alive = Encounter(15);
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

        bool Encounter(int monsterDamage)
        {
            //Monster Encounter
            Console.WriteLine("");
            Console.WriteLine("A Carbuncle blocks your way!");

            string action = "";
            Console.WriteLine("What is thy action? (fight/spell/flee) ");
            action = Console.ReadLine();
            if (action == "fight" || action == "Fight")
            {
                //monster attacks
                Console.WriteLine("The Carbuncle strikes!");
                Console.WriteLine(playerName + " takes " + monsterDamage + " damage!");
                playerHealth = playerHealth - monsterDamage;
                Console.WriteLine(playerName + " has " + playerHealth + " life remaining");
                if (playerHealth <= 0)
                {
                    //player defear
                    Console.WriteLine(playerName + " has fallen! The world is ruled be Darkness!");
                    return false;
                }
                //player attacks
                Console.WriteLine(playerName + " strikes!");
                Console.WriteLine("The Carbuncle is defeated!");
                playerExp = playerExp + 10;
                Console.WriteLine(playerName + " gained 10 experience!");

            }
            else if (action == "spell" || action == "Spell")
            {
                //monster attacks
                Console.WriteLine("The Carbuncle strikes!");
                Console.WriteLine(playerName + " takes " + monsterDamage + " damage!");
                playerHealth = playerHealth - monsterDamage;
                Console.WriteLine(playerName + "has " + playerHealth + " life remaining");
                //player uses spell
                Console.WriteLine(playerName + " casts Fire!");
                playerMana = playerMana - 5;
                Console.WriteLine("The Carbuncle is defeated!");
                playerExp = playerExp + 10;
                Console.WriteLine(playerName + " gained 10 experience!");
            }
            else if (action == "flee" || action == "Flee")
            {

                //escape
                Console.WriteLine(playerName + " managed to escape!");
            }
            return true;
        }
    }
}
