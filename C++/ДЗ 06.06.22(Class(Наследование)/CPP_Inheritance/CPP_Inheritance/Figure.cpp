#include "Figure.h"

#include <iostream>

using namespace std;

Figure::Figure(int x, int y)
{
	cout << "Figure constr" << endl;
	X = x;
	Y = y;
}

Figure::~Figure()
{
	cout << "Figure destr" << endl;
}

void Figure::Print()
{
	cout << "Figure. X = " << X << ", Y = " << Y << endl;
}