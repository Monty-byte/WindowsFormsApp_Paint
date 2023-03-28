using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {

        Color color = Color.Black; //Создаем переменную типа колор, присваиваем ей черный цвет
        bool isPressed = false; // Логическая переменная для определения, когда можно рисовать
        Point CurrentPoint; // Текущая точка рисунка
        Point PrevPoint; // Начальная точка рисунка
        Graphics g; // Создаем графический элемент
        ColorDialog colorDialog = new ColorDialog(); // Диалоговое окно, для выбора цвета
        public Form1()
        {
            InitializeComponent();
            label2.BackColor = Color.Black; // По умолчанию, для пера, задан черный цвет, такой же цвет для фона
            g = panel1.CreateGraphics(); //Создаем область для работы с графикой

        }

        private void label2_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK) // Если окно закрылось с ОК, то меняем цвет пера и фона
            {
                color = colorDialog.Color;//Меняем цвет для пера
                label2.BackColor= colorDialog.Color; // Меняем цвет для фона
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e) //Нажатие левой кнопки мыши
        {
            isPressed= true; //Разрешаем рисовать
            CurrentPoint = e.Location; //Начальная точка равна текущему положению на форме

        }

        private void panel1_MouseUp(object sender, MouseEventArgs e) //Отпускаем левую кнопку мыши
        {
            isPressed= false; //Запрещаем рисовать
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)//Водим курсором, с зажатой левой кнопкой мыши
        {
            if (isPressed)
            {
                PrevPoint= CurrentPoint; //Наносим первую точку на панель
                CurrentPoint= e.Location;//Наносим вторую точку
                my_Pen(); //Соединяем две точки линией
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Refresh(); //Очищает панель
        }

        private void my_Pen()
        {
            Pen pen = new Pen(color,(float)numericUpDown1.Value); //Создаем перо, задаем ему цвет и толщину
            g.DrawLine(pen, CurrentPoint, PrevPoint); //Соединяем точки линиями
        }
    }
}
