using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uno
{
    internal class Game_AI
    {
        public void AI()
        {
            int outCardNumber = 0;
            bool isNumberCardPlay = false;

            for (int i = 0; i < Game.gameInfo.PlayerCordCount[1]; i++)
            {
                if (Game.gameInfo.Center_Num[Game.gameInfo.Center_Num.Count() - 1] == Game.gameInfo.P2_Num[i])
                {
                    Console.WriteLine("カードの出し方: 数字");
                    Console.WriteLine($"出すカードの数字: {Game.gameInfo.P2_Num[i]}");
                    Console.WriteLine($"出すカードの色: {Game.gameInfo.P2_Color[i]}");

                    isNumberCardPlay = true;
                    outCardNumber = Game.gameInfo.P2_Num[i];
                    Game.cardOut.CardOut(1, i);
                }
            }

            // 数字で見つからなければ色で出せるか確認して出す
            if (!isNumberCardPlay)
            {
                for (int i = 0; i < Game.gameInfo.P2_Color.Count(); i++)
                {
                    if (Game.gameInfo.Center_Color[Game.gameInfo.Center_Color.Count() - 1] == Game.gameInfo.P2_Color[i])
                    {
                        Console.WriteLine("カードの出し方: 色");
                        Console.WriteLine($"出すカードの数字: {Game.gameInfo.P2_Num[i]}");
                        Console.WriteLine($"出すカードの色: {Game.gameInfo.P2_Color[i]}");

                        isNumberCardPlay = false;
                        Game.cardOut.CardOut(1, i);
                        break;
                    }
                }
            }

            Game.gameInfo.Turn++;
        }
    }
}
