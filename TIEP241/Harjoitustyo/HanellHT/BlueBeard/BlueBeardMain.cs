using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

/// <summary>
/// @author Esko Hanell
/// @version 7.12.2016
/// </summary>
namespace BlueBeard
{
    /// <summary>
    /// A game about definitely no heroes and some monsters.
    /// </summary>
    static class BlueBeardMain
    {

        internal static LocationNFA maze;
        internal static Alien alien;
        internal static CFG cfg;
        internal static bool foundYou;
        internal static bool gotYou;
        internal static bool alienDead;
        private static Random rand = new Random();

        public static void Main(string[] args)
        {
            maze = new LocationNFA();
            alien = new Alien(maze);
            cfg = new CFG(maze);
            alienDead = false;
            foundYou = false;
            gotYou = false;
            //Aloitetaan peli
            Console.WriteLine("Your name is Gilles de Rais. \nA knight and a lord. Leader in the French army. \nYou are also know as the knight blue beard. \nYou were doing great in the war against the English. \nNow you just woke up in this maze and \nyou don't have a clue what is going on.");
            Loop();
        }

        /// <summary>
        /// main game loop
        /// </summary>
        public static void Loop()
        {
            stuff.SpaceText();
            DidAlienGetYou();
            string input = Console.ReadLine();
            DidAlienGetYou();
            cfg.Read(input);
            Loop();
        }

        /// <summary>
        /// Notices if you met the alien and handles that.
        /// </summary>
        private static void DidAlienGetYou()
        {
            if (foundYou)
            {
                Console.Clear();
                Console.WriteLine("There is a terrifying creature groaning right in front of you. \nIts face is filled with teeth some of which them seem to be missing. \nYou don't have the slightest clue where its eyes are. \nIn the ends of its arms it has long and pointy scythe looking claws. \n");
                maze.movement = false;
                alien.prepareToKill();
                foundYou = false;
                Loop();
            }
            if (gotYou)
            {
                Console.WriteLine("too slow");
                switch (rand.Next(0, 2))
                {
                    case 0:
                        Console.WriteLine("The creature charges at you and pierces your stomach with its scythes. \nyou try to scream but there doesn't appear to be any breath available to you. \nThe creature cringes and you are shredded to pieces.");
                        break;
                    case 1:
                        Console.WriteLine("The creature charges at you and hits your neck with its scythe. \nYou feel something warm and wet on your bodys left side for about 3 seconds. \n");
                        break;
                    case 2:
                        Console.WriteLine("creature leaps to you and pierces your chest with one of its scythes. \nYou lose all your strength and everything slowly and painfully \nfades to black and cold in the next 10 seconds.");
                        break;
                }
                maze.UrDed();
            }
            if (alienDead)
            {
                maze.alienLocation = null;
                Console.WriteLine("You killed the monster! Yey! Yey! Trial has ended. Buy full verion to continue.");
                Console.WriteLine("Press any -key to continue");
                Console.ReadLine();
                Console.WriteLine(".");
                Console.WriteLine(".");
                Console.WriteLine(".");
                Console.WriteLine(".");
                Console.WriteLine(".");
                Console.WriteLine("Project manager: Esko Hanell");
                Console.WriteLine("Lead designer: Esko Hanell");
                Console.WriteLine("Lead programmer: Esko Hanell");
                Console.WriteLine("Programmer: Esko Hanell");
                Console.WriteLine("Art director: Esko Hanell");
                Console.WriteLine("Consept artist: Esko Hanell");
                Console.WriteLine("Special effects: Esko Hanell");
                Console.WriteLine("Sound design: Esko Hanell");
                Console.WriteLine("Writer: Esko Hanell");
                Console.WriteLine("All grammar mistakes: Esko Hanell");
                Console.WriteLine("Graphics design: console");
                Console.WriteLine("technical support: stackoverflow.com");
                Console.WriteLine("design platform support: msdn");
                Console.WriteLine("Special thanks to: Antti-Juhani Kaijananho");
                Console.WriteLine("Press any -key to restart");
                Console.ReadLine();
                Restart();
            }
        }

        internal static void Restart()
        {
            Console.ReadLine();
            stuff.SpaceText();
            Console.WriteLine("Your name is Gilles de Rais. \nA knight and a lord. Leader in the French army. \nYou are also know as the knight blue beard. \nYou were doing great in the war against the English. \nNow you just woke up in this maze and \nyou don't have a clue what is going on.");
            maze = new LocationNFA();
            alien = new Alien(maze);
            cfg = new CFG(maze);
            alienDead = false;
            foundYou = false;
            gotYou = false;
            Loop();
        }
    }
}
