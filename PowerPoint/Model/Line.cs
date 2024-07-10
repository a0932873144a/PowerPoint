using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    public class Line : Shape
    {
        public Line() 
        {
            const string LINE = "線";
            SetShapeName(LINE);
        }

        //畫出線形
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawLine(_pointX1, _pointY1, _pointX2, _pointY2);
        }

        //畫出紅色線形
        public override void DrawRed(IGraphics graphics)
        {
            graphics.DrawRedLine(_pointX1, _pointY1, _pointX2, _pointY2);
        }
    }
}
