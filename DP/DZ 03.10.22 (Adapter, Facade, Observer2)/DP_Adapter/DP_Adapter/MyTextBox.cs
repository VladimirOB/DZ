using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter2
{
    class MyTextBox: Control
    {
        public string Hint { get; set; }

        public int WatermarkColor { get; set; }

        public MyTextBox(int x, int y, int width, int height, string title)
        {
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
            this.Title = title;
        }
    }
}
