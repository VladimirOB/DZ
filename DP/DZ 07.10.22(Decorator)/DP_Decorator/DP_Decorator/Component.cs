using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_Decorator
{
    // "Component" - базовый класс для всех элементов управления
    public abstract class Component
    {
        // метод, позволяющий компоненту отрисовать самого себя
        public abstract void Draw();
    }

    // "ConcreteComponent" - класс обычного элемента управления
    public class TextBox : Component
    {
        public override void Draw()
        {
            Console.WriteLine("TextBox.Draw()");
        }
    }

    // "ConcreteComponent" - класс обычного элемента управления
    public class Button : Component
    {
        public override void Draw()
        {
            Console.WriteLine("Button.Draw()");
        }
    }
}
