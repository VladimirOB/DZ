using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter2
{
    // Адаптер
    class MyButton3D: Control
    {
        // ссылка на адаптируемый объект
        Button3D button;

        public MyButton3D(int x, int y, int width, int height, string title)
        {
            // установка свойств адаптер
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
            this.Title = title;

            // установка свойств адаптируемого объекта
            button = new Button3D(x, y);
            button.Width = width;
            button.Height = height;
            button.Text = title;
        }
    }
}
