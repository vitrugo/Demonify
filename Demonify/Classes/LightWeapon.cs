using System;
using System.Collections.Generic;
using System.Text;

namespace Demonify.Classes
{
    public class LightWeapon : Items
    {
        public int DMG { get { return this.LVL * 15; } }
        private static string Img { get { return ""; } }
    }
}
