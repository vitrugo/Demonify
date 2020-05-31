using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Demonify.Classes
{
    public class Items
    {
        private int _lvl;
        public int LVL
        { 
            get
            {
                return _lvl;
            } 
            set
            { 
                _lvl = value;
            } }
        public string Name { get; set; }
        public int Slot { get; set; }
        public int Cost { get { return (int)(0.25 * (this._lvl * 100)); } }
    }
}
