using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MK_Ultra.Sandwich.SupportTools
{
    [Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(IDesigner))]
    public partial class ucWidgetContainer : UserControl
    {
        private ControlBoxManager _controlBoxManager = new ControlBoxManager();
        private bool _resizing = false;

        private bool _smartResize = false;
        [Browsable(true)]
        public bool SmartResize
        {
            get { return _smartResize; }
            set { _smartResize = value; }
        }

        public ucWidgetContainer()
        {
            InitializeComponent();
        }

        class Place
        {
            public Point Location { get; set; }
            public Size Size { get; set; }

            public int Width => Size.Width;
            public int Height => Size.Height;
            public int Top => Location.Y;
            public int Left => Location.X;
            public int Right => Location.X + Width;
            public int Bottom => Location.Y + Height;

            public Place(Control control)
            {
                Location = control.Location;
                Size = control.Size;
            }
        }

        class ControlBox
        {
            public Control Control { get; set; }
            public Place Place { get; set; }

            public int MinDistanceRight { get; set; }
            public Place PlaceRight { get; set; }

            public int MinDistanceLeft { get; set; }
            public Place PlaceLeft { get; set; }    
            
            public int MinDistanceTop { get; set; }
            public Place PlaceTop { get; set; } 
            
            public int MinDistanceBottom { get; set; }
            public Place PlaceBottom { get; set; }

            public int Left { get; set; }
            public int Right { get; set; }
            public int Width { get; set; }
            public int ParentWidth { get; set; }

            public int Top { get; set; }
            public int Bottom { get; set; }
            public int Height { get; set; }
            public int ParentHeight { get; set; }

            public int NewLeft { get; set; }
            public int NewTop { get; set; }
            public int NewWidth { get; set; }
            public int NewHeight { get; set; } 
        }

        class ControlBoxManager
        {
            public List<ControlBox> ControlBoxes { get; set; }

            public ControlBoxManager()
            {
                ControlBoxes = new List<ControlBox>();
            }

            public void Clear()
            {
                ControlBoxes.Clear();
            }

            public void Add(Control control)
            {
                var ctrl = new ControlBox();
                ctrl.Control = control;
                ctrl.Place = new Place(control);

                ctrl.Left = control.Left;
                ctrl.Right = control.Right;
                ctrl.Width = control.Width;
                ctrl.ParentWidth = control.Parent.Width;

                ctrl.Top = control.Top;
                ctrl.Bottom = control.Bottom;
                ctrl.Height = control.Height;
                ctrl.ParentHeight = control.Parent.Height;

                ControlBoxes.Add(ctrl);

                foreach (var box in ControlBoxes)
                {
                    var right = ControlBoxes.Where(x => x.Left >= box.Right).OrderBy(x => x.Left).FirstOrDefault();
                    if (right == null)
                    {
                        box.MinDistanceRight = box.ParentWidth - box.Right;
                    }
                    else
                    {
                        box.PlaceRight = right.Place;
                        box.MinDistanceRight = right.Left - box.Right;
                    }

                    var left = ControlBoxes.Where(x => x.Right <= box.Left).OrderBy(x => x.Right).LastOrDefault();
                    if (left == null)
                    {
                        box.MinDistanceLeft = box.Left;
                    }
                    else
                    {
                        box.PlaceLeft = left.Place;
                        box.MinDistanceLeft = box.Left - left.Right;
                    }

                    var bottom = ControlBoxes.Where(x => x.Top >= box.Bottom).OrderBy(x => x.Top).FirstOrDefault();
                    if (bottom == null)
                    {
                        box.MinDistanceBottom = box.ParentHeight - box.Bottom;
                    }
                    else
                    {
                        box.PlaceBottom = bottom.Place; 
                        box.MinDistanceBottom = bottom.Top - box.Bottom;
                    }

                    var top = ControlBoxes.Where(x => x.Bottom <= box.Top).OrderBy(x => x.Bottom).LastOrDefault();
                    if (top == null)
                    {
                        box.MinDistanceTop = box.Top;
                    }
                    else
                    {
                        box.PlaceTop = top.Place;
                        box.MinDistanceTop = box.Top - top.Bottom;
                    }
                }
            }

            public void Resize(Size newSize)
            {
                ControlBoxes.ForEach(ctrl =>
                {
                    int x = Convert.ToInt32(ctrl.Left / (double)ctrl.ParentWidth * newSize.Width);
                    int y = Convert.ToInt32(ctrl.Top / (double)ctrl.ParentHeight * newSize.Height);

                    ctrl.Place.Location = new Point(x, y);
                });

                ControlBoxes.ForEach(ctrl =>
                {
                    int width = newSize.Width - ctrl.Place.Left - ctrl.MinDistanceRight;
                    if (ctrl.PlaceRight != null)
                        width = ctrl.PlaceRight.Left - ctrl.Place.Left - ctrl.MinDistanceRight;

                    int height = newSize.Height - ctrl.Place.Top - ctrl.MinDistanceBottom;
                    if (ctrl.PlaceBottom != null)
                        height = ctrl.PlaceBottom.Top - ctrl.Place.Top - ctrl.MinDistanceBottom;

                    ctrl.Place.Size = new Size(width, height);
                });

                ControlBoxes.ForEach(ctrl =>
                {
                    int left, top, width, height;

                    int r = ctrl.Place.Right;
                    if (ctrl.PlaceLeft == null)
                    {
                        left = ctrl.MinDistanceLeft;
                        width = r - ctrl.MinDistanceLeft;
                    }
                    else
                    {
                        left = ctrl.PlaceLeft.Right + ctrl.MinDistanceLeft;
                        width = r - ctrl.PlaceLeft.Right - ctrl.MinDistanceLeft;
                    }

                    int b = ctrl.Place.Bottom;
                    if (ctrl.PlaceTop == null)
                    {
                        top = ctrl.MinDistanceTop;
                        height = b - ctrl.MinDistanceTop;
                    }
                    else
                    {
                        top = ctrl.PlaceTop.Bottom + ctrl.MinDistanceTop;
                        height = b - ctrl.PlaceTop.Bottom - ctrl.MinDistanceTop;
                    }

                    ctrl.Place.Location = new Point(left, top);
                    ctrl.Place.Size = new Size(width, height);
                });

                ControlBoxes.ForEach(ctrl => 
                {
                    ctrl.Control.Location = ctrl.Place.Location; 
                    ctrl.Control.Size = ctrl.Place.Size;
                    ctrl.Control.Refresh();
                });
            }
        }

        private void ucWidgetContainer_Load(object sender, EventArgs e)
        {
            try
            {
                SetBoxes();
            }
            catch (Exception ex)
            {
            }
        }

        private void SetBoxes()
        {
            foreach (Control ctrl in Controls)
            {
                ctrl.LocationChanged -= Ctrl_LocationChanged;
                ctrl.SizeChanged -= Ctrl_SizeChanged;
            }  

            _controlBoxManager.Clear();

            foreach (Control ctrl in Controls)
            {
                ctrl.LocationChanged += Ctrl_LocationChanged;
                ctrl.SizeChanged += Ctrl_SizeChanged;
                _controlBoxManager.Add(ctrl);
            }
        }

        private void Ctrl_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                if (_resizing)
                    return;
            }
            catch (Exception ex)
            {
            }
        }

        private void Ctrl_LocationChanged(object sender, EventArgs e)
        {
            try
            {
                if (_resizing)
                    return;
            }
            catch (Exception ex) {  }
        }

        private void ucWidgetContainer_Resize(object sender, EventArgs e)
        {
            try
            {
                _resizing = true;

                if (SmartResize)
                {
                    _controlBoxManager.Resize(Size);
                }

                _resizing = false;
            }
            catch (Exception ex)
            {
            }
        }

        private void ucWidgetContainer_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                if (DesignMode && (BorderStyle == BorderStyle.None))
                {
                    Pen pen = new Pen(Color.FromArgb(133, 133, 133));
                    pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                    e.Graphics.DrawRectangle(pen, 0, 0, Width - 1, Height - 1);
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}
