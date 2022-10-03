using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter2
{
    // Адаптируемый класс
    class Button3D
    {
        public int Top { get; set; }

        public int Left { get; set; }

        public int Z { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public string Text { get; set; }

        public string BackgroundColor { get; set; }

        public string ForegroundColor { get; set; }

        public Button3D(int x, int y)
        {
            Top = x;
            Left = y;
            Width = 50;
            Height = 20;
        }
    }
}
