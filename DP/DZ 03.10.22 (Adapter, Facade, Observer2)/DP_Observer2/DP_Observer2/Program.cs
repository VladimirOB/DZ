using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_Observer2
{
    class MainApp
    {
        static void Main()
        {
            // создание наблюдаемых объектов
            Node node1 = new Node(23, 4);
            Node node2 = new Node(2, 14);
            Node node3 = new Node(20, 30);

            // создание наблюдателей
            Link link1 = new Link(node1, node2);
            Link link2 = new Link(node2, node3);

            node2.Move(3, 5);

            //node2.X = 34;
            //node2.Y = 54;

            // Wait for user 
            Console.Read();
        }
    }

    // делегат для наблюдателей
    delegate void ObserverDelegate(int x, int y);

    // наблюдаемый объект
    abstract class Subject
    {
        // Ссылка на методы наблюдателей
        protected event ObserverDelegate observers;

        public void Attach(ObserverDelegate ev)
        {
            observers += ev;
        }

        public void Notify(int x, int y)
        {
            observers?.Invoke(x, y);    // Уведомить всех наблюдателей об изменении координат узла
        }
    }

    // "ConcreteSubject" - конкретный наблюдаемый объект
    class Node: Subject
    {
        public int x, y;

        public int X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
                Notify(x, y);
            }
        }

        public int Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
                Notify(x, y);
            }
        }

        public Node(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public void Move(int x, int y)
        {
            this.x = x;
            this.y = y;
            Notify(x, y);
        }
    }

    // "Observer" - абстрактный класс наблюдатей
    abstract class Observer
    {
        public abstract void Update(int x, int y);
    }

    // "ConcreteObserver" - конкретный наблюдатель
    class Link: Observer
    {
        private Node node1, node2;
        int x1, y1, x2, y2;

        void EraseLink()
        {
            Console.WriteLine("Erase link {0},{1} - {2},{3}", x1, y1, x2, y2);
        }

        void DrawLink()
        {
            Console.WriteLine("Draw link {0},{1} - {2},{3}", x1, y1, x2, y2);
        }

        // Constructor 
        public Link(Node n1, Node n2)
        {
            this.node1 = n1;
            this.node2 = n2;

            // Подписка на сообщения от узлов
            n1.Attach(this.Update);
            n2.Attach(this.Update);

            // Сохранить координаты узлов
            x1 = n1.x; y1 = n1.y;
            x2 = n2.x; y2 = n2.y;
        }

        public override void Update(int x, int y)
        {
            EraseLink();
            x1 = node1.x;
            x2 = node2.x;
            y1 = node1.y;
            y2 = node2.y;
            DrawLink();
        }
    }
}
