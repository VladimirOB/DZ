#define _CRT_SECURE_NO_WARNINGS
#include "Car.h"
#include <iostream>

using namespace std;

Car::Car()
{
	cout << "Constr" << endl;

	Brand = new char[40];
	strcpy(Brand, "Unknown");

	Model = new char[40];
	strcpy(Model, "Unknown");

	MaxSpeed = 0;
	Price = 0;
}

Car::Car(const char* brand, const char* model, const unsigned price, const unsigned maxSpeed)
{
	cout << "Constr with params" << endl;

	Brand = new char[strlen(brand) + 1];
	strcpy(Brand, brand);

	Model = new char[strlen(model) + 1];
	strcpy(Model, model);

	MaxSpeed = maxSpeed;
	Price = price;
}

Car::Car(const Car& source)
{
	cout << "Copy constr" << endl;

	Brand = new char[strlen(source.Brand) + 1];
	strcpy(Brand, source.Brand);

	Model = new char[strlen(source.Model) + 1];
	strcpy(Model, source.Model);

	MaxSpeed = source.MaxSpeed;
	Price = source.Price;
}

Car Car::operator= (const Car& source)
{
	if (Brand != NULL)
		delete[] Brand;

	if (Model != NULL)
		delete[] Model;

	Brand = new char[strlen(source.Brand) + 1];
	strcpy(Brand, source.Brand);

	Model = new char[strlen(source.Model) + 1];
	strcpy(Model, source.Model);

	MaxSpeed = source.MaxSpeed;
	Price = source.Price;

	return *this;
}

void Car::Print()
{
	cout << "Brand: " << Brand << endl;
	cout << "Model: " << Model << endl;
	cout << "Max speed: " << MaxSpeed << endl;
	cout << "Price: " << Price << endl;
}

Car::~Car()
{
	cout << "Car destr" << endl;
	delete[] Brand;
	delete[] Model;
}