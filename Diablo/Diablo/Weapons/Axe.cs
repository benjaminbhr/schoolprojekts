using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diablo.Weapons
{
    public class Axe:Weapon
    {
        //This list contains all the predefined magic props that an axe can have.
        public List<string> magicproperties = new List<string>();
        private string name;

        public override string Name
        {
            get { return name; }
            set { name = value; }
        }

        private int damage;

        public override int Damage
        {
            get { return damage; }
            set { damage = value; }
        }


        private EWeaponType eweapon;
        //This gets and sets the Weapon type of the weapon from the enum name EWeaponType
        public override EWeaponType EWeapon { get => eweapon; set => eweapon = value; }

        public Axe(int damage,string name)
        {
            this.Damage = damage;
            this.Name = name;
            magicproperties.Add("10% Damage");
            magicproperties.Add("400 vitality");
            magicproperties.Add("500 Strength");
            magicproperties.Add("500 Dexterity");
            magicproperties.Add("500 Inteligence");
            magicproperties.Add("Attack Speed Increased by 9%");
            magicproperties.Add("Regenerates 100 Life per Second");
            magicproperties.Add("45% Critical strike chance");
            magicproperties.Add("50% Critical strike multiplier");
            magicproperties.Add("Chance to Deal 20% area damage on Hit");
            magicproperties.Add("500 Life per Hit");
            magicproperties.Add("Reduces Cooldown of all Skills by 10%");
            magicproperties.Add("Reduces all Resource Costs by 20%");
            magicproperties.Add("Sockets 1");
            magicproperties.Add("Chance to Inflict Bleed for 10% Weapon Damage over 10 Seconds");
        }


        public override string ToString()
        {
            return base.ToString();
        }

    }
}
