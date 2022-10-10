using System;
using System.Collections.Generic;

namespace MyPrototype
{
    class MainApp
    {
        static void Main()
        {
            Game mygame = new Game();
            mygame.Start();
            mygame.print();

            Console.ReadKey();
        }
    }

    class Game
    {
        Field field = new Field();

        string GetId()
        {
            return "TR237848";
        }

        // Объявление экземпляра прототипа
        Car prototype;

        public Game()
        {
            // Создание прототипа при помощи конструктора
            prototype = new GameCar(this.GetId(), "Nissan", 23, 345, 25, 250);
        }

        Random r = new Random();

        // генерация поля игры, содержащего много клонируемых объектов
        public void Start()
        {
            for (int i = 0; i < 5; i++)
            {
                // Генерация нового объекта при помощи клонирования прототипа
                GameCar c1 = (GameCar)prototype.Clone();

                // Изменение свойств клонированного объекта при помощи случайных значений
                c1.Speed = r.Next(120, 250);
                c1.Mass = r.Next(1000, 2500);
                if (r.Next(2) == 0)
                    c1.Model = "BMW";
                else c1.Model = "Mercedes";

                field.Add(c1);
            }
        }

        public void print()
        {
            field.print();
        }
    }

    class Field
    {
        List<Car> cars = new List<Car>();

        public void Add(Car c)
        {
            cars.Add(c);
        }

        public void print()
        {
            foreach (Car c in cars)
            {
                c.print();
            }
        }
    }

    // абстрактный класс прототипа
    abstract class Car
    {

        private string _id;
        int color;

        public int Color
        {
            get { return color; }
            set { color = value; }
        }
        string model;

        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        int mass;

        public int Mass
        {
            get { return mass; }
            set { mass = value; }
        }
        int speed;

        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        public Car(string id)
        {
            this._id = id;
        }

        public string Id
        {

            get { return _id; }
        }

        public virtual void print()
        {

        }

        // Объявление метода, который клонирует прототип
        public abstract Car Clone();
    }

    // конкретный прототип
    class GameCar: Car
    {
        public GameCar(string id) : base(id)
        {

        }

        public int MaxSpeed { get; set; }

        public GameCar(string id, string model, int color, int mass, int speed, int maxSpeed) : base(id)
        {
            this.MaxSpeed = maxSpeed;
            this.Color = color;
            this.Mass = mass;
            this.Speed = speed;
            this.Model = model;
        }

        public override void print()
        {
            Console.WriteLine("Brand: {0} Speed: {1} Weight: {2} Id: {3} MaxSpeed: {4}", Model, Speed, Mass, Id, MaxSpeed);
        }

        // реализация клонирования прототипа
        public override Car Clone()
        {
            // чаще всего здесь производится глубокое клонирование
            return (Car)this.MemberwiseClone();
        }

    }
}
