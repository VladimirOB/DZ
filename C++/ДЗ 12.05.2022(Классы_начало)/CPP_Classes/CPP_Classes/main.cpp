#define _CRT_SECURE_NO_WARNINGS

#include <iostream>
using namespace std;

class Person
{
	// поля класса
	char* FirstName;
	char* LastName;
	unsigned int Age;
	unsigned int Height;

public:

	// конструкторы класса

	Person()
	{
		cout << "Constr" << endl;
		FirstName = new char[10];
		LastName = new char[10];

		strcpy(FirstName, "Vasya");
		strcpy(LastName, "Pupkin");
		Age = 23;
		Height = 180;
	}

	Person(const char* name, const char* lastName, unsigned int age, unsigned int height)
	{
		cout << "Constr with params" << endl;
		if (name != NULL && lastName != NULL && age > 0 && age <= 150 && height >= 30 && height <= 260)
		{
			FirstName = new char[strlen(name) + 1];
			LastName = new char[strlen(lastName) + 1];

			strcpy(FirstName, name);
			strcpy(LastName, lastName);
			Age = age;
			Height = height;
		}
		else {
			FirstName = new char[10];
			LastName = new char[10];

			strcpy(FirstName, "Vasya");
			strcpy(LastName, "Pupkin");
			Age = 23;
			Height = 180;
		}
	}

	// Деструктор класса

	~Person()
	{
		cout << "Destr" << endl;

		delete[] FirstName;
		delete[] LastName;
	}

	// Сеттеры

	void SetFirstName(const char* name)
	{
		if(name != NULL)
			strcpy(FirstName, name);
	}

	void SetLastName(const char* lastName)
	{
		if (lastName != NULL)
			strcpy(LastName, lastName);
	}

	void SetAge(unsigned int age)
	{
		if(age > 0 && age <= 150)
			Age = age;
	}

	void SetHeight(unsigned int height)
	{
		if (height >= 30 && height <= 260)
			Height = height;
	}

	// Геттеры

	char* GetFirstName()
	{
		return FirstName;
	}

	char* GetLastName()
	{
		return LastName;
	}

	unsigned int GetAge()
	{
		return Age;
	}

	unsigned int GetHeight()
	{
		return Height;
	}

	// методы класса

	void Print()
	{
		cout << "First name: " << FirstName << endl;
		cout << "Last name: " << LastName << endl;
		cout << "Age: " << Age << endl;
		cout << "Height: " << Height << endl;
	}
};

void main()
{
	/*Person person("Varfolomey", "Petrov", 34, 209);

	person.SetFirstName("Alex");
	person.SetLastName("Petrov");
	person.SetAge(43);
	person.SetHeight(200);

	cout << person.GetAge() << endl;

	person.Print();*/

	/* Разработать класс Car, который имеет следующие поля :
	- марка
	- модель
	- маскимальная скорость
	- цена

	методы:
	- конструкторы:
	- деструктор
	- сеттеры
	- геттеры
	- print
	*/
}