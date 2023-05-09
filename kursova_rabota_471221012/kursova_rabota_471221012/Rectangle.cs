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
    public class Rectangle:Shape
    {
        private int _h, _w;
        public int Height 
        { 
            get=>_h; 
            set
            {
                if (value < 0)
                    throw new InvalidValueException("Only positive values allowed!");

                _h = value;
            }
        }
        public int Width 
        { 
            get=>_w;
            set
            {
                if (value < 0)
                    throw new InvalidValueException("Only positive values allowed!");

                _w = value;
            }
        }
        public override double Area
        {
            get
            {
                return Width * Height;
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
                graphics.FillRectangle(brush, Location.X, Location.Y, Width, Height);
            }
            using (var pen = new Pen(Color))
            {
                graphics.DrawRectangle(pen, Location.X, Location.Y, Width, Height);
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
