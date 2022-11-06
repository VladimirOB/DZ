using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WinForms_MDIApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void newWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Создание дочернего MDI-окна
            Form2 f2 = new Form2();
            f2.MdiParent = this;
            f2.pictureBox1.Image = Bitmap.FromFile(@"c:\admin.gif");
            f2.Show();
        }

        private void activeFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Обращение к активному MDI-окну
            this.ActiveMdiChild.BackColor = Color.Cyan;
        }

        private void arrangeWindowsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void arrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void tileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void tileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Взаимодействие с коллекцией дочерних MDI-окон
            this.MdiChildren[0].BackColor = Color.Red;

            // Сделать первое дочернее окно активным
            this.MdiChildren[0].Activate();
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if ((e.AllowedEffect & DragDropEffects.Copy) != 0)
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] str = (string[])e.Data.GetData(DataFormats.FileDrop);
                foreach (string s in str)
                {
                    
                    FileInfo fi = new FileInfo(s);
                    if (fi.Attributes == FileAttributes.Directory)
                    {
                        DirectoryInfo di = new DirectoryInfo(s);
                        FileInfo[] ff = di.GetFiles();
                        foreach (FileInfo f in ff)
                        {
                            Form3 f3 = new Form3();
                            f3.MdiParent = this;
                            f3.textBox1.Text = File.ReadAllText(f.FullName, Encoding.Default);
                            f3.Show();
                        }
                    }
                    else
                    {
                        Form3 f3 = new Form3();
                        f3.MdiParent = this;
                        f3.textBox1.Text = File.ReadAllText(s, Encoding.Default);
                        f3.Show();
                    }
                }
            }
        }
    }
}
