#include "Rectangle.h"

#include <iostream>

using namespace std;

Rectangle::Rectangle(int x, int y, int a, int b): Figure(x, y)
{
	cout << "Rectangle constr" << endl;
	A = a;
	B = b;
}

Rectangle::~Rectangle()
{
	cout << "Rectangle destr" << endl;
}

void Rectangle::Print()
{
	//Figure::Print();
	cout << "Rectangle. X = " << X << ", Y = " << Y << ", A = " << A << ", B = " << B << endl;
}