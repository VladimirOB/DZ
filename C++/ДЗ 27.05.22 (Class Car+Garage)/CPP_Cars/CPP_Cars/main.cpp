#include <iostream>
#include "Car.h"
#include "Garage.h"

using namespace std;

void main()
{
	// Car car("Bmw", "M5", 150000, 250);
	// car.Print();

	Garage garage(5);
	garage.Add(new Car("Bmw", "M3", 150000, 250));
	garage.Add(new Car("Bmw", "M5", 150000, 250));
	garage.Add(new Car("Audi", "A4", 150000, 250));
	garage.Add(new Car("Audi", "A6", 150000, 250));
	garage.Add(new Car("Audi", "A8", 150000, 250));

	garage.Print();
}