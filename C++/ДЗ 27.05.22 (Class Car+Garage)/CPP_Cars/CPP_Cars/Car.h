#pragma once

class Car
{
	char* Brand;
	char* Model;
	unsigned Price;
	unsigned MaxSpeed;

public:
	Car();
	Car(const char* brand, const char* model, const unsigned price, const unsigned maxSpeed);
	Car(const Car& source);

	Car operator= (const Car& source);
	void Print();

	~Car();
};
