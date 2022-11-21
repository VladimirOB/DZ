using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace WinForms_PictureSelection
{
    public partial class Form1 : Form
    {
        [DllImport("gdi32", SetLastError = true, EntryPoint = "SetROP2")]
        static extern unsafe int SetROP2(
            IntPtr hWnd,
            int mode
        );

        [DllImport("gdi32", SetLastError = true, EntryPoint = "CreatePen")]
        static extern unsafe IntPtr CreatePen(
            int style,
            int width,
            int color
        );

        [DllImport("gdi32", SetLastError = true, EntryPoint = "SelectObject")]
        static extern unsafe IntPtr SelectObject(
            IntPtr hWnd,
            IntPtr obj
        );

        [DllImport("gdi32", SetLastError = true, EntryPoint = "DeleteObject")]
        static extern unsafe bool DeleteObject(
            IntPtr obj
        );

        [DllImport("gdi32", SetLastError = true, EntryPoint = "LineTo")]
        static extern unsafe bool LineTo(
            IntPtr hWnd,
            int x,
            int y
        );

        [DllImport("gdi32", SetLastError = true, EntryPoint = "MoveToEx")]
        static extern unsafe bool MoveToEx(
            IntPtr hWnd,
            int x,
            int y,
            IntPtr point
        );

        Point start, old;
        bool flag = false;

        List<Point> selPoints = new List<Point>();

        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            // если включен режим рисования
            if (flag)
            {
                // соддать контекст для рисования в окне
                Graphics gr = pictureBox1.CreateGraphics();

                // получить низкоуровневый адрес контекста для рисования в окне
                IntPtr dc = gr.GetHdc();

                // занести во второй указатель 0
                IntPtr ptr2 = (IntPtr)0;

                // включить режим COPY_PEN (обычное рисование)
                SetROP2(dc, 13);

                // создать карандаш для рисования
                IntPtr pen = CreatePen(1, 1, 0);

                // выбрать его в контекст
                IntPtr oldobj = SelectObject(dc, pen);

                // нарисовать линию в обычном режиме (навсегда)
                MoveToEx(dc, start.X, start.Y, ptr2);
                LineTo(dc, e.X, e.Y);

                // вернуть старый карандаш и удалить новый
                SelectObject(dc, oldobj);
                DeleteObject(pen);

                // занести координаты мыши в список точек выделения
                selPoints.Add(new Point(e.X, e.Y));

                // освободить контексты для рисования
                gr.ReleaseHdc();
                gr.Dispose();

                // занести координаты мыши в стартовую точку
                start = new Point(e.X, e.Y);
            }
            else
            {
                // очистить список точек выделения
                selPoints.Clear();          

                // перерисовать область рисования
                pictureBox1.Invalidate();

                // старые координаты содержат координаты мыши
                old = new Point(e.X, e.Y);

                // новые координаты (координаты начала линии) содержат координаты мыши
                start = new Point(e.X, e.Y);

                // координаты старта линии занести в список точек
                selPoints.Add(new Point(e.X, e.Y));

                // включить режим рисования
                flag = true;
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            // если включен режим рисования
            if (flag)
            {
                // соддать контекст для рисования в окне
                Graphics gr = pictureBox1.CreateGraphics();

                // получить низкоуровневый адрес контекста для рисования в окне
                IntPtr dc = gr.GetHdc();

                // занести во второй указатель 0
                IntPtr ptr2 = (IntPtr)0;

                // включить режим рисования XOR в окне PictureBox
                SetROP2(dc, 10);

                // создать карандаш для рисования
                IntPtr pen = CreatePen(1, 1, 0);

                // выбрать карандаш в контекст для рисования
                IntPtr oldobj = SelectObject(dc, pen);

                /* стирание старой линии*/
                // переместить световое перо в координаты начала линии
                MoveToEx(dc, start.X, start.Y, ptr2);
                // нарисовать линию от координат начала до старых координат
                LineTo(dc, old.X, old.Y);

                /*рисование новой линии*/
                // переместить координаты светового пера в начало линии, которую нужно нарисовать
                MoveToEx(dc, start.X, start.Y, ptr2);
                // нарисовать линию от начала до координат мыши
                LineTo(dc, e.X, e.Y);

                // вернуть в контекст старый карандаш
                SelectObject(dc, oldobj);
                // удалить наш карандаш за ненадобностью
                DeleteObject(pen);

                // текущие координаты мыши сделать старыми
                old = new Point(e.X, e.Y);

                // освободить низкоуровневый контекст устройства
                gr.ReleaseHdc();

                // освободить объект Graphics
                gr.Dispose();
            }
        }

        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // если точек выделения больше одной (т.е. было выделение)
            if (selPoints.Count > 1)
            {
                // выключить режим рисования
                flag = false;
                // перерисовать выделение в методе Paint
                pictureBox1.Invalidate();
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            // если точек выделения больше одной (т.е. было выделение)
            if (selPoints.Count > 1)
            {
                // преобразовать список точек выделения в массив
                Point[] p = selPoints.ToArray<Point>();

                // задать массив пунктирной линии
                float[] pattern = { 10/* длина закрашенной части */,
                                    10 /*длина незакрашенной части */ };

                // создать карандаш чёрного цвета с толщиной 1
                Pen pen = new Pen(Color.Black, 1);

                // применить стиль пунктира к карандашу
                pen.DashPattern = pattern;

                // нарисовать выделение
                e.Graphics.DrawPolygon(pen, p);
            }
        }
    }
}
