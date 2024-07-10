using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPoint
{
    interface ICommand
    {
        //執行
        void Execute();

        //取消執行
        void RedoExecution();
    }
}
