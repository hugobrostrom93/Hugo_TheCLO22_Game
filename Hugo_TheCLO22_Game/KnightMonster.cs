using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hugo_TheCLO22_Game
{
    public class KnightMonster : Monster
    {
        /// <summary>
        /// Konstruktor för vår knight monster
        /// </summary>
        public KnightMonster()
        {
            hp = 150;
            exp = 90; 
            name = "Aegon the Great Knight";
        }
    }
}