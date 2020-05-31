using System;
using System.Collections.Generic;
using System.Text;

namespace Demonify.Classes
{
    public class HeavyWeapon : Items
    {
        public int DMG { get { return this.LVL * 10; } }
        private static string Img { get { return ""; } }
    }
}
