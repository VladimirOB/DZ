#define _CRT_SECURE_NO_WARNINGS

#include "Garage.h"
#include "Car.h"

#include <iostream>

using namespace std;

Garage::Garage(size_t maxLength)
{
	cout << endl << "Garage constr" << endl;

	MaxLength = maxLength;
	CurrentLength = 0;
	Cars = new Car*[maxLength];
}

Garage::Garage(const Garage& source)
{
	cout << endl << "Garage copy constr" << endl;

	MaxLength = source.MaxLength;
	CurrentLength = 0;

	Cars = new Car * [MaxLength];

	// перебрать все машины в исходном гараже
	for (size_t i = 0; i < source.CurrentLength; i++)
	{
		// создать копию автомобиля по указателю на исходный автомобиль
		Car* car = new Car(*source.Cars[i]);

		// добавить автомобиль в новый гараж
		Add(car);
	}
}

Garage::~Garage()
{
	cout << endl << "Garage destr" << endl;

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
	{
		size_t newSize = MaxLength + 3;

		cout << "Garage resize. New size: " << newSize << endl;

		// выделить память под новый гараж
		Car** new_cars = new Car * [newSize];

		size_t i = 0;
		// перебрать все машины в исходном массиве
		for (; i < CurrentLength; i++)
		{
			// добавить автомобиль в новый массив
			new_cars[i] = Cars[i];
		}

		// добавить новую машину в новый массив машин
		new_cars[i] = car;

		// изменить размеры с учётом новой машины
		MaxLength = newSize;
		CurrentLength++;

		// удалить старый массив указателей
		delete[] Cars;

		// сохранить новый массив с машинами в поле класса Cars
		Cars = new_cars;
	}
}

void Garage::Print()
{
	for (size_t i = 0; i < CurrentLength; i++)
		Cars[i]->Print();

	cout << endl;
}

Garage& Garage::operator=(const Garage& source)
{
	if (MaxLength != source.MaxLength)
	{
		for (size_t i = 0; i < CurrentLength; i++)
		{
			delete Cars[i];
		}
		delete[] Cars;

		// скопировать размеры исходного гаража
		MaxLength = source.MaxLength;
		CurrentLength = 0;

		// выделить память под новый гараж
		Cars = new Car * [MaxLength];

		// перебрать все машины в исходном гараже
		for (size_t i = 0; i < source.CurrentLength; i++)
		{
			// создать копию автомобиля по указателю на исходный автомобиль
			Car* car = new Car(*source.Cars[i]);

			// добавить автомобиль в новый гараж
			Add(car);
		}
	}

	return *this;
}

Garage Garage::operator+(Car* car)
{
	Garage result = *this;
	result.Add(car);
	return result;
}

Garage Garage::operator+(const Garage& source)
{
	/*Garage result = *this;

	for (size_t i = 0; i < source.CurrentLength; i++)
	{
		result.Add(new Car(*source.Cars[i]));
	}

	return result;*/

	Garage result(MaxLength + source.MaxLength + 3);

	for (size_t i = 0; i < CurrentLength; i++)
	{
		result.Add(new Car(*Cars[i]));
	}

	for (size_t i = 0; i < source.CurrentLength; i++)
	{
		result.Add(new Car(*source.Cars[i]));
	}

	return result;
}

Garage& Garage::operator+=(const Garage& source)
{
	for (size_t i = 0; i < source.CurrentLength; i++)
	{
		Add(new Car(*source.Cars[i]));
	}
	return *this;
}

bool Garage::Save(const char* file_name)
{
	FILE* file;
	file = fopen(file_name, "w");
	if (file != NULL)
	{
		for (size_t i = 0; i < CurrentLength; i++)
		{
			if (!Cars[i]->Save(file))
			{
				cout << "Error saving cars!!!" << endl;
				fclose(file);
				return false;
			}
		}
		fclose(file);
		return true;
	}
	else
	{
		cout << "Error opening file!!!" << endl;
		return false;
	}
}

bool Garage::Load(const char* file_name)
{
	FILE* file;
	file = fopen(file_name, "r");
	if (file != NULL)
	{
		// удалить существующие машины
		for (size_t i = 0; i < CurrentLength; i++)
		{
			delete Cars[i];
		}

		CurrentLength = 0;
		while (!feof(file))
		{
			unsigned price = 0;
			unsigned speed = 0;
			char brand[200];
			char model[200];
			strcpy(brand, "");
			strcpy(model, "");

			int res = fscanf(file, "%s %s %d %d", brand, model, &speed, &price);

			if (strlen(brand) > 0 && strlen(model) > 0)
			{
				Car* car = new Car(brand, model, price, speed);
				Add(car);
			}
		}

		fclose(file);
		return true;
	}
	else
	{
		cout << "Error opening file!!!" << endl;
		return false;
	}
}