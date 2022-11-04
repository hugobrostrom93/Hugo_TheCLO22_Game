using Hugo_TheCLO22_Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hugo_TheCLO22_Game
{
    internal class Game
    {
        public static void StartGame()
        {
            SpelMeny spelMeny = new SpelMeny();
            SpelMeny.introText();
        }        
    }
}