using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diablo.Weapons
{
    public abstract class Weapon
    {
        public abstract string Name { get; set; }
        public abstract int Damage { get; set; }
        public abstract EWeaponType EWeapon { get; set; }
        public ERarityType ERarity { get; set; }

        public override string ToString()
        {
            return "\nName: " + Name + "\nDamage: " + Damage;
        }
    }
}
