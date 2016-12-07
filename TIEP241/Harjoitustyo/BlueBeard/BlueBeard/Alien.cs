using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BlueBeard
{
    class Alien
    {
        private static Random rand = new Random();
        private static int alienCallInterval = 40;
        private static int alienMoveInInterval = 20;
        private LocationNFA maze;
        private Timer CallAlien;
        private bool eka1;
        private bool eka0;

        public static string attackDirection {get; set; }
        private int alienAttackInterval = 40;
        private bool eka2;

        public Alien(LocationNFA maze)
        {
            this.maze = maze;
            eka0 = true;
            CallAlien = new Timer(AlienUpdate, new AutoResetEvent(false), 0, alienCallInterval * 1000);
        }


        private void AlienUpdate(object state)
        {
            if (eka0)
            {
                eka0 = false;
                return;
            }

            int dice = rand.Next(0, 3);
            switch (dice)
            {
                case 0:
                    TryMove("north");
                    break;
                case 1:
                    TryMove("east");
                    break;
                case 2:
                    TryMove("south");
                    break;
                case 3:
                    TryMove("west");
                    break;
            }
        }

        private void TryMove(string direction)
        {
            //Console.WriteLine("Aliens bell collar tinkle and jingle...");
            if (maze.AlienWander(direction))
            {
                Intrigue();
            }
        }

        public void Intrigue()
        {
            string direction = null;
            switch (attackDirection)
            {
                case "south":
                    direction = "north";
                    break;
                case "west":
                    direction = "east";
                    break;
                case "north":
                    direction = "south";
                    break;
                case "east":
                    direction = "west";
                    break;
            }
            stuff.SpaceText();
            Console.WriteLine("Something is moving right behind " + direction + " entrance!!!");
            CallAlien.Dispose();
            eka1 = true;
            CallAlien = new Timer(Advance, new AutoResetEvent(false), 0, alienMoveInInterval * 1000);
        }

        /// <summary>
        /// Jump to the room where you think the enemy hides.
        /// Puts everything back to the usual phase if nothing happens.
        /// </summary>
        /// <param name="state"></param>
        private void Advance(object state)
        {
            if (eka1)
            {
                eka1 = false;
                return;
            }
            CallAlien.Dispose();
            maze.AlienCharge(attackDirection);
            eka0 = true;
            CallAlien = new Timer(AlienUpdate, new AutoResetEvent(false), 0, alienCallInterval * 1000);
        }

        /// <summary>
        /// Sloved down and open.
        /// </summary>
        internal void staggered()
        {
            Console.WriteLine("The creature is just about to get free.");
            stuff.SpaceText();
            CallAlien.Dispose();
            eka2 = true;
            CallAlien = new Timer(Kill, new AutoResetEvent(false), 0, alienAttackInterval * 1000);
        }


        internal void prepareToKill()
        {
            CallAlien.Dispose();
            eka2 = true;
            CallAlien = new Timer(Kill, new AutoResetEvent(false), 0, alienAttackInterval * 1000);
        }

        /// <summary>
        /// Kill the player
        /// </summary>
        /// <param name="state"></param>
        public void Kill(object state)
        {
            if (eka2)
            {
                eka2 = false;
                return;
            }
            BlueBeardMain.gotYou = true;
            CallAlien.Dispose();
        }

        /// <summary>
        /// Alien ded. So sad. q_q
        /// </summary>
        internal void ded()
        {
            BlueBeardMain.alienDead = true;
            CallAlien.Dispose();
        }
    }
}
