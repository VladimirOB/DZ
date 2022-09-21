using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Disposable
{
    class Car
    {
        public string Brand { get; set; }

        public string Model { get; set; }

        public int Speed { get; set; }

        public int Price { get; set; }

        /// <summary>
        /// Moves the car to some position
        /// </summary>
        /// <param name="x">X coord</param>
        /// <param name="y">Y coord</param>
        /// <returns>Time of move</returns>
        public double Move(int x, int y)
        {
            return 4.7;
        }

        // Деструктор класса
        ~Car()
        {
            Console.WriteLine("Car destructor!");
        }
    }
}
