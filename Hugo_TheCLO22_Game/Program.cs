using Hugo_TheCLO22_Game;
using System;
using System.Numerics;
using static System.Net.Mime.MediaTypeNames;

namespace Area_Kalkylator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player newPlayer = new Player(); // Skapa objekt av våra klasser
            MummieMonster mummieMonster = new MummieMonster();
            SkeletonMonster skeletonMonster = new SkeletonMonster();
            KnightMonster knightMonster = new KnightMonster();
            Bowser bowser = new Bowser();
            Monster monster = new Monster();
            Random random = new Random();
            int shopNum = 0; // Min lösning för att göra så att shoppen visas efter varje dödat monster

            Console.WriteLine("+---------------------------+");
            Console.WriteLine("+ Welcome to The CLO22 Game +");
            Console.WriteLine("+---------------------------+");
            Console.Write("Enter your name: ");
            newPlayer.name = Console.ReadLine();
            Console.WriteLine("");

            GameMenu();

            // En metod för att möta ett monster där vi har olika parametrar som krävs för spelet
            // Monster objekt, Spelare objekt, minsta attack power för monster, max attack power för monster, random guldvärde vid dödat monster
            void GameLoop(Monster monster, Player player, int min_enemy_attack_power, int max_enemy_attack_power, int lootGold)
            {
                // Metoden som gör så att menyn visas efter monster X har dött och menyn har visats X gånger 
                MenyEfterStrid(mummieMonster, 0);
                MenyEfterStrid(skeletonMonster, 1);
                MenyEfterStrid(knightMonster, 2);

                // Om det är spelarens första attack mot ett monster som lever och även sista bossen lever skriver vi ut nedan för att introducera fighten
                if (player.numAttack == 0 && !bowser.IsDead && !monster.IsDead)
                {
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
                        Console.WriteLine(player.name + ": " + player.hp + "hp");
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
                        player.gold += lootGold;
                        player.exp += monster.exp;
                        Console.WriteLine("You killed the monster gaining " + monster.exp + " experience and " + lootGold + " gold");
                        player.LevelUp();
                        Console.WriteLine("You are level " + player.level + ", and you have " + player.exp + " experience, " + player.hp + " hp and " + player.gold + " gold");
                    }

                    // Om spelaren dör
                    if (player.IsDead)
                    {
                        Console.WriteLine("You were killed by the monster and lost the game..");
                        break;
                    }

                    // Om spelaren blir lvl 10
                    if (player.level >= 10)
                    {
                        Console.WriteLine("Congratulations! You won the game!");
                        newPlayer.numAttack = 10; // så att den inte loopar om igen - kommer ej på hur jag förhindrar detta i metoden istället
                        break;
                    }

                    // Om sista bossen dör
                    if (bowser.IsDead)
                    {
                        Console.WriteLine("Congratulations " + player.name + " you defeted all the enemies and have won the game!");
                        break;
                    }

                    // Om sista bossen och spelaren fortfarande lever så fortsätter vi
                    if (!bowser.IsDead && !player.IsDead)
                    {
                        // Fråga spelaren att fortsätta
                        EnterContinue();
                    }
                }
            }

            void GameMenu()
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
                                GameLoop(mummieMonster, newPlayer, 45, 5, random.Next(100, 200));
                            }
                            // Om spelaren överlever mot mummie
                            if (!newPlayer.IsDead && mummieMonster.IsDead)
                            {
                                // skapar en spel loop med skelett
                                GameLoop(skeletonMonster, newPlayer, 55, 10, random.Next(200, 300));
                                // om spelaren överlever mot skelett
                            }
                            if (!newPlayer.IsDead && skeletonMonster.IsDead)
                            {
                                // skapar en spel loop med knight
                                GameLoop(knightMonster, newPlayer, 65, 20, random.Next(300, 400));
                            }
                            if (!newPlayer.IsDead && knightMonster.IsDead)
                            {
                                // skapar en spel loop med bowser
                                GameLoop(bowser, newPlayer, 75, 20, random.Next(400, 500));
                            }

                        }
                        if (selection == "2")
                        {
                            ShowDetails();
                        }
                        if (selection == "3")
                        {
                            Shop();
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
                        EnterContinue();
                    }
                }
            }

            // Min metod för Enter funktionen
            void EnterContinue()
            {
                while (true)
                {
                    Console.WriteLine("Press Enter to continue: ");
                    string key = Console.ReadKey().Key.ToString();

                    if (key.ToUpper() == "ENTER")
                    {
                        Console.WriteLine("");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("");
                    }
                }
            }

            // Metod för mitt Shop System
            void Shop()
            {
                while (true)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Welcome to the shop! What would you like to buy?");
                    Console.WriteLine("1. Attack Amulet ( +5 Strength ) - 100 gold");
                    Console.WriteLine("2. Defence Amulet ( +2 Toughness ) - 100 gold");
                    Console.WriteLine("3. XP Potion ( +300 Exp ) - 400 gold");
                    Console.WriteLine("4. HP Potion ( +50 Hp ) - 250 gold");
                    Console.WriteLine("E. Exit shop");
                    Console.Write("> ");
                    string shopItem = Console.ReadLine().ToUpper();
                    Console.WriteLine("");

                    // Om vi har mer eller lika med 100 guld kan vi köpa nedan
                    if (shopItem == "1" && newPlayer.gold >= 100)
                    {
                        // Ger oss stats och - guld
                        Console.WriteLine("You bought an 'Attack Amulet' and you can feel the power!");
                        newPlayer.strength += 5;
                        newPlayer.gold = newPlayer.gold - 100;
                        Console.WriteLine("You have " + newPlayer.gold + " gold");
                    }
                    // Om vi har mer eller lika med 100 guld kan vi köpa nedan
                    if (shopItem == "2" && newPlayer.gold >= 100)
                    {
                        // Ger oss stats och - guld
                        Console.WriteLine("You bought an 'Defence Amulet' and you can feel the power!");
                        newPlayer.toughness += 2;
                        newPlayer.gold -= 100;
                        Console.WriteLine("You have " + newPlayer.gold + " gold");
                    }
                    // Om vi har mer eller lika med 400 guld kan vi köpa nedan
                    if (shopItem == "3" && newPlayer.gold >= 400)
                    {
                        // Ger oss stats och - guld
                        Console.WriteLine("You bought an 'XP Potion' and you can feel the power!");
                        newPlayer.exp += 300; // öka min xp med 300
                        newPlayer.level += 2; // ge mig +2 levels för min LevelUp läser inte in rätt annars
                        newPlayer.gold -= 400; // ge mig minus guld
                        Console.WriteLine("You have " + newPlayer.gold + " gold");
                        newPlayer.LevelUp(); // spela upp LevelUp metoden
                        Console.WriteLine("");
                        newPlayer.exp -= 200; // ge mig - 200 exp eftersom jag ökade mina lvls med 2
                        break;
                    }
                    // Om vi har mer eller lika med 250 guld kan vi köpa nedan
                    if (shopItem == "4" && newPlayer.gold >= 250)
                    {
                        // Ger oss stats och - guld
                        Console.WriteLine("You bought an 'HP Potion' and you gained 50 hp!");
                        newPlayer.hp += 50; // öka min xp med 300
                        newPlayer.gold -= 250;
                        if (newPlayer.hp >= 100)
                        {
                            newPlayer.hp = 100;
                        }
                        Console.WriteLine("You now have " + newPlayer.hp + "/100 hp");
                        Console.WriteLine("You now have " + newPlayer.gold + " gold left");
                        Console.WriteLine("");
                        break;
                    }
                    // Öppna menyn igen
                    if (shopItem == "E")
                    {
                        GameMenu();
                    }
                    // Om man försöker köpa 1 eller 2 men inte tillräckligt med guld
                    if ((shopItem == "1" || shopItem == "2") && newPlayer.gold <= 100)
                    {
                        Console.WriteLine("You don't have enough gold");
                    }
                    // Om man försöker köpa XP Potion men inte tillräckligt med guld
                    if ((shopItem == "3") && newPlayer.gold <= 400)
                    {
                        Console.WriteLine("You don't have enough gold");
                    }
                    // Om man försöker köpa HP Potion men inte tillräckligt med guld
                    if ((shopItem == "4") && newPlayer.gold <= 250)
                    {
                        Console.WriteLine("You don't have enough gold");
                    }
                    if (shopItem != "1" && shopItem != "2" && shopItem != "3" && shopItem != "E")
                    {
                        Console.WriteLine("Please enter: 1, 2, 3 or E");
                    }
                }
            }

            // En metod för att visa vår statistik i spelet 
            void ShowDetails()
            {
                Console.WriteLine("");
                Console.WriteLine("**********");
                Console.WriteLine("Name: " + newPlayer.name);
                Console.WriteLine("Level: " + newPlayer.level + "/10");
                Console.WriteLine("Exp: " + newPlayer.exp + "/100");
                Console.WriteLine("Hp: " + newPlayer.hp + "/500");
                Console.WriteLine("Gold: " + newPlayer.gold + " gold");
                Console.WriteLine("Strength: " + newPlayer.strength);
                Console.WriteLine("Toughness: " + newPlayer.strength);
                Console.WriteLine("**********");
                Console.WriteLine("");
            }

            // En metod så menyn kommer upp efter att vi har dödat ett monster 
            // Tar in en paramenter om monstret lever och shop nummer vilket är min egna lösning så att de visas när jag vill
            void MenyEfterStrid(Monster monster, int a)
            {
                if (newPlayer.numAttack == 0 && !bowser.IsDead && monster.IsDead && shopNum == a)
                {
                    shopNum++;
                    GameMenu();
                }
            }
        }
    }
}