using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace PowerPoint.PresentationModel
{
    class WindowsFormsGraphicsAdaptor : IGraphics
    {
        Graphics _graphics;
        const int RED_PEN_SIZE = 3;
        Pen _redPen = new Pen(Color.Red, RED_PEN_SIZE);

        public WindowsFormsGraphicsAdaptor(Graphics graphics)
        {
            this._graphics = graphics;
        }

        //清除全部
        public void ClearAll()
        {
            _graphics.Clear(Color.White);
        }

        //畫出線形
        public void DrawLine(double x1, double y1, double x2, double y2)
        {
            _graphics.DrawLine(Pens.Black, (float)x1, (float)y1, (float)x2, (float)y2);
        }

        //畫出矩形
        public void DrawRectangle(double x1, double y1, double x2, double y2)
        {
            _graphics.DrawRectangle(Pens.Black, (float)x1, (float)y1, (float)x2, (float)y2);
        }

        //畫出橢圓形
        public void DrawEllipse(double x1, double y1, double x2, double y2)
        {
            _graphics.DrawEllipse(Pens.Black, (float)x1, (float)y1, (float)x2, (float)y2);
        }

        //畫出紅色線形
        public void DrawRedLine(double x1, double y1, double x2, double y2)
        {
            _graphics.DrawLine(_redPen, (float)x1, (float)y1, (float)x2, (float)y2);
        }

        //畫出紅色矩形
        public void DrawRedRectangle(double x1, double y1, double x2, double y2)
        {
            _graphics.DrawRectangle(_redPen, (float)x1, (float)y1, (float)x2, (float)y2);
        }

        //畫出紅色橢圓形
        public void DrawRedEllipse(double x1, double y1, double x2, double y2)
        {
            _graphics.DrawEllipse(_redPen, (float)x1, (float)y1, (float)x2, (float)y2);
        }
    }
}
