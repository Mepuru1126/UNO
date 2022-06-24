using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Uno
{
    internal class Card
    {
        public void DrawCard(int x, int y, int num, int color, float scale, float rotate)
        {
            ChangeScale(Program.tx.Game_CardBase, scale);
            ChangeScale(Program.tx.Game_CardColor[color], scale);
        }

        private void ChangeScale(Texture texture ,float scale)
        { 
            texture.ScaleX = scale;
            texture.ScaleY = scale;
        }
    }
}
