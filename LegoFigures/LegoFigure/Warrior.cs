using LegoFigures.Equipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegoFigures.LegoFigure
{
    class Warrior
    {
        public string Name { get; set; }
        public bool Dead { get; private set; } = false;
        public int AttackPower { get; private set; }
        public int MagicPower { get; private set; } = 1;
        public int Defense { get; private set; }
        public int Health { get; private set; } = 100;
        public int Gold { get; private set; } = 125;
        public Armor BodyArmor { get; set; }
        public Armor HeadArmor { get; set; }
        public Armor LegArmor { get; set; }
        public Accessory RingOne { get; set; }
        public Accessory RingTwo { get; set; }
        public Weapon Weapon { get; set; }
        public Warrior(string name)
        {
            Name = name;
            BodyArmor = new Armor("Leather cuirass", "Leather", 8, "Torso");
            HeadArmor = new Armor("Leather helm", "Leather", 3, "Head");
            LegArmor = new Armor("Leather greaves", "Leather", 7, "Legs");
            Weapon = new Weapon("Crude bronze axe", "crude bronze", 14, "Warrior");
            Defense = 5 + HeadArmor.Defense + BodyArmor.Defense + LegArmor.Defense;
            AttackPower = 12 + Weapon.AttackPower;

            Console.WriteLine($"Welcome, {Name}!");
            Console.WriteLine(
                @$" A warrior has awakened....
                                            


                                            -=Stats=-
                                            ______________________

      _,.                                   {Gold}g
    ,` -.)                                  Attack: {AttackPower}                                              
   ( _/-\\-._                               Defense: {Defense}
  /,|`--._,-^|            ,                 Health: {Health}
  \_| |`-._/||          ,'|                 {(Dead ? "You are dead" : "You are alive")}
    |  `-, / |         /  /
    |     || |        /  /
     `r-._||/   __   /  /
 __,-<_     )`-/  `./  /
'  \   `---'   \   /  /
    |           |./  /
    /           //  /
\_/' \         |/  /
 |    |   _,^-'/  /
 |    , ``  (\/  /_
  \,.->._    \X-=/^
  (  /   `-._//^')
   `Y-.____(__)
    |     (__)
          ()
"
);
        }
        public int GetAttackPower()
        {
            int ringOneAttackPower = 0;
            int ringTwoAttackPower = 0;
            if (RingOne != null)
            {
                ringOneAttackPower = RingOne.AttackPower;
            }
            if (RingTwo != null)
            {
                ringTwoAttackPower = RingTwo.AttackPower;
            }
            AttackPower += (Weapon.AttackPower + ringOneAttackPower + ringTwoAttackPower);
            Console.WriteLine($"{Name} now has {AttackPower} Attack");
            return AttackPower;
        }
        public void ShowStats()
        {
            Console.WriteLine(
                @$" -{Name} the Warrior-
                                            


                                            -=Stats=-
                                            ______________________

      _,.                                   {Gold}g
    ,` -.)                                  Attack: {AttackPower}                                              
   ( _/-\\-._                               Defense: {Defense}
  /,|`--._,-^|            ,                 Health: {Health}
  \_| |`-._/||          ,'|                 {(Dead ? "You are dead" : "You are alive")}
    |  `-, / |         /  /
    |     || |        /  /
     `r-._||/   __   /  /
 __,-<_     )`-/  `./  /
'  \   `---'   \   /  /
    |           |./  /
    /           //  /
\_/' \         |/  /
 |    |   _,^-'/  /
 |    , ``  (\/  /_
  \,.->._    \X-=/^
  (  /   `-._//^')
   `Y-.____(__)
    |     (__)
          ()
"
);
        }
        public int GetDefense()
        {
            Defense = 5 + BodyArmor.Defense + LegArmor.Defense + HeadArmor.Defense;
            Console.WriteLine($"{Name} now has {Defense} defense");
            return Defense;
        }
        public void EquipArmor(Armor armor)
        {
            switch (armor.EquippableOn)
            {
                case "Torso":
                    Console.WriteLine($"{Name} equips {armor.Name} to {armor.EquippableOn}");
                    BodyArmor = armor;
                    break;
                case "Head":
                    Console.WriteLine($"{Name} equips {armor.Name} to {armor.EquippableOn}");
                    HeadArmor = armor;
                    break;
                case "Legs":
                    Console.WriteLine($"{Name} equips {armor.Name} to {armor.EquippableOn}");
                    LegArmor = armor;
                    break;
                default:
                    Console.WriteLine("You cannot equip this piece of armor.");
                    break;
            }
            GetDefense();
        }
        public void EquipRingOne(Accessory ring)
        {
            if (ring.Magical)
            {
                Console.WriteLine("A warrior cannot wield such magic");
            } else
            {
                RingOne = ring;
                Console.WriteLine($"{Name} equips {ring.Name}");
                GetAttackPower();
            }
        }
       
        public void CheckDeath()
        {
            if (Health <= 0)
            {
                Dead = true;
                Console.Clear();
                Console.WriteLine("You have died...");
                Console.WriteLine(@"
                               ...
             ;::::;
           ;::::; :;
         ;:::::'   :;
        ;:::::;     ;.
       ,:::::'       ;           OOO\
       ::::::;       ;          OOOOO\
       ;:::::;       ;         OOOOOOOO
      ,;::::::;     ;'         / OOOOOOO
    ;:::::::::`. ,,,;.        /  / DOOOOOO
  .';:::::::::::::::::;,     /  /     DOOOO
 ,::::::;::::::;;;;::::;,   /  /        DOOO
;`::::::`'::::::;;;::::: ,#/  /          DOOO
:`:::::::`;::::::;;::: ;::#  /            DOOO
::`:::::::`;:::::::: ;::::# /              DOO
`:`:::::::`;:::::: ;::::::#/               DOO
 :::`:::::::`;; ;:::::::::##                OO
 ::::`:::::::`;::::::::;:::#                OO
 `:::::`::::::::::::;'`:;::#                O
  `:::::`::::::::;' /  / `:#
   ::::::`:::::;'  /  /   `#
");
            }
        }
        public int TakeDamage(int damage)
        {
            Health -= damage;
            CheckDeath();
            return Health;
        }
        public int GiveGold(int gold)
        {
            Gold += gold;
            return Gold; 
        }
        public void BasicAttack(Monster opponent)
        {
            var rnd = new Random();
            decimal armorDamageReduction = ((decimal)opponent.Defense) / 50;
            decimal damage = rnd.Next(8, AttackPower);
            int modifiedDamage = (int)(damage * armorDamageReduction);
            opponent.TakeDamage(modifiedDamage, this);
            Console.WriteLine($"{Name} strikes at {opponent.Type} for {modifiedDamage} damage. {opponent.Type} has {opponent.Health} health");
        }
        public void Combat(Monster opponent)
        {
            bool validInput = false;
            while (validInput == false)
            {
                Console.WriteLine(
                @$" -{Name} the Warrior-
                                            


                                            -=Stats=-
                                            ______________________

      _,.                                   {Gold}g
    ,` -.)                                  Attack: {AttackPower}                                              
   ( _/-\\-._                               Defense: {Defense}
  /,|`--._,-^|            ,                 Health: {Health}
  \_| |`-._/||          ,'|                 {(Dead ? "You are dead" : "You are alive")}
    |  `-, / |         /  /
    |     || |        /  /                   -=Combat Menu=-
     `r-._||/   __   /  /                     
 __,-<_     )`-/  `./  /                        0) Basic Attack 
'  \   `---'   \   /  /                         1) Heavy Slash
    |           |./  /                          2) View Stats
    /           //  /
\_/' \         |/  /
 |    |   _,^-'/  /
 |    , ``  (\/  /_
  \,.->._    \X-=/^
  (  /   `-._//^')
   `Y-.____(__)
    |     (__)
          ()
"
);

                var playerInput = Console.ReadKey();
                switch (playerInput.Key)
                {
                    case ConsoleKey.D0:
                        BasicAttack(opponent);
                        validInput = true;
                        break;
                    case ConsoleKey.D1:
                        Console.WriteLine("Invalid Input");
                        break;
                    case ConsoleKey.D2:
                        ShowStats();
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;

                }
            }
           
        }

    }
}
