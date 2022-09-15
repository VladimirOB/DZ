using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Polymorphism
{
    public class Rect: Figure
    {
        protected int a, b;

        public Rect(int x, int y, int a, int b): base(x, y)
        {
            this.a = a;
            this.b = b;
        }

        public override void Print()
        {
            Console.WriteLine($"Rect, a = {a}, b = {b}");

            // вызов метода базового класса
            base.Print();
            Console.WriteLine();
        }

        public override double GetS()
        {
            return a * b;
        }
    }
}
