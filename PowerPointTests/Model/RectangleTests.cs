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
    public class RectangleTests
    {
        Shape _shape;

        //初始化測試
        [TestInitialize()]
        public void Initialize()
        {
            _shape = new Rectangle();
        }

        //測試畫出長方形
        [TestMethod()]
        public void TestDraw()
        {
            var graphicsMock = new Mock<IGraphics>();
            double pointX1 = 10.0;
            double pointY1 = 20.0;
            double pointX2 = 30.0;
            double pointY2 = 40.0;
            _shape.SetInformation(pointX1, pointY1, pointX2, pointY2);
            _shape.Draw(graphicsMock.Object);
            graphicsMock.Verify(g => g.DrawRectangle(pointX1, pointY1, pointX2, pointY2), Times.Once);
        }

        //測試畫出長方形
        [TestMethod()]
        public void TestDrawRed()
        {
            var graphicsMock = new Mock<IGraphics>();
            double pointX1 = 10.0;
            double pointY1 = 20.0;
            double pointX2 = 30.0;
            double pointY2 = 40.0;
            _shape.SetInformation(pointX1, pointY1, pointX2, pointY2);
            _shape.DrawRed(graphicsMock.Object);
            graphicsMock.Verify(g => g.DrawRedRectangle(pointX1, pointY1, pointX2, pointY2), Times.Once);
        }
    }
}