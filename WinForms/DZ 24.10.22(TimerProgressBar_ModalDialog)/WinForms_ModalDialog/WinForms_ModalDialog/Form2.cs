using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinForms_ModalDialog
{
    // Тип данных, ссылка на метод, принимающий 2 параметра
    public delegate void ColorChangedEvent(object sender, Color currentColor);

    public partial class Form2 : Form
    {
        // Ссылка на метод, принимающий 4 параметра
        public event ColorChangedEvent OnColorChanged;

        Color color;

        public Color CurrentColor {
            get => color;
        }

        public Form2()
        {
            InitializeComponent();
        }

        public Form2(string title)
        {
            InitializeComponent();
            this.Text = title;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MainWindow f = (MainWindow)this.Owner;
            color = Color.FromArgb(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text));
            f.BackColor = color;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            color = Color.FromArgb(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text));
            OnColorChanged?.Invoke(this, color);
        }
    }

}