namespace Uno
{
    internal class Game_CardOut
    {
        public void CardOut(int playerIndex, int outIndex)
        {
            var info = Game.gameInfo;

            switch (playerIndex)
            {
                case 0:
                    info.Center_Num.Add(info.P1_Num[outIndex]);
                    info.Center_Color.Add(info.P1_Color[outIndex]);
                    info.P1_Num.RemoveAt(outIndex);
                    info.P1_Color.RemoveAt(outIndex);
                    break;

                case 1:
                    info.Center_Num.Add(info.P2_Num[outIndex]);
                    info.Center_Color.Add(info.P2_Color[outIndex]);
                    info.P2_Num.RemoveAt(outIndex);
                    info.P2_Color.RemoveAt(outIndex);
                    break;
            }

            info.PlayerCordCount[playerIndex]--;
        }
    }
}
