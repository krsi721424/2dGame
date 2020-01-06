using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2DGame.Engine
{
    class UserInputController
    {
        private static Hashtable m_KeyTable = new Hashtable();

        public static bool KeyPressed(Keys i_Key)
        {
            if (m_KeyTable[i_Key] == null)
            {
                return false;
            }

            return (bool)m_KeyTable[i_Key];
        }

        public static void ChangeState(Keys key, bool state)
        {
            m_KeyTable[key] = state;
        }
    }
}
