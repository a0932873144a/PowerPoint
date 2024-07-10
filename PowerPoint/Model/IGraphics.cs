using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    public interface IGraphics
    {
        //清除全部
        void ClearAll();

        //畫出線形
        void DrawLine(double x1, double y1, double x2, double y2);

        //畫出橢圓形
        void DrawEllipse(double x1, double y1, double x2, double y2);

        //畫出矩形
        void DrawRectangle(double x1, double y1, double x2, double y2);

        //畫出紅色線形
        void DrawRedLine(double x1, double y1, double x2, double y2);

        //畫出紅色橢圓形
        void DrawRedEllipse(double x1, double y1, double x2, double y2);

        //畫出紅色矩形
        void DrawRedRectangle(double x1, double y1, double x2, double y2);
    }
}
