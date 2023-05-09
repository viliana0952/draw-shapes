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
    public class Square:Shape
    {
        private int _b;
        public int a 
        {
            get => _b;
            set
            {
                if (value < 0)
                    throw new InvalidValueException("Only positive values allowed!");

                _b = value;
            }
        }
        public override double Area
        {
            get
            {
                return a * a;
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
                graphics.FillRectangle(brush, Location.X, Location.Y, a, a);
            }
            using (var pen = new Pen(Color))
            {
                graphics.DrawRectangle(pen, Location.X, Location.Y, a, a);
            }

        }
        public override bool PointInShape(Point point)
        {
            return Location.X <= point.X && point.X <= Location.X + a && Location.Y <= point.Y && point.Y <= Location.Y + a;
        }
        public override bool Intersect(Rectangle rectangle)
        {
            return
                this.Location.X <= rectangle.Location.X + rectangle.Width &&
                rectangle.Location.X <= this.Location.X + this.a &&
                this.Location.Y <= rectangle.Location.Y + rectangle.Height &&
                rectangle.Location.Y <= this.Location.Y + this.a;
        }
    }
}
