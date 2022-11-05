using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hugo_TheCLO22_Game
{
    internal class Logic
    {
        Player newPlayer = new Player();
        Random random = new Random();
        MummieMonster mummieMonster = new MummieMonster();
        SkeletonMonster skeletonMonster = new SkeletonMonster();
        KnightMonster knightMonster = new KnightMonster();
        Bowser bowser = new Bowser();
        public int shopNum;

        //public Logic()
        //{
        //    Player newPlayer = new Player();
        //    Random random = new Random();
        //    MummieMonster mummieMonster = new MummieMonster();
        //    SkeletonMonster skeletonMonster = new SkeletonMonster();
        //    KnightMonster knightMonster = new KnightMonster();
        //    Bowser bowser = new Bowser();
        //    public int shopNum;
        //}

        public static void introText()
        {
            Console.WriteLine("+---------------------------+");
            Console.WriteLine("+ Welcome to The CLO22 Game +");
            Console.WriteLine("+---------------------------+");
            GetName.EnterName();
            Console.WriteLine("");
        }

        // Metod för att få upp spel menyn och "starta spelet"
        public void GameMenu()
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
                            GameLoop(mummieMonster, newPlayer, 50, 100, random.Next(100, 200));
                        }
                        // Om spelaren överlever mot mummie
                        if (!newPlayer.IsDead && mummieMonster.IsDead)
                        {
                            // skapar en spel loop med skelett
                            GameLoop(skeletonMonster, newPlayer, 25, 50, random.Next(200, 300));
                            // om spelaren överlever mot skelett
                        }
                        if (!newPlayer.IsDead && skeletonMonster.IsDead)
                        {
                            // skapar en spel loop med knight
                            GameLoop(knightMonster, newPlayer, 25, 30, random.Next(300, 400));
                        }
                        if (!newPlayer.IsDead && knightMonster.IsDead)
                        {
                            // skapar en spel loop med bowser
                            GameLoop(bowser, newPlayer, 15, 55, random.Next(400, 500));
                        }

                    }
                    if (selection == "2")
                    {
                        VisaStats.ShowDetails();
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
        public void GameLoop(Monster monster, Player player, int min_enemy_attack_power, int max_enemy_attack_power, int lootGold)
        {
            // Metoden som gör så att menyn visas efter monster X har dött och menyn har visats X gånger
            MenyEfterStrid(mummieMonster, 0);
            MenyEfterStrid(skeletonMonster, 1);
            MenyEfterStrid(knightMonster, 2);

            // Om det är spelarens första attack mot ett monster som lever och även sista bossen lever skriver vi ut nedan för att introducera fighten
            if (player.numAttack == 0 && !bowser.IsDead && !monster.IsDead)
            {
                Console.Clear();
                MonsterBildMetod(monster);
                Console.WriteLine("");
                Console.WriteLine("Uh oh! A wild " + monster.name + " appeared!");
            }

            while (!player.IsDead && !monster.IsDead)
            {
                // Spelaren attackerar om vi lever
                monster.GetsHit(player.Attack(player.strength, player.strength * 2));

                // Monstret attackerar om det lever
                if (!monster.IsDead)
                {
                    player.GetsHit(player.Attack(min_enemy_attack_power, max_enemy_attack_power));
                }

                // skiver ut hp för spelare om spelaren överlever
                if (!player.IsDead)
                {
                    Console.WriteLine(GetName.name + ": " + PlayerStats.hp + "hp");
                }

                // skriver ut hp för monster om monster överlever
                if (!monster.IsDead)
                {
                    // skriver ut hp för monster
                    Console.WriteLine(monster.name + ": " + monster.hp + "hp");
                }

                // Om monstret dör får vi nedan saker och stats skrivs ut 
                if (monster.IsDead)
                {
                    player.numAttack = 0;
                    PlayerStats.gold += lootGold;
                    PlayerStats.exp += monster.exp;
                    Console.WriteLine("You killed the monster gaining " + monster.exp + " experience and " + lootGold + " gold");
                    player.LevelUp();
                    Console.WriteLine("You are level " + PlayerStats.level + ", and you have " + PlayerStats.exp + " experience, " + PlayerStats.hp + " hp and " + PlayerStats.gold + " gold");
                    Console.WriteLine("");                    
                }

                // Om spelaren dör
                if (player.IsDead)
                {
                    Console.WriteLine("You were killed by the monster and lost the game..");
                    break;
                }

                // Om spelaren blir lvl 10
                if (PlayerStats.level >= 10)
                {
                    Console.WriteLine("Congratulations " + GetName.name + " You won the game!");
                    player.numAttack = 10; // så att den inte loopar om igen - kommer ej på hur jag förhindrar detta i metoden istället
                    break;
                }

                // Om sista bossen dör
                if (bowser.IsDead && !player.IsDead)
                {
                    Console.WriteLine("Congratulations " + GetName.name + " you defeted all the enemies and have won the game!");
                    break;
                }

                // Om sista bossen och spelaren fortfarande lever så fortsätter vi
                if (!bowser.IsDead && !player.IsDead && !monster.IsDead)
                {
                    // Fråga spelaren att fortsätta
                    EnterFunktion.EnterContinue();
                }
            }

            void MonsterBildMetod(Monster monsterI)
            {
                if (player.numAttack == 0 && !bowser.IsDead && !monster.IsDead && monster == monsterI)
                {
                    Console.WriteLine("");
                    MonsterBild(monsterI);
                    Console.WriteLine("");
                }
            }

            void MonsterBild(Monster monsterI)
            {
                // spongebob
                if (monsterI == mummieMonster)
                    MonsterBilder.MummieBild();
                // skeleton
                if (monsterI == skeletonMonster)
                    MonsterBilder.SkeletonBild();
                // homer
                if (monsterI == knightMonster)
                    MonsterBilder.HomerBild();
                // devil
                if (monsterI == bowser)
                    MonsterBilder.DevilBild();
            }
        }

        public void MenyEfterStrid(Monster monster, int a)
        {
            if (newPlayer.numAttack == 0 && !bowser.IsDead && monster.IsDead && shopNum == a)
            {
                shopNum++;
                GameMenu();
            }
        }
    }
}
