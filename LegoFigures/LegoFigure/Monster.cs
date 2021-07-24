using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegoFigures.LegoFigure
{
    class Monster
    {
        // Properties
        public string Name { get; set; }
        public string Type { get; }
        public bool Dead { get; private set; } = false;
        public int Defense { get; private set; }
        public int AttackPower { get; private set; }
        public int Health { get; private set; } = 25;
        public int Gold { get; private set; }

        // Constructor
        public Monster(string name, string type, int defense, int attackPower)
        {
            var rand = new Random();
            Name = name;
            Type = type;
            Defense = defense;
            AttackPower = attackPower;
            Gold = 10 + rand.Next(1,16);

            switch(type)
            {
                case "demonkin":
                    Console.WriteLine(@"        
          (                      )
          |\    _,--------._    / |
          | `.,'            `. /  |
          `  '              ,-'   '
           \/_         _   (     /
          (,-.`.    ,',-.`. `__,'
           |/#\ ),-','#\`= ,'.` |
           `._/)  -'.\_,'   ) ))|
           /  (_.)\     .   -'//
          (  /\____/\    ) )`'\
           \ |V----V||  ' ,    \
            |`- -- -'   ,'   \  \      _____
     ___    |         .'    \ \  `._,-'     `-
        `.__,`---^---'       \ ` -'
           -.______  \ . /  ______,-
                   `.     ,'            ");
                    break;
                default:
                    Console.WriteLine(@"Unidentified beast");
                    break;
            }
        }
        // Expanded Constructor
        public Monster(string name, string type, int defense, int attackPower, int health) : this(name, type, defense, attackPower) => Health = health;

        // Methods
        public void CheckDeath(Warrior player)
        {
            if (Health <= 0)
            {
                Dead = true;
                player.GiveGold(Gold);
                player.ShowStats();
                Console.WriteLine($"You have defeated the {Type} and gained {Gold} gold! You now have {player.Gold} gold!");
            }
        }
        public int TakeDamage(int damage, Warrior player)
        {
            Health -= damage;
            CheckDeath(player);
            return Health;
        }
        public void Attack(LegoFigure.Warrior warrior)
        {
            var rnd = new Random();
            decimal armorDamageReduction = ((decimal)warrior.Defense) / 50;
            decimal damage = rnd.Next(5, AttackPower);
            int modifiedDamage = (int)(damage * armorDamageReduction);
            warrior.TakeDamage(modifiedDamage);
            Console.WriteLine(@"        
          (                      )
          |\    _,--------._    / |
          | `.,'            `. /  |
          `  '              ,-'   '
           \/_         _   (     /
          (,-.`.    ,',-.`. `__,'
           |/#\ ),-','#\`= ,'.` |
           `._/)  -'.\_,'   ) ))|
           /  (_.)\     .   -'//
          (  /\____/\    ) )`'\
           \ |V----V||  ' ,    \
            |`- -- -'   ,'   \  \      _____
     ___    |         .'    \ \  `._,-'     `-
        `.__,`---^---'       \ ` -'
           -.______  \ . /  ______,-
                   `.     ,'            ");
            Console.WriteLine($"{Type} slashes at {warrior.Name} for {modifiedDamage} damage.");
        }
    }
}
