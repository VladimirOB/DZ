#pragma once

#include "Car.h"

class Garage
{
	// динамический массив, который хранит указатели на автомобили
	Car** Cars;
	size_t MaxLength;
	size_t CurrentLength;

public:
	Garage(size_t maxLength);
	~Garage();

	void Add(Car* car);
	void Print();
};

