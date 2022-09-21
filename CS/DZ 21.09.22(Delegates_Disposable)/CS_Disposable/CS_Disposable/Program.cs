using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Disposable
{
    class Program
    {
        static void Main(string[] args)
        {
            var car = new Car() { Brand = "Mercedes", Model = "E-320", Speed = 250, Price = 60000 };

            car.Move(34, 67);
            
            car = null;

            // заставить сборщик мусора отработать по 0 уровню объектов и не дожидаться удобного момента
            //GC.Collect(0, GCCollectionMode.Forced);

            // подождать пока GC всё очистит
            //GC.WaitForFullGCComplete();

            Console.ReadLine();

            // Dispose будет вызван автоматически по выходу из блока using
            using (Person person = new Person() { FirstName = "Alex", LastName = "Petrov", Age = 23, Address = "Donetsk"})
            {
                person.Print();
            }
        }
    }
}
