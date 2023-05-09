using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kursova_rabota_471221012
{
    public partial class FormScene : Form
    {
        private List<Shape> _shapes = new List<Shape>();
        private Rectangle _frameRectangle;
        private Point _mouseDownLocation;
        private int i = 1;
        private Shape sh;
        public FormScene()
        {
            InitializeComponent();

            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
        }

        private double CalculateShapesArea()
        {
            double area = 0;
            for (int s = 0; s < _shapes.Count(); s++)
            {
                area += _shapes[s].Area;

            }
            return area;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            foreach (var s in _shapes)
            {
                s.Paint(e.Graphics);
            }
            _frameRectangle?.Paint(e.Graphics);

            var centerPoint = new Point
            {
                X = Width / 2,
                Y = Height / 2,
            };

            using (var pen = new Pen(Color.Gray))
            {
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
                pen.Width = 2;
                e.Graphics.DrawEllipse(pen, centerPoint.X - 2, centerPoint.Y - 2, 4, 4);
            }
        }

        private void FormScene_MouseDown(object sender, MouseEventArgs e)
        {
            _mouseDownLocation = e.Location;
            _frameRectangle = new Rectangle
            {
                Color = Color.Gray,
            };

            NotSelectShapes(_shapes);

            for (int s = _shapes.Count() - 1; s >= 0; s--)
            {
                if (_shapes[s].PointInShape(e.Location))
                {
                    _shapes[s].Selected = true;
                    break;
                }

            }

            Invalidate();
        }

        private void FormScene_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Delete)
                return;

            for (int s = _shapes.Count - 1; s >= 0; s--)
            {
                if (_shapes[s].Selected)
                    _shapes.RemoveAt(s);
            }

            toolStripStatusLabelArea.Text = CalculateShapesArea().ToString();
            Invalidate();
        }

        private void FormScene_MouseMove(object sender, MouseEventArgs e)
        {
            if (_frameRectangle == null)
                return;

            _frameRectangle.Location = new Point
            {
                X = Math.Min(_mouseDownLocation.X, e.Location.X),
                Y = Math.Min(_mouseDownLocation.Y, e.Location.Y),
            };

            _frameRectangle.Width = Math.Abs(_mouseDownLocation.X - e.Location.X);
            _frameRectangle.Height = Math.Abs(_mouseDownLocation.Y - e.Location.Y);

            if (e.Button == MouseButtons.Right)
            {
                for (int s = 0; s < _shapes.Count(); s++)
                {
                    _shapes[s].Selected = _shapes[s].Intersect(_frameRectangle);
                }
            }

            Invalidate();
        }

        private void AfterDrawWork(Shape sh, List<Shape> shapes)
        {
            shapes.Add(sh);
            sh.Selected = true;

            toolStripStatusLabelArea.Text = CalculateShapesArea().ToString();
        }
        private void FormScene_MouseUp(object sender, MouseEventArgs e)
        {
            if (_frameRectangle == null)
                return;
            
            if (e.Button == MouseButtons.Left)
            {
                switch(i)
                {
                    case 1:
                        var r1 = new Random();
                        _frameRectangle.Color = Color.FromArgb(r1.Next(255), r1.Next(255), r1.Next(255));

                        NotSelectShapes(_shapes);

                        AfterDrawWork(_frameRectangle, _shapes);
                        break;

                    case 2:
                        var r2 = new Random();
                        int min;
                        min = Math.Min(_frameRectangle.Height, _frameRectangle.Width);
                        sh = new Square()
                        {
                            a = min,
                            Color = Color.FromArgb(r2.Next(255), r2.Next(255), r2.Next(255)),
                        };

                        sh.Location = new Point
                        {
                            X = _frameRectangle.Location.X,
                            Y = _frameRectangle.Location.Y,
                        };

                        NotSelectShapes(_shapes);

                        AfterDrawWork(sh, _shapes);
                        break;
                    case 3:
                        var r3 = new Random();
                        int min3;
                        min3 = Math.Min(_frameRectangle.Height, _frameRectangle.Width);
                        sh = new Circle()
                        {
                            Radius = ((double)min3) / 2.0,
                            Color = Color.FromArgb(r3.Next(255), r3.Next(255), r3.Next(255)),
                        };

                        sh.Location = new Point
                        {
                            X = _frameRectangle.Location.X,
                            Y = _frameRectangle.Location.Y,
                        };

                        NotSelectShapes(_shapes);

                        AfterDrawWork(sh, _shapes);
                        break;

                    case 4:
                        var r4 = new Random();

                        Point P1 = new Point()
                        {
                            X = _frameRectangle.Location.X,
                            Y = _frameRectangle.Location.Y + _frameRectangle.Height,
                        };

                        Point P2 = new Point()
                        {
                            X = _frameRectangle.Location.X + _frameRectangle.Width,
                            Y = _frameRectangle.Location.Y + _frameRectangle.Height,
                        };

                        Point P3 = new Point()
                        {
                            X = _frameRectangle.Location.X + (int)(((float)_frameRectangle.Width) / 2),
                            Y = _frameRectangle.Location.Y,
                        };

                        sh = new Triangle()
                        {
                            Color = Color.FromArgb(r4.Next(255), r4.Next(255), r4.Next(255)),
                            p1 = P1,
                            p2 = P2,
                            p3 = P3,

                        };

                        sh.Location = new Point
                        {
                            X = _frameRectangle.Location.X,
                            Y = _frameRectangle.Location.Y,
                        };

                        NotSelectShapes(_shapes);

                        AfterDrawWork(sh, _shapes);

                        break;

                    case 5:
                        sh = new Flag()
                        {
                            Height = _frameRectangle.Height,
                            Width = _frameRectangle.Width,
                        };

                        sh.Location = new Point
                        {
                            X = _frameRectangle.Location.X,
                            Y = _frameRectangle.Location.Y,
                        };

                        NotSelectShapes(_shapes);

                        AfterDrawWork(sh, _shapes);

                        break;

                }
                

            }
            _frameRectangle = null;
            sh = null;

            Invalidate();
        }

        private void FormScene_DoubleClick(object sender, EventArgs e)
        {
            foreach (var shape in _shapes)
                if (shape.Selected)
                {
                    shape.Selected = false;
                    if(shape is Rectangle)
                    {
                        var fr = new FormRectangle();
                        fr.Rectangle = (Rectangle)shape;
                        fr.ShowDialog();
                        break;
                    }

                    else if(shape is Square)
                    {
                        var fr = new FormSquare();
                        fr.Square = (Square)shape;
                        fr.ShowDialog();
                        break;
                    }

                    else if (shape is Circle)
                    {
                        var fr = new FormCircle();
                        fr.Circle = (Circle)shape;
                        fr.ShowDialog();
                        break;
                    }

                    else if (shape is Flag)
                    {
                        var fr = new FormBGFlag();
                        fr.Flag = (Flag)shape;
                        fr.ShowDialog();
                        break;
                    }

                    else 
                    {
                        var fr = new FormTriangle();
                        fr.Triangle = (Triangle)shape;
                        fr.ShowDialog();
                        break;
                    }
                }

            Invalidate();
        }

        private void SelectShapes(List<Shape> shapes)
        {
            foreach (var s in shapes)
                s.Selected = true;

            Invalidate();
        }

        private void NotSelectShapes(List<Shape> shapes)
        {
            foreach (var s in shapes)
                s.Selected = false;

            Invalidate();
        }

        private void rectangleButton_Click(object sender, EventArgs e)
        {
            i = 1;
        }

        private void squareButton_Click(object sender, EventArgs e)
        {
            i = 2;
        }

        private void circleButton_Click(object sender, EventArgs e)
        {
            i = 3;
        }

        private void triangleButton_Click(object sender, EventArgs e)
        {
            i = 4;
        }

        private void flagButton_Click(object sender, EventArgs e)
        {
            i = 5;
        }

        /*private void rightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var centerX = Width / 2;

            var rightShapes = _shapes.Where(s => s.Location.X + s.Width >= centerX);

            SelectShapes(rightShapes);
        }
        */
        private void centerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NotSelectShapes(_shapes);

            var centerPoint = new Point
            {
                X = Width / 2,
                Y = Height / 2,
            };

            var centerShapes = _shapes
                .Where(s => s.PointInShape(centerPoint))
                .ToList();

            if (centerShapes.Count == 0)
            {
                MessageBox.Show("There are NO shapes in which the center point is positioned", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            else
            {
                SelectShapes(centerShapes);
            }

        }

        private void FormScene_FormClosing(object sender, FormClosingEventArgs e)
        {
            IFormatter formatter = new BinaryFormatter();

            using (var fs = new FileStream("memory", FileMode.Create))
            {
                formatter.Serialize(fs, _shapes);
            }
        }

        private void FormScene_Load(object sender, EventArgs e)
        {
            if (!File.Exists("memory"))
                return;

            IFormatter formatter = new BinaryFormatter();

            using (var fs = new FileStream("memory", FileMode.Open))
            {
                _shapes=(List<Shape>) formatter.Deserialize(fs);
            }
        }

        /*private void leftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var centerX = Width / 2;

            var leftShapes = (List<Shape>)_shapes.Where(s => s.Location.X <= centerX);

            SelectShapes(leftShapes);
        }*/
    }
}
