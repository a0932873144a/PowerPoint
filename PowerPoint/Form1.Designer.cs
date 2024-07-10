
namespace PowerPoint
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this._graphDataGridView = new System.Windows.Forms.DataGridView();
            this._shapeComboBox = new System.Windows.Forms.ComboBox();
            this._addShapeButton = new System.Windows.Forms.Button();
            this._shapeGroupBox = new System.Windows.Forms.GroupBox();
            this._menuStrip1 = new System.Windows.Forms.MenuStrip();
            this._illustrationMenuStrip = new System.Windows.Forms.ToolStripMenuItem();
            this._aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._slideButton = new System.Windows.Forms.Button();
            this._printDialog1 = new System.Windows.Forms.PrintDialog();
            this._slidePanel = new System.Windows.Forms.Panel();
            this._drawPictureBox = new System.Windows.Forms.PictureBox();
            this._shapeToolStrip = new System.Windows.Forms.ToolStrip();
            this._lineToolStripButton = new System.Windows.Forms.ToolStripButton();
            this._rectangleToolStripButton = new System.Windows.Forms.ToolStripButton();
            this._ellipseToolStripButton = new System.Windows.Forms.ToolStripButton();
            this._arrowToolStripButton = new System.Windows.Forms.ToolStripButton();
            this._undoToolStripButton = new System.Windows.Forms.ToolStripButton();
            this._redoToolStripButton = new System.Windows.Forms.ToolStripButton();
            this._splitContainer1 = new System.Windows.Forms.SplitContainer();
            this._splitContainer2 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this._graphDataGridView)).BeginInit();
            this._shapeGroupBox.SuspendLayout();
            this._menuStrip1.SuspendLayout();
            this._slidePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._drawPictureBox)).BeginInit();
            this._shapeToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._splitContainer1)).BeginInit();
            this._splitContainer1.Panel1.SuspendLayout();
            this._splitContainer1.Panel2.SuspendLayout();
            this._splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._splitContainer2)).BeginInit();
            this._splitContainer2.Panel1.SuspendLayout();
            this._splitContainer2.Panel2.SuspendLayout();
            this._splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // _graphDataGridView
            // 
            this._graphDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._graphDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._graphDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._graphDataGridView.Location = new System.Drawing.Point(0, 80);
            this._graphDataGridView.Name = "_graphDataGridView";
            this._graphDataGridView.RowHeadersVisible = false;
            this._graphDataGridView.RowTemplate.Height = 24;
            this._graphDataGridView.Size = new System.Drawing.Size(268, 557);
            this._graphDataGridView.TabIndex = 0;
            this._graphDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ClickDeleteShapeButton);
            // 
            // _shapeComboBox
            // 
            this._shapeComboBox.FormattingEnabled = true;
            this._shapeComboBox.Items.AddRange(new object[] {
            "矩形",
            "線",
            "橢圓形"});
            this._shapeComboBox.Location = new System.Drawing.Point(110, 39);
            this._shapeComboBox.Name = "_shapeComboBox";
            this._shapeComboBox.Size = new System.Drawing.Size(74, 20);
            this._shapeComboBox.TabIndex = 2;
            // 
            // _addShapeButton
            // 
            this._addShapeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this._addShapeButton.Location = new System.Drawing.Point(21, 22);
            this._addShapeButton.Name = "_addShapeButton";
            this._addShapeButton.Size = new System.Drawing.Size(53, 52);
            this._addShapeButton.TabIndex = 3;
            this._addShapeButton.Text = "新增";
            this._addShapeButton.UseVisualStyleBackColor = true;
            this._addShapeButton.Click += new System.EventHandler(this.ClickAddShapeButton);
            // 
            // _shapeGroupBox
            // 
            this._shapeGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._shapeGroupBox.Controls.Add(this._addShapeButton);
            this._shapeGroupBox.Controls.Add(this._shapeComboBox);
            this._shapeGroupBox.Controls.Add(this._graphDataGridView);
            this._shapeGroupBox.Location = new System.Drawing.Point(-4, -1);
            this._shapeGroupBox.Name = "_shapeGroupBox";
            this._shapeGroupBox.Size = new System.Drawing.Size(268, 637);
            this._shapeGroupBox.TabIndex = 4;
            this._shapeGroupBox.TabStop = false;
            this._shapeGroupBox.Text = "資料顯示";
            // 
            // _menuStrip1
            // 
            this._menuStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this._menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._illustrationMenuStrip});
            this._menuStrip1.Location = new System.Drawing.Point(0, 0);
            this._menuStrip1.Name = "_menuStrip1";
            this._menuStrip1.Size = new System.Drawing.Size(51, 24);
            this._menuStrip1.TabIndex = 5;
            this._menuStrip1.Text = "menuStrip1";
            // 
            // _illustrationMenuStrip
            // 
            this._illustrationMenuStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._aboutToolStripMenuItem});
            this._illustrationMenuStrip.Name = "_illustrationMenuStrip";
            this._illustrationMenuStrip.Size = new System.Drawing.Size(43, 20);
            this._illustrationMenuStrip.Text = "說明";
            // 
            // _aboutToolStripMenuItem
            // 
            this._aboutToolStripMenuItem.Name = "_aboutToolStripMenuItem";
            this._aboutToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this._aboutToolStripMenuItem.Text = "關於";
            // 
            // _slideButton
            // 
            this._slideButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._slideButton.Location = new System.Drawing.Point(6, 4);
            this._slideButton.Name = "_slideButton";
            this._slideButton.Size = new System.Drawing.Size(144, 81);
            this._slideButton.TabIndex = 6;
            this._slideButton.UseVisualStyleBackColor = true;
            // 
            // _printDialog1
            // 
            this._printDialog1.UseEXDialog = true;
            // 
            // _slidePanel
            // 
            this._slidePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._slidePanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this._slidePanel.Controls.Add(this._slideButton);
            this._slidePanel.Location = new System.Drawing.Point(-1, -1);
            this._slidePanel.Name = "_slidePanel";
            this._slidePanel.Size = new System.Drawing.Size(160, 641);
            this._slidePanel.TabIndex = 8;
            // 
            // _drawPictureBox
            // 
            this._drawPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._drawPictureBox.BackColor = System.Drawing.Color.White;
            this._drawPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._drawPictureBox.Location = new System.Drawing.Point(6, 100);
            this._drawPictureBox.Name = "_drawPictureBox";
            this._drawPictureBox.Size = new System.Drawing.Size(688, 387);
            this._drawPictureBox.TabIndex = 9;
            this._drawPictureBox.TabStop = false;
            this._drawPictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ClickDrawPictureBox);
            this._drawPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PressDrawPictureBox);
            this._drawPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MoveMouseOnDrawPictureBox);
            this._drawPictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ReleaseDrawPictureBox);
            // 
            // _shapeToolStrip
            // 
            this._shapeToolStrip.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._shapeToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this._shapeToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._lineToolStripButton,
            this._rectangleToolStripButton,
            this._ellipseToolStripButton,
            this._arrowToolStripButton,
            this._undoToolStripButton,
            this._redoToolStripButton});
            this._shapeToolStrip.Location = new System.Drawing.Point(0, 24);
            this._shapeToolStrip.Name = "_shapeToolStrip";
            this._shapeToolStrip.Size = new System.Drawing.Size(150, 25);
            this._shapeToolStrip.TabIndex = 10;
            // 
            // _lineToolStripButton
            // 
            this._lineToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._lineToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("_lineToolStripButton.Image")));
            this._lineToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._lineToolStripButton.Name = "_lineToolStripButton";
            this._lineToolStripButton.Size = new System.Drawing.Size(23, 22);
            this._lineToolStripButton.Click += new System.EventHandler(this.ClickLineShapeButton);
            // 
            // _rectangleToolStripButton
            // 
            this._rectangleToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._rectangleToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("_rectangleToolStripButton.Image")));
            this._rectangleToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._rectangleToolStripButton.Name = "_rectangleToolStripButton";
            this._rectangleToolStripButton.Size = new System.Drawing.Size(23, 22);
            this._rectangleToolStripButton.Click += new System.EventHandler(this.ClickRectangleShapeButton);
            // 
            // _ellipseToolStripButton
            // 
            this._ellipseToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._ellipseToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("_ellipseToolStripButton.Image")));
            this._ellipseToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._ellipseToolStripButton.Name = "_ellipseToolStripButton";
            this._ellipseToolStripButton.Size = new System.Drawing.Size(23, 22);
            this._ellipseToolStripButton.Click += new System.EventHandler(this.ClickEllipseShapeButton);
            // 
            // _arrowToolStripButton
            // 
            this._arrowToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._arrowToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("_arrowToolStripButton.Image")));
            this._arrowToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._arrowToolStripButton.Name = "_arrowToolStripButton";
            this._arrowToolStripButton.Size = new System.Drawing.Size(23, 22);
            this._arrowToolStripButton.Click += new System.EventHandler(this.ClickArrowShapeButton);
            // 
            // _undoToolStripButton
            // 
            this._undoToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._undoToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("_undoToolStripButton.Image")));
            this._undoToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._undoToolStripButton.Name = "_undoToolStripButton";
            this._undoToolStripButton.Size = new System.Drawing.Size(23, 22);
            this._undoToolStripButton.Click += new System.EventHandler(this.ClickUndoToolStripButton);
            // 
            // _redoToolStripButton
            // 
            this._redoToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._redoToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("_redoToolStripButton.Image")));
            this._redoToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._redoToolStripButton.Name = "_redoToolStripButton";
            this._redoToolStripButton.Size = new System.Drawing.Size(23, 22);
            this._redoToolStripButton.Click += new System.EventHandler(this.ClickRedoToolStripButton);
            // 
            // _splitContainer1
            // 
            this._splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._splitContainer1.Location = new System.Drawing.Point(0, 50);
            this._splitContainer1.Name = "_splitContainer1";
            // 
            // _splitContainer1.Panel1
            // 
            this._splitContainer1.Panel1.Controls.Add(this._slidePanel);
            // 
            // _splitContainer1.Panel2
            // 
            this._splitContainer1.Panel2.Controls.Add(this._splitContainer2);
            this._splitContainer1.Size = new System.Drawing.Size(1122, 641);
            this._splitContainer1.SplitterDistance = 157;
            this._splitContainer1.SplitterWidth = 3;
            this._splitContainer1.TabIndex = 11;
            this._splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.MoveLeftSplitContainer);
            // 
            // _splitContainer2
            // 
            this._splitContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._splitContainer2.Location = new System.Drawing.Point(-2, -1);
            this._splitContainer2.Name = "_splitContainer2";
            // 
            // _splitContainer2.Panel1
            // 
            this._splitContainer2.Panel1.Controls.Add(this._drawPictureBox);
            // 
            // _splitContainer2.Panel2
            // 
            this._splitContainer2.Panel2.Controls.Add(this._shapeGroupBox);
            this._splitContainer2.Size = new System.Drawing.Size(966, 637);
            this._splitContainer2.SplitterDistance = 701;
            this._splitContainer2.SplitterWidth = 3;
            this._splitContainer2.TabIndex = 10;
            this._splitContainer2.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.MoveRightSplitContainer);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1123, 689);
            this.Controls.Add(this._shapeToolStrip);
            this.Controls.Add(this._menuStrip1);
            this.Controls.Add(this._splitContainer1);
            this.KeyPreview = true;
            this.MainMenuStrip = this._menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HW2";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ClickDeleteKey);
            ((System.ComponentModel.ISupportInitialize)(this._graphDataGridView)).EndInit();
            this._shapeGroupBox.ResumeLayout(false);
            this._menuStrip1.ResumeLayout(false);
            this._menuStrip1.PerformLayout();
            this._slidePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._drawPictureBox)).EndInit();
            this._shapeToolStrip.ResumeLayout(false);
            this._shapeToolStrip.PerformLayout();
            this._splitContainer1.Panel1.ResumeLayout(false);
            this._splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._splitContainer1)).EndInit();
            this._splitContainer1.ResumeLayout(false);
            this._splitContainer2.Panel1.ResumeLayout(false);
            this._splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._splitContainer2)).EndInit();
            this._splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView _graphDataGridView;
        private System.Windows.Forms.ComboBox _shapeComboBox;
        private System.Windows.Forms.Button _addShapeButton;
        private System.Windows.Forms.GroupBox _shapeGroupBox;
        private System.Windows.Forms.MenuStrip _menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem _illustrationMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem _aboutToolStripMenuItem;
        private System.Windows.Forms.Button _slideButton;
        private System.Windows.Forms.PrintDialog _printDialog1;
        private System.Windows.Forms.Panel _slidePanel;
        private System.Windows.Forms.PictureBox _drawPictureBox;
        private System.Windows.Forms.ToolStrip _shapeToolStrip;
        private System.Windows.Forms.ToolStripButton _lineToolStripButton;
        private System.Windows.Forms.ToolStripButton _rectangleToolStripButton;
        private System.Windows.Forms.ToolStripButton _ellipseToolStripButton;
        private System.Windows.Forms.ToolStripButton _arrowToolStripButton;
        private System.Windows.Forms.ToolStripButton _undoToolStripButton;
        private System.Windows.Forms.ToolStripButton _redoToolStripButton;
        private System.Windows.Forms.SplitContainer _splitContainer1;
        private System.Windows.Forms.SplitContainer _splitContainer2;
    }
}

