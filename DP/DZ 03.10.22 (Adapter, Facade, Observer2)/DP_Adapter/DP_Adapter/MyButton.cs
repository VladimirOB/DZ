using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter2
{
    class MyButton: Control
    {
        public int FgColor { get; set; }

        public int BgColor { get; set; }

        public MyButton(int x, int y, int width, int height, string title)
        {
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
            this.Title = title;
        }
    }
}
