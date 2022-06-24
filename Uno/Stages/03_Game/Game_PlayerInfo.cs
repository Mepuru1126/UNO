using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uno
{
    internal class Game_PlayerInfo
    {
        public int AllDrawCount;
        public int AllOutCount;

        public List<int> P1_Num;
        public List<int> P2_Num;

        public List<int> P1_Color;
        public List<int> P2_Color;

        public void Init()
        {
            P1_Num = new List<int>();
            P2_Num = new List<int>();
            P1_Color = new List<int>();
            P2_Color = new List<int>();
        }
    }
}
