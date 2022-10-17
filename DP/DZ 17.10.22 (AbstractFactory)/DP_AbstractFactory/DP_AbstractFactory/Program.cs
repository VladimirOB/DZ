using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_AbstractFactory
{
    public abstract class GameObject
    {
        protected int x, y;
        public virtual void print()
        {
            Console.WriteLine(this.GetType().Name);
        }
    }

    public class City
    {
        int w, h;
        List<GameObject> lst = new List<GameObject>();
        public City(int x, int y)
        {
            this.w = x;
            this.h = y;
        }
        public void Add(GameObject obj)
        {
            lst.Add(obj);
        }
        public void print()
        {
            foreach (GameObject obj in lst)
            {
                obj.print();
            }
        }
    }

    public class Tree : GameObject
    {

    }

    public class Tree2D : Tree
    {
        string Name;
        public Tree2D(int x, int y, string n)
        {
            this.x = x;
            this.y = y;
            this.Name = n;
        }
        public override void print()
        {
            Console.WriteLine("Tree 2D. {0}, {1}, {2}", x, y, Name);
        }
    }

    public class Tree3D : Tree
    {
        int z;
        string Name;
        int age = 1;
        string Adr = "Donetsk";

        public Tree3D(int x, int y, int z, string n)
        {
            this.x = x;
            this.y = y;
            this.z = z;
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
            Console.WriteLine("Tree 3D. {0}, {1}, {2}, {3}, {4}", x, y, z, Name, Adr, age);
        }
    }

    public class Car : GameObject
    {
    }

    public class Car2D : Car
    {
        string Marka;
        string Model;
        public Car2D(int x, int y, string n, string m)
        {
            this.x = x;
            this.y = y;
            this.Marka = n;
            this.Model = m;
        }
        public override void print()
        {
            Console.WriteLine("Car 2D. {0}, {1}, {2}, {3}", x, y, Marka, Model);
        }
    }

    public class Car3D : Car
    {
        string Marka;
        string Model;
        public Car3D(int x, int y, string n, string m)
        {
            this.x = x;
            this.y = y;
            this.Marka = n;
            this.Model = m;
        }
        public override void print()
        {
            Console.WriteLine("Car 3D. {0}, {1}, {2}, {3}", x, y, Marka, Model);
        }
    }

    public class House : GameObject
    {
    }

    public class House2D : House
    {
        string Adr;
        public House2D(int x, int y, string a)
        {
            this.x = x;
            this.y = y;
            this.Adr = a;
        }
        public override void print()
        {
            Console.WriteLine("House 2D. {0}, {1}, {2}", x, y, Adr);
        }
    }

    public class House3D : House
    {
        string Adr;
        public House3D(int x, int y, string a)
        {
            this.x = x;
            this.y = y;
            this.Adr = a;
        }
        public override void print()
        {
            Console.WriteLine("House 3D. {0}, {1}, {2}", x, y, Adr);
        }
    }

    public class Game
    {
        // ссылка на фабрику, содержащую фабричные методы для генерации продуктов
        GameFactory factory;

        Random r = new Random();

        // конструктор, принимающий фабрику для генерации продуктов (игровых объектов)
        public Game(GameFactory factory)
        {
            this.factory = factory;
        }

        public City CreateCity()
        {
            City p = new City(10, 10);
            for (int i = 0; i < 5; i++)
            {
                GameObject obj = null;
                int x, y;
                x = r.Next(0, 9);
                y = r.Next(0, 9);
                int n = r.Next(0, 3);
                switch (n)
                {
                    case 0:
                        obj = factory.CreateTree(x, y, "Oak");
                        break;
                    case 1:
                        obj = factory.CreateCar(x, y, "BMW", "X8");
                        break;
                    case 2:
                        obj = factory.CreateHouse(x, y, "Donetsk");
                        break;
                }
                p.Add(obj);
            }
            return p;
        }
    }

    // класс-абстрактная фабрика, задающая фабричные методы
    public abstract class GameFactory
    {
        public abstract Tree CreateTree(int x, int y, string n);
        public abstract Car CreateCar(int x, int y, string n, string m);
        public abstract House CreateHouse(int x, int y, string a);
    }

    // "ConcreteFactory1" - конкретная фабрика, реализующая фабричные методы
    class GameFactory2D : GameFactory
    {
        public override Tree CreateTree(int x, int y, string n)
        {
            return new Tree2D(x, y, n);
        }

        public override Car CreateCar(int x, int y, string n, string m)
        {
            return new Car2D(x, y, n, m);
        }

        public override House CreateHouse(int x, int y, string a)
        {
            return new House2D(x, y, a);
        }
    }

    // "ConcreteFactory2" - конкретная фабрика, реализующая фабричные методы
    class GameFactory3D : GameFactory
    {
        public override Tree CreateTree(int x, int y, string n)
        {
            return new Tree3D(x, y, 2, n);
        }

        public override Car CreateCar(int x, int y, string n, string m)
        {
            return new Car3D(x, y, n, m);
        }

        public override House CreateHouse(int x, int y, string a)
        {
            return new House3D(x, y, a);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //GameFactory factory = new GameFactory2D();
            GameFactory factory = new GameFactory3D();

            Game game = new Game(factory);
            City p = game.CreateCity();
            p.print();
        }

    }
}
