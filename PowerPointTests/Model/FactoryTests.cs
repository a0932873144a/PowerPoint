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
    public class FactoryTests
    {
        //測試給予隨機座標
        [TestMethod()]
        public void TestCreateInformation()
        {
            Shape shape = new Line();
            shape = Factory.CreateInformation(Factory.ShapeType.Line, shape);
            Assert.IsNotNull(shape);
            Shape shape2 = new Rectangle();
            shape2 = Factory.CreateInformation(Factory.ShapeType.Rectangle, shape2);
            Assert.IsNotNull(shape2);
        }

        //測試創建圖形
        [TestMethod()]
        public void TestCreateShape()
        {
            Shape shape = Factory.CreateShape(Factory.ShapeType.Line);
            Assert.IsTrue(shape.GetShapeName() == "線");
            Shape shape2 = Factory.CreateShape(Factory.ShapeType.Rectangle);
            Assert.IsTrue(shape2.GetShapeName() == "矩形");
            Shape shape3 = Factory.CreateShape(Factory.ShapeType.Ellipse);
            Assert.IsTrue(shape3.GetShapeName() == "橢圓形");
            Shape shape4 = Factory.CreateShape(Factory.ShapeType.None);
            Assert.IsNull(shape4);

        }

        //測試用新增按鈕創建圖形
        [TestMethod()]
        public void TestAddShapeButton()
        {
            Shape shape = Factory.AddShapeButton(Factory.ShapeType.Line);
            Assert.IsNotNull(shape);
            Shape shape2 = Factory.AddShapeButton(Factory.ShapeType.None);
            Assert.IsNull(shape2);
        }
    }
}