using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegoFigures.Equipment
{
    class Accessory
    {
        public string Name { get; set; }
        public int Value { get; private set; }
        public bool Magical { get; private set; }
        public int MagicPower { get; set; }
        public int AttackPower { get; set; }

        public Accessory(string name, int value, bool magical)
        {
            Name = name;
            Value = value;
            Magical = magical;
            if (magical)
            {
                MagicPower = 10;
            } else
            {
                AttackPower = 10;
            }
        }

    }
}
