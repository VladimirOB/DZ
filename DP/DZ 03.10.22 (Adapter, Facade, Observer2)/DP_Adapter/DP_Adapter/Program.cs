using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter2
{
    class Program
    {
        static void Main(string[] args)
        {
            MyWindow window = new MyWindow();

            window.children.Add(new MyButton(1, 2, 3, 4, "Button1"));
            window.children.Add(new MyTextBox(1, 2, 3, 4, "TextBox1"));
            window.children.Add(new MyButton3D(1, 2, 3, 4, "Button3D_1"));

            Console.WriteLine(window);
        }
    }
}
