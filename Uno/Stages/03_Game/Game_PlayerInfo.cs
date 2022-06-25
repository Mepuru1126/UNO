using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uno
{
    internal class Game_PlayerInfo
    {
        public readonly int PlayerNum = 2;

        public int AllDrawCount;
        public int AllOutCount;

        public int[] PlayerCordCount;

        public int[] Deck_Num;
        public int[] Deck_Color;

        public List<int> P1_Num;
        public List<int> P2_Num;

        public List<int> P1_Color;
        public List<int> P2_Color;

        public List<double> CardJump;
        public List<bool> isJump;

        public void Init()
        {
            AllDrawCount = 0;
            AllOutCount = 0;

            PlayerCordCount = new int[PlayerNum];
            Deck_Num = new int[110];
            Deck_Color = new int[110];

            P1_Num = new List<int>();
            P2_Num = new List<int>();
            P1_Color = new List<int>();
            P2_Color = new List<int>();

            CardJump = new List<double>();
            isJump = new List<bool>();

            int[] arrayNum = new int[110];
            for (int i = 0; i < 11; i++)
            {
                for(int j = 0; j < 10; j++)
                    arrayNum[i * 10 + j] = i + 1;
            }

            int[] arrayColor = new int[110];
            for (int i = 0; i < 4; i++)
            {
                for(int j = 0; j < (int)(110 / 4); j++)
                    arrayColor[i * (int)(110 / 4) + j] = i;
            }

            Random r = new Random();
            Deck_Num = arrayNum.OrderBy(i => r.Next()).ToArray();
            Deck_Color = arrayColor.OrderBy(i => r.Next()).ToArray();
            r = null;
        }
    }
}
