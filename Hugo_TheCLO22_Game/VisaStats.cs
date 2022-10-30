using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hugo_TheCLO22_Game
{
    internal class VisaStats
    {
        public void ShowDetailss()
        {
            Player newPlayer = new Player();

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
    }
}
