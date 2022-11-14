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

namespace WinForms_Layers
{
    public partial class Form1 : Form
    {
        Bitmap[] layers = new Bitmap[5];
        float [] trans = new float[5] {1, 0.5f, 1f, 1, 1};
        BitmapLayers layers2 = new BitmapLayers(400, 300, 5);

        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < 5; i++)
            {
                layers[i] = new Bitmap(400, 300);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap res = new Bitmap(400, 300);

            Graphics resgr = Graphics.FromImage(res);

            Graphics gr = Graphics.FromImage(layers[0]);
            gr.Clear(Color.Blue);

            Graphics gr1 = Graphics.FromImage(layers[1]);
            gr1.Clear(Color.Transparent);
            gr1.FillRectangle(Brushes.Red,20,20,100,100);
            gr1.DrawLine(Pens.Green, 10, 10, 200, 200);

            Graphics gr2 = Graphics.FromImage(layers[2]);
            gr2.Clear(Color.Transparent);
            gr2.DrawEllipse(Pens.Yellow, 10, 10, 300, 100);

            ImageAttributes attr = new ImageAttributes();

            resgr.DrawImage(layers[0], new Rectangle(0, 0, 400, 300), 0, 0, 400, 300, GraphicsUnit.Pixel);

            for (int k = 1; k < 5; k++)
            {
                ColorMatrix myColorMatrix = new ColorMatrix();
                myColorMatrix.Matrix00 = 1.00f;
                myColorMatrix.Matrix11 = 1.00f;
                myColorMatrix.Matrix22 = 1.00f;
                myColorMatrix.Matrix33 = trans[k];

                attr.SetColorMatrix(myColorMatrix);
                resgr.DrawImage(layers[k], new Rectangle(0, 0, 400, 300), 0, 0, 400, 300, GraphicsUnit.Pixel, attr);
            }

            pictureBox1.Image = res;

            gr2.Dispose();
            gr1.Dispose();
            gr.Dispose();
            resgr.Dispose();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Image layer0 = layers2.layers[0].img;
            Graphics g1 = Graphics.FromImage(layer0);
            g1.Clear(Color.Blue);

            Image layer1 = layers2.layers[1].img;
            Graphics g2 = Graphics.FromImage(layer1);
            g2.Clear(Color.White);
            g2.FillRectangle(Brushes.Red, 10,10,200,100);

            g1.Dispose();
            g2.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            layers2.Show(pictureBox1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Layer l = new Layer(400, 300, 0.8f);

            Image img = l.img;
            Graphics g2 = Graphics.FromImage(img);
            g2.Clear(Color.White);
            g2.FillRectangle(Brushes.Yellow, 70, 70, 200, 200);
            layers2.Add(l);
        }
    }

    // класс, представляющий один слой
    public class Layer
    {
        public Bitmap img;              // картинка со слоем
        private float transparency;     // прозрачность слоя

        public float Transparency       // свойство прозрачночти
        {
            get { return transparency; }
            set { transparency = value; }
        }

        public Layer(int w, int h, float tr)    // конструктор задаёт размеры слоя и прозрачность
        {
            transparency = tr;
            img = new Bitmap(w, h);
        }
    }

    // класс всех слоёв
    public class BitmapLayers
    {
        int width, height;                  // размеры слоёв

        public int Height                   // высота
        {
            get { return height; }
            set { height = value; }
        }

        public int Width                    // ширина
        {
            get { return width; }
            set { width = value; }
        }

        public List<Layer> layers = new List<Layer>();      // список слоёв

        public BitmapLayers(int w, int h, int count)        // конструктор задаёт размеры и количество слоёв
        {
            width = w;
            height = h;
            for (int i = 0; i < count; i++)
            {
                layers.Add(new Layer(w, h, 1));             // добавление слоя в список
            }
        }

        public void Add(Layer l)                            // метод добавляет слой в список
        {
            layers.Add(l);
        }

        public void Remove(int n)                           // удаление слоя по номеру
        {
            if (n < layers.Count) layers.RemoveAt(n);
        }

        public void Show(PictureBox pic)                    // показ слоёв в picturebox
        {
            Bitmap res = new Bitmap(width, height);         // создание результирующей картинки
            Graphics resgr = Graphics.FromImage(res);       // graphics для результирующей картинки

            ImageAttributes attr = new ImageAttributes();   // создание атрибутов изображения
            
            // обеспечение прозрачности слоёв за счёт замены белого цвета на прозрачный
            attr.SetColorKey(Color.FromArgb(255, 255, 255), Color.FromArgb(255, 255, 255)); // белый цвет делаем прозрачным

            // рисование фона на картинке
            resgr.DrawImage(layers[0].img, new Rectangle(0, 0, 400, 300), 0, 0, 400, 300, GraphicsUnit.Pixel); 
            
            // отображение всех слоёв на результирующей картинке с учётом прозрачности
            for (int k = 1; k < layers.Count; k++)
            {
                // матрица цветов задаёт прозрачноть для каждого слоя
                ColorMatrix myColorMatrix = new ColorMatrix();
                myColorMatrix.Matrix00 = 1.00f;
                myColorMatrix.Matrix11 = 1.00f;
                myColorMatrix.Matrix22 = 1.00f;
                myColorMatrix.Matrix33 = layers[k].Transparency;

                attr.SetColorMatrix(myColorMatrix); // применение матрицы

                // отображение слоя
                resgr.DrawImage(layers[k].img, new Rectangle(0, 0, 400, 300), 0, 0, 400, 300, GraphicsUnit.Pixel, attr);
            }

            // выбор результирующей картинки для показа в picturebox
            pic.Image = res;

            resgr.Dispose();
        }
    
    }
}
