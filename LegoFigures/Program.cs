using LegoFigures.Equipment;
using LegoFigures.LegoFigure;
using System;
using System.Threading;

namespace LegoFigures
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(@"
 __      __       .__                                  __           .____                        ________                          __   
/  \    /  \ ____ |  |   ____  ____   _____   ____   _/  |_  ____   |    |    ____   ____   ____ \_____  \  __ __   ____   _______/  |_ 
\   \/\/   // __ \|  | _/ ___\/  _ \ /     \_/ __ \  \   __\/  _ \  |    |  _/ __ \ / ___\ /  _ \ /  / \  \|  |  \_/ __ \ /  ___/\   __\
 \        /\  ___/|  |_\  \__(  <_> )  Y Y  \  ___/   |  | (  <_> ) |    |__\  ___// /_/  >  <_> )   \_/.  \  |  /\  ___/ \___ \  |  |  
  \__/\  /  \___  >____/\___  >____/|__|_|  /\___  >  |__|  \____/  |_______ \___  >___  / \____/\_____\ \_/____/  \___  >____  > |__|  
       \/       \/          \/            \/     \/                         \/   \/_____/               \__>           \/     \/       
  
");
            string characterChoice = "";
            var characterCreation = true;
            while (characterCreation)
            {
                Console.WriteLine(@"
            -+=Choose A Character=+-
            ________________________
            0) Warrior
            1) Mage (unavailable)
            2) Archer (unavailable)
");

                var createCharacter = Console.ReadKey();
                switch (createCharacter.Key)
                {
                    case ConsoleKey.D0:
                        characterChoice = "warrior";
                        Console.Clear();
                        Console.WriteLine("You have chosen the way of the warrior.");
                        Thread.Sleep(1500);
                        Console.WriteLine("Born into a world of pain and suffering...");
                        Thread.Sleep(1500);
                        Console.WriteLine("You have known nothing but combat...");
                        Thread.Sleep(1500);
                        Console.WriteLine("You awaken from a dark dream to an even darker reality.");
                        Thread.Sleep(1500);
                        characterCreation = false;
                        break;
                    case ConsoleKey.D1:
                        Console.Clear();
                        Console.WriteLine("Mage is currently unavailable.");
                        break;
                    case ConsoleKey.D2:
                        Console.Clear();
                        Console.WriteLine("Archer is currently unavailable.");
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid choice");
                        break;
                }

            }
            LegoFigure.Warrior playerWarrior;
            switch (characterChoice)
            {
                case "warrior":
                    Console.WriteLine("Choose a name for your character.");
                    var userInput = Console.ReadLine();
                    Console.Clear();
                    playerWarrior = new Warrior(userInput);

                    // Warrior game start - wake up at camp
                    Console.WriteLine(@"
You awaken inside your shoddy tent in the woods to the sound of leaves rustling nearby. 
                A demonic smell is thick in the air.
Press any key to continue...
");
                    Console.ReadKey();
                    Console.Clear();
                    playerWarrior.ShowStats(); 
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();

                    Console.WriteLine("Sure enough the stench gets stronger and a Demonkin emerges from the darkness to preemptively strike but you are prepared.");
                    Console.WriteLine("You prepare for a fight!");
                    Console.Clear();
                    var demonFightOne = new Monster("Jarax", "demonkin", 10, 10);
                    // combat loop
                    while (demonFightOne.Dead == false && playerWarrior.Dead == false)
                    {
                        Console.Clear();
                        demonFightOne.Attack(playerWarrior);
                        playerWarrior.Combat(demonFightOne);

                        Console.WriteLine("Press 'Enter' for next turn");
                        Console.Read();
                    }
                    break;
                default:
                    break;
            }

            
            var MetalArmor = new Armor("Metal Cuirass","Metal", 14, "Torso");
            var basicRing = new Accessory("Ring of Power", 125, false);

            Console.Read();


        }
    }
}
