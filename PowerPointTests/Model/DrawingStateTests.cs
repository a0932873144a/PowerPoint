using Microsoft.VisualStudio.TestTools.UnitTesting;
using PowerPoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint.Tests
{
    [TestClass()]
    public class DrawingStateTests
    {
        DrawingState _state;
        Model _model;

        //初始化測試
        [TestInitialize()]
        public void Initialize()
        {
            _model = new Model();
            _state = new DrawingState(_model);
        }

        //測試DrawingState
        [TestMethod()]
        public void DrawingStateTest()
        {
            Assert.IsNotNull(_state._model);
        }

        //測試滑鼠點擊
        [TestMethod()]
        public void ClickMouseTest()
        {
            _state.ClickMouse(1, 2);
        }

        //測試滑鼠按壓
        [TestMethod()]
        public void PressMouseTest()
        {
            _state.PressMouse(Factory.ShapeType.Line, 1, 1);
            Assert.IsTrue(_state._isPressed);
            Assert.IsTrue(_state._firstPointX == 1);
            Assert.IsTrue(_state._firstPointY == 1);
            Initialize();
            _state.PressMouse(Factory.ShapeType.Line, 1, 0);
            Assert.IsFalse(_state._isPressed);
            _state.PressMouse(Factory.ShapeType.Line, 0, 1);
            Assert.IsFalse(_state._isPressed);
            _state.PressMouse(Factory.ShapeType.Line, 0, 0);
            Assert.IsFalse(_state._isPressed);
        }

        //測試滑鼠移動
        [TestMethod()]
        public void MoveMouseTest()
        {
            _state._isPressed = true;
            _state._shape = new Line();
            _state.MoveMouse(1, 1);
            Assert.IsTrue(_state._shape.GetShapeName() == "線");
            Assert.IsTrue(_state._shape.GetInformationNumber()[2] == 1);
            Initialize();
            _state._isPressed = false;
            _state.MoveMouse(1, 1);
            Initialize();
            _state._isPressed = true;
            _state._shape = new Rectangle();
            _state._firstPointX = 0;
            Assert.IsFalse(_state._shape.GetInformationNumber()[2] == 1);
            _state.MoveMouse(0, 1);
            Assert.IsTrue(_state._shape.GetShapeName() == "矩形");
            Initialize();
            _state._isPressed = true;
            _state._shape = new Line();
            _state.MoveMouse(1, 0);
            Assert.IsTrue(_state._shape.GetShapeName() == "線");
            Initialize();
            Initialize();
            _state._isPressed = true;
            _state._shape = new Line();
            _state.MoveMouse(0, 0);
            Assert.IsTrue(_state._shape.GetShapeName() == "線");
        }

        //測試滑鼠移動
        [TestMethod()]
        public void ReleaseMouseTest()
        {
            _state.ReleaseMouse(Factory.ShapeType.Line, 1, 1);
            Assert.IsTrue(_state._firstPointX == -1);
            Assert.IsTrue(_state._firstPointY == -1);
            Initialize();
            _state._isPressed = true;
            _state.ReleaseMouse(Factory.ShapeType.Line, 1, 1);
            Assert.IsFalse(_state._isPressed);
            _state._isPressed = true;
            _state.ReleaseMouse(Factory.ShapeType.Line, 0, 0);
            Assert.IsTrue(_state._isPressed);
            Initialize();
            _state._isPressed = true;
            _state.ReleaseMouse(Factory.ShapeType.Ellipse, 1, 1);
            Assert.IsFalse(_state._isPressed);
        }
    }
}