using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hugo_TheCLO22_Game
{
    internal class SkeletonMonster : Monster
    {
        /// <summary>
        /// Konstruktor för vårt skeleton monster
        /// </summary>
        public SkeletonMonster()
        {
            hp = 100;
            exp = 85;
            name = "Krok the Skeleton King";
        }
    }
}