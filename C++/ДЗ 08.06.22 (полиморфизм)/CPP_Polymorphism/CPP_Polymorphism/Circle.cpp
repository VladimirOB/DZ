#include "Circle.h"
#include <iostream>

using namespace std;

Circle::Circle(int x, int y, int r) : Figure(x, y)
{
	cout << "Circle constr" << endl;
	R = r;
}

Circle::~Circle()
{
	cout << "Circle destr" << endl;
}

void Circle::Print()
{
	//Figure::Print();
	cout << "Circle. X = " << X << ", Y = " << Y << ", R = " << R << endl << endl;
}

double Circle::GetS()
{
	return 3.14*R*R;
}