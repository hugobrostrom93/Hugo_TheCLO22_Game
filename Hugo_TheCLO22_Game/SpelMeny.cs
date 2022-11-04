using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Hugo_TheCLO22_Game
{
    internal class SpelMeny
    {
        Player newPlayer;
        Random random;
        MummieMonster mummieMonster;
        SkeletonMonster skeletonMonster;
        KnightMonster knightMonster;
        Bowser bowser;

        public SpelMeny()
        {
            newPlayer = new Player();
            random = new Random();
            mummieMonster = new MummieMonster();
            skeletonMonster = new SkeletonMonster();
            knightMonster = new KnightMonster();
            bowser = new Bowser();
        }
        public static void introText()
        {
            Console.WriteLine("+---------------------------+");
            Console.WriteLine("+ Welcome to The CLO22 Game +");
            Console.WriteLine("+---------------------------+");
            GetName.EnterName();
            Console.WriteLine("");
        }

        // Metod för att få upp spel menyn och "starta spelet"
        public void GameMenuuu()
        {
            while (true)
            {
                Console.WriteLine("1. Go adventuring");
                Console.WriteLine("2. Show details about your character");
                Console.WriteLine("3. Go to shop");
                Console.WriteLine("4. Exit game");
                Console.Write("> ");

                string selection = Console.ReadLine();

                // Skapar ett random nummer mellan 1-10
                int randomNum = random.Next(1, 11);
                // Om nummret är mellan 2-10 så möter vi ett monster
                if (randomNum == 2 || randomNum == 3 || randomNum == 4 || randomNum == 5 || randomNum == 6 || randomNum == 7 || randomNum == 8 || randomNum == 9 || randomNum == 10)
                {
                    while (selection == "1")
                    {
                        if (!newPlayer.IsDead && !mummieMonster.IsDead)
                        {
                            // skapar en spel loop med mummie monster
                            GameLoopen.GameLoopie(mummieMonster, newPlayer, 50, 100, random.Next(100, 200));
                        }
                        // Om spelaren överlever mot mummie
                        if (!newPlayer.IsDead && mummieMonster.IsDead)
                        {
                            // skapar en spel loop med skelett
                            GameLoopen.GameLoopie(skeletonMonster, newPlayer, 25, 50, random.Next(200, 300));
                            // om spelaren överlever mot skelett
                        }
                        if (!newPlayer.IsDead && skeletonMonster.IsDead)
                        {
                            // skapar en spel loop med knight
                            GameLoopen.GameLoopie(knightMonster, newPlayer, 25, 30, random.Next(300, 400));
                        }
                        if (!newPlayer.IsDead && knightMonster.IsDead)
                        {
                            // skapar en spel loop med bowser
                            GameLoopen.GameLoopie(bowser, newPlayer, 15, 55, random.Next(400, 500));
                        }

                    }
                    if (selection == "2")
                    {
                        VisaStats.ShowDetailss();
                    }
                    if (selection == "3")
                    {
                        Shoppen.Shopp();
                    }
                    // Om man skriver in ngt annat än 1-4 
                    if (selection != "1" && selection != "2" && selection != "3" && selection != "4")
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Please enter: 1, 2, 3 or 4");
                        Console.WriteLine("");
                    }
                    // Avsluta programmet 
                    if (selection == "4")
                    {
                        Environment.Exit(0);
                    }
                }
                else // Om nummret blir 1 och vi inte möter ett monster (10% chans)
                {
                    EnterFunktion.EnterContinue();
                }
            }
        }
    }
}
