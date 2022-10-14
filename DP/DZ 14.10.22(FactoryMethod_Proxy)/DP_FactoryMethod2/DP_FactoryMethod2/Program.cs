using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DP_FactoryMethod2
{
    // Product - абстрактный продукт
    public abstract class GameObject2D
    {
        public int x, y;
        public virtual void print()
        {
            Console.WriteLine("x = {0}; y = {1}", x, y);
        }
    }

    // Контейнер для продуктов
    public class City
    {
        int w, h;
        List<GameObject2D> lst = new List<GameObject2D>();

        public City(int w, int h)
        {
            this.w = w;
            this.h = h;
        }

        public void Add(GameObject2D obj)
        {
            lst.Add(obj);
        }

        public void print()
        {
            foreach (GameObject2D obj in lst)
            {
                obj.print();
            }
        }
    }

    // Concrete product - конкретный продукт, генерируемый фабричным методом
    public class Tree : GameObject2D
    {
        string Name;
        public Tree(int x, int y, string n)
        {
            this.x = x;
            this.y = y;
            this.Name = n;
        }
        public override void print()
        {
            Console.WriteLine("{0}, {1}, {2}", x, y, Name);
        }
    }

    // Concrete product - конкретный продукт, генерируемый фабричным методом
    public class AdvancedTree : Tree
    {
        string Name;
        int age = 1;
        string Adr = "Donetsk";

        public AdvancedTree(int x, int y, string n) : base(x, y, n)
        {
            this.x = x;
            this.y = y;
            this.Name = n;
        }
        public void SetAge(int a)
        {
            age = a;
        }
        public void SetAdr(string a)
        {
            Adr = a;
        }
        public override void print()
        {
            Console.WriteLine("{0}, {1}, {2}, {3}, {4}", x, y, Name, Adr, age);
        }
    }

    // Concrete product - конкретный продукт, генерируемый фабричным методом
    public class Car : GameObject2D
    {
        string Marka;
        string Model;
        public Car(int x, int y, string n, string m)
        {
            this.x = x;
            this.y = y;
            this.Marka = n;
            this.Model = m;
        }
        public override void print()
        {
            Console.WriteLine("{0}, {1}, {2}, {3}", x, y, Marka, Model);
        }
    }

    // Concrete product - конкретный продукт, генерируемый фабричным методом
    public class House : GameObject2D
    {
        string Adr;
        public House(int x, int y, string a)
        {
            this.x = x;
            this.y = y;
            this.Adr = a;
        }
        public override void print()
        {
            Console.WriteLine("{0}, {1}, {2}", x, y, Adr);
        }
    }

    // Creator - абстрактный создатель, в котором объявлены фабричные методы
    public abstract class GeneralGame
    {
        Random r = new Random();

        // Генерация игрового поля
        public City CreateCity()
        {
            City p = new City(10, 10);

            // цикл создания игровых объектов
            for (int i = 0; i < 5; i++)
            {
                GameObject2D obj = null;
                int x, y;
                x = r.Next(0, 9);
                y = r.Next(0, 9);
                int n = r.Next(0, 3);

                // Вызов фабричных методов для генерации конкретных продуктов
                switch (n)
                {
                    case 0:
                        obj = CreateTree(x, y);
                        break;
                    case 1:
                        obj = CreateCar(x, y);
                        break;
                    case 2:
                        obj = CreateHouse(x, y);
                        break;
                }
                p.Add(obj);
            }
            return p;
        }

        // Объявление фабричных методов
        public abstract Tree CreateTree(int x, int y);
        public abstract Car CreateCar(int x, int y);
        public abstract House CreateHouse(int x, int y);
    }

    // ConcreteCreator - конкретный создатель конкретных продуктов
    public class Game : GeneralGame
    {
        public override Tree CreateTree(int x, int y)
        {
            return new Tree(x, y, "Oak");
        }

        public override Car CreateCar(int x, int y)
        {
            return new Car(x, y, "BMW", "M5");
        }

        public override House CreateHouse(int x, int y)
        {
            return new House(x, y, "Restaurant");
        }
    }

    // ConcreteCreator - конкретный создатель конкретных продуктов
    public class Game2 : GeneralGame
    {
        public override Tree CreateTree(int x, int y)
        {
            return new AdvancedTree(x, y, "Baobab");
        }

        public override Car CreateCar(int x, int y)
        {
            return new Car(x, y, "Audi", "A8");
        }

        public override House CreateHouse(int x, int y)
        {
            return new House(x, y, "Church");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Создание конкретного создателя
            //GeneralGame game = new Game2();
            GeneralGame game = new Game();

            // Генерация продуктов
            City p = game.CreateCity();

            // Вывод сгенерированного уровня игры
            p.print();
        }
    }
}
