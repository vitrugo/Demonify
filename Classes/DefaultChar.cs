using System;
using System.Collections.Generic;
using System.Text;

namespace Demonify.Classes
{
    public class DefaultChar
    {
        public DefaultChar(int strenght, int defense, int dexterity, int wisdom, string nick)
        {
            this.Name = nick;
            this.Str = strenght;
            this.Def = defense;
            this.Dex = dexterity;
            this.Wis = wisdom;
            this.LVL = 1;
        }
        public String Name { get; set; }
        public int Str { get; set; }
        public int Def { get; set; }
        public int Dex { get; set; }
        public int Wis { get; set; }
        public int HP { get { return 100 * LVL; } }
        public int MP { get { return 5 * Wis; } }
        public int LVL { get; set; }
        public int XP { get; set; }

    }
}
