using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Hugo_TheCLO22_Game
{
    internal class GameLoopen
    {
        MummieMonster mummieMonster = new MummieMonster();
        SkeletonMonster skeletonMonster = new SkeletonMonster();
        KnightMonster knightMonster = new KnightMonster();
        Bowser bowser = new Bowser();
        EnterFunktion enterFunktion = new EnterFunktion();
        SpelMeny spelMeny = new SpelMeny();

        public void GameLoopie(Monster monster, Player player, int min_enemy_attack_power, int max_enemy_attack_power, int lootGold)
        {
            // Metoden som gör så att menyn visas efter monster X har dött och menyn har visats X gånger 
            spelMeny.MenyEfterStrid(mummieMonster, 0);
            spelMeny.MenyEfterStrid(skeletonMonster, 1);
            spelMeny.MenyEfterStrid(knightMonster, 2);

            // Om det är spelarens första attack mot ett monster som lever och även sista bossen lever skriver vi ut nedan för att introducera fighten
            if (player.numAttack == 0 && !bowser.IsDead && !monster.IsDead)
            {
                Console.WriteLine("");
                Console.WriteLine("Uh oh! A wild " + monster.name + " appeared!");
            }

            while (!player.IsDead && !monster.IsDead)
            {
                // Spelaren attackerar om vi lever
                monster.GetsHit(player.Attack(player.strength, player.strength * 2));

                // Monstret attackerar om det lever
                if (!monster.IsDead)
                {
                    player.GetsHit(player.Attack(min_enemy_attack_power, max_enemy_attack_power));
                }

                // skiver ut hp för spelare om spelaren överlever
                if (!player.IsDead)
                {
                    Console.WriteLine(player.name + ": " + player.hp + "hp");
                }

                // skriver ut hp för monster om monster överlever
                if (!monster.IsDead)
                {
                    // skriver ut hp för monster
                    Console.WriteLine(monster.name + ": " + monster.hp + "hp");
                }

                // Om monstret dör får vi nedan saker och stats skrivs ut 
                if (monster.IsDead)
                {
                    player.numAttack = 0;
                    player.gold += lootGold;
                    player.exp += monster.exp;
                    Console.WriteLine("You killed the monster gaining " + monster.exp + " experience and " + lootGold + " gold");
                    player.LevelUp();
                    Console.WriteLine("You are level " + player.level + ", and you have " + player.exp + " experience, " + player.hp + " hp and " + player.gold + " gold");
                }

                // Om spelaren dör
                if (player.IsDead)
                {
                    Console.WriteLine("You were killed by the monster and lost the game..");
                    break;
                }

                // Om spelaren blir lvl 10
                if (player.level >= 10)
                {
                    Console.WriteLine("Congratulations! You won the game!");
                    player.numAttack = 10; // så att den inte loopar om igen - kommer ej på hur jag förhindrar detta i metoden istället
                    break;
                }

                // Om sista bossen dör
                if (bowser.IsDead)
                {
                    Console.WriteLine("Congratulations " + player.name + " you defeted all the enemies and have won the game!");
                    break;
                }

                // Om sista bossen och spelaren fortfarande lever så fortsätter vi
                if (!bowser.IsDead && !player.IsDead)
                {
                    // Fråga spelaren att fortsätta
                    enterFunktion.EnterContinue();
                }
            }
        }


    }    
}
