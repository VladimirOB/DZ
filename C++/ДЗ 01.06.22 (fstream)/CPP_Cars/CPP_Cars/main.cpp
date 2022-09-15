#include <iostream>
#include "Car.h"
#include "Garage.h"

using namespace std;

void main()
{
	// Car car("Bmw", "M5", 150000, 250);
	// car.Print();

	Garage garage(2);
	garage.Add(new Car("Bmw", "M3", 150000, 250));
	garage.Add(new Car("Bmw", "M5", 150000, 250));
	garage.Add(new Car("Audi", "A4", 150000, 250));
	garage.Add(new Car("Audi", "A6", 150000, 250));
	garage.Add(new Car("Audi", "A8", 150000, 250));

	Garage garage2(3);
	garage2.Add(new Car("Mercedes", "SLK", 150000, 250));
	garage2.Add(new Car("Ford", "GT", 350000, 310));
	garage2.Add(new Car("Ferrari", "360", 350000, 350));
	garage2.Add(new Car("Ferrari", "F40", 6050000, 310));

	Garage garage3(3);
	garage3.Add(new Car("Mazda", "Rx7", 50000, 250));
	garage3.Add(new Car("Nissan", "GTR", 550000, 350));

	//Garage garage3 = garage + garage2;
	//garage3.Print();

	(garage += garage2) += garage3;
	garage.Print();

	/*garage.Print();

	garage.Save("c:\\Temp\\cars.txt");

	Garage garage2(2);
	garage2.Load("c:\\Temp\\cars.txt");
	garage2.Print();*/

	/*Garage garage2 = garage;
	garage2.Print();*/

	/*Garage garage2(3);
	Garage garage3(3);
	garage2 = (garage3 = garage);

	garage3.Print();
	garage2.Print();*/

	/*Garage garage2 = garage + new Car("Mercedes", "SLK", 150000, 250);
	garage2.Print();*/
}