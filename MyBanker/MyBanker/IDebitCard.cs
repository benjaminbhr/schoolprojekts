using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBanker
{
    public interface IDebitCard
    {
        int AgeRequirement { get; set; }
        bool InternationalUse { get; set; }
        bool InternetUse { get; set; }
    }
}
