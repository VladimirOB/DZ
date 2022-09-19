using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Interfaces
{
    abstract class AbstractCat
    {
        int weight;

        int height;

        int age;

        abstract public void Move(int x, int y);
        abstract public void Eat();
        abstract public void Drink();
    }

    interface IAlive
    {
        void Move(int x, int y);
        void Eat();
        void Drink();
    }

    interface IHunter
    {
        void Move(int x, int y);
        void Kill();
    }

    class Cat : AbstractCat, IAlive, IHunter
    {
        public override void Drink()
        {
            Console.WriteLine("Drink");
        }

        public override void Eat()
        {
            Console.WriteLine("Eat");
        }

        public override void Move(int x, int y)
        {
            Console.WriteLine("Move");
        }

        public void Kill()
        {
            Console.WriteLine("Kill");
        }

        void IHunter.Move(int x, int y)
        {
            Console.WriteLine("IHunter.Move");
        }

        void IAlive.Move(int x, int y)
        {
            Console.WriteLine("IAlive.Move");
        }
    }
}
