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
	Garage(const Garage& source);
	~Garage();

	void Add(Car* car);
	void Print();
	Garage& operator=(const Garage& source);
	Garage operator+(Car* car);

	bool Save(const char* file_name);
	bool Load(const char* file_name);
};

