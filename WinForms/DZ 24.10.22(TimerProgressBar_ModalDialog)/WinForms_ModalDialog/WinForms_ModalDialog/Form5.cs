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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        public Form5(string title, int width, int height)
        {
            InitializeComponent();

            this.Text = title;

            if(width > 0 && height > 0)
            {
                this.Width = width;
                this.Height = height;
            }
        }
    }
}
