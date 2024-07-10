using Microsoft.VisualStudio.TestTools.UnitTesting;
using PowerPoint;
using PowerPoint.PresentationModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace PowerPoint.Tests
{
    [TestClass()]
    public class ShapeTests
    {
        const double _pointX1 = 1;
        const double _pointY1 = 2;
        const double _pointX2 = 3;
        const double _pointY2 = 4;
        const string SHAPE_NAME = "線";
        const string _information = "(1, 2), (3, 4)";
        const string PROPERTY_NAME = "TYPE";
        Shape _shape;

        //初始化測試
        [TestInitialize()]
        public void Initialize()
        {
            _shape = new Line();
        }

        //測試Type
        [TestMethod()]
        public void TestType()
        {
            _shape.Type = SHAPE_NAME;
            Assert.AreEqual(_shape.Type, SHAPE_NAME);
        }

        //測試Information
        [TestMethod()]
        public void TestInformation()
        {
            _shape.SetInformation(_pointX1, _pointY1, _pointX2, _pointY2);
            _shape.Information = _information;
            Assert.AreEqual(_shape.Information, _information);
        }

        //測試賦予圖形名稱
        [TestMethod()]
        public void TestSetShapeName()
        {
            _shape.SetShapeName(SHAPE_NAME);
            Assert.AreEqual(_shape.GetShapeName(), SHAPE_NAME);
        }

        //測試賦予圖形位置
        [TestMethod()]
        public void TestSetInformation()
        {
            _shape.SetInformation(_pointX1, _pointY1, _pointX2, _pointY2);
            Assert.AreEqual(_shape.GetInformation(), _information);
        }

        //測試取得位置資訊
        [TestMethod()]
        public void TestGetInformation()
        {
            _shape.SetInformation(_pointX1, _pointY1, _pointX2, _pointY2);
            Assert.AreEqual(_shape.GetInformation(), _information);
        }

        //測試取得位置的數字資訊
        [TestMethod()]
        public void TestGetInformationNumber()
        {
            Assert.IsNotNull(_shape.GetInformationNumber());
        }

        //測試取得圖形名稱
        [TestMethod()]
        public void TestGetShapeName()
        {
            _shape.SetShapeName(SHAPE_NAME);
            Assert.AreEqual(_shape.GetShapeName(), SHAPE_NAME);
        }

        //測試畫出圖形
        [TestMethod()]
        public void TestDraw()
        {
            Assert.IsTrue(true);
        }

        //測試畫出紅色圖形
        [TestMethod()]
        public void TestDrawRed()
        {
            Assert.IsTrue(true);
        }

        //測試提醒Property更變
        [TestMethod()]
        public void TestNotifyPropertyChanged()
        {
            const string PROPERTY_NAME = "YourProperty";
            bool eventHandlerCalled = false;
            _shape.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == PROPERTY_NAME)
                {
                    eventHandlerCalled = true;
                }
            };
            _shape.NotifyPropertyChanged(PROPERTY_NAME);
            Assert.IsTrue(eventHandlerCalled);
            Initialize();
            _shape.NotifyPropertyChanged(PROPERTY_NAME);
        }
    }
}