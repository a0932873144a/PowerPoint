using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    interface IState
    {
        //滑鼠點擊
        void ClickMouse(double pointX, double pointY);

        //滑鼠按壓
        void PressMouse(Factory.ShapeType shapeType, double pointX, double pointY);

        //滑鼠移動
        void MoveMouse(double pointX, double pointY);
        
        //滑鼠放開
        void ReleaseMouse(Factory.ShapeType shapeType, double pointX, double pointY);
    }
}
