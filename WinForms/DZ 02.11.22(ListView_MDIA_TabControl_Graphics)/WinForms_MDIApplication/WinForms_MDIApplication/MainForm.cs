using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

// Multi document interface
namespace WinForms_MDIApplication
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void newWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Создание дочернего MDI-окна
            ChildForm f2 = new ChildForm();
            
            // задать MDI-родителя для окна
            f2.MdiParent = this;

            f2.pictureBox1.Image = Bitmap.FromFile(@"admin.gif");

            // показ дочернего MDI-окна
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
    }
}
