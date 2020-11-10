using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Characters
{
    interface IWitch
    {
        void RaiseShield();
        void ShieldGlare();
        void Teleport(int x, int y);
        void ThrowFrostNova();
        void ThrowMagicMisile();
    }
}
