using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Hugo_TheCLO22_Game
{
    public class SpelMeny
    {
        Random random = new Random();
        Player newPlayer = new Player(); // Skapa objekt av våra klasser
        MummieMonster mummieMonster = new MummieMonster();
        SkeletonMonster skeletonMonster = new SkeletonMonster();
        KnightMonster knightMonster = new KnightMonster();
        Bowser bowser = new Bowser();
        EnterFunktion enterFunktion = new EnterFunktion();
        GameLoopen gameLoopen = new GameLoopen();
        VisaStats visaStats = new VisaStats();
        Shoppen shoppen = new Shoppen();
        Player player = new Player();

        public void introText()
        {
            Console.WriteLine("+---------------------------+");
            Console.WriteLine("+ Welcome to The CLO22 Game +");
            Console.WriteLine("+---------------------------+");
            Console.Write("Enter your name: ");
            newPlayer.name = Console.ReadLine();
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
                            gameLoopen.GameLoopie(mummieMonster, newPlayer, 45, 5, random.Next(100, 200));
                        }
                        // Om spelaren överlever mot mummie
                        if (!newPlayer.IsDead && mummieMonster.IsDead)
                        {
                            // skapar en spel loop med skelett
                            gameLoopen.GameLoopie(skeletonMonster, newPlayer, 55, 10, random.Next(200, 300));
                            // om spelaren överlever mot skelett
                        }
                        if (!newPlayer.IsDead && skeletonMonster.IsDead)
                        {
                            // skapar en spel loop med knight
                            gameLoopen.GameLoopie(knightMonster, newPlayer, 65, 20, random.Next(300, 400));
                        }
                        if (!newPlayer.IsDead && knightMonster.IsDead)
                        {
                            // skapar en spel loop med bowser
                            gameLoopen.GameLoopie(bowser, newPlayer, 75, 20, random.Next(400, 500));
                        }

                    }
                    if (selection == "2")
                    {
                        visaStats.ShowDetailss();
                    }
                    if (selection == "3")
                    {
                        shoppen.Shopp();
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
                    enterFunktion.EnterContinue();
                }
            }
        }
        public void MenyEfterStrid(Monster monster, int a)
        {
            int shopNum = 0;

            if (player.numAttack == 0 && !bowser.IsDead && monster.IsDead && shopNum == a)
            {
                Console.WriteLine("awdawdd");
                shopNum++;
                GameMenuuu();
            }
        }
    }
}
