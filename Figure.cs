﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace OOPLab4
{
    public abstract class Figure
    {
        public int x { get; set; }
        public int y { get; set; }
        public bool isActive { get; set; }
        protected Pen selectedPen, standartPen;
        public Color currentColor { get; set; } = Color.White;
        public abstract void myPaint(in Graphics g);
        public abstract bool intersects(MyVector coords);
        public abstract void changeColor(Color newColor);
        public abstract void move(MyVector direction);
        public abstract void changeScale(float factor);
        public abstract void getRect(MyVector leftTop, MyVector rightBottom);
    }
}