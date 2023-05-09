using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_kr_471221012
{
    [Serializable]
    public abstract class Shape
    {
        public Point Location { get; set; }

        private Color color;
        public virtual Color Color 
        { 
            get
            {
                if (Selected)
                {
                    return Color.Red;
                }
                return color;
            }
            set
            {
                color = value;
            }
        }
        protected virtual Color _colorFill 
        {
            get
            {
                return Color.FromArgb(100, color);
            }
        }

        [NonSerialized]
        private bool _sel;
        public bool Selected 
        { 
            get=>_sel; 
            set=>_sel=value; 
        }
        public abstract double Area { get; }

        public abstract void Paint(IGraphics graphics);
        public abstract bool PointInShape(Point point);
        public abstract bool Intersect(Rectangle rectangle);
    }
}
