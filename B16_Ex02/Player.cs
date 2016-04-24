using System;
using System.Collections.Generic;
using System.Text;

namespace B16_Ex02
{
    internal class Player
    {
        public readonly string r_name;
        private int m_score ;
        private bool m_isHuman;

        public int Score
        {
            get
            {
                return m_score;
            }
            set
            {
                m_score = value;
            }
        }

        public Player(string i_name, bool i_isHuman)
        {
            m_isHuman = i_isHuman;
            r_name = i_name;
            m_score = 0;
        }

        public virtual int SelectColumn()
        {
            return 0;
        }
    }
}
