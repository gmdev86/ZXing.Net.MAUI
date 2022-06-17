using Microsoft.Maui.Graphics;
using System;
using ZXing.Net.Maui;

namespace BigIslandBarcode.Controls
{
    public class GraphicsDrawable : IDrawable
    {
        public Color StrokeColor { get; set; } = Colors.White;

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            canvas.StrokeColor = StrokeColor;
            canvas.StrokeSize = 6;

            //top left
            canvas.DrawLine(0, 100, 20, 100);
            canvas.DrawLine(0, 100, 0, 120);

            //top right
            canvas.DrawLine(450, 100, 430, 100);
            canvas.DrawLine(450, 100, 450, 120);

            //bottom left
            canvas.DrawLine(0, 200, 0, 180);
            canvas.DrawLine(0, 200, 20, 200);


            //bottom right
            canvas.DrawLine(450, 200, 450, 180);
            canvas.DrawLine(450, 200, 430, 200);
        }
    }
}
