namespace Uno
{
    internal class Card
    {
        public void DrawCard(int x, int y, int num, int color, float scale, float rotate, Texture.drawpoints point = Texture.drawpoints.TopLeft)
        {
            ChangeScale(Program.tx.Game_CardBase, scale);
            ChangeScale(Program.tx.Game_CardColor[color], scale);
            ChangeScale(Program.tx.Game_CardNum[num], scale);

            Program.tx.Game_CardBase.Rotate = rotate;
            Program.tx.Game_CardColor[color].Rotate = rotate;
            Program.tx.Game_CardNum[num].Rotate = rotate;

            Program.tx.Game_CardBase.DrawPoint = point;
            Program.tx.Game_CardColor[color].DrawPoint = point;
            Program.tx.Game_CardNum[num].DrawPoint = point;

            Program.tx.Game_CardBase.Draw(x, y);
            Program.tx.Game_CardColor[color].Draw(x, y);
            Program.tx.Game_CardNum[num].Draw(x, y);
        }

        private void ChangeScale(Texture texture, float scale)
        {
            texture.ScaleX = scale;
            texture.ScaleY = scale;
        }
    }
}
