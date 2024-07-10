using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    internal class DrawingState : IState
    {
        internal Model _model;
        internal Shape _shape;
        internal bool _isPressed = false;
        internal double _firstPointX = -1;
        internal double _firstPointY = -1;
        const string LINE = "線";

        public DrawingState(Model model)
        {
            _model = model;
        }

        //滑鼠點擊
        public void ClickMouse(double pointX, double pointY)
        {
        }

        //滑鼠按壓
        public void PressMouse(Factory.ShapeType shapeType, double pointX, double pointY)
        {
            _shape = Factory.CreateShape(shapeType);
            _model._shape = _shape;
            if (pointX > 0 && pointY > 0)
            {
                _isPressed = _model._isPressed = true;
                _firstPointX = pointX;
                _firstPointY = pointY;
            }
        }

        //滑鼠移動
        public void MoveMouse(double pointX, double pointY)
        {
            if (_isPressed && pointX > 0 && pointY > 0)
            {
                if (_shape.GetShapeName() == LINE)
                    _shape.SetInformation(_firstPointX, _firstPointY, pointX, pointY);
                else
                    _shape.SetInformation(_firstPointX, _firstPointY, pointX - _firstPointX, pointY - _firstPointY);
            }
        }

        //滑鼠放開
        public void ReleaseMouse(Factory.ShapeType shapeType, double pointX, double pointY)
        {
            _model._shape = null;
            if (_isPressed && pointX > 0 && pointY > 0)
            {
                _isPressed = _model._isPressed = false;
                Shape shape = Factory.CreateShape(shapeType);
                if (shape.GetShapeName() == LINE)
                    shape.SetInformation(_firstPointX, _firstPointY, pointX, pointY);
                else
                    shape.SetInformation(_firstPointX, _firstPointY, pointX - _firstPointX, pointY - _firstPointY);
                _model._commandManager.Execute(new DrawCommand(_model, shape));
            }
            _firstPointX = _firstPointY = -1;
        }
    }
}
