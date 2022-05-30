using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MK_Ultra.Sandwich.SupportTools
{
    //[Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(IDesigner))]
    public partial class ucWidgetBox : Panel
    {
        class Box
        {
            public int MinDistanceRight { get; set; }
            public int? ControlRightLeft { get; set; }

            public int MinDistanceLeft { get; set; }
            public int? ControlLeftRight { get; set; }

            public int MinDistanceTop { get; set; }
            public Control ControlTop { get; set; }
            
            public int MinDistanceBottom { get; set; }
            public int? ControlBottomTop { get; set; }

            public int Left { get; set; }
            public int Right { get; set; }
            public int Width { get; set; }
            public int ParentWidth { get; set; }

            public int Top { get; set; }
            public int Bottom { get; set; }
            public int Height { get; set; }
            public int ParentHeight { get; set; }
        }

        private Box _box = new Box();

        private Point _mouseMoveLocation = new Point();
        
        private bool _closeHover = false;
        private bool _gripHover = false;
        private bool _headerHover = false;

        int _feedbackMovX, _feedbackMovY, _feedbackLocX, _feedbackLocY, _feedbackWidth, _feedbackHeight;
        bool _feedbackIsMoving;

        private bool _locked = false;
        public bool Locked
        {
            get { return _locked; }
            set { _locked = value; }
        }

        private bool _visible = true;
        public new bool Visible
        {
            get
            {
                return _visible; 
            }
            set
            {
                _visible = value;
                base.Visible = value;
            }
        }

        // Border
        private Color _borderColour = Color.LightSlateGray;
        public Color BorderColour
        {
            get { return _borderColour; }
            set { _borderColour = value; this.Refresh(); }
        }
        private bool _borderVisible = true;
        public bool BorderVisible
        {
            get { return _borderVisible; }
            set 
            { 
                _borderVisible = value;
                SetPadding();
                this.Refresh();
            }
        }

        // Header
        private string _headerText = "WidgetBox";
        public string HeaderText
        {
            get { return _headerText; }
            set { _headerText = value; this.Refresh(); }
        }
        private Color _headerBackColour = Color.FromArgb(209, 224, 237);
        public Color HeaderBackColour
        {
            get { return _headerBackColour; }
            set { _headerBackColour = value; this.Refresh(); }
        }
        private int _headerHeight = 19;
        public int HeaderHeight
        {
            get { return _headerHeight; }
            set 
            { 
                _headerHeight = value;
                SetPadding();
                this.Refresh(); 
            }
        }
        private bool _headerLineVisible = true;
        public bool HeaderLineVisible
        {
            get { return _headerLineVisible; }
            set { _headerLineVisible = value; this.Refresh(); }
        }
        private Color _headerLineColour = Color.LightSteelBlue;
        public Color HeaderLineColour
        {
            get { return _headerLineColour; }
            set { _headerLineColour = value; this.Refresh(); }
        }
        private Font _headerFont = new Font("Segoe UI Semibold", 9f, FontStyle.Bold);
        public Font HeaderFont
        {
            get { return _headerFont; }
            set { _headerFont = value; this.Refresh(); }
        }
        private Color _headerForeColour = Color.FromArgb(49, 91, 125);
        public Color HeaderForeColour
        {
            get { return _headerForeColour; }
            set { _headerForeColour = value; this.Refresh(); }
        }

        // Close
        private string _closeText = "❌";
        private Font _closeFont = new Font("Segoe UI", 8.5f);
        private Color _closeForeColour = Color.FromArgb(49, 91, 125);
        public Color CloseForeColour
        {
            get { return _closeForeColour; }
            set { _closeForeColour = value; this.Refresh(); }
        }
        private Color _closeHoverColour = Color.FromArgb(136, 174, 208);
        public Color CloseHoverColour
        {
            get { return _closeHoverColour; }
            set { _closeHoverColour = value; this.Refresh(); }
        }
        private bool _closeAllowed = true;
        public bool CloseAllowed
        {
            get
            {
                return _closeAllowed;
            }
            set
            {
                _closeAllowed = value;
                this.Refresh();
            }
        }

        // Grip
        private int _gripHeight = 13;
        private int _gripWidth = 16;
        private string _gripText = "";
        private Font _gripFont = new Font("Segoe UI Symbol", 8.5f);
        private Color _gripForeColour = Color.SteelBlue;
        public Color GripForeColour
        {
            get { return _gripForeColour; }
            set { _gripForeColour = value; this.Refresh(); }
        }
        private Color _gripBackColour = Color.White;
        public Color GripBackColour
        {
            get { return _gripBackColour; }
            set { _gripBackColour = value; this.Refresh(); }
        }
        private bool _gripVisible = true;
        public bool GripVisible
        {
            get { return _gripVisible; }
            set
            {
                _gripVisible = value;
                SetPadding();
                this.Refresh();
            }
        }


        private void SetPadding()
        {
            int border = BorderVisible ? 1 : 0;
            int grip = GripVisible ? _gripHeight : 0;
            Padding = new Padding(border, _headerHeight + border, border, grip + border);
        }

        public ucWidgetBox()
        {
            InitializeComponent();
            DoubleBuffered = true;
            BackColor = Color.White;
            Size = new Size(200, 100);
            SetPadding();
            Margin = new Padding(10);
        }

        private void Parent_Resize(object sender, EventArgs e)
        {
            return;
            #region (1) Set the location
            int x = Convert.ToInt32(_box.Left / (double)_box.ParentWidth * Parent.Width);
            int y = Convert.ToInt32(_box.Top / (double)_box.ParentHeight * Parent.Height);
            Location = new Point(x, y);
            #endregion

            #region (2) Set the width and height
            int width = Parent.Width - Location.X - _box.MinDistanceRight;
            if (_box.ControlRightLeft.HasValue)
            {
                int left = Convert.ToInt32(_box.ControlRightLeft.Value / (double)_box.ParentWidth * Parent.Width);
                width = left - Location.X - _box.MinDistanceRight;
            }

            int height = Parent.Height - Location.Y - _box.MinDistanceBottom;
            if (_box.ControlBottomTop.HasValue)
            {
                int top = Convert.ToInt32(_box.ControlBottomTop / (double)_box.ParentHeight * Parent.Height);
                height = top - Location.Y - _box.MinDistanceBottom;
            }

            Size = new Size(width, height);
            #endregion


            int r = Right;
            if (_box.ControlLeftRight == null)
            {
                Left = _box.MinDistanceLeft;
                Width = r - _box.MinDistanceLeft;
            }
            else
            {
                //Left = _box.ControlLeftRight.Value + _box.MinDistanceLeft;
                //Width = r - _box.ControlLeftRight.Value - _box.MinDistanceLeft;
            }

            //int b = ctrl.Control.Bottom;
            //if (ctrl.ControlTop == null)
            //{
            //    ctrl.Control.Top = ctrl.MinDistanceTop;
            //    ctrl.Control.Height = b - ctrl.MinDistanceTop;
            //}
            //else
            //{
            //    ctrl.Control.Top = ctrl.ControlTop.Bottom + ctrl.MinDistanceTop;
            //    ctrl.Control.Height = b - ctrl.ControlTop.Bottom - ctrl.MinDistanceTop;
            //}


            Refresh();
        }

        private void ucFeedback2_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_feedbackIsMoving)
            {
                _mouseMoveLocation = e.Location;
                var l = e.Location;

                _headerHover = (l.Y < HeaderHeight) && (l.X < Width - HeaderHeight);
                var wasCloseHover = _closeHover;
                _closeHover = CloseAllowed && (l.Y < HeaderHeight) && (l.X > Width - HeaderHeight);
                _gripHover = _gripVisible && (l.Y > Height - _gripHeight) && (l.X > Width - _gripWidth);

                if (_gripHover)
                {
                    Cursor = Cursors.SizeNWSE;
                }
                else
                {
                    Cursor = Cursors.Default;
                }

                if(wasCloseHover != _closeHover)
                {
                    Invalidate(new Rectangle(Width - HeaderHeight, 0, HeaderHeight, HeaderHeight + 1));
                }
            }
            else
            {
                Invalidate(new Rectangle(0, 0, Width, HeaderHeight + 1));
                Invalidate(new Rectangle(0, Height - _gripHeight - 1, Width, _gripHeight + 2));
            }

            ControlMove(e);
        }
        private void ucFeedback2_MouseLeave(object sender, EventArgs e)
        {
            _closeHover = false;
            _gripHover = false;
            this.Refresh();
            Cursor = Cursors.Default;
        }

        private void ucFeedback2_MouseDown(object sender, MouseEventArgs e)
        {
            if (_gripHover || _headerHover)
            {
                var frm = this.FindForm();
                frm.ActiveControl = null;
                _feedbackIsMoving = true;
                _feedbackMovX = MousePosition.X;
                _feedbackMovY = MousePosition.Y;
                _feedbackWidth = this.Width;
                _feedbackHeight = this.Height;
                _feedbackLocX = this.Location.X;
                _feedbackLocY = this.Location.Y;
            }
        }

        private void ucWidgetBox_Load(object sender, EventArgs e)
        {
        }

        private void ucFeedback2_MouseUp(object sender, MouseEventArgs e)
        {
            if(_feedbackIsMoving)
            {
                this.Select();
            }
            _feedbackIsMoving = false;
        }

        private void ucFeedback2_Click(object sender, EventArgs e)
        {
            if(_closeHover)
            {
                Visible = false;
            }
        }

        private void ucFeedback2_Paint(object sender, PaintEventArgs e)
        {
            // Border
            if (BorderVisible)
            {
                e.Graphics.DrawRectangle(new Pen(BorderColour), 0, 0, Width - 1, Height - 1);
            }

            // Header Background
            int offset = BorderVisible ? 1 : 0;
            e.Graphics.FillRectangle(new SolidBrush(HeaderBackColour), offset, offset, Width - offset*2, HeaderHeight);

            // Header Text
            Size size = TextRenderer.MeasureText(e.Graphics, HeaderText, HeaderFont, new Size(Width - 2, HeaderHeight), TextFormatFlags.NoPadding);
            int x = offset;
            int y = (HeaderHeight - size.Height) / 2 + offset;
            int w = Width- offset*2; // Math.Min(Width, size.Width);
            int h = Math.Min(size.Height, HeaderHeight - y); //Height;
            Rectangle rect = new Rectangle(x, y, w, h);
            TextRenderer.DrawText(e.Graphics, HeaderText, HeaderFont, rect, HeaderForeColour, TextFormatFlags.Left | TextFormatFlags.VerticalCenter);

            // Close Text
            if (CloseAllowed)
            {
                size = TextRenderer.MeasureText(e.Graphics, _closeText, _closeFont, new Size(100, 100), TextFormatFlags.NoPadding);
                w = Math.Max(HeaderHeight, size.Width);
                x = Width - w - offset;
                y = offset; //(HeaderHeight - size.Height) / 2 + offset;
                h = HeaderHeight; //Math.Min(size.Height, HeaderHeight - y); //Height;
                rect = new Rectangle(x, y, w, h);
                if (_closeHover)
                    e.Graphics.FillRectangle(new SolidBrush(CloseHoverColour), rect);
                TextRenderer.DrawText(e.Graphics, _closeText, _closeFont, rect, _closeForeColour);
            }

            // Header Line
            if (HeaderLineVisible)
                e.Graphics.DrawLine(new Pen(HeaderLineColour), offset, HeaderHeight + offset - 1, Width - offset * 2, HeaderHeight + offset - 1);

            // Grip
            if (GripVisible)
            {
                // Grip BackColour
                e.Graphics.FillRectangle(new SolidBrush(GripBackColour), offset, Height - _gripHeight - offset, Width - offset * 2, _gripHeight);

                // Grip Text
                w = _gripWidth;
                x = Width - w - offset;
                y = Height  - _gripHeight - offset;
                h = _gripHeight;
                rect = new Rectangle(x, y, w, h);

                //if (_gripHover)
                //    e.Graphics.FillRectangle(new SolidBrush(Color.Red), rect);

                rect.Y -= 1;
                TextRenderer.DrawText(e.Graphics, _gripText, _gripFont, rect, _gripForeColour, TextFormatFlags.NoPadding);
            }

            //TextRenderer.DrawText(e.Graphics, $"x: {x}\r\ny: {y}\r\nw: {w}\r\nh: {h}", this.Font, new Point(0,30), this.ForeColor);
            //TextRenderer.DrawText(e.Graphics, $"mouse x: {_mouseMoveLocation.X}\r\nmouse y: {_mouseMoveLocation.Y}", this.Font, new Point(0,30), this.ForeColor);


        }

        private void ControlMove(MouseEventArgs e)
        {
            if (Locked)
                return;

            if (_feedbackIsMoving)
            {
                List<Control> ctrls = new List<Control>();
                foreach (Control ctrl in this.Parent.Controls)
                    if (ctrl != this)
                        ctrls.Add(ctrl);

                if (_headerHover)
                {
                    this.BringToFront();

                    int x = _feedbackLocX - (_feedbackMovX - MousePosition.X);
                    int y = _feedbackLocY - (_feedbackMovY - MousePosition.Y);

                    // To ensure the control stays completely visible on the panel
                    //x = Math.Min(this.Parent.Width - this.Width, Math.Max(0, x));  
                    //y = Math.Min(this.Parent.Height - this.Height, Math.Max(0, y));


                    foreach (var c in ctrls)
                    {
                        var dist = c.Left - (x + this.Width);
                        if ((dist > 10) && (dist < 30))
                        {
                            x = c.Location.X - 20 - this.Width;
                            break;
                        }
                    }

                    foreach (var c in ctrls)
                    {
                        var dist = c.Left - x;
                        if ((dist > -10) && (dist < 10))
                        {
                            x = c.Left;
                            break;
                        }
                    }

                    foreach (var c in ctrls)
                    {
                        var dist = x - (c.Left + c.Width);
                        if ((dist > 10) && (dist < 30))
                        {
                            x = (c.Left + c.Width) + 20;
                            break;
                        }
                    }

                    foreach (var c in ctrls)
                    {
                        var dist = c.Top - y;
                        if ((dist > -10) && (dist < 10))
                        {
                            y = c.Location.Y;
                            break;
                        }
                    }

                    foreach (var c in ctrls)
                    {
                        var dist = y - (c.Top + c.Height);
                        if ((dist > 10) && (dist < 30))
                        {
                            y = c.Top + c.Height + 20;
                            break;
                        }
                    }

                    foreach (var c in ctrls)
                    {
                        var dist = c.Top - (y + this.Height);
                        if ((dist > 10) && (dist < 30))
                        {
                            y = c.Top - this.Height - 20;
                            break;
                        }
                    }

                    this.Location = new Point(x, y);
                }
                else if (_gripHover)
                {
                    //this.Width = Math.Max(200, _feedbackWidth - (_feedbackMovX - MousePosition.X));
                    //this.Height = Math.Max(100, _feedbackHeight - (_feedbackMovY - MousePosition.Y));

                    var width = _feedbackWidth - (_feedbackMovX - MousePosition.X);
                    var height = _feedbackHeight - (_feedbackMovY - MousePosition.Y);

                    foreach (var c in ctrls)
                    {
                        var dist = c.Left - (this.Left + width);
                        if ((dist > 10) && (dist < 30))
                        {
                            width = c.Left - this.Left - 20;
                            break;
                        }
                    }

                    foreach (var c in ctrls)
                    {
                        var dist = c.Right - (this.Left + width);
                        if ((dist > -10) && (dist < 10))
                        {
                            width = c.Right - this.Left;
                            break;
                        }
                    }

                    foreach (var c in ctrls)
                    {
                        var dist = c.Top - (this.Top + height);
                        if ((dist > 10) && (dist < 30))
                        {
                            height = c.Top - this.Top - 20;
                            break;
                        }
                    }

                    foreach (var c in ctrls)
                    {
                        var dist = c.Bottom - (this.Top + height);
                        if ((dist > -10) && (dist < 10))
                        {
                            height = c.Bottom - this.Top;
                            break;
                        }
                    }

                    Rectangle rectHeader = new Rectangle(0, 0, width, _headerHeight + 1);
                    Rectangle rectFooter = new Rectangle(0, this.Height - _gripHeight - 1, width, _gripHeight + 1);

                    this.Width = width;
                    this.Height = height;

                    //this.Refresh();
                }
            }
        }


    }
}
