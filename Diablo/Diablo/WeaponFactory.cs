using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diablo
{
    public class WeaponFactory
    {
        //This is so my number generator doesn't use the same seed, so i've made a single instance of GetRandom to ensure i get random numbers.
        private Random GetRandom { get; set; }
        private int RandomNumber()
        {
            return this.GetRandom.Next(0, 14);
        }

        /// <summary>
        /// This method is responsible for creating the different weapons, it takes a type,rarity,name and will then form a weapon randomly from the properties allowed for that rarity.
        /// </summary>
        /// <param name="type">Weapon Type</param>
        /// <param name="rarity">Rarity type</param>
        /// <param name="name">Weapon name</param>
        /// <returns>Weapon object</returns>
        public Weapons.Weapon Create(EWeaponType type, ERarityType rarity,string name)
        {
            if (rarity == ERarityType.normal)
            {
                if (type == EWeaponType.twohandaxe)
                {
                    Weapons.Weapon axe = new Weapons.TwoHandAxe(3000, name, 15);
                    axe.ERarity = rarity;
                    return axe;
                }
                else if (type == EWeaponType.throwingaxe)
                {
                    Weapons.Weapon axe = new Weapons.ThrowingAxe(3000, name, 15);
                    axe.ERarity = rarity;
                    return axe;
                }
            }
            else if (rarity == ERarityType.magic)
            {
                if (type == EWeaponType.twohandaxe)
                {
                    Weapons.Weapon axe = new Weapons.TwoHandAxe(3000, name, 15);
                    for (int i = 0; i < 3; i++)
                    {
                        string temp = ((Weapons.Axe)axe).magicproperties.ElementAt(RandomNumber());
                        ((Weapons.TwoHandAxe)axe).magic.Add(temp);
                    }
                    axe.ERarity = rarity;
                    return axe;
                }
                else if (type == EWeaponType.throwingaxe)
                {
                    Weapons.Weapon axe = new Weapons.ThrowingAxe(3000, name, 15);
                    for (int i = 0; i < 3; i++)
                    {
                        string temp = ((Weapons.Axe)axe).magicproperties.ElementAt(RandomNumber());
                        ((Weapons.ThrowingAxe)axe).magic.Add(temp);
                    }
                    axe.ERarity = rarity;
                    return axe;
                }
            }
            else if (rarity == ERarityType.rare)
            {
                if (type == EWeaponType.twohandaxe)
                {
                    Weapons.Weapon axe = new Weapons.TwoHandAxe(3000,name,15);
                    for (int i = 0; i < 5; i++)
                    {
                        string temp = ((Weapons.Axe)axe).magicproperties.ElementAt(RandomNumber());
                        ((Weapons.TwoHandAxe)axe).magic.Add(temp);
                    }
                    axe.ERarity = rarity;
                    return axe;
                }
                else if (type == EWeaponType.throwingaxe)
                {
                    Weapons.Weapon axe = new Weapons.ThrowingAxe(3000, name, 15);
                    for (int i = 0; i < 5; i++)
                    {
                        string temp = ((Weapons.Axe)axe).magicproperties.ElementAt(RandomNumber());
                        ((Weapons.ThrowingAxe)axe).magic.Add(temp);
                    }
                    axe.ERarity = rarity;
                    return axe;
                }
            }
            return new Weapons.Axe(1000,name);
        }
        public WeaponFactory()
        {
            this.GetRandom = new Random();
        }
    }
}
