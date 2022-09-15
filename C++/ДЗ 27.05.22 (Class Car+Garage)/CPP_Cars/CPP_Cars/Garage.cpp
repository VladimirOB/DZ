#include "Garage.h"
#include "Car.h"

#include <iostream>

using namespace std;

Garage::Garage(size_t maxLength)
{
	MaxLength = maxLength;
	CurrentLength = 0;
	Cars = new Car*[maxLength];
}

Garage::~Garage()
{
	// удаление машин из гаража по адресам
	for (size_t i = 0; i < CurrentLength; i++)
		delete Cars[i];

	// удаление массива указателей на машины
	delete[] Cars;
}

void Garage::Add(Car* car)
{
	if (CurrentLength < MaxLength)
	{
		Cars[CurrentLength++] = car;
	}
	else
		cout << "Error! There is not enough space for one more car!" << endl;
}

void Garage::Print()
{
	for (size_t i = 0; i < CurrentLength; i++)
		Cars[i]->Print();

	cout << endl;
}