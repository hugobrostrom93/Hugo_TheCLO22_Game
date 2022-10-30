using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Hugo_TheCLO22_Game
{
    public class Bowser : Monster
    {
        /// <summary>
        /// Konstruktor för vår bowser monster
        /// </summary>
        public Bowser()
        {
            hp = 100;
            exp = 95;
            name = "Bowser the furious";
        }
    }
}