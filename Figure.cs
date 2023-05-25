using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace OOPLab4
{
    public abstract class Figure
    {
        public bool isActive { get; set; }
        public abstract void myPaint(in Graphics g);
        public abstract bool intersects(Point coords);
    }
}
