using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms_ModalDialog
{
	// Тип данных, ссылка на метод, принимающий 2 параметра
	public delegate void ColorChangedEvent(object sender, Color currentColor);

	public partial class Form6 : Form
	{
		// Ссылка на метод, принимающий 2 параметра
		public event ColorChangedEvent OnColorChanged;

		public Form6()
		{
			InitializeComponent();
		}

		public Form6(string title, int width, int height)
		{
			InitializeComponent();

			this.Text = title;
			this.Width = width;
			this.Height = height;
		}

		public int R
		{
			get
			{
				try
				{
					return Convert.ToInt32(textBox1.Text);
				}
				catch
				{
					return 0;
				}
			}
		}

		public int G
		{
			get
			{
				try
				{
					return Convert.ToInt32(textBox2.Text);
				}
				catch
				{
					return 0;
				}
			}
		}

		public int B
		{
			get
			{
				try
				{
					return Convert.ToInt32(textBox3.Text);
				}
				catch
				{
					return 0;
				}
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			MainWindow wnd = this.Owner as MainWindow;
			Color color = Color.FromArgb(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text));
			wnd.BackColor = color;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Color color = Color.FromArgb(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text));
			OnColorChanged?.Invoke(this, color);
		}
	}
}
