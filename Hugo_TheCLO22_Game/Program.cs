using Hugo_TheCLO22_Game;
using System;
using static System.Net.Mime.MediaTypeNames;

namespace The_CLO22_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StartGame();
            Console.WriteLine("");
            GameMenu();
        }

        static void StartGame()
        {
            Console.WriteLine("+---------------------------+");
            Console.WriteLine("+ Welcome to The CLO22 Game +");
            Console.WriteLine("+---------------------------+");
            Console.Write("Enter your name: ");
            string playerName = Console.ReadLine();            
        }

        static void GameMenu()
        {            
            while (true)
            {
                Console.WriteLine("1. Go adventuring");
                Console.WriteLine("2. Show details about your character");
                Console.WriteLine("3. Exit game");
                Console.Write("> ");
                string selection = Console.ReadLine(); // Gör så man måste välja ett tal melan 1 - 3 endast

                if (selection == "1")
                {
                    Console.WriteLine("");
                    GoAdventuring();
                    break;
                }
                if (selection == "2")
                {
                    ShowDetails();
                }
                if (selection == "3")
                {
                    GameMenuThree();
                }
            } 
        }

        static void GoAdventuring()
        {
            Player newPlayer = new Player(); // Skapa nytt objekt av vår klass Player
            MummieMonster mummieMonster = new MummieMonster();
            SkeletonMonster skeletonMonster = new SkeletonMonster();
            KnightMonster knightMonster = new KnightMonster();

            newPlayer.hp = 500;
            newPlayer.exp = 0;
            newPlayer.toughness = 5;
            newPlayer.strength = 50;

            mummieMonster.name = "Hully the Mummie";
            mummieMonster.hp = 100;
            mummieMonster.exp = 100;

            skeletonMonster.name = "Krok the Skeleton King";
            skeletonMonster.hp = 200;
            skeletonMonster.exp = 200;

            knightMonster.name = "Aegon the Great Knight";
            knightMonster.hp = 300;
            knightMonster.exp = 400;

            void Attack(int dmg)
            {
                Random random = new Random();
                int damage = random.Next(newPlayer.strength, newPlayer.strength * 2);
            }

            Random random = new Random();
            int randomNum = random.Next(1, 11);

            if (randomNum == 2 || randomNum == 3 || randomNum == 4 || randomNum == 5 || randomNum == 6 || randomNum == 7 || randomNum == 9 || randomNum == 9 || randomNum == 10)
            {
                int randomMonster = random.Next(1, 4);
                if (randomMonster == 1)
                Console.WriteLine("Uh oh! The mummy 'Hully the Mummie' appeared!");
                Console.WriteLine("You hit the monster, dealing " + dmg);

                
                


                if (randomMonster == 2)
                Console.WriteLine("Uh oh! The skeleton 'Krok the Skeleton King' appeared!");


                if (randomMonster == 3)
                Console.WriteLine("Uh oh! The knight 'Aegon the Great Knight' appeared!");

            }
            else
            {
                Console.WriteLine("You see nothing but swaing grass all around you...");
                Console.WriteLine("[Press Enter to continue]");
            }
        }

        static void ShowDetails()
        {
            Console.WriteLine("");
            Console.WriteLine("**********");
            Console.WriteLine("Name: ");
            Console.WriteLine("Level: ");
            Console.WriteLine("Hp: ");
            Console.WriteLine("Exp: ");
            Console.WriteLine("Gold: ");
            Console.WriteLine("Strength: ");
            Console.WriteLine("Toughness: ");
            Console.WriteLine("**********");
            Console.WriteLine("");
        }

        static void GameMenuThree()
        {

        }

    }
}