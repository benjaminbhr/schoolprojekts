using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Characters
{
    interface ICharacter
    {
        void Die();
        void Fight();
        void Heal();
    }
}
