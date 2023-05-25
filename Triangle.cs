﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace OOPLab4
{
    internal class Triangle : Figure
    {

        public int side;
        public Triangle(int x, int y, Color color, int side = 100)
        {
            this.x = x;
            this.y = y;
            this.side = side;
            standartPen = new Pen(Color.Black, 5);
            selectedPen = new Pen(Color.Red, 5);
            isActive = false;
            currentColor = color;
        }

        public override void myPaint(in Graphics g)
        {
            if (isActive)
            {
                g.DrawPolygon(selectedPen, new Point[] { new Point(x, y - side), new Point((x + side), y), new Point(x - side, y) });

            }
            else
            {
                g.DrawPolygon(standartPen, new Point[] { new Point(x, y - side), new Point((x + side), y), new Point(x - side, y) });
            }
            g.FillPolygon(new SolidBrush(currentColor), new Point[] { new Point(x, y - side), new Point((x + side), y), new Point(x - side, y) });
        }

        public override bool intersects(MyVector coords)
        {

            int a = (x - coords.X) * (side) - (x - side - x) * (y - side - coords.Y);
            int b = -2 * side * (y - coords.Y);
            int c = (x + side - coords.X) * (-side) - (-side) * (y - coords.Y);

            if ((a >= 0 && b >= 0 && c >= 0) || (a <= 0 && b <= 0 && c <= 0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void changeColor(Color newColor)
        {
            currentColor = newColor;
        }

        public override void move(MyVector direction)
        {
            x += direction.X;
            y += direction.Y;
        }

        public override void getRect(MyVector leftTop, MyVector rightBottom)
        {
            leftTop.X = x - side;
            leftTop.Y = y - side;
            rightBottom.X = x + side;
            rightBottom.Y = y;
        }

        public override void changeScale(float factor)
        {
            side = Convert.ToInt32(factor * side);
        }
    }
}