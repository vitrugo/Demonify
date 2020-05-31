using System;
using System.Collections.Generic;
using System.Text;

namespace Demonify.Classes
{
    public class MediumWeapon : Items
    {
        public int DMG { get { return this.LVL * 5; } }
        private static string Img { get { return ""; } }
    }
}
