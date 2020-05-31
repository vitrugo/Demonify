using System;
using System.Collections.Generic;
using System.Text;

namespace Demonify.Classes
{
    public class LightArmor : Items
    {
        public int WIS { get { return 10 * this.LVL; } }
        public int DEF { get { return 5 * this.LVL; } }
        private static string Img { get { return ""; } }
    }
}
