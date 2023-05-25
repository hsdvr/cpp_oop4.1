using System;
using System.Drawing;
using System.Windows.Forms;

namespace OOPLab4
{
    public partial class Form1 : Form
    {
        Storage storage; // Хранилище с нарисованными окружностями

        bool isCtrlActive = false;
        bool isCollisionActive = true;
        bool pressedCtrl = false;
        public Form1()
        {
            InitializeComponent();
            storage = new Storage();
        }

        private void PaintBox_MouseClick(object sender, MouseEventArgs e)
        {
            bool isFirstLayer = true;
            //for (int i = storage.size - 1; i >= 0; --i)
            foreach(Figure item in storage)
            {
                // Нажатие мышки вместе с активным checkBoxCtrl
                if (isCtrlActive && pressedCtrl)
                {
                    if (isCollisionActive)
                    {
                        // Делаем активными все выбранные левой кнопкой мыши элементы
                        if (e.Button == MouseButtons.Left && item.intersects(e.Location) && isFirstLayer)
                        {
                            item.isActive = true;
                            isFirstLayer = false;
                        }
                        // Не затираем активные элементы, так как работает Ctrl
                    }
                    else
                    {
                        if (e.Button == MouseButtons.Left && item.intersects(e.Location))
                        {
                            item.isActive = true;
                        }
                    }
                }
                else
                {
                    if (isCollisionActive)
                    {
                        if (e.Button == MouseButtons.Left && item.intersects(e.Location) && isFirstLayer)
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
                        if (e.Button == MouseButtons.Left && item.intersects(e.Location))
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

            // Добавление окружности на полотно
            if (e.Button == MouseButtons.Right)
            {
                CCircle element = new CCircle(e.Location.X, e.Location.Y);
                storage.push_back(element);
                
            }

            // Перерисовка
            PaintBox.Refresh();
        }

        private void PaintBox_Paint(object sender, PaintEventArgs e)
        {
            
           // for (int i = 0; i < storage.size; ++i)
           foreach(Figure fig in storage)
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
            if (e.KeyCode == Keys.Back)
            {
                storage.deleteActiveElements();

                // Перерисовка
                PaintBox.Refresh();
            }
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
        }

        private void checkBoxCollision_CheckedChanged(object sender, EventArgs e)
        {
            isCollisionActive = !isCollisionActive;
        }
    }
}