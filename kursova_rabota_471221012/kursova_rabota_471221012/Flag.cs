using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using kursova_rabota_471221012.Exceptions;

namespace kursova_rabota_471221012
{
    [Serializable]
    public class Flag:Shape
    {
        private double _height;
        private double _width;
        public double Height 
        {
            get => _height;
            set
            {
                if (value < 0)
                    throw new InvalidValueException("Only positive values allowed!");

                _height = value;
            }
        }
        public double Width 
        { 
            get => _width;
            set
            {
                if (value < 0)
                    throw new InvalidValueException("Only positive values allowed!");

                _width = value;
            }
        }
        private int fl = 1;
        private int _transp=255;
        public int Transparency
        {
            get
            {
                return _transp;
            }
            set
            {
                _transp = value;
            }
        }

        public override double Area
        {
            get
            {
                return Width * Height;
            }
        }
        public double Area2
        {
            get
            {
                return Area / 3;
            }
        }
        public override Color Color
        {
            get
            {
                if (Selected)
                {
                    return Color.Brown;
                }
                return Color.Yellow;
            }
        }
        protected override Color _colorFill
        {
            get
            {
                if(fl==1)
                    return Color.FromArgb(_transp, Color.White);
                if(fl==2)
                    return Color.FromArgb(_transp, Color.Green);
                else
                    return Color.FromArgb(_transp, Color.Red);
            }
        }
        

        public override void Paint(Graphics graphics)
        {
            /*Color colorBoard;
            if (Selected)
            {
                colorBoard = Color.Red;
            }
            else
                colorBoard = Color;*/

            //var colorFill = Color.FromArgb(100, Color);
            
            using (var brush = new SolidBrush(_colorFill))
            {
                graphics.FillRectangle(brush, Location.X, Location.Y, (float)Width,(float) (Height/3));
            }
            fl++;
            using (var brush = new SolidBrush(_colorFill))
            {
                graphics.FillRectangle(brush, Location.X, (float)((double)Location.Y + Height / 3), (float)Width, (float)(Height / 3));
            }
            fl++;
            using (var brush = new SolidBrush(_colorFill))
            {
                graphics.FillRectangle(brush, Location.X, (float)((double)Location.Y+2*Height/3), (float)Width, (float)(Height / 3));
            }
            fl = 1;
            using (var pen = new Pen(Color))
            {
                graphics.DrawRectangle(pen, Location.X, Location.Y, (float)Width, (float)Height);
            }

        }
        public override bool PointInShape(Point point)
        {
            return Location.X <= point.X && point.X <= Location.X + Width && Location.Y <= point.Y && point.Y <= Location.Y + Height;
        }
        public override bool Intersect(Rectangle rectangle)
        {
            return
                this.Location.X <= rectangle.Location.X + rectangle.Width &&
                rectangle.Location.X <= this.Location.X + this.Width &&
                this.Location.Y <= rectangle.Location.Y + rectangle.Height &&
                rectangle.Location.Y <= this.Location.Y + this.Height;
        }
    }
}
