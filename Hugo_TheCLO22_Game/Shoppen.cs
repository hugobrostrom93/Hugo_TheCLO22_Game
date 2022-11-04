using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hugo_TheCLO22_Game
{
    internal class Shoppen
    {        
        public static void Shopp()
        {
            Console.Clear();
            Player player = new Player();
            Logic spelMeny = new Logic();

            while (true)
            {                
                Console.WriteLine("Welcome to the shop " + GetName.name.ToUpper() + "! What would you like to buy?");
                Console.WriteLine("+----------- YOU HAVE " + PlayerStats.gold + " GOLD AVAILABLE ------------+");
                Console.WriteLine("");
                Console.WriteLine("1. Attack Amulet ( +5 Strength ) - 100 gold");
                Console.WriteLine("2. Defence Amulet ( +2 Toughness ) - 100 gold");
                Console.WriteLine("3. XP Potion ( +300 Exp ) - 400 gold");
                Console.WriteLine("4. HP Potion ( +50 Hp ) - 250 gold");
                Console.WriteLine("E. Exit shop");
                Console.Write("> ");
                string shopItem = Console.ReadLine().ToUpper();
                Console.WriteLine("");

                // Om vi har mer eller lika med 100 guld kan vi köpa nedan
                if (shopItem == "1" && PlayerStats.gold >= 100)
                {
                    // Ger oss stats och - guld
                    Console.WriteLine("You bought an 'Attack Amulet' and you can feel the power!");
                    PlayerStats.strength += 5;
                    PlayerStats.gold -= 100;
                    Console.WriteLine("You have " + PlayerStats.gold + " gold");
                }
                // Om vi har mer eller lika med 100 guld kan vi köpa nedan
                if (shopItem == "2" && PlayerStats.gold >= 100)
                {
                    // Ger oss stats och - guld
                    Console.WriteLine("You bought an 'Defence Amulet' and you can feel the power!");
                    PlayerStats.toughness += 2;
                    PlayerStats.gold -= 100;
                    Console.WriteLine("You have " + PlayerStats.gold + " gold");
                }
                // Om vi har mer eller lika med 400 guld kan vi köpa nedan
                if (shopItem == "3" && PlayerStats.gold >= 400)
                {
                    // Ger oss stats och - guld
                    Console.WriteLine("You bought an 'XP Potion' and you can feel the power!");
                    PlayerStats.exp += 300; // öka min xp med 300
                    PlayerStats.level += 2; // ge mig +2 levels för min LevelUp läser inte in rätt annars
                    PlayerStats.gold -= 400; // ge mig minus guld
                    Console.WriteLine("You have " + PlayerStats.gold + " gold");
                    player.LevelUp(); // spela upp LevelUp metoden
                    Console.WriteLine("");
                    PlayerStats.exp -= 200; // ge mig - 200 exp eftersom jag ökade mina lvls med 2
                    break;
                }
                // Om vi har mer eller lika med 250 guld kan vi köpa nedan
                if (shopItem == "4" && PlayerStats.gold >= 250)
                {
                    // Ger oss stats och - guld
                    Console.WriteLine("You bought an 'HP Potion' and you gained 50 hp!");
                    PlayerStats.hp += 50; // öka min xp med 300
                    PlayerStats.gold -= 250;
                    if (PlayerStats.hp >= 100)
                    {
                        PlayerStats.hp = 100;
                    }
                    Console.WriteLine("You now have " + PlayerStats.hp + "/100 hp");
                    Console.WriteLine("You now have " + PlayerStats.gold + " gold left");
                    Console.WriteLine("");
                    break;
                }
                // Öppna menyn igen
                if (shopItem == "E")
                {
                    Console.Clear();
                    spelMeny.GameMenu();
                }
                // Om man försöker köpa 1 eller 2 men inte tillräckligt med guld
                if ((shopItem == "1" || shopItem == "2") && PlayerStats.gold <= 100)
                {
                    Console.WriteLine("You don't have enough gold");
                }
                // Om man försöker köpa XP Potion men inte tillräckligt med guld
                if ((shopItem == "3") && PlayerStats.gold <= 400)
                {
                    Console.WriteLine("You don't have enough gold");
                }
                // Om man försöker köpa HP Potion men inte tillräckligt med guld
                if ((shopItem == "4") && PlayerStats.gold <= 250)
                {
                    Console.WriteLine("You don't have enough gold");
                }
                if (shopItem != "1" && shopItem != "2" && shopItem != "3" && shopItem != "E")
                {
                    Console.WriteLine("Please enter: 1, 2, 3 or E");
                }
            }
        }
    }
}
