using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hugo_TheCLO22_Game
{
    internal class MenynEfterStrid
    {
        Player newPlayer;
        Bowser bowser;
        SpelMeny spelMeny;
        int shopNum = 0;
        public MenynEfterStrid()
        {
            newPlayer = new Player();
            bowser = new Bowser();
            spelMeny = new SpelMeny();
        }
        public void MenyEfterStrid(Monster monster, int a)
        {
            if (newPlayer.numAttack == 0 && !bowser.IsDead && monster.IsDead && shopNum == a)
            {
                shopNum++;
                spelMeny.GameMenuuu();
            }
        }
    }
}
