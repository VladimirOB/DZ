#pragma once
#include "Figure.h"

class Rectangle: public Figure
{
	int A, B;
public:
	Rectangle(int x, int y, int a, int b);
	~Rectangle();
	void Print();
};

