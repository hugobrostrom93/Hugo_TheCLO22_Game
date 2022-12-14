using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace Hugo_TheCLO22_Game
{
    internal class Player
    {
        /// <summary>
        /// Namnet på spelaren
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// Spelaren level
        /// </summary>
        public int level { get; set; }
        /// <summary>
        /// Spelaren experience
        /// </summary>
        public int exp { get; set; }
        /// <summary>
        /// Spelarens health
        /// </summary>
        //public int hp { get; set; }
        /// <summary>
        /// Om spelaren lever 
        /// </summary>
        public bool IsDead { get; set; }
        /// <summary>
        /// Hur mycket guld spelaren har
        /// </summary>
        public int gold { get; set; }
        /// <summary>
        /// En siffra för att hålla koll på om det är första attacken mot ett monster
        /// </summary>
        public int numAttack { get; set; }

        /// <summary>
        /// Hur mycket strength spelaren har. Desto mer strength, desto mer skadar man
        /// </summary>
        public int strength { get; set; }
        /// <summary>
        /// Hur mycket toughtness spelaren har. Desto mer toughness, desto mer blockar man skada från monster
        /// </summary>
        public int toughness { get; set; }

        //public Player()
        //{
        //    name = GetName.name;
        //}

        /// <summary>
        /// En metod som gör att spelaren levlar upp vid varje 100 exp uppnådd. När spelaren når 100 exp får den därefter - 100 exp
        /// </summary>
        public void LevelUp() 
        {
            if (PlayerStats.exp >= 100)
            {
                PlayerStats.level++;
                PlayerStats.exp -= 100;
                Console.WriteLine("You leveled up, and are now level " + PlayerStats.level + "!");
            }
        }

        /// <summary>
        /// Metod för när spelaren attackerar. Skadan är ett tal mellan strength och strength * 2
        /// </summary>
        /// <param name="a">tal 1 (strength)</param>
        /// <param name="b">tal 2 (strength) som gångras med 2</param>
        /// <returns></returns>
        public int Attack(int a, int b)
        {
            numAttack++;
            Random random = new Random();
            int damage = random.Next(PlayerStats.strength, PlayerStats.strength * 2);
            return damage;
        }

        /// <summary>
        /// Metod för när spelaren blir träffad och tar skada och får - i toughness
        /// </summary>
        /// <param name="hit_value">skada från monstret</param>
        public void GetsHit(int hit_value)
        {
            PlayerStats.hp = PlayerStats.hp - hit_value + PlayerStats.toughness;
            //hp = hp - hit_value + toughness; // antar man kan skriva: hp -= hit_value + toughness;
            PlayerStats.toughness--;
            Console.WriteLine("The monster hits you dealing " + (hit_value - PlayerStats.toughness - 1) + " damage!");
            Console.WriteLine("You blocked " + PlayerStats.toughness + " damage with your toughness!");
            Console.WriteLine("*** Kapaoooww ***");

            if (PlayerStats.hp <= 0)
            {
                Die();
            }
        }

        /// <summary>
        /// Om vi får <= 0 i hp så dör vi och IsDead = true och vi skriver det till konsollen 
        /// </summary>
        public void Die()
        {
            Console.WriteLine(GetName.name + " has died!");
            IsDead = true;
        }
    }
}