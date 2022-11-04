using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hugo_TheCLO22_Game
{
    internal static class EnterFunktion
    {
        public static void EnterContinue()
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
    }
}
