#pragma once
#include "Figure.h"

class Circle : public Figure
{
	int R;
public:
	Circle(int x, int y, int r);
	~Circle();
	void Print();
	double GetS();
};


