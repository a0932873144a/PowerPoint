using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PowerPoint.PresentationModel;

[assembly: InternalsVisibleTo("ViewModelTests")]
namespace PowerPoint
{
    internal class ViewModel
    {
        internal Model _model;
        internal bool _isDrawing = false;
        internal bool _isPointer = true;
        internal bool _isRectangleEnabled = false;
        internal bool _isLineEnabled = false;
        internal bool _isEllipseEnabled = false;

        public ViewModel(Model model)
        {
            this._model = model;
        }

        //畫圖
        public void Draw(Graphics graphics)
        {
            // graphics物件是Paint事件帶進來的，只能在當次Paint使用
            // 而Adaptor又直接使用graphics，這樣DoubleBuffer才能正確運作
            // 因此，Adaptor不能重複使用，每次都要重新new
            _model.Draw(new WindowsFormsGraphicsAdaptor(graphics));
        }

        //重回預設狀態
        public void ResetState() 
        {
            _isDrawing = false;
            _isPointer = true;
            _isRectangleEnabled = false;
            _isLineEnabled = false;
            _isEllipseEnabled = false;
            _model.SetPointerMode();
        }

        public bool _pointer 
        {
            get
            {
                return _isPointer;
            }
        }

        //確認是否為繪圖模式
        public bool IsDrawingEnabled()
        {
            if (_isEllipseEnabled || _isLineEnabled || _isRectangleEnabled)
            {
                if (_isDrawing && !_isPointer)
                {
                    return true;
                }
            }
            return false;
        }

        //確認是否為矩形模式
        public bool IsRectangleEnabled()
        {
            return _isRectangleEnabled;
        }

        //確認是否為線形模式
        public bool IsLineEnabled()
        {
            return _isLineEnabled;
        }

        //確認是否為橢圓形模式
        public bool IsEllipseEnabled()
        {
            return _isEllipseEnabled;
        }

        //繪圖中
        public void StartDrawing() 
        {
            _isDrawing = true;
            _isPointer = false;
            _model.SetDrawingMode();
        }

        //矩形繪圖模式
        public void BeingRectangleMode() 
        {
            _isRectangleEnabled = true;
            _isLineEnabled = false;
            _isEllipseEnabled = false;
            _isPointer = false;
        }

        //線形繪圖模式
        public void BeingLineMode()
        {
            _isRectangleEnabled = false;
            _isLineEnabled = true;
            _isEllipseEnabled = false;
            _isPointer = false;
        }

        //橢圓形繪圖模式
        public void BeingEllipseMode()
        {
            _isRectangleEnabled = false;
            _isLineEnabled = false;
            _isEllipseEnabled = true;
            _isPointer = false;
        }

        //新增圖形
        public void AddShape(Factory.ShapeType shapeType) 
        {
            _model.AddShapeButton(shapeType);
        }

        //刪除圖形
        public void DeleteShapeButton(int index) 
        {
            _model.DeleteShapeButton(index);
        }

        //用鍵盤刪除圖形
        public void DeleteSelectedShape(Keys key)
        {
            if (key == Keys.Delete)
            {
                _model.DeleteSelectedShape();
            }
        }

        //鼠標點擊繪圖區
        public void ClickDrawPictureBox(double pointX, double pointY)
        {
            if (!IsDrawingEnabled())
            {
                _model.ClickMouse(pointX, pointY);
            }
        }

        //鼠標按住繪圖區
        public void PressDrawPictureBox(Factory.ShapeType shapeType, double pointX, double pointY)
        {
            _model.PressMouse(shapeType, pointX, pointY);
        }

        //鼠標在繪圖區移動
        public void MoveMouseOnDrawPictureBox(double pointX, double pointY)
        {
            _model.MoveMouse(pointX, pointY);
        }

        //鼠標放開繪圖區
        public void ReleaseDrawPictureBox(Factory.ShapeType shapeType, double pointX, double pointY)
        {
            _model.ReleaseMouse(shapeType, pointX, pointY);
        }
    }
}
