using System;
using System.Collections.Generic;
using System.Text;

namespace Demonify.Classes
{
    public static class Inventory
    {
        public static List<Items> Inv = new List<Items> 
        {
            new MediumArmor { Name = "Iron Cuirass", LVL = 1 },
            new MediumWeapon { Name = "Iron Dagger", LVL = 1}
        };
        public static Items slot1 = null;
        public static Items slot2 = null;
    }
}
