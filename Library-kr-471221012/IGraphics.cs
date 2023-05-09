using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_kr_471221012
{
    public interface IGraphics
    {
        void DrawRectangle(Color colorBorder, Color colorFill, int x, double y, double width, double height);
        void DrawCircle(Color colorBorder, Color colorFill, int x, int y, double r);
        void DrawTriangle(Color colorBorder, Color colorFill, Point[] p);
        void DrawSquare(Color colorBorder, Color colorFill, int x, int y, int width);

    }
}
