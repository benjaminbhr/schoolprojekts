using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Diablo
{
    class Program
    {
        public static void PrintProperties(object obj)
        {
            foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(obj))
            {
                string name = descriptor.Name;
                object value = descriptor.GetValue(obj);
                string zerovalue = value.ToString();
                if (zerovalue != "0")
                {
                    Console.WriteLine("{0}: {1}", name, value);
                }
                else
                {

                }
            }
            Console.WriteLine("\n");
        }
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
