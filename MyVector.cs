using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace OOPLab4
{
    public class MyVector
    {
        public int X { get; set; }
        public int Y { get; set; }
        public MyVector()
        {
            X = 0;
            Y = 0;
        }
        public MyVector(int x, int y)
        {
            X = x;
            Y = y;
        }

        public MyVector(MyVector vector)
        {
            X = vector.X;
            Y = vector.Y;
        }

        public MyVector(Point point)
        {
            X = point.X;
            Y = point.Y;
        }

        public void changeCoords(in Point point)
        {
            X = point.X;
            Y = point.Y;
        }

        public void changeCoords(in Size size)
        {
            X = size.Width;
            Y = size.Height;
        }

        public static MyVector operator +(MyVector a, MyVector b)
        {
            return new MyVector(a.X + b.X, a.Y + b.Y);
        }

        public static MyVector operator -(MyVector a, MyVector b)
        {
            return new MyVector(a.X - b.X, a.Y - b.Y);
        }

        public static MyVector operator *(MyVector a, float b)
        {
            return new MyVector(Convert.ToInt32(a.X * b), Convert.ToInt32(a.Y * b));
        }

        public static MyVector operator /(MyVector a, int b)
        {
            return new MyVector(Convert.ToInt32(a.X / b), Convert.ToInt32(a.Y / b));
        }
    }
}