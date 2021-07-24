using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegoFigures.Equipment
{
    class Armor
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Defense { get; set; }
        public string EquippableOn { get; set; }
        public Armor(string name, string type, int defense, string equippableOn)
        {
            List<string> validEquipList = new List<string>()
            {
                "Torso",
                "Legs",
                "Head"
            };
            if (validEquipList.Contains(equippableOn))
            {
                Name = name;
                Type = type;
                Defense = defense;
                EquippableOn = equippableOn;
            } else
            {
                Console.WriteLine("Armor must be equipped on either: Torso, Legs, or Head");
            }
            
        }
    }
}
