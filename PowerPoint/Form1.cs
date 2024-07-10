using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowerPoint
{
    public partial class Form1 : Form
    {
        ViewModel _viewModel;
        Bitmap _paintMap;
        Graphics _graphic;
        Model _model;
        Factory.ShapeType _currentShapeType = Factory.ShapeType.None;
        const string DELETE_STRING = "刪除";
        const int WIDTH_SCALE = 16;
        const int HEIGHT_SCALE = 9;

        public Form1()
        {
            InitializeComponent();
            _model = new Model();
            _viewModel = new ViewModel(_model);
            _paintMap = new Bitmap(_drawPictureBox.Width, _drawPictureBox.Height);
            _graphic = Graphics.FromImage(_paintMap);
            _graphic.Clear(Color.White);
            _drawPictureBox.Image = _paintMap;
            _model._modelChanged += HandleModelChanged;
            _graphDataGridView.DataSource = _model._shapes;
            _graphDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();
            deleteButtonColumn.HeaderText = "Delete";
            deleteButtonColumn.Text = DELETE_STRING;
            deleteButtonColumn.UseColumnTextForButtonValue = true;
            _graphDataGridView.Columns.Insert(0, deleteButtonColumn);
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            _undoToolStripButton.Enabled = false;
            _redoToolStripButton.Enabled = false;
            _viewModel.ResetState();
        }

        private BindingManagerBase _bindingManager 
        {
            get 
            {
                return BindingContext[_model._shapes];
            }
        }

        //更改畫布
        protected override void OnPaint(PaintEventArgs e)
        {
            _viewModel.Draw(_graphic);
            _slideButton.Image = new Bitmap(_paintMap, _slideButton.Width, _slideButton.Height);
            _drawPictureBox.Image = new Bitmap(_paintMap, _drawPictureBox.Width, _drawPictureBox.Height);
        }

        //點擊新增圖形按鈕
        private void ClickAddShapeButton(object sender, EventArgs e)
        {
            _viewModel.ResetState();
            _currentShapeType = (Factory.ShapeType)_shapeComboBox.SelectedIndex;
            _viewModel.AddShape(_currentShapeType);
            _bindingManager.Position = _bindingManager.Count - 1;
            RefreshUi();
        }

        //點擊刪除圖形按鈕
        private void ClickDeleteShapeButton(object sender, DataGridViewCellEventArgs e)
        {
            _viewModel.ResetState();
            _viewModel.DeleteShapeButton(e.RowIndex);
            RefreshUi();
        }

        //點擊線圖形按鈕
        private void ClickLineShapeButton(object sender, EventArgs e)
        {
            _viewModel.StartDrawing();
            _currentShapeType = Factory.ShapeType.Line;
            _viewModel.BeingLineMode();
            CheckToolStripButton();
            Cursor = Cursors.Cross;
        }

        //點擊矩形圖形按鈕
        private void ClickRectangleShapeButton(object sender, EventArgs e)
        {
            _viewModel.StartDrawing();
            _currentShapeType = Factory.ShapeType.Rectangle;
            _viewModel.BeingRectangleMode();
            CheckToolStripButton();
            Cursor = Cursors.Cross;
        }

        //點擊橢圓形圖形按鈕
        private void ClickEllipseShapeButton(object sender, EventArgs e)
        {
            _viewModel.StartDrawing();
            _currentShapeType = Factory.ShapeType.Ellipse;
            _viewModel.BeingEllipseMode();
            CheckToolStripButton();
            Cursor = Cursors.Cross;
        }

        //點擊箭頭圖形按鈕
        private void ClickArrowShapeButton(object sender, EventArgs e)
        {
            _viewModel.ResetState();
            CheckToolStripButton();
            Cursor = Cursors.Default;
        }

        //鼠標按住繪圖區
        private void PressDrawPictureBox(object sender, MouseEventArgs e)
        {
            _viewModel.PressDrawPictureBox(_currentShapeType, e.X, e.Y);
            RefreshUi();
        }

        //鼠標在繪圖區移動
        private void MoveMouseOnDrawPictureBox(object sender, MouseEventArgs e)
        {
            if (_model.IsScaling(e.X, e.Y))
                Cursor = Cursors.SizeNWSE;
            _viewModel.MoveMouseOnDrawPictureBox(e.X, e.Y);
            RefreshUi();
        }

        //鼠標放開繪圖區
        private void ReleaseDrawPictureBox(object sender, MouseEventArgs e)
        {
            _viewModel.ReleaseDrawPictureBox(_currentShapeType, e.X, e.Y);
            Cursor = Cursors.Default;
            _viewModel.ResetState();
            CheckToolStripButton();
            _currentShapeType = Factory.ShapeType.None;
            RefreshUi();
        }

        //檢查各按鈕的狀況
        private void CheckToolStripButton() 
        {
            _arrowToolStripButton.Checked = _viewModel._pointer;
            _lineToolStripButton.Checked = _viewModel.IsLineEnabled();
            _rectangleToolStripButton.Checked = _viewModel.IsRectangleEnabled();
            _ellipseToolStripButton.Checked = _viewModel.IsEllipseEnabled();
        }

        //控制model改變
        public void HandleModelChanged()
        {
            Invalidate(true);
        }

        //鼠標點擊繪圖區
        private void ClickDrawPictureBox(object sender, MouseEventArgs e)
        {
            _viewModel.ClickDrawPictureBox(e.X, e.Y);
        }

        //點擊刪除鍵
        private void ClickDeleteKey(object sender, KeyEventArgs e)
        {
            _viewModel.ResetState();
            _viewModel.DeleteSelectedShape(e.KeyCode);
            RefreshUi();
        }

        //更新redo與undo是否為enabled
        void RefreshUi()    
        {
            _redoToolStripButton.Enabled = _model.IsRedoEnabled;
            _undoToolStripButton.Enabled = _model.IsUndoEnabled;
            Invalidate();
        }

        //點擊undo
        private void ClickUndoToolStripButton(object sender, EventArgs e)
        {
            _model.Undo();
            RefreshUi();
        }

        //點擊redo
        private void ClickRedoToolStripButton(object sender, EventArgs e)
        {
            _model.Redo();
            RefreshUi();
        }

        //移動Splitter2時動態調整繪圖區大小
        private void MoveRightSplitContainer(object sender, SplitterEventArgs e)
        {
            _drawPictureBox.Height = HEIGHT_SCALE * (_drawPictureBox.Width / WIDTH_SCALE);
            RefreshUi();
        }

        //移動Splitter1時動態調整繪圖區大小
        private void MoveLeftSplitContainer(object sender, SplitterEventArgs e)
        {
            _drawPictureBox.Height = HEIGHT_SCALE * (_drawPictureBox.Width / WIDTH_SCALE);
            _slideButton.Height = HEIGHT_SCALE * (_slideButton.Width / WIDTH_SCALE);
            RefreshUi();
        }
    }
}