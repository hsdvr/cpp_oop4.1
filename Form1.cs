using System;
using System.Drawing;
using System.Windows.Forms;

namespace OOPLab4
{
    public partial class Form1 : Form
{
    Storage storage; 

    bool isCtrlActive = false;
    bool isCollisionActive = true;
    bool pressedCtrl = false;
    bool isMove = false;
    bool isScale = false;

    MyVector leftTopPaintBox, rightBottomPaintBox;

    enum Figures
    {
        Circle,
        Square,
        Triangle,
    }
    Figures currentFigure;

    Object[] colors = { Color.White, Color.Blue, Color.Green, Color.Yellow, Color.Red };
    Color currentColor;

    MyVector lastMouseCoords;

    public Form1()
    {
        InitializeComponent();
        storage = new Storage();
        setFigure.DataSource = Enum.GetValues(typeof(Figures));
        setFigure.SelectedItem = Figures.Circle;
        currentFigure = Figures.Circle;
        setColor.Items.AddRange(colors);
        setColor.SelectedItem = Color.White;
        currentColor = Color.White;
        leftTopPaintBox = new MyVector(0, 0);
        rightBottomPaintBox = new MyVector(PaintBox.Width, PaintBox.Height);
        lastMouseCoords = new MyVector();
        checkBoxCtrl.Checked = true;
    }

        private void PaintBox_MouseClick(object sender, MouseEventArgs e)
        {
            bool isFirstLayer = true;

            foreach (Figure item in storage)
            {
                // Нажатие мышки вместе с активным checkBoxCtrl
                if (isCtrlActive && pressedCtrl)
                {
                    if (isCollisionActive)
                    {
                        // Делаем активными все выбранные левой кнопкой мыши элементы
                        if (e.Button == MouseButtons.Left && item.intersects(new MyVector(e.Location)) && isFirstLayer)
                        {
                            item.isActive = true;
                            isFirstLayer = false;
                        }

                    }
                    else
                    {
                        if (e.Button == MouseButtons.Left && item.intersects(new MyVector(e.Location)))
                        {
                            item.isActive = true;
                        }
                    }
                }
                else
                {
                    if (isCollisionActive)
                    {
                        if (e.Button == MouseButtons.Left && item.intersects(new MyVector(e.Location)) && isFirstLayer)
                        {
                            item.isActive = true;
                            isFirstLayer = false;
                        }
                        else
                        {
                            item.isActive = false;
                        }
                    }
                    else
                    {
                        if (e.Button == MouseButtons.Left && item.intersects(new MyVector(e.Location)))
                        {
                            item.isActive = true;
                        }
                        else
                        {
                            item.isActive = false;
                        }
                    }
                }
            }

            
        

       
        if (e.Button == MouseButtons.Right)
        {
            Figure element = null;
            switch (currentFigure)
            {
                case Figures.Circle:
                    element = new CCircle(e.Location.X, e.Location.Y, currentColor);
                    break;
                case Figures.Square:
                    element = new Square(e.Location.X, e.Location.Y, currentColor);
                    break;
                case Figures.Triangle:
                    element = new Triangle(e.Location.X, e.Location.Y, currentColor);
                    break;
            }
            MyVector leftTop = new MyVector();
            MyVector rightBottom = new MyVector();
            element.getRect(leftTop, rightBottom);
            if (isNotCollision(leftTop, rightBottom))
            {
                storage.push_back(element);
            }
        }

    
        PaintBox.Refresh();
    }

        private void PaintBox_Paint(object sender, PaintEventArgs e)
        {

            
            foreach (Figure fig in storage)
            {

                fig.myPaint(e.Graphics);

            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.Control)
        {
            pressedCtrl = true;
        }
        if (e.KeyCode == Keys.G)
        {
            isMove = true;
        }
        if (e.KeyCode == Keys.S)
        {
            isScale = true;
        }
      

        if (e.KeyCode == Keys.Delete)
        {
            storage.deleteActiveElements();

            
            PaintBox.Refresh();
        }
        if (e.KeyCode == Keys.Up && isScale)
        {
            changeScale(1.1f);
        }
        else if (e.KeyCode == Keys.Down && isScale)
        {
            changeScale(0.9f);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="factor"></param>
    private void changeScale(float factor)
    {
        MyVector leftTop = new MyVector();
        MyVector rightBottom = new MyVector();
        getRect(leftTop, rightBottom);
        MyVector center = (leftTop + rightBottom) / 2;

        MyVector ray = leftTop - center;
        MyVector factorRay = (leftTop - center) * factor;
        MyVector testLeftTop = leftTop + factorRay - ray;

        ray = rightBottom - center;
        factorRay = (rightBottom - center) * factor;
        MyVector testRightBottom = rightBottom + factorRay - ray;

            if (isNotCollision(testLeftTop, testRightBottom) &&
                testRightBottom.X - leftTop.X > 50 && testRightBottom.Y - leftTop.Y > 50)
            {
               
                foreach (Figure fig in storage)
                {
                ray = new MyVector(fig.x, fig.y) - center;
                factorRay = (new MyVector(fig.x, fig.y) - center) * factor;
              
                if (fig.isActive)
                {
                   
                    fig.changeScale(factor);
                }
            }
        }
        PaintBox.Refresh();
    }

    private void checkBoxCtrl_CheckedChanged(object sender, EventArgs e)
    {
        isCtrlActive = !isCtrlActive;
    }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
        if (e.KeyCode == Keys.ControlKey)
        {
            pressedCtrl = false;
        }
        if (e.KeyCode == Keys.G)
        {
            isMove = false;
        }
        if (e.KeyCode == Keys.S)
        {
            isScale = false;
              
        }
     
        }
    private void checkBoxCollision_CheckedChanged(object sender, EventArgs e)
    {
        isCollisionActive = !isCollisionActive;
    }

    private void setFigure_SelectedIndexChanged(object sender, EventArgs e)
    {
        currentFigure = (Figures)setFigure.SelectedItem;
    }

    private void setColor_SelectedIndexChanged(object sender, EventArgs e)
    {
        currentColor = (Color)setColor.SelectedItem;
          
            foreach (Figure fig in storage)
            {
            if (fig.isActive)
            {
                fig.changeColor((Color)setColor.SelectedItem);
            }
        }
        PaintBox.Refresh();
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="leftTop"></param>
    /// <param name="rightBottom"></param>
    private void getRect(MyVector leftTop, MyVector rightBottom)
    {
        storage.get_front().getRect(leftTop, rightBottom);
        MyVector curLeftTop = new MyVector();
        MyVector curRightBottom = new MyVector();
            
            foreach (Figure fig in storage)
            {
                if (fig != storage.get_front())
                {
                    Figure curElem = fig;
                    curElem.getRect(curLeftTop, curRightBottom);
                    if (curElem.isActive)
                    {
                        if (curLeftTop.X < leftTop.X)
                        {
                            leftTop.X = curLeftTop.X;
                        }
                        if (curLeftTop.Y < leftTop.Y)
                        {
                            leftTop.Y = curLeftTop.Y;
                        }
                        if (curRightBottom.X > rightBottom.X)
                        {
                            rightBottom.X = curRightBottom.X;
                        }
                        if (curRightBottom.Y > rightBottom.Y)
                        {
                            rightBottom.Y = curRightBottom.Y;
                        }
                    }
                }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="leftTop"></param>
    /// <param name="rightBottom"></param>
    /// <returns></returns>
    private bool isNotCollision(MyVector leftTop, MyVector rightBottom)
    {
        if (leftTop.X > leftTopPaintBox.X && leftTop.Y > leftTopPaintBox.Y &&
            rightBottom.X < rightBottomPaintBox.X && rightBottom.Y < rightBottomPaintBox.Y)
        {
            return true;
        }
        return false;
    }

        private void PaintBox_MouseMove(object sender, MouseEventArgs e)
    {
        MyVector leftTop = new MyVector();
        MyVector rightBottom = new MyVector();
        if (isMove)
        {
            getRect(leftTop, rightBottom);
            int dX = e.Location.X - lastMouseCoords.X;
            int dY = e.Location.Y - lastMouseCoords.Y;
            MyVector direction = new MyVector(dX, dY);
            if (isNotCollision(leftTop + direction, rightBottom + direction))
            {
                    foreach (Figure fig in storage)
                    {
                    if (fig.isActive)
                    {
                        fig.move(direction);
                    }
                }
            }
            PaintBox.Refresh();
        }
        lastMouseCoords.changeCoords(e.Location);
    }

        private void PaintBox_Resize(object sender, EventArgs e)
        {
            rightBottomPaintBox.changeCoords(PaintBox.Size);
            
            foreach (Figure fig in storage)
            {
                MyVector leftTop = new MyVector();
                MyVector rightBottom = new MyVector();
                fig.getRect(leftTop, rightBottom);
                if (!isNotCollision(leftTop, rightBottom))
                {
                    storage.remove(fig);
                }
            }
            PaintBox.Refresh();
        }
    }
}