using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_Decorator
{
    // "Decorator" - базовый класс для всех декораторов
    abstract class Decorator : Component
    {
        // Декорируемый элемент управления
        protected Component component = null;

        public void SetComponent(Component component)
        {
            this.component = component;
        }

        public override void Draw()
        {
            // Если задан декорируемый компонент - то отрисовать его
            if (component != null)
            {
                // отрисовка объекта-хозяина (компонент или другой декоратор)
                component.Draw();
            }
        }
    }

    // "ConcreteDecoratorA" - объявление конкретного декоратора - рамка вокруг
    class Border : Decorator
    {
        private int thickness;

        public Border(Component component)
        {
            this.component = component;
        }

        public override void Draw()
        {
            // вызов отрисовки базового класса, которая вызывает отрисовку "хозяина"
            base.Draw();

            thickness = 2;
            Console.WriteLine("Border.Draw()");
        }
    }

    // "ConcreteDecoratorB" - объявление конкретного декоратора - полоса прокрутки
    class ScrollBar : Decorator
    {
        public ScrollBar(Component component)
        {
            this.component = component;
        }

        public override void Draw()
        {
            // вызов отрисовки базового класса, которая вызывает отрисовку "хозяина"
            base.Draw();

            AddedBehavior();
            Console.WriteLine("ScrollBar.Draw()");
        }

        void AddedBehavior()
        {
        }
    }
}
