using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace PowerPoint
{
    public abstract class Shape : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected double _pointX1;
        protected double _pointY1;
        protected double _pointX2;
        protected double _pointY2;
        protected string _shapeName;
        protected string _information;
        const string TYPE = "Type";
        const string INFORMATION = "Information";

        public string Type
        {
            get 
            {
                return this._shapeName;
            }
            set 
            {
                SetShapeName(value);
                NotifyPropertyChanged(TYPE);
            }
        }

        public string Information
        {
            get 
            {
                return this._information;
            }
            set 
            {
                this._information = GetInformation();
                NotifyPropertyChanged(INFORMATION);
            }
        }

        //賦予圖形名稱
        public void SetShapeName(string name) 
        {
            _shapeName = name;
        }

        //賦予圖形位置
        public void SetInformation(double x1, double y1, double x2, double y2)
        {
            _pointX1 = x1;
            _pointY1 = y1;
            _pointX2 = x2;
            _pointY2 = y2;
            const string INFORMATION_TEMPLATE = "({0}, {1}), ({2}, {3})";
            _information = string.Format(INFORMATION_TEMPLATE, _pointX1, _pointY1, _pointX2, _pointY2);
        }

        //取得位置資訊
        public string GetInformation() 
        {
            return _information;
        }

        //取得位置的數字資訊
        public double[] GetInformationNumber()
        {
            return new double[]{_pointX1, _pointY1, _pointX2, _pointY2};
        }

        //取得圖形名稱
        public string GetShapeName() 
        {
            return _shapeName;
        }

        //畫出圖形
        public abstract void Draw(IGraphics graphics);

        //畫出紅色圖形
        public abstract void DrawRed(IGraphics graphics);

        //提醒Property更變
        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null) 
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
