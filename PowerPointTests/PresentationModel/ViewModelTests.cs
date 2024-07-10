using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PowerPoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowerPoint.Tests
{
    [TestClass()]
    public class ViewModelTests
    {
        ViewModel _viewModel;
        Model _model;

        //初始化測試
        [TestInitialize()]
        public void Initialize()
        {
            _model = new Model();
            _viewModel = new ViewModel(_model);
        }

        //測試ViewModel
        [TestMethod()]
        public void TestViewModel()
        {
            Assert.IsNotNull(_viewModel._model);
        }

        //測試畫圖
        [TestMethod()]
        public void TestDraw()
        {
            Assert.IsTrue(true);
        }

        //測試重回預設狀態
        [TestMethod()]
        public void TestResetState()
        {
            _viewModel.ResetState();
            Assert.IsFalse(_viewModel._isDrawing);
            Assert.IsTrue(_viewModel._isPointer);
            Assert.IsFalse(_viewModel._isRectangleEnabled);
            Assert.IsFalse(_viewModel._isLineEnabled);
            Assert.IsFalse(_viewModel._isEllipseEnabled);
            Assert.IsTrue(_model._mode == Model.Mode.Pointer);

        }

        //測試pointer
        [TestMethod()]
        public void TestPointer()
        {
            Assert.IsTrue(_viewModel._pointer);
        }

        //測試確認是否為繪圖模式
        [TestMethod()]
        public void TestIsDrawingEnabled()
        {
            Assert.IsFalse(_viewModel.IsDrawingEnabled());
            _viewModel.StartDrawing();
            _viewModel.BeingLineMode();
            Assert.IsTrue(_viewModel.IsDrawingEnabled());
            _viewModel.BeingRectangleMode();
            Assert.IsTrue(_viewModel.IsDrawingEnabled());
            _viewModel.BeingEllipseMode();
            Assert.IsTrue(_viewModel.IsDrawingEnabled());
            _viewModel._isPointer = true;
            _viewModel._isDrawing = false;
            Assert.IsFalse(_viewModel.IsDrawingEnabled());
        }

        //測試確認是否為矩形模式
        [TestMethod()]
        public void TestIsRectangleEnabled()
        {
            Assert.IsFalse(_viewModel.IsRectangleEnabled());
        }

        //測試確認是否為線形模式
        [TestMethod()]
        public void TestIsLineEnabled()
        {
            Assert.IsFalse(_viewModel.IsLineEnabled());
        }

        //測試確認是否為橢圓形模式
        [TestMethod()]
        public void TestIsEllipseEnabled()
        {
            Assert.IsFalse(_viewModel.IsEllipseEnabled());
        }

        //測試繪圖中
        [TestMethod()]
        public void TestStartDrawing()
        {
            _viewModel.StartDrawing();
            Assert.IsTrue(_viewModel._isDrawing);
            Assert.IsFalse(_viewModel._isPointer);
            Assert.IsTrue(_model._mode == Model.Mode.Drawing);
        }

        //測試矩形繪圖模式
        [TestMethod()]
        public void TestBeingRectangleMode()
        {
            _viewModel.BeingRectangleMode();
            Assert.IsTrue(_viewModel._isRectangleEnabled);
            Assert.IsFalse(_viewModel._isLineEnabled);
            Assert.IsFalse(_viewModel._isEllipseEnabled);
            Assert.IsFalse(_viewModel._isPointer);
        }

        //測試線形繪圖模式
        [TestMethod()]
        public void TestBeingLineMode()
        {
            _viewModel.BeingLineMode();
            Assert.IsFalse(_viewModel._isRectangleEnabled);
            Assert.IsTrue(_viewModel._isLineEnabled);
            Assert.IsFalse(_viewModel._isEllipseEnabled);
            Assert.IsFalse(_viewModel._isPointer);
        }

        //測試橢圓形繪圖模式
        [TestMethod()]
        public void TestBeingEllipseMode()
        {
            _viewModel.BeingEllipseMode();
            Assert.IsFalse(_viewModel._isRectangleEnabled);
            Assert.IsFalse(_viewModel._isLineEnabled);
            Assert.IsTrue(_viewModel._isEllipseEnabled);
            Assert.IsFalse(_viewModel._isPointer);
        }

        //測試新增圖形
        [TestMethod()]
        public void TestAddShape()
        {
            _viewModel.AddShape(Factory.ShapeType.Line);
            TestResetState();
            Assert.IsNotNull(_model.AddShapeButton(Factory.ShapeType.Line));
            Assert.IsNull(_model.AddShapeButton(Factory.ShapeType.None));
        }

        //測試刪除圖形
        [TestMethod()]
        public void TestDeleteShapeButton()
        {
            _viewModel.DeleteShapeButton(0);
            TestResetState();
            Assert.IsFalse(_model.DeleteShapeButton(0));
        }

        //測試用鍵盤刪除圖形
        [TestMethod()]
        public void TestDeleteSelectedShape()
        {
            _viewModel.DeleteSelectedShape(Keys.Delete);
            Assert.IsTrue(_model._currentSelect == -1);
            _viewModel.DeleteSelectedShape(Keys.N);
            Assert.IsTrue(_model._currentSelect == -1);
        }

        //測試鼠標點擊繪圖區
        [TestMethod()]
        public void TestClickDrawPictureBox()
        {
            double pointX = 10.0;
            double pointY = 20.0;
            _model._state = new PointerState(_model);
            _viewModel._isDrawing = true;
            _viewModel._isEllipseEnabled = true;
            _viewModel._isPointer = false;
            _viewModel.ClickDrawPictureBox(pointX, pointY);
            Assert.IsTrue(_viewModel.IsDrawingEnabled());
            Assert.IsNotNull(_viewModel._model);
            _viewModel._isDrawing = false;
            _viewModel.ClickDrawPictureBox(pointX, pointY);
            Assert.IsFalse(_viewModel.IsDrawingEnabled());
            Assert.IsNotNull(_viewModel._model);
        }

        //測試鼠標按住繪圖區
        [TestMethod()]
        public void TestPressDrawPictureBox()
        {
            double pointX = 10.0;
            double pointY = 20.0;
            _model._state = new PointerState(_model);
            _viewModel.PressDrawPictureBox(Factory.ShapeType.Line, pointX, pointY);
            Assert.IsNotNull(_viewModel._model);
        }

        //測試鼠標在繪圖區移動
        [TestMethod()]
        public void TestMoveMouseOnDrawPictureBox()
        {
            double pointX = 10.0;
            double pointY = 20.0;
            _model._state = new PointerState(_model);
            _viewModel.MoveMouseOnDrawPictureBox(pointX, pointY);
            Assert.IsNotNull(_viewModel._model);
        }

        //測試鼠標放開繪圖區
        [TestMethod()]
        public void TestReleaseDrawPictureBox()
        {
            double pointX = 10.0;
            double pointY = 20.0;
            _model._state = new PointerState(_model);
            _viewModel.ReleaseDrawPictureBox(Factory.ShapeType.Line, pointX, pointY);
            Assert.IsNotNull(_viewModel._model);
        }
    }
}