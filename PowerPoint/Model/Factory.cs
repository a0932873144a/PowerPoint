using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    public class Factory
    {
        const int FIRST_INFORMATION = 0;
        const int SECOND_INFORMATION = 1;
        const int THIRD_INFORMATION = 2;
        const int FOURTH_INFORMATION = 3;

        public enum ShapeType : int 
        { 
            Rectangle,
            Line,
            Ellipse,
            None
        }

        //給予隨機座標
        public static Shape CreateInformation(ShapeType shapeType, Shape shape)
        {
            const int INFORMATION_SIZE = 4;
            const int WIDTH = 672;
            const int HEIGHT = 387;
            const int PAIR_OF_POSITION = 2;
            Random randomObject = new Random();
            int[] information = new int[INFORMATION_SIZE];
            for (int i = 0; i < INFORMATION_SIZE; i += PAIR_OF_POSITION)
            {
                information[i] = randomObject.Next(0, WIDTH);
                information[i + 1] = randomObject.Next(0, HEIGHT);
            }
            shape.SetInformation(information[FIRST_INFORMATION], information[SECOND_INFORMATION], information[THIRD_INFORMATION], information[FOURTH_INFORMATION]);
            return shape;
        }

        //創建圖形
        public static Shape CreateShape(ShapeType shapeType) 
        {
            if (shapeType == ShapeType.Rectangle) 
            {
                return new Rectangle();
            }
            else if (shapeType == ShapeType.Line) 
            {
                return new Line();
            }
            else if (shapeType == ShapeType.Ellipse) 
            {
                return new Ellipse();
            }
            else
            {
                return null;
            }
        }

        //用新增按鈕創建圖形
        public static Shape AddShapeButton(ShapeType shapeType)
        {
            if (shapeType != ShapeType.None)
            {
                Shape shape = CreateShape(shapeType);
                shape = CreateInformation(shapeType, shape);
                return shape;
            }
            return null;
        }
    }
}
