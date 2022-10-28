using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinForms_NotifyIcon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void test1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("test");
        }

        // Сворачивание в трей
        private void Form1_Resize(object sender, EventArgs e)
        {
            // Если пользователь сворачивает окно
            if (this.Left == -32000 && this.Top == -32000)
            {
                notifyIcon1.Visible = true;
                this.Visible = false;
                notifyIcon1.ShowBalloonTip(2000);
            }
        }

        // Разворачивание из трея
        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.Visible = true;
            notifyIcon1.Visible = false;
            this.WindowState = FormWindowState.Normal;
        }

        private void test2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notifyIcon1.ShowBalloonTip(2000);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ToolStripLabel l1 = new ToolStripLabel();
            l1.Text = "My label";
            this.MainMenuStrip.Items.Add(l1);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("My menu!!!");
        }
    }
}
