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
	public partial class Form6 : Form
	{
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
	}
}
