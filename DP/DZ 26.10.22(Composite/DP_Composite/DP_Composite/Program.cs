using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_Composite
{
    class Program
    {
        static void Main()
        {
            // Создание структуры дерева
            Panel root = new Panel("root");
            root.Add(new Button("Button 1"));
            root.Add(new Button("Button 2"));

            Panel panel1 = new Panel("Panel");
            panel1.Add(new Button("Button 3"));
            panel1.Add(new Button("Button 4"));

            root.Add(panel1);
            root.Add(new Button("Button 5"));

            // Добавление и удаление листа
            TextEdit textEdit = new TextEdit("TextEdit 1");
            root.Add(textEdit);
            //root.Remove(leaf);

            // Рекурсивный показ дерева
            root.Display(1);

            Console.Read();
        }
    }

    // "Component" - абстрактный класс для всех компонетов системы (задаёт общее поведение)
    abstract class Component
    {
        protected string name;

        // Constructor 
        public Component(string name)
        {
            this.name = name;
        }

        public abstract void MoveBy(int dx, int dy);    // Перемещение на какое-то смещение

        // Добавленные методы для групп
        public abstract void Add(Component c);          // Добавление в группу элементов
        public abstract void Remove(Component c);       // Удаление из группы
        public abstract void Display(int depth);        // Просмотр группы
    }

    // "Composite" 
    class Panel : Component
    {
        // Список дочерних элементов
        private List<Component> children = new List<Component>();

        // Constructor 
        public Panel(string name)
            : base(name)
        {
        }

        public override void MoveBy(int dx, int dy)
        {
            foreach (Component component in children)
            {
                component.MoveBy(dx, dy);
            }
        }

        public override void Add(Component component)
        {
            children.Add(component);
        }

        public override void Remove(Component component)
        {
            children.Remove(component);
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + name);

            // Recursively display child nodes 
            foreach (Component component in children)
            {
                component.Display(depth + 2);
            }
        }
    }

    // "Leaf" - не групповой элемент
    class Button : Component
    {
        // Constructor 
        public Button(string name)
            : base(name)
        {
        }

        public override void MoveBy(int dx, int dy)
        {

        }

        // НЕ реализованные методы
        public override void Add(Component c)
        {
            Console.WriteLine("Cannot add to a leaf");
        }

        public override void Remove(Component c)
        {
            Console.WriteLine("Cannot remove from a leaf");
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + name);
        }
    }

    class TextEdit : Component
    {
        // Constructor 
        public TextEdit(string name)
            : base(name)
        {
        }

        public override void MoveBy(int dx, int dy)
        {

        }

        // НЕ реализованные методы
        public override void Add(Component c)
        {
            Console.WriteLine("Cannot add to a leaf");
        }

        public override void Remove(Component c)
        {
            Console.WriteLine("Cannot remove from a leaf");
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + name);
        }
    }
}
