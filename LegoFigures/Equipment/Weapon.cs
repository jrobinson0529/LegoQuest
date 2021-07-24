using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegoFigures.Equipment
{
    class Weapon
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int AttackPower { get; set; }
        public string EquippableBy { get; set; }
        public Weapon(string name, string type, int attackPower, string equippableBy)
        {
            Name = name;
            Type = type;
            AttackPower = attackPower;
            EquippableBy = equippableBy;
        }
    }
}
