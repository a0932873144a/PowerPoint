using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    public class Ellipse : Shape
    {
        public Ellipse()
        {
            const string ELLIPSE = "橢圓形";
            SetShapeName(ELLIPSE);
        }

        //畫出橢圓形
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawEllipse(_pointX1, _pointY1, _pointX2, _pointY2);
        }

        //畫出紅色橢圓形
        public override void DrawRed(IGraphics graphics)
        {
            graphics.DrawRedEllipse(_pointX1, _pointY1, _pointX2, _pointY2);
        }
    }
}
