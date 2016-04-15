using System;
using System.Collections.Generic;
using System.Text;

namespace B16_Ex02
{
    internal class Player
    {
        public readonly string r_name;
        public Player(string i_name)
        {
            r_name = i_name;
        }

        public virtual int SelectColumn()
        {
            return 0;
        }
    }
}
