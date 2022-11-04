using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hugo_TheCLO22_Game
{
    internal static class VisaStats
    {
        public static void ShowDetailss()
        {
            Console.WriteLine("");
            Console.WriteLine("**********");
            Console.WriteLine("Name: " + GetName.name);
            Console.WriteLine("Level: " + PlayerStats.level + "/10");
            Console.WriteLine("Exp: " + PlayerStats.exp + "/100");
            Console.WriteLine("Hp: " + PlayerStats.hp + "/500");
            Console.WriteLine("Gold: " + PlayerStats.gold + " gold");
            Console.WriteLine("Strength: " + PlayerStats.strength);
            Console.WriteLine("Toughness: " + PlayerStats.strength);
            Console.WriteLine("**********");
            Console.WriteLine("");
        }
    }
}
