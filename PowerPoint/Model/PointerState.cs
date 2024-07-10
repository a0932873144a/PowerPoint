using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    internal class PointerState : IState
    {
        internal Model _model;
        internal double _firstPointX = -1;
        internal double _firstPointY = -1;
        internal bool _isPressed = false;
        internal double[] _tempInfo;
        const int FIRST_INFORMATION = 0;
        const int SECOND_INFORMATION = 1;
        const int THIRD_INFORMATION = 2;
        const int FOURTH_INFORMATION = 3;
        const string LINE = "線";

        public PointerState(Model model)
        {
            _model = model;
        }

        //滑鼠點擊
        public void ClickMouse(double pointX, double pointY)
        {
            BindingList<Shape> shapeList = _model._shapes;
            foreach (Shape aShape in shapeList)
            {
                _model._tempInfo = _tempInfo = aShape.GetInformationNumber();
                Double[] sortedInfo = _model.SortInfo(_tempInfo);
                if (sortedInfo[FIRST_INFORMATION] <= pointX && sortedInfo[SECOND_INFORMATION] <= pointY && sortedInfo[THIRD_INFORMATION] >= pointX && sortedInfo[FOURTH_INFORMATION] >= pointY && !_model._isSelected)
                {
                    _model._currentSelect = shapeList.IndexOf(aShape);
                    _model._selectedShape = shapeList[_model._currentSelect];
                    _model._isSelected = true;
                    break;
                }
                else
                {
                    _model._currentSelect = -1;
                    _model._isSelected = false;
                }
            }
        }

        //滑鼠按壓
        public void PressMouse(Factory.ShapeType shapeType, double pointX, double pointY)
        {
            _model._isScaling = false;
            if (pointX > 0 && pointY > 0)
            {
                _isPressed = _model._isPressed = true;
                _firstPointX = pointX;
                _firstPointY = pointY;
                if (_model.IsScaling(pointX, pointY))
                    _model._isScaling = true;
            }
        }

        //滑鼠移動
        public void MoveMouse(double pointX, double pointY)
        {
            if (_model.IsScale())
            {
                if (_isPressed && _model._isSelected && _model._currentSelect >= 0)
                {
                    _model._selectedShape.SetInformation(_model._tempInfo[FIRST_INFORMATION], _model._tempInfo[SECOND_INFORMATION], pointX, pointY);
                    _model._shapeList[_model._currentSelect] = _model._selectedShape;
                }
            }
            else
            {
                if (_isPressed && _model._isSelected && pointX > 0 && pointY > 0 && _model._currentSelect >= 0)
                {
                    double distanceX = pointX - _firstPointX;
                    double distanceY = pointY - _firstPointY;
                    if (_model._selectedShape.GetShapeName() == LINE)
                        _model._selectedShape.SetInformation(_model._tempInfo[FIRST_INFORMATION] + distanceX, _model._tempInfo[SECOND_INFORMATION] + distanceY, _model._tempInfo[THIRD_INFORMATION] + distanceX, _model._tempInfo[FOURTH_INFORMATION] + distanceY);
                    else
                        _model._selectedShape.SetInformation(_model._tempInfo[FIRST_INFORMATION] + distanceX, _model._tempInfo[SECOND_INFORMATION] + distanceY, _model._tempInfo[THIRD_INFORMATION], _model._tempInfo[FOURTH_INFORMATION]);
                    _model._shapeList[_model._currentSelect] = _model._selectedShape;
                }
            }
        }

        //滑鼠放開
        public void ReleaseMouse(Factory.ShapeType shapeType, double pointX, double pointY)
        {
            _model._shape = null;
            _isPressed = _model._isPressed = false;
            if (_isPressed && _model._isSelected && pointX > 0 && pointY > 0)
            {
                double distanceX = pointX - _firstPointX;
                double distanceY = pointY - _firstPointY;
                if (_model.IsScale())
                {
                    _model._selectedShape.SetInformation(_model._tempInfo[FIRST_INFORMATION], _model._tempInfo[SECOND_INFORMATION], _model._tempInfo[THIRD_INFORMATION] + distanceX, _model._tempInfo[FOURTH_INFORMATION] + distanceY);
                }
                else
                {
                    _model._selectedShape.SetInformation(_model._tempInfo[FIRST_INFORMATION] + distanceX, _model._tempInfo[SECOND_INFORMATION] + distanceY, _model._tempInfo[THIRD_INFORMATION] + distanceX, _model._tempInfo[FOURTH_INFORMATION] + distanceY);
                    if (_model._selectedShape.GetShapeName() == LINE)
                        _model._selectedShape.SetInformation(_model._tempInfo[FIRST_INFORMATION] + distanceX, _model._tempInfo[SECOND_INFORMATION] + distanceY, _model._tempInfo[THIRD_INFORMATION] + distanceX, _model._tempInfo[FOURTH_INFORMATION] + distanceY);
                    else
                        _model._selectedShape.SetInformation(_model._tempInfo[FIRST_INFORMATION] + distanceX, _model._tempInfo[SECOND_INFORMATION] + distanceY, _model._tempInfo[THIRD_INFORMATION], _model._tempInfo[FOURTH_INFORMATION]);
                }
                _model._isScaling = false;
                _model._shapeList[_model._currentSelect] = _model._selectedShape;
            }
            _firstPointX = _firstPointY = -1;
        }
    }
}
