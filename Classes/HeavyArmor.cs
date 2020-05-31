using System;
using System.Collections.Generic;
using System.Text;

namespace Demonify.Classes
{
    public class HeavyArmor : Items
    {
        public int STR { get { return 10 * this.LVL; } }
        public int DEF { get { return 20 * this.LVL; } }
        private static string Img { get { return ""; } }
    }
}
