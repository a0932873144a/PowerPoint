using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("PowerPointTests")]
[assembly: InternalsVisibleTo("ViewModelTests")]
namespace PowerPoint
{
    internal class Model
    {
        public event ModelChangedEventHandler _modelChanged;
        public delegate void ModelChangedEventHandler();
        internal CommandManager _commandManager = new CommandManager();
        internal bool _isPressed = false;
        internal Shape _shape;
        internal BindingList<Shape> _shapeList = new BindingList<Shape>();
        internal Mode _mode = Mode.Pointer;
        internal bool _isSelected = false;
        internal int _currentSelect = -1;
        internal Shape _selectedShape;
        internal double[] _tempInfo;
        internal bool _isScaling = false;
        internal IState _state;
        const int FIRST_INFORMATION = 0;
        const int SECOND_INFORMATION = 1;
        const int THIRD_INFORMATION = 2;
        const int FOURTH_INFORMATION = 3;
        const int INFORMATION_SIZE = 4;
        const int SCALE_RANGE = 5;

        internal enum Mode
        {
            Pointer,
            Drawing
        }

        public BindingList<Shape> _shapes
        {
            get
            {
                return _shapeList;
            }
        }

        //變為一般模式
        public void SetPointerMode()
        {
            _mode = Mode.Pointer;
            _state = new PointerState(this);
            NotifyModelChanged();
        }

        //變為繪圖模式
        public void SetDrawingMode()
        {
            _mode = Mode.Drawing;
            _state = new DrawingState(this);
            NotifyModelChanged();
        }

        //滑鼠點擊
        public void ClickMouse(double pointX, double pointY)
        {
            _state.ClickMouse(pointX, pointY);
            NotifyModelChanged();
        }

        //滑鼠按壓
        public void PressMouse(Factory.ShapeType shapeType, double pointX, double pointY)
        {
            _state.PressMouse(shapeType, pointX, pointY);
            NotifyModelChanged();
        }

        //滑鼠移動
        public void MoveMouse(double pointX, double pointY)
        {
            _state.MoveMouse(pointX, pointY);
            NotifyModelChanged();
        }

        //滑鼠放開
        public void ReleaseMouse(Factory.ShapeType shapeType, double pointX, double pointY)
        {
            _state.ReleaseMouse(shapeType, pointX, pointY);
            NotifyModelChanged();
        }

        //排序位置資訊
        public double[] SortInfo(double[] info)
        {
            double[] sortedInfo = new double[INFORMATION_SIZE];
            if (info[FIRST_INFORMATION] < info[THIRD_INFORMATION])
            {
                sortedInfo[FIRST_INFORMATION] = info[FIRST_INFORMATION];
                sortedInfo[THIRD_INFORMATION] = info[THIRD_INFORMATION];
            }
            else
            {
                sortedInfo[FIRST_INFORMATION] = info[THIRD_INFORMATION];
                sortedInfo[THIRD_INFORMATION] = info[FIRST_INFORMATION];
            }
            if (info[SECOND_INFORMATION] < info[FOURTH_INFORMATION])
            {
                sortedInfo[SECOND_INFORMATION] = info[SECOND_INFORMATION];
                sortedInfo[FOURTH_INFORMATION] = info[FOURTH_INFORMATION];
            }
            else
            {
                sortedInfo[SECOND_INFORMATION] = info[FOURTH_INFORMATION];
                sortedInfo[FOURTH_INFORMATION] = info[SECOND_INFORMATION];
            }
            return sortedInfo;
        }

        //清空全部
        public void Clear()
        {
            _isPressed = false;
            _shapeList.Clear();
            NotifyModelChanged();
        }

        //畫圖
        public void Draw(IGraphics graphics)
        {
            graphics.ClearAll();
            foreach (Shape aShape in _shapeList)
                aShape.Draw(graphics);
            if (_isPressed)
                if (_shape != null)
                    _shape.Draw(graphics);
            if (_isSelected)
                _selectedShape.DrawRed(graphics);
        }

        //提醒Model更變
        public void NotifyModelChanged()
        {
            if (_modelChanged != null)
                _modelChanged();
        }

        //用新增按鈕創建圖形
        public Shape AddShapeButton(Factory.ShapeType shapeType)
        {
            Shape shape = Factory.AddShapeButton(shapeType);
            if (shape != null)
            {
                _commandManager.Execute(new DrawCommand(this, shape));
                return shape;
            }
            return null;
        }

        //用刪除按鈕刪除圖形
        public bool DeleteShapeButton(int index)
        {
            _isSelected = false;
            if (index < 0 || index >= _shapeList.Count)
            {
                return false;
            }
            _shapeList.RemoveAt(index);
            NotifyModelChanged();
            return true;
        }

        //用鍵盤刪除選取圖案
        public void DeleteSelectedShape()
        {
            if (_isSelected && _currentSelect >= 0 && _mode == Mode.Pointer)
            {
                DeleteShapeButton(_currentSelect);
                _isSelected = false;
                _currentSelect = -1;
            }
        }

        //圖形是否處於選擇中可被拖移的狀態
        public bool IsScaling(double pointX, double pointY)
        {
            if (_isSelected)
            {
                Double[] sortedInfo = SortInfo(_tempInfo);
                if (sortedInfo[THIRD_INFORMATION] - SCALE_RANGE <= pointX && sortedInfo[THIRD_INFORMATION] + SCALE_RANGE >= pointX && sortedInfo[FOURTH_INFORMATION] - SCALE_RANGE <= pointY && sortedInfo[FOURTH_INFORMATION] + SCALE_RANGE >= pointY)
                    return true;
            }
            return false;
        }

        //取得isScaling狀態
        public bool IsScale()
        {
            return _isScaling;
        }

        //把新圖形加入list
        public void AddShape(Shape shape)
        {
            _shapeList.Add(shape);
            NotifyModelChanged();
        }

        //取得圖形畫圖
        public void DeleteShape()
        {
            _shapeList.RemoveAt(_shapeList.Count - 1);
            NotifyModelChanged();
        }

        //復原
        public void Undo()
        {
            _commandManager.Undo();
        }

        //重做
        public void Redo()
        {
            _commandManager.Redo();
        }

        //是否可以重做
        public bool IsRedoEnabled
        {
            get
            {
                return _commandManager.IsRedoEnabled;
            }
        }

        //是否可以復原
        public bool IsUndoEnabled
        {
            get
            {
                return _commandManager.IsUndoEnabled;
            }
        }
    }
}
