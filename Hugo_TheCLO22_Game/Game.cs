using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hugo_TheCLO22_Game
{
    internal class Game
    {
        public void StartGame()
        { 
            SpelMeny SpelMeny = new SpelMeny(); 
            SpelMeny.introText();
            SpelMeny.GameMenuuu();
        }        
    }
}
