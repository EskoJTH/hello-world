using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBeard
{
    class CFG
    {

        public static readonly string[] moveTerminalSymbols = new string[] { "move", "go", "proceed", "walk", "run", "sprint" };
        public static readonly string[] attackTerminalSymbols = new string[] { "cut", "hit", "thrust", "attack", "charge", "punch", "kick", "bite", "shoot"};
        public static readonly string[] readTerminalSymbols = new string[] { "read" };
        public static readonly string[] takeTerminalSymbols = new string[] { "take", "get", "hold", "grab" };
        public static readonly string[] itemsTerminalSymbols = new string[] { "sword", "scabbard", "polearm", "bow", "terahedron" };
        public static readonly string[] directionsTerminalSymbols = new string[] { "north", "east", "south", "west" };
        public static readonly string[] lookTerminalSymbols = new string[] { "see", "watch", "look", "inspect", "investigate", "read" };
        public static readonly string[] roomTerminalSymbols = new string[] { "around", "room", };
        public static readonly string[] targetTerminalSymbols = new string[] { "monster", "alien", "creature", "stone square" };
        public static readonly string[] weaponTerminalSymbols = new string[] { "bow", "polearm", "sword", "fist", "foot", "head", "teeth", "jaws", "tetrahedron" };
        public static readonly string[] literatureTerminalSymbols = new string[] { "book", "necronomicon" };

        private LocationNFA maze;
        public CFG(LocationNFA maze)
        {
            this.maze = maze;
        }

        /// <summary>
        /// Sens from string input
        /// </summary>
        /// <param name="input"></param>
        public void Read(string input)
        {
            input = input.Trim();
            input = input.ToLower();
            Treeify(input);
        }

        //--------------------------------------Logic figuring the language---------------------------------------------------------
        private void Treeify(string input)
        {
            int ekaSana = input.IndexOf(" ");
            if (ekaSana == -1) ekaSana = input.Length;

            //Drop
            try
            {
                Parse(input, new string[] { "drop", "put down", "empty hands", "free hands", "lay down", "leave", "discard" });
                maze.Drop();
                return;
            }
            catch (ParseException) { }

            //Move
            try
            {
                Parse(input.Substring(0, ekaSana), moveTerminalSymbols);
                try
                {
                    string direction = Parse(input, directionsTerminalSymbols);
                    Console.WriteLine("You go to " + direction);
                    maze.Move(direction);
                    return;
                }
                catch (ParseException) { };

                Console.WriteLine("Which compass direction do you want to go to?");
                string newDirection = Console.ReadLine();

                try
                {
                    Parse(newDirection, directionsTerminalSymbols);
                    Console.WriteLine("You go to " + newDirection);
                    maze.Move(newDirection);
                    return;
                }
                catch (ParseException)
                {
                    Console.WriteLine("Don't know what direction you mean so let's stay here!");
                    return;
                }
            }
            catch (ParseException) { }

            //Take
            try
            {
                Parse(input.Substring(0, ekaSana), takeTerminalSymbols);
                try
                {
                    string itemName = Parse(input, itemsTerminalSymbols);
                    maze.TakeItem(itemName);
                    return;
                }
                catch (ParseException)
                {
                    try
                    {
                        Console.WriteLine("Which item do you wish to take with you?");
                        string newitem = Console.ReadLine();
                        string itemName = Parse(newitem, itemsTerminalSymbols);
                        maze.TakeItem(itemName);
                        return;

                    }
                    catch (ParseException)
                    {
                        Console.WriteLine("Don't think that is something I wish to carry around");
                        return;
                    }
                }

            }
            catch (ParseException) { }

            //Look
            try
            {
                Parse(input.Substring(0, ekaSana), lookTerminalSymbols);

                if (LookLogic(input)) return;

                Console.WriteLine("What do you wish to inspect?");
                input = Console.ReadLine();

                if (LookLogic(input)) return;

                Console.WriteLine("Didn't understand that.");
                return;

            }
            catch (ParseException) { }

            //Attack
            try
            {
                Parse(input.Substring(0, ekaSana), attackTerminalSymbols);
                string targetName = TargetLogic(input);
                if (targetName == null)
                {
                    Console.WriteLine("What do you want to attack?");
                    string Correction = Console.ReadLine();
                    targetName = TargetLogic(Correction);
                    if (targetName == null)
                    {
                        Console.WriteLine("Didn't understand that. Start from the beginning.");
                        return;
                    }
                }

                string weaponName = attackLogic(input);

                if (weaponName == null)
                {
                    Console.WriteLine("What do you want to attack " + targetName + "with?");
                    string Correction = Console.ReadLine();
                    weaponName = attackLogic(Correction);
                    if (weaponName == null)
                    {
                        Console.WriteLine("Didn't understand that. Start from the beginning.");
                        return;
                    }
                }

                if (!(weaponName == null) && !(targetName == null))
                {
                    maze.Battle(targetName, weaponName);
                    return;
                }

                Console.WriteLine("Didn't understand that. Start from the beginning.");
                return;
            }
            catch (ParseException) { }


            Console.WriteLine("What you described was not understood. try Look around or move to a compass direction.");


        }

        //helps lessen repetition
        private string TargetLogic(string input)
        {
            try
            {
                string targetName = Parse(input, targetTerminalSymbols);
                return targetName;
            }
            catch (ParseException) { return null; }
        }

        //helps lessen repetition
        private string attackLogic(string input)
        {
            try
            {
                string weaponName = Parse(input, weaponTerminalSymbols);
                return weaponName;
            }
            catch (ParseException) { return null; }
        }

        //helps lessen repetition
        private bool LookLogic(string input)
        {

            try
            {
                string targetName = Parse(input, itemsTerminalSymbols);
                maze.TargetOfInterest(targetName);
                return true;
            }
            catch (ParseException) { }

            try
            {
                string targetName = Parse(input, directionsTerminalSymbols);
                maze.LookForRoom(targetName);
                return true;
            }
            catch (ParseException) { }

            try
            {
                string targetName = Parse(input, roomTerminalSymbols);
                Console.WriteLine("You inspect the room around you. " + maze.present.text);
                return true;
            }
            catch (ParseException) { }

            try
            {
                string targetName = Parse(input, literatureTerminalSymbols);
                maze.ChechLiterature();
                return true;
            }
            catch (ParseException) { }

            return false;
        }

        //---------------------------------Parse -ing-------------------------------------------------------------------------

            /// <summary>
            /// Tries to find any of the given qualifiers in the input string
            /// and throws exception when unsuccesful
            /// </summary>
            /// <param name="input"></param>
            /// <param name="qualifiers"></param>
            /// <returns></returns>
        private string Parse(string input, string[] qualifiers)
        {
            for (int i = 0; i < qualifiers.Length; i++)
            {
                if (-1 < input.IndexOf(qualifiers[i]))
                {
                    return qualifiers[i];
                }
            }
            throw new ParseException("couldn't find'n stuff...");
        }

    }

    public class ParseException : SystemException
    {
        public ParseException() : base() { }
        public ParseException(string message) : base(message) { }
        public ParseException(string message, System.Exception inner) : base(message, inner) { }
    }
}
