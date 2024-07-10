using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PowerPoint;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint.Tests
{
    [TestClass()]
    public class PointerStateTests
    {
        PointerState _state;
        Model _model;

        //初始化測試
        [TestInitialize()]
        public void Initialize()
        {
            _model = new Model();
            _state = new PointerState(_model);
        }

        //測試PointerState
        [TestMethod()]
        public void PointerStateTest()
        {
            Assert.IsNotNull(_state._model);
        }

        //測試滑鼠點擊
        [TestMethod()]
        public void ClickMouseTest()
        {
            Shape shape1 = new Line();
            shape1.SetInformation(1, 1, 10, 10);
            Shape shape2 = new Line();
            shape2.SetInformation(5, 6, 7, 8);
            Shape shape3 = new Line();
            shape3.SetInformation(9, 10, 11, 12);
            _model.AddShape(shape1);
            _model.AddShape(shape2);
            _model.AddShape(shape3);
            _state.ClickMouse(2, 2);
            Assert.IsTrue(_model._isSelected);
            Assert.AreEqual(0, _model._currentSelect);
            Assert.AreEqual(_model._shapeList[0], _model._selectedShape);
            _state.ClickMouse(17, 60);
            Assert.IsFalse(_model._isSelected);
            Assert.AreEqual(-1, _model._currentSelect);
        }

        //測試滑鼠按壓
        [TestMethod()]
        public void PressMouseTest()
        {
            double pointX = 10.0;
            double pointY = 20.0;
            _state.PressMouse(Factory.ShapeType.Line, pointX, pointY);
            Assert.IsTrue(_state._model._isPressed);
            Assert.AreEqual(pointX, _state._firstPointX);
            Assert.AreEqual(pointY, _state._firstPointY);
            Assert.IsFalse(_state._model.IsScale());
            _model._tempInfo = new double[] {5, 10, 10, 20};
            _model._isSelected = true;
            _state.PressMouse(Factory.ShapeType.Line, pointX, pointY);
            Assert.IsTrue(_model._isScaling);
        }

        //測試滑鼠移動
        [TestMethod()]
        public void MoveMouseTest()
        {
            _model._isScaling = true;
            _model._isPressed = true;
            _model._isSelected = true;
            _model._currentSelect = 0;
            Shape shape = new Line();
            _model._selectedShape = shape;
            _model._tempInfo = new double[] { 5, 10, 10, 20 };
            _model.AddShape(shape);
            Assert.IsTrue(_model._shapeList[0] == shape);
            Initialize();
            _model._isScaling = false;
            _model._isPressed = true;
            _model._isSelected = true;
            _model._currentSelect = 0;
            Shape shape2 = new Line();
            _model._selectedShape = shape;
            _model._tempInfo = new double[] { 5, 10, 10, 20 };
            _model.AddShape(shape2);
            Assert.IsTrue(_model._shapeList[0] == shape2);
            Shape shape3 = new Rectangle();
            _model._selectedShape = shape;
            _model._tempInfo = new double[] { 5, 10, 10, 20 };
            _model.AddShape(shape3);
            Assert.IsTrue(_model._shapeList[1] == shape3);
        }

        //測試滑鼠釋放
        [TestMethod()]
        public void ReleaseMouseTest()
        {
            _state._isPressed = true;
            _model._isSelected = true;
            _model._isScaling = true;
            Shape shape = new Line();
            _model._selectedShape = shape;
            _model._tempInfo = new double[] { 5, 10, 10, 20 };
            _model.AddShape(shape);
            _state.ReleaseMouse(Factory.ShapeType.Line, 10, 10);
            Assert.IsNotNull(_model._selectedShape);
            Initialize();
            _state._isPressed = true;
            _model._isSelected = true;
            _model._isScaling = false;
            Shape shape2 = new Line();
            _model._selectedShape = shape2;
            _model._tempInfo = new double[] { 5, 10, 10, 20 };
            _model.AddShape(shape2);
            _state.ReleaseMouse(Factory.ShapeType.Line, 10, 10);
            Assert.IsNotNull(_model._selectedShape);
            Initialize();
            _state._isPressed = true;
            _model._isSelected = true;
            _model._isScaling = false;
            Shape shape3 = new Rectangle();
            _model._selectedShape = shape3;
            _model._tempInfo = new double[] { 5, 10, 10, 20 };
            _model.AddShape(shape3);
            _state.ReleaseMouse(Factory.ShapeType.Line, 10, 10);
            Assert.IsNotNull(_model._selectedShape);
            Assert.IsFalse(_model._isScaling);
            Assert.IsTrue(_state._firstPointX == -1);
        }
    }
}