using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hugo_TheCLO22_Game
{
    internal static class GetName
    {
        public static string name = "";
        public static void EnterName()
        {
            Logic spelMeny = new Logic();
            //Player newPlayer = new Player();
            Console.Write("Please enter your name: ");
            name = Console.ReadLine();
            Console.WriteLine("");
            spelMeny.GameMenu();
        }   
    }
}
