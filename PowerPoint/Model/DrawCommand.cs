using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    class DrawCommand : ICommand
    {
        Shape _shape;
        Model _model;

        public DrawCommand(Model model, Shape shape)
        {
            _model = model;
            _shape = shape;
        }

        //執行
        public void Execute()
        {
            _model.AddShape(_shape);
        }

        //取消執行
        public void RedoExecution()
        {
            _model.DeleteShape();
        }
    }
}
