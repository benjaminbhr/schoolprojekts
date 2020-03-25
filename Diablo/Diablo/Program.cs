using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diablo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Weapons.Weapon> weapons = new List<Weapons.Weapon>();
            WeaponFactory factory = new WeaponFactory();
            Weapons.Weapon wep1 = factory.Create(EWeaponType.twohandaxe, ERarityType.normal, "Axe of Bear instinct");
            Weapons.Weapon wep2 = factory.Create(EWeaponType.throwingaxe, ERarityType.magic, "Flesh Tearer");
            Weapons.Weapon wep3 = factory.Create(EWeaponType.twohandaxe, ERarityType.rare, "Bullova");
            Weapons.Weapon wep4 = factory.Create(EWeaponType.throwingaxe, ERarityType.rare, "Adze");
            weapons.Add(wep1);
            weapons.Add(wep2);
            weapons.Add(wep3);
            weapons.Add(wep4);
            foreach (Weapons.Weapon weapon in weapons)
            {
                Console.WriteLine(weapon.ToString());
            }
            Console.ReadLine();
        }
    }
}
