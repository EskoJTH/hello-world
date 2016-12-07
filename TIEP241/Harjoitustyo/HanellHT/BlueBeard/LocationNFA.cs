using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBeard
{
    class LocationNFA
    {
        public Room present { get; set; }
        public static Item hands;
        public static Item scabbard = null;
        public static Item inScabbard = null;
        public Room alienLocation;
        private bool staggered = false;

        public bool movement { get; set; }

        public LocationNFA()
        {
            movement = true;
            //luodaan huoneet
            Room entrance = new Room("You see a weird Glass pod there, \nfrom which you crawled out before you were really concious.", "entrance");
            Room weaponRoom = new Room("There is a polearm on the room wall. \nIt has a lot of spikes and hooks to all directions in its blade end. \nThat is one of the most usual weapons you know. \nVery effective when used together in a group and not too bad when alone either. \nExtremely good if you want to hook enemys weapon.\nThere also is an old light crossbow. \nIt would be useless against platemail the one you used to have. \nThey have broad heads designed for hunting.", "weaponRoom");
            Room library = new Room("There is a room with a paintings and books. \nThey are all religious with deep meaning and a lot of symbolism.", "library");
            Room swordRoom = new Room("In this room there is a complex hilted sword withouth its scabbard on a table. \nYou usually carry one of those with you. \nIt is a very easy weapon to carry around with its scabbard. \nIt is very effective agains unarmored enemies. \nIts complex hilt keeps your hand safe so therer is no need for a shield with it. \nIt is almost useless against platemail unless using specialised techniques like half swording or murder stroke. \nit is easy to carry so you usually had it as a back up when on the battlefield.", "swordRoom");
            Room keyRoom = new Room("In this room there is a giant weirdly shaped metallic tetrahedron -ish thing in the middle of the room.", "keyRoom");
            Room nest = new Room("There is a nest of some form here. \nIt is made of hair and some pieces of wood and other common things you have seen in this maze. \nThere is slime all around it and the stench is burning your noce.", "nest");
            Room Portal = new Room("There is a giant stone square on the wall with stairs leading through it. \nThe The square is surrounded by symbols in unkown languages.", "Portal");
            Room keyHole = new Room("There is a hole on the ground with a tetrahedron shape. \nThe hole is surrounded by disks filled with symbols of unknown origin.", "keyHole");
            Room kitchen = new Room("There is a scabbard of a sword here. \nYou quickly notice this room has been used for handling of meat. \nYou find some very smoothly shredded meat laying around. \nThere are a lot of weird devices with writing in languages foreign to you. \nShapes so complex but at the same time simple that they could have never been created by any human. \nThings bend out of glass and metal like nothing you have ever seen before with self illumination. \nThere is a cursed black plate to the corner that is smoking and appears hot as flames.", "kitchen");
            weaponRoom.itemsAround.Add(new Item("polearm", "polearm with multipurpose spear head", "It has a head with lots of varying spikes and hooks. for the most part its edges are sharpened."));
            weaponRoom.itemsAround.Add(new Item("bow", "light hunting crossbow and a quiver full of crossbow bolts with hunting broadheads", "This bow really is a device to hunt. \nIt has bolts with wide broadheads that would be ideal to cause a deer bleed a lot so tracking would be easy and the animal dies fast. \nIt doesn't have enough power to really be useful in battlefield with any armored targets though"));
            swordRoom.itemsAround.Add(new Item("sword", "complex hilted sword", "Personal defence weapon preferred by many in your time."));
            kitchen.itemsAround.Add(new Item("scabbard", "scabbard", "A leather covered wooden artpiece. There are metal reignforced parts that are full of nice looking texturing. The leather is filled with pictures of a forgotten battle."));
            keyRoom.itemsAround.Add(new Item("tetrahedron", "tetrahedron", "This thing gives you a headache. You let it just be"));
            present = entrance;
            alienLocation = nest;

            //asetetaan huoneiston järjestys.
            entrance.AdjacentRooms(swordRoom, keyRoom, null, weaponRoom);
            weaponRoom.AdjacentRooms(library, entrance, null, null);
            library.AdjacentRooms(keyHole, swordRoom, weaponRoom, null);
            swordRoom.AdjacentRooms(Portal, kitchen, entrance, library);
            keyRoom.AdjacentRooms(kitchen, null, null, entrance);
            nest.AdjacentRooms(null, null, kitchen, Portal);
            Portal.AdjacentRooms(null, nest, swordRoom, keyHole);
            keyHole.AdjacentRooms(null, Portal, library, null);
            kitchen.AdjacentRooms(nest, null, keyRoom, swordRoom);
            //Luodaan Itemit.
        }


        //----------Handles game data, generally called from outside--------------------------------------------------------
        //easier to understand in the context of other parts of the progtram.


        internal void AlienCharge(string attackDirection)
        {
            alienLocation = alienLocation.GetAdjacent(attackDirection);
            FoundYou();
        }

        internal void FoundYou()
        {
            if (alienLocation.name.Equals(present.name))
            {
                BlueBeardMain.foundYou = true;
            }
        }

        internal void TargetOfInterest(string targetName)
        {
            switch (targetName)
            {
                case "alien":
                    Console.WriteLine("That thing is absolutely horrifying and I'm about to die...");
                    return;
                case "creature":
                    Console.WriteLine("That thing is absolutely horrifying and I'm about to die...");
                    return;
                case "stone square":
                    Console.WriteLine("That thing is propably used for travelling to out of this palce");
                    return;
                case "hole":
                    Console.WriteLine("You feel like the tetrahedron shaped hole is probably quite complex under its cover eventhough its outsides are quite simple");
                    return;
            }
        }

        internal void Battle(string targetName, string weaponName)
        {
            switch (targetName)
            {
                case "alien":
                    UseWeaponOnAlien(weaponName);
                    break;
                case "creature":
                    UseWeaponOnAlien(weaponName);
                    break;
                case "monster":
                    UseWeaponOnAlien(weaponName);
                    break;
                case "stone square":
                    Console.WriteLine("You vigorously attack the stone square. \nIt feels like attackin the bedrock.");
                    break;
            }
        }

        private void UseWeaponOnAlien(string weaponName)
        {

            //Do we have access to the weapon.
            if ((hands != null && weaponName.Equals(hands.name)) || (inScabbard.name != null && weaponName.Equals(inScabbard.name)))
            {
                switch (weaponName)
                {
                    case "bow":
                        Console.WriteLine("You shoot the creature with the crossbow. \nCreature swings to the side and the bolt dissappears to the wall behind it. \nIt swings a claw at you and you seem to fall to the ground \nthe world spins around a couple of laps and then the greyness fades in.");
                        UrDed();
                        return;
                    case "tetrahedron":
                        Console.WriteLine("You throw the thing at the creature. It shows it away with one of its scythes. It eats your head.");
                        UrDed();
                        return;
                    case "polearm":
                        Console.WriteLine("You charge at the creature with your full force. \nYou thrust the spear trough its chest and hit the wall behind it. \nThe creature seems to be mangled and stuck on the polearms head \nwhich is stuck on the wall behind. \nyour hands lose grip of the weapon. \nThe creature is wiggling around attached to the wall.");
                        staggered = true;
                        present.itemsAround.Add(hands);
                        hands = null;
                        BlueBeardMain.alien.staggered();
                        return;
                    case "sword":
                        if (staggered == false)
                        {
                            Console.WriteLine("You cleave a lob off the creatures left side with your trusty sword. \nIt regenerates almost immediately. \nCreature doesn't seem to care as it continues straight to mutilate your guts. \nImportant bits of you fly around the room as you lose your consciusness. ");
                            UrDed();
                        }
                        else
                        {
                            Console.WriteLine("You swing the sword with all your strength to the aliens neck and it goes through. \nThe alien is decapitated.");
                            BlueBeardMain.alien.ded();
                        }
                        return;
                }
            }

            //Human integrated weapons generally carried by most of people.
            switch (weaponName)
            {
                case "fist":
                    Console.WriteLine("You punch the creatures face while it eats yours.");
                    UrDed();
                    return;
                case "foot":
                    Console.WriteLine("You kick the creatures stomack. It is not super effective.\nYour leg gets sheredded and soon the rest follows.");
                    UrDed();
                    return;
                case "head":
                    Console.WriteLine("You headbut the the creature. What are you thinking? \nThat doesn't help. Well you are dead now...");
                    UrDed();
                    return;
                case "teeth":
                    Console.WriteLine("You open your mouhth as open as you can and run at the creature. You feel a crunching hit somewhere and everything goes to dark.");
                    UrDed();
                    return;
                case "jaws":
                    Console.WriteLine("You open your mouth as open as you can and run at the creature. You feel a crunching hit somewhere and everything goes to dark.");
                    UrDed();
                    return;
            }
        }

        internal void UrDed()
        {

            Console.WriteLine("You are dead.");
            movement = true;
            BlueBeardMain.Restart();
        }

        internal bool AlienWander(string direction)
        {

            //tarkastetaan onko kaveri vieressä
            for (int i = 0; i < CFG.directionsTerminalSymbols.Length; i++)
            {
                if (alienLocation.GetAdjacent(CFG.directionsTerminalSymbols[i]) != null && present.name.Equals(alienLocation.GetAdjacent(CFG.directionsTerminalSymbols[i]).name))
                {
                    Alien.attackDirection = CFG.directionsTerminalSymbols[i];
                    return true;
                }
            }

            //liikutaan
            switch (direction)
            {
                case "north":
                    if (alienLocation.north != null)
                    {
                        alienLocation = alienLocation.north;
                    }
                    break;
                case "east":
                    if (alienLocation.east != null)
                    {
                        alienLocation = alienLocation.east;
                    }
                    break;
                case "south":
                    if (alienLocation.south != null)
                    {
                        alienLocation = alienLocation.south;
                    }
                    break;
                case "west":
                    if (alienLocation.west != null)
                    {
                        alienLocation = alienLocation.west;
                    }
                    break;

            }

            //tarkastetaan onko kaveri vieressä liikkumisen jälkeen.
            for (int i = 0; i < CFG.directionsTerminalSymbols.Length; i++)
            {
                if (alienLocation.GetAdjacent(CFG.directionsTerminalSymbols[i]) != null && present.name.Equals(alienLocation.GetAdjacent(CFG.directionsTerminalSymbols[i]).name))
                {
                    stuff.SpaceText();
                    Console.WriteLine("You hear something moving in the room to the " + CFG.directionsTerminalSymbols[i] + "!");
                    stuff.SpaceText();
                }
            }
            return false;

        }

        internal void ChechLiterature()
        {
            if (present.name.Equals("library"))
            {
                stuff.SpaceText();
                Console.WriteLine("You take an old book and read a bit. \nIt tells stories of times far long past. \nTt tells of how world was when the great old ones ruled. \nYou think the book has a lot of meaning and good teachings.");
            }
        }

        internal void ChechItem(string itemName)
        {
            for (int i = 0; i < present.itemsAround.Count(); i++)
            {
                if (present.itemsAround[i].name.Equals(itemName))
                {
                    inspect(present.itemsAround[i]);
                    return;
                }
            }
            if (hands.name.Equals(itemName))
            {
                inspect(hands);
            }
        }

        private void inspect(Item item)
        {
            Console.WriteLine("You inspect the " + item.name + ". " + item.advancedDescription);
        }

        internal void TakeItem(string itemName)
        {
            for (int i = 0; i < present.itemsAround.Count(); i++)
            {
                if (present.itemsAround[i].name.Equals(itemName))
                {
                    AddToInventory(present.itemsAround[i]);
                    return;
                }
            }
        }

        /// <summary>
        /// You have things you don't need?
        /// </summary>
        internal void Drop()
        {
            if (hands != null)
            {
                Console.WriteLine("You lay down the " + hands.name + " to the ground.");
                present.itemsAround.Add(hands);
                present.text += "\nThere is the " + hands.description + " laying on the ground.";
                hands = null;
            }
            else
            {
                Console.WriteLine("You aren't carrying anything...");
            }
        }

        /// <summary>
        /// handles the movement of the player
        /// </summary>
        /// <param name="direction"></param>
        public void Move(string direction)
        {
            if (!movement)
            {
                Console.WriteLine("You can't outrun the Creature.");
                return;
            }
            Room behindDoor = present.GetAdjacent(direction);
            if (behindDoor == null)
            {
                Console.WriteLine("There's apparently no door that way.");
                return;
            }
            present = behindDoor;

            //katsotaan onko viereisessä huoneessa alieni
            for (int i = 0; i < CFG.directionsTerminalSymbols.Length; i++)
            {
                if (alienLocation.GetAdjacent(CFG.directionsTerminalSymbols[i]) != null && present.name.Equals(alienLocation.GetAdjacent(CFG.directionsTerminalSymbols[i]).name))
                {
                    Alien.attackDirection = CFG.directionsTerminalSymbols[i];
                    BlueBeardMain.alien.Intrigue();
                }
            }
            FoundYou();
            Console.WriteLine(present.Text());
        }

        /// <summary>
        /// Looka ahead for rooms
        /// </summary>
        /// <param name="direction"></param>
        internal void LookForRoom(string direction)
        {
            if (!movement)
            {
                Console.WriteLine("You spin your head around for a while.");
                return;
            }
            Room behindDoor = present.GetAdjacent(direction);
            if (behindDoor == null)
            {
                Console.WriteLine("There's just a wall that way.");
                return;
            }

            Console.WriteLine("You see there appears to be an entrance to anopther room.");
            if (alienLocation!=null && alienLocation.name.Equals(behindDoor.name))
            {
                Console.WriteLine("You think there is someone in that room.");
            }
        }
         
        /// <summary>
        /// Add item to your inventory.
        /// </summary>
        /// <param name="item">Item to add.</param>
        public void AddToInventory(Item item)
        {
            if (-1 < present.itemsAround.IndexOf(item))
            {
                present.itemsAround.Remove(item);
                if (item.name.Equals("scabbard"))
                {
                    scabbard = item;
                    Console.WriteLine("you attach the scabbard to your side and attach it to the belt");
                    if (hands != null && hands.name.Equals("sword"))
                    {
                        inScabbard = hands;
                        Console.WriteLine("You put the sword from your hands to the scabbard.");
                        hands = null;
                        return;
                    }
                    return;
                }
                if (scabbard != null && item.name.Equals("sword"))
                {
                    inScabbard = item;
                    Console.WriteLine("You put the sword to the scabbard.");
                    return;
                }
                if (hands != null)
                {
                    Console.WriteLine("You don't think it is sensible to carry any more stuff in your hands.");
                    return;
                }
                Console.WriteLine("You take the " + item.description + ".");
                hands = item;
                present.itemsAround.Remove(item);
            }
            else
            {
                Console.WriteLine("Item you describe doesent appear to be available.");
            }
        }

    }

    //--------------does what it looks like-------------------------------------
    class Room
    {

        public Room north;
        public Room east;
        public Room south;
        public Room west;
        public List<Item> itemsAround = new List<Item>();
        public string text { get; set; }
        public string name;

        public Room()
        {
            this.north = null;
            this.east = null;
            this.south = null;
            this.west = null;
        }

        public Room(string roomText, string name)
        {
            this.name = name;
            this.text = roomText;
            this.north = null;
            this.east = null;
            this.south = null;
            this.west = null;
        }

        public Room(Room north, Room east, Room south, Room west)
        {
            this.north = north;
            this.east = east;
            this.south = south;
            this.west = west;
        }
        public void AdjacentRooms(Room north, Room east, Room south, Room west)
        {
            this.north = north;
            this.east = east;
            this.south = south;
            this.west = west;
        }

        public Room GetAdjacent(string direction)
        {
            switch (direction)
            {
                case "north":
                    return this.north;
                case "east":
                    return this.east;
                case "south":
                    return this.south;
                case "west":
                    return this.west;
                default:
                    Console.WriteLine("Direction you described wasn't understood.");
                    return null;
            }
        }
        public string Text()
        {
            return this.text;
        }

    }




    //--------------does what it looks like------------------------------------------
    public class Item
    {
        public readonly string name;
        public string advancedDescription;

        public string description { get; set; }

        public Item(string name, string description, string advancedDescription)
        {
            this.name = name;
            this.description = description;
            this.advancedDescription = advancedDescription;
        }
    }
}
