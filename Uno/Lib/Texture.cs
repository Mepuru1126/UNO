using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using static DxLibDLL.DX;

namespace Uno
{
    internal class Texture : IDisposable
    {
        public Texture(string path)
        {
            texture = LoadGraph(path);
            Opacity = 255;
            ScaleX = 1.0f;
            ScaleY = 1.0f;
            Rotate = 0.0f;
        }

        ~Texture()
        {
            Dispose();
        }

        public void Draw(double x, double y, Rectangle? rectangle = null)
        {
            var origin = new Point();

            if (rectangle == null)
            {
                rectangle = new Rectangle(0, 0, Program.windowSize.Width, Program.windowSize.Height);
            }

            switch (DrawPoint)
            {
                case drawpoints.TopLeft:
                    origin.X = 0;
                    origin.Y = 0;
                    break;

                case drawpoints.TopCenter:
                    origin.X = TextureSize.Width / 2;
                    origin.Y = 0;
                    break;

                case drawpoints.TopRight:
                    origin.X = TextureSize.Width;
                    origin.Y = 0;
                    break;

                case drawpoints.CenterLeft:
                    origin.X = 0;
                    origin.Y = TextureSize.Height / 2;
                    break;

                case drawpoints.Center:
                    origin.X = TextureSize.Width / 2;
                    origin.Y = TextureSize.Height / 2;
                    break;

                case drawpoints.CenterRight:
                    origin.X = TextureSize.Width;
                    origin.Y = TextureSize.Height / 2;
                    break;

                case drawpoints.BottomLeft:
                    origin.X = 0;
                    origin.Y = TextureSize.Height;
                    break;

                case drawpoints.BottomCenter:
                    origin.X = TextureSize.Width / 2;
                    origin.Y = TextureSize.Height;
                    break;

                case drawpoints.BottomRight:
                    origin.X = TextureSize.Width;
                    origin.Y = TextureSize.Height;
                    break;
            }

            SetDrawBlendMode(DX_BLENDMODE_ALPHA, (int)Opacity);

            if (ScaleX == 1.0f && ScaleY == 1.0f)
            {
                DrawRectRotaGraph2F(
                    (float)x,
                    (float)y,
                    rectangle.Value.X,
                    rectangle.Value.Y,
                    rectangle.Value.Width,
                    rectangle.Value.Height,
                    origin.X,
                    origin.Y,
                    1.0f,
                    Rotate,
                    texture,
                    TRUE);
            }
            else
            {
                DrawRectRotaGraph3F(
                    (float)x,
                    (float)y,
                    rectangle.Value.X,
                    rectangle.Value.Y,
                    rectangle.Value.Width,
                    rectangle.Value.Height,
                    origin.X,
                    origin.Y,
                    ScaleX,
                    ScaleY,
                    Rotate,
                    texture,
                    TRUE);
            }

            SetDrawBlendMode(DX_BLENDMODE_NOBLEND, 0);
        }

        public void Dispose()
        {
            if (texture != -1)
            {
                DeleteGraph(texture);
            }
        }

        private int texture { get; set; }

        public float Opacity { get; set; }
        public float ScaleX { get; set; }
        public float ScaleY { get; set; }
        public float Rotate { get; set; }

        public Size TextureSize
        {
            get
            {
                GetGraphSize(texture ,out int width, out int heigth);
                return new Size(width, heigth);
            }
        }
        public drawpoints DrawPoint { get; set; }

        public enum drawpoints
        {
            /// <summary>
            /// 左上
            /// </summary>
            TopLeft,

            /// <summary>
            /// 中央上
            /// </summary>
            TopCenter,

            /// <summary>
            /// 右上
            /// </summary>
            TopRight,

            /// <summary>
            /// 左中央
            /// </summary>
            CenterLeft,

            /// <summary>
            /// 中央
            /// </summary>
            Center,

            /// <summary>
            /// 右中央
            /// </summary>
            CenterRight,

            /// <summary>
            /// 左下
            /// </summary>
            BottomLeft,

            /// <summary>
            /// 中央下
            /// </summary>
            BottomCenter,

            /// <summary>
            /// 右下
            /// </summary>
            BottomRight
        }
    }
}
