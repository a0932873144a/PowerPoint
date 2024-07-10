using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    public class Rectangle : Shape
    {
        public Rectangle()
        {
            const string RECTANGLE = "矩形";
            SetShapeName(RECTANGLE);
        }

        //畫出矩形
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawRectangle(_pointX1, _pointY1, _pointX2, _pointY2);
        }

        //畫出紅色矩形
        public override void DrawRed(IGraphics graphics)
        {
            graphics.DrawRedRectangle(_pointX1, _pointY1, _pointX2, _pointY2);
        }
    }
}
