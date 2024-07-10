using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PowerPoint;
using PowerPoint.PresentationModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint.Tests
{
    [TestClass()]
    public class ModelTests
    {
        Model _model;

        //初始化測試
        [TestInitialize()]
        public void Initialize()
        {
            _model = new Model();
        }

        //測試BindingList<Shape>
        [TestMethod()]
        public void TestBindingListShape()
        {
            Assert.IsTrue(_model._shapes == _model._shapeList);
        }

        //測試變為一般模式
        [TestMethod()]
        public void TestSetPointerMode()
        {
            _model.SetPointerMode();
            Assert.IsTrue(_model._mode == Model.Mode.Pointer);
        }

        //測試變為繪圖模式
        [TestMethod()]
        public void TestSetDrawingMode()
        {
            _model.SetDrawingMode();
            Assert.IsTrue(_model._mode == Model.Mode.Drawing);
        }

        //測試滑鼠點擊
        [TestMethod()]
        public void TestClickMouse()
        {
            _model._state = new PointerState(_model);
            _model.ClickMouse(1, 2);
            Assert.IsNotNull(_model._state);
        }

        //測試滑鼠按壓
        [TestMethod()]
        public void TestPressMouse()
        {
            _model._state = new PointerState(_model);
            _model.PressMouse(Factory.ShapeType.Line, 1, 2);
            Assert.IsNotNull(_model._state);
        }

        //測試滑鼠移動
        [TestMethod()]
        public void TestMoveMouse()
        {
            _model._state = new PointerState(_model);
            _model.MoveMouse(1, 2);
            Assert.IsNotNull(_model._state);
        }

        //測試滑鼠放開
        [TestMethod()]
        public void TestReleaseMouse()
        {
            _model._state = new PointerState(_model);
            _model.ReleaseMouse(Factory.ShapeType.Line, 1, 2);
            Assert.IsNotNull(_model._state);
        }

        //測試排序位置資訊
        [TestMethod()]
        public void TestSortInfo()
        {
            double[] unsortedInfo = { 4.0, 2.0, 8.0, 6.0 };
            double[] sortedInfo = _model.SortInfo(unsortedInfo);
            double[] expectedSortedInfo = { 4.0, 2.0, 8.0, 6.0 };
            CollectionAssert.AreEqual(expectedSortedInfo, sortedInfo);
            double[] unsortedInfo2 = { 8.0, 2.0, 4.0, 6.0 };
            double[] sortedInfo2 = _model.SortInfo(unsortedInfo2);
            CollectionAssert.AreEqual(expectedSortedInfo, sortedInfo2);
            double[] unsortedInfo3 = { 8.0, 6.0, 4.0, 2.0 };
            double[] sortedInfo3 = _model.SortInfo(unsortedInfo3);
            CollectionAssert.AreEqual(expectedSortedInfo, sortedInfo3);
            double[] unsortedInfo4 = { 4.0, 6.0, 8.0, 2.0 };
            double[] sortedInfo4 = _model.SortInfo(unsortedInfo4);
            CollectionAssert.AreEqual(expectedSortedInfo, sortedInfo4);
        }

        //測試清空全部
        [TestMethod()]
        public void TestClear()
        {
            _model.Clear();
            Assert.IsFalse(_model._isPressed);
            Assert.IsNotNull(_model._shapeList);
        }

        //測試畫圖
        [TestMethod()]
        public void TestDraw()
        {
            var mockGraphics = new Mock<IGraphics>();
            var shape1 = new Mock<Shape>();
            var shape2 = new Mock<Shape>();
            var selectedShape = new Mock<Shape>();
            _model.AddShape(shape1.Object);
            _model.AddShape(shape2.Object);
            _model._isPressed = false;
            _model._isSelected = false;
            shape1.Verify(s => s.Draw(mockGraphics.Object), Times.Never());
            shape2.Verify(s => s.Draw(mockGraphics.Object), Times.Never());
            _model._isPressed = true;
            _model._shape = shape1.Object;
            _model._isSelected = true;
            _model._selectedShape = selectedShape.Object;
            _model.Draw(mockGraphics.Object);
            mockGraphics.Verify(g => g.ClearAll(), Times.Once);
            shape1.Verify(s => s.Draw(mockGraphics.Object), Times.Exactly(2));
            shape2.Verify(s => s.Draw(mockGraphics.Object), Times.Once());
            if (_model._isPressed)
            {
                Assert.IsNotNull(_model._shape);
            }

            if (_model._isSelected)
            {
                Assert.IsNotNull(_model._selectedShape);
            }
        }

        //測試提醒Model更變
        [TestMethod()]
        public void TestNotifyModelChanged()
        {
            bool eventHandlerCalled = false;
            _model._modelChanged += () => { eventHandlerCalled = true; };
            _model.NotifyModelChanged();
            Assert.IsTrue(eventHandlerCalled);
        }

        //測試用新增按鈕創建圖形
        [TestMethod()]
        public void TestAddShapeButton()
        {
            Assert.IsNotNull(_model.AddShapeButton(Factory.ShapeType.Line));
            Assert.IsNull(_model.AddShapeButton(Factory.ShapeType.None));
        }

        //測試用刪除按鈕刪除圖形
        [TestMethod()]
        public void TestDeleteShapeButton()
        {
            _model.AddShapeButton(Factory.ShapeType.Line);
            Assert.IsTrue(_model.DeleteShapeButton(0));
            Assert.IsFalse(_model.DeleteShapeButton(0));
        }

        //測試用鍵盤刪除選取圖案
        [TestMethod()]
        public void TestDeleteSelectedShape()
        {
            _model._isSelected = true;
            _model._currentSelect = 0;
            _model.DeleteSelectedShape();
            Assert.IsTrue(_model._currentSelect == -1);
        }

        //測試圖形是否處於選擇中可被拖移的狀態
        [TestMethod()]
        public void TestIsScaling()
        {
            _model._isSelected = true;
            _model._tempInfo = new double[] { 0, 0, 10, 10 };
            double pointX = 5.0;
            double pointY = 5.0;
            bool result = _model.IsScaling(pointX, pointY);
            Assert.IsTrue(result);
            _model._isSelected = false;
            double pointX2 = 5.0;
            double pointY2 = 5.0;
            bool result2 = _model.IsScaling(pointX2, pointY2);
            Assert.IsFalse(result2);
            _model._isSelected = true;
            double pointX3 = 20.0;
            double pointY3 = 20.0;
            bool result3 = _model.IsScaling(pointX3, pointY3);
            Assert.IsFalse(result3);
        }

        //測試取得isScaling狀態
        [TestMethod()]
        public void TestGetIsScaling()
        {
            _model._isScaling = true;
            Assert.IsTrue(_model.IsScale());
        }

        //測試取得圖形畫圖
        [TestMethod()]
        public void TestDrawShape()
        {
            Shape shape = new Line();
            _model.AddShape(shape);
            Assert.IsNotNull(_model._shapeList[0]);
        }

        //測試復原
        [TestMethod()]
        public void TestUndo()
        {
            try 
            {
                _model.Undo();
            }
            catch (Exception e) 
            {
                Assert.AreEqual(e.Message, "Cannot Undo exception\n");
            }
            _model.AddShapeButton(Factory.ShapeType.Line);
            _model.Undo();
            Assert.IsNotNull(_model._commandManager);
        }

        //測試重做
        [TestMethod()]
        public void TestRedo()
        {
            try
            {
                _model.Redo();
            }
            catch (Exception e)
            {
                Assert.AreEqual(e.Message, "Cannot Redo exception\n");
            }
            _model.AddShapeButton(Factory.ShapeType.Line);
            _model.Undo();
            _model.Redo();
            Assert.IsNotNull(_model._commandManager);
        }

        //測試是否可以重做
        [TestMethod()]
        public void TestIsRedoEnabled()
        {
            Assert.IsFalse(_model.IsRedoEnabled);
        }

        //測試是否可以復原
        [TestMethod()]
        public void TestIsUndoEnabled()
        {
            Assert.IsFalse(_model.IsUndoEnabled);
        }
    }
}