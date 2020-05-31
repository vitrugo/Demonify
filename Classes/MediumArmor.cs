using System;
using System.Collections.Generic;
using System.Text;

namespace Demonify.Classes
{
    public class MediumArmor : Items
    {
        public int DEX { get { return 10 * this.LVL; } }
        public int DEF { get { return 10 * this.LVL; } }
        private static string Img { get { return ""; } }
    }
}
