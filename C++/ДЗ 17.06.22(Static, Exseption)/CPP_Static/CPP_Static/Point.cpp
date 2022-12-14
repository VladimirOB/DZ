#include "Point.h"
#include <iostream>

using namespace std;

// инициализация статического поля класса
unsigned Point::count = 0;

Point::Point(int x, int y)
{
	this->x = x;
	this->y = y;

	// увеличить счётчик переменных класса
	count++;
}

Point::~Point()
{
	// уменьшить счётчик переменных класса
	count--;
}

void Point::Print()
{
	cout << "x = " << this->x << ", y = " << y << endl;
}

// статическим методам не передаётся указатель this
// поэтому из в них нельзя обращаться к обычным (не статическим) полям класса
unsigned Point::GetCount()
{
	return count;
}
