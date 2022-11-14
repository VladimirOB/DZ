using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms_BitmapData
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        byte[] ScrPic;
        byte[] ResPic;

        Bitmap bmp2;

        int TheR = 0, TheB = 0, TheG = 0;

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            TheR = trackBar1.Value;
            ChannelChange();
        }

        private void trackBar2_ValueChanged(object sender, EventArgs e)
        {
            TheB = trackBar2.Value;
            ChannelChange();
        }

        private void trackBar3_ValueChanged(object sender, EventArgs e)
        {
            TheG = trackBar3.Value;
            ChannelChange();
        }

        private void trackBar4_ValueChanged(object sender, EventArgs e)
        {
            int value = trackBar4.Value;

            int len = ScrPic.Length;

            // Осветлить изображение
            // Цикл по изображению (модификация изображения)
            for (int counter = 0; counter < len; counter++)
            {
                int newValue = ScrPic[counter] + value;
                if (newValue > 255)
                    newValue = 255;
                if (newValue < 0)
                    newValue = 0;

                ResPic[counter] = (byte)newValue;
            }

            Rectangle rect = new Rectangle(0, 0, bmp2.Width, bmp2.Height);

            BitmapData bmpData = bmp2.LockBits(rect, ImageLockMode.WriteOnly, bmp2.PixelFormat);

            IntPtr ptr = bmpData.Scan0;

            Marshal.Copy(ResPic, 0, ptr, ResPic.Length);

            bmp2.UnlockBits(bmpData);

            pictureBox1.Image = bmp2;
        }

        private void ChannelChange()
        {
            int len = ScrPic.Length;

            for (int counter = 0; counter < len; counter++)
            {
                if (counter % 3 == 0) // Blue
                {
                    int res = (ScrPic[counter] + TheB);
                    if (res > 255) res = 255;
                    else if (res < 0) res = 0;
                    ResPic[counter] = (byte)res;
                }

                if (counter % 3 == 1) // Green
                {
                    int res = (ScrPic[counter] + TheG);
                    if (res > 255) res = 255;
                    else if (res < 0) res = 0;
                    ResPic[counter] = (byte)res;
                }

                if (counter % 3 == 2) // Red
                {
                    int res = (ScrPic[counter] + TheR);
                    if (res > 255) res = 255;
                    else if (res < 0) res = 0;
                    ResPic[counter] = (byte)res;
                }
            }

            Rectangle rect = new Rectangle(0, 0, bmp2.Width, bmp2.Height);

            BitmapData bmpData = bmp2.LockBits(rect, ImageLockMode.WriteOnly, bmp2.PixelFormat);

            IntPtr ptr = bmpData.Scan0;

            Marshal.Copy(ResPic, 0, ptr, ResPic.Length);

            bmp2.UnlockBits(bmpData);

            pictureBox1.Image = bmp2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Choose picture";

            // Открытие диалога
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Bitmap bmp = new Bitmap(openFileDialog1.FileName);

                pictureBox1.Image = bmp;

                Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);

                bmp2 = new Bitmap(bmp.Width, bmp.Height, bmp.PixelFormat);

                BitmapData bmpData = bmp.LockBits(rect, ImageLockMode.ReadWrite, bmp.PixelFormat);

                IntPtr ptr = bmpData.Scan0;

                int bytes = bmpData.Stride * bmp.Height;

                ScrPic = new byte[bytes];
                ResPic = new byte[bytes];

                Marshal.Copy(ptr, ScrPic, 0, bytes);

                Marshal.Copy(ptr, ResPic, 0, bytes);

                bmp.UnlockBits(bmpData);
            }
        }
    }
}
