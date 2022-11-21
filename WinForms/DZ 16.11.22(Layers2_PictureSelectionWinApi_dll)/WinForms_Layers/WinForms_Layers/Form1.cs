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
using System.Reflection.Emit;

namespace WinForms_Layers
{
    public partial class Form1 : Form
    {
        Bitmap[] layers = new Bitmap[5];
        float [] trans = new float[5] {1, 0.9f, 1f, 1, 1};

        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < 5; i++)
            {
                layers[i] = new Bitmap(400, 300);
            }

			layers2.Attach(pictureBox1);
            layers2.OnLayersChanged += Layers2_OnLayersChanged;
            layers2.LayersRefresh();
		}

        private void Layers2_OnLayersChanged(BitmapLayers layers)
        {
            layersCheckedListBox1.Items.Clear();

            foreach (Layer layer in layers.layers)
            {
				layersCheckedListBox1.Items.Add(layer.Name);
                if (layer.Visible)
                    layersCheckedListBox1.SetItemChecked(layersCheckedListBox1.Items.Count - 1, true);
                else
					layersCheckedListBox1.SetItemChecked(layersCheckedListBox1.Items.Count - 1, false);
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

        BitmapLayers layers2 = new BitmapLayers(400, 300, 5);

        private void button2_Click(object sender, EventArgs e)
        {
            layers2.Clear(Color.LightBlue, 0);
			layers2.FillRectangle(Brushes.Red, 10, 10, 200, 100, 1);


            layers2.Invalidate();
		}

        private void button3_Click(object sender, EventArgs e)
        {
			layers2.Add(0.6f, "New layer");
			layers2.DrawRectangle(Pens.Yellow, 90, 90, 250, 150, layers2.LayerCount - 1);
			layers2.Invalidate();
		}

        private void button4_Click(object sender, EventArgs e)
        {
			layers2.Add(1f, "New layer 2");
			layers2.FillEllipse(Brushes.Green, 90, 90, 250, 150, layers2.LayerCount-1);
            layers2.Invalidate();
		}

        private void layersCheckedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if(e.Index < layers2.LayerCount)
            {
                if(e.NewValue == CheckState.Checked)
                    layers2.layers[e.Index].Visible = true;
                else
					layers2.layers[e.Index].Visible = false;

                layers2.Invalidate();
			}
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if(layersCheckedListBox1.SelectedIndex != -1)
            {
                Random random = new Random();
                int num = random.Next(5);

                Brush brush = null;

                switch(num)
                {
                    case 0:
                        brush = Brushes.Red;
                        break;
                    case 1:
                        brush = Brushes.Green;
                        break;
                    case 2:
                        brush = Brushes.Blue;
                        break;
                    case 3:
                        brush = Brushes.Magenta;
                        break;
                    default:
						brush = Brushes.Yellow;
                        break;
				}

                layers2.FillRectangle(brush, e.X, e.Y, 20, 20, layersCheckedListBox1.SelectedIndex);
                layers2.Invalidate();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                layers2.Save(saveFileDialog1.FileName, ImageFormat.Jpeg);
            }
        }
    }
}
