using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Library_kr_471221012
{
    [Serializable]
    public class Triangle : Shape
    {
        
        public  Point p1 { get;  set; }
        public  Point p2 { get; set; }
        public  Point p3 { get; set; }


        public override double Area
        {
            get
            {
                return (double)((p2.X-p1.X)*(p2.Y-p3.Y))/2.0;
            }
        }
        
        private double _area(int x1, int y1, int x2, int y2, int x3, int y3)
        {
            return Math.Abs((double)(x1 * (y2 - y3) +
                         x2 * (y3 - y1) +
                         x3 * (y1 - y2)) / 2.0);
        }
        public override void Paint(IGraphics graphics)
        {

            /*Color colorBoard;
            if (Selected)
            {
                colorBoard = Color.Red;
            }
            else
                colorBoard = Color;*/

            //var colorFill = Color.FromArgb(100, Color);

            Point[] points = { p1, p2, p3 };

            /*using (var brush = new SolidBrush(_colorFill))
            {
                graphics.FillPolygon(brush, points);
            }
            using (var pen = new Pen(Color))
            {
                graphics.DrawPolygon(pen, points);
            }*/

            graphics.DrawTriangle(Color,_colorFill,points);

        }
        public override bool PointInShape(Point point)
        {
            double A1 = _area(p1.X, p1.Y, p2.X, p2.Y, point.X, point.Y);
            double A2 = _area(point.X, point.Y, p2.X, p2.Y, p3.X, p3.Y);
            double A3 = _area(p1.X, p1.Y, point.X, point.Y, p3.X, p3.Y);
            return Area == A1 + A2 + A3;
        }
        public override bool Intersect(Rectangle rectangle)
        {
            Point r_p1 = new Point
            {
                X = rectangle.Location.X+rectangle.Width,
                Y = rectangle.Location.Y,
            };
            Point r_p2 = new Point
            {
                X = rectangle.Location.X + rectangle.Width,
                Y = rectangle.Location.Y+rectangle.Height,
            };
            Point r_p3 = new Point
            {
                X = rectangle.Location.X,
                Y = rectangle.Location.Y+rectangle.Height,
            };
            return 
                PointInShape(rectangle.Location) ||
                PointInShape(r_p1) ||
                PointInShape(r_p2) ||
                PointInShape(r_p3)||
                rectangle.PointInShape(p1)||
                rectangle.PointInShape(p2)||
                rectangle.PointInShape(p3)||
                (rectangle.Location.Y<=p1.Y && p1.Y<=rectangle.Location.Y+rectangle.Height&&
                rectangle.Location.X<=p3.X && p3.X<= rectangle.Location.X + rectangle.Width)||
                (rectangle.Location.X<=p3.X && p3.X<=rectangle.Location.X+rectangle.Width&&
                p3.Y<=rectangle.Location.Y && rectangle.Location.Y+rectangle.Height<=p1.Y)||
                (((p1.X<=rectangle.Location.X&&rectangle.Location.X<=p3.X)||(p3.X <= rectangle.Location.X && rectangle.Location.X <= p2.X))&&
                rectangle.Location.Y+rectangle.Height>=p1.Y&&
                rectangle.Location.Y<=p1.Y);
        }
    }
}
