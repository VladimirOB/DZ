using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms_MouseKeyboard
{
    public partial class Form1 : Form, IMessageFilter
    {
        public Form1()
        {
            InitializeComponent();

            // перехват ввода в любое текстовое поле
            Application.AddMessageFilter(this);
        }

        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg == 256)
            {
                Keys key = (Keys)(int)m.WParam;
                switch (key)
                {
                    case Keys.A:
                        MessageBox.Show("A");
                        break;
                    case Keys.B:
                        MessageBox.Show("B");
                        break;
                }
            }
            return false;   // true, если требуется "съесть" нажатия
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Text = String.Format(@"x = {0}, y = {1}", e.X, e.Y);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                textBox1.Text = String.Format(@"Left down. x = {0}, y = {1}", e.X, e.Y);
            else
                textBox1.Text = String.Format(@"Right down. x = {0}, y = {1}", e.X, e.Y);
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                textBox1.Text = String.Format(@"Left up. x = {0}, y = {1}", e.X, e.Y);
            else
                textBox1.Text = String.Format(@"Right up. x = {0}, y = {1}", e.X, e.Y);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //textBox2.Text = String.Format(@"Key DOWN. Code: {0}, Alt: {1}, Control: {2}, Shift: {3}", e.KeyCode, e.Alt, e.Control, e.Shift);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            //textBox2.Text = String.Format(@"Key UP. Code: {0}, Alt: {1}, Control: {2}, Shift: {3}", e.KeyCode, e.Alt, e.Control, e.Shift);
        }

        private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                textBox2.Text = String.Format(@"Left double click. x = {0}, y = {1}", e.X, e.Y);
            else
                textBox2.Text = String.Format(@"Right double click. x = {0}, y = {1}", e.X, e.Y);
        }

        private void Form1_MouseEnter(object sender, EventArgs e)
        {
            textBox1.Text = String.Format(@"Mouse enter");
        }

        private void Form1_MouseLeave(object sender, EventArgs e)
        {
            textBox1.Text = String.Format(@"Mouse leave");
        }

        private void Form1_MouseHover(object sender, EventArgs e)
        {
            textBox1.Text = String.Format(@"Mouse hover");
        }
    }
}
