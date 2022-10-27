using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hugo_TheCLO22_Game
{
    internal class Monster
    {
        /// <summary>
        /// Namnet på monstret
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// Om monstret är dött
        /// </summary>
        public bool IsDead { get; set; }
        /// <summary>
        /// Monstret health
        /// </summary>
        public int hp { get; set; }
        /// <summary>
        /// Monstrets experience
        /// </summary>
        public int exp { get; set; }

        /// <summary>
        /// Metod för när monstret blir träffad och tar skada 
        /// </summary>
        /// <param name="hit_value">Skadan från spelaren</param>
        public void GetsHit(int hit_value)
        {
            hp = hp - hit_value; // blir fel om jag skriver hp -= hit_value?

            Console.WriteLine("You hit the monster dealing " + hit_value + " damage!");
            Console.WriteLine("*** Swooosh ***");
            // Console.WriteLine(name + " was hit for " + hit_value + " damage! He now have " + hp + " hp left");

            if (hp <= 0)
            {
                Die();
            }
        }

        /// <summary>
        /// Om monstret får <= 0 i hp så dör den och IsDead = true och vi skriver det till konsollen 
        /// </summary>
        public void Die()
        {
            Console.WriteLine(name + " has died!");
            IsDead = true;
        }
    }
}
