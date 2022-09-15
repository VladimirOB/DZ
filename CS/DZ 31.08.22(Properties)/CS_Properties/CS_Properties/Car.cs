using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Properties
{
    class Car
    {
        public string Brand { get; set; }

        public string Model { get; set; }

        public int Speed { get; set; }

        public double Price { get; set; }

        public Car(string brand)
        {
            Brand = brand;
        }

		public override string ToString()
		{
			return $"{Brand} {Model}. Speed = {Speed}, Price = {Price}";
		}
	}
}
