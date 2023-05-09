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
    public class Circle : Shape
    {
        private double _radius;
        public double Radius 
        {
            get => _radius;
            set
            {
                if (value < 0)
                    throw new InvalidValueException("Only positive values allowed!");

                _radius = value;
            }
        }
        
        public override double Area
        {
            get
            {
                return Math.PI * Radius * Radius;
            }
        }

        public double Perimeter
        {
            get
            {
                return Math.PI * Radius * 2;
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
                graphics.FillEllipse(brush, Location.X, Location.Y, (float)(2 * Radius), (float)(2 * Radius));
            }
            using (var pen = new Pen(Color))
            {
                graphics.DrawEllipse(pen, Location.X, Location.Y, (float)(2 * Radius), (float)(2 * Radius));
            }

        }
        public override bool PointInShape(Point point)
        {
            if (Math.Pow((point.X - (Location.X + Radius)), 2) + Math.Pow((point.Y - (Location.Y + Radius)), 2) <= Radius * Radius)
                return true;
            return false;
        }
        public override bool Intersect(Rectangle rectangle)
        {
            return
                Math.Pow((rectangle.Location.X - (this.Location.X + Radius)), 2) + Math.Pow((rectangle.Location.Y - (this.Location.Y + Radius)), 2) <= Radius * Radius ||
                Math.Pow(((rectangle.Location.X + rectangle.Width) - (this.Location.X + Radius)), 2) + Math.Pow((rectangle.Location.Y - (this.Location.Y + Radius)), 2) <= Radius * Radius ||
                Math.Pow(((rectangle.Location.X + rectangle.Width) - (this.Location.X + Radius)), 2) + Math.Pow(((rectangle.Location.Y + rectangle.Height) - (this.Location.Y + Radius)), 2) <= Radius * Radius ||
                Math.Pow((rectangle.Location.X - (this.Location.X + Radius)), 2) + Math.Pow(((rectangle.Location.Y + rectangle.Height) - (this.Location.Y + Radius)), 2) <= Radius * Radius ||
                (rectangle.Location.X<=this.Location.X&&(rectangle.Location.X+rectangle.Width)>=(this.Location.X+2*Radius)&&
                rectangle.Location.Y<=this.Location.Y&&(rectangle.Location.Y+rectangle.Height)>=(this.Location.Y+2*Radius))||
                (Math.Abs(rectangle.Location.Y-(this.Location.Y+Radius))<=Radius&&rectangle.Location.X<(this.Location.X+Radius)&& (this.Location.X + Radius) < (rectangle.Location.X+rectangle.Width))||
                (Math.Abs((rectangle.Location.Y+rectangle.Height) - (this.Location.Y + Radius)) <= Radius && rectangle.Location.X < (this.Location.X + Radius) && (this.Location.X + Radius) < (rectangle.Location.X + rectangle.Width))||
                (Math.Abs(rectangle.Location.X - (this.Location.X + Radius)) <= Radius && rectangle.Location.Y < (this.Location.Y + Radius) && (this.Location.Y + Radius) < (rectangle.Location.Y + rectangle.Height))||
                (Math.Abs((rectangle.Location.X+rectangle.Width) - (this.Location.X + Radius)) <= Radius && rectangle.Location.Y < (this.Location.Y + Radius) && (this.Location.Y + Radius) < (rectangle.Location.Y + rectangle.Height))
                ;
        }
    }
}
