#include "Document.h"
#include <iostream>
#include "Figure.h"
#include "Rectangle.h"
#include "Circle.h"

using namespace std;

Document::Document(size_t size)
{
	cout << "Document constr" << endl;

	figures = new Figure * [size];
	MaxSize = size;
	CurrentSize = 0;
}

Document::~Document()
{
	cout << "Document destr" << endl;

	/*for (size_t i = 0; i < CurrentSize; i++)
	{
		delete[] figures[i];
	}*/

	delete[] figures;
}

bool Document::Add(Figure* figure)
{
	if (CurrentSize < MaxSize)
	{
		figures[CurrentSize++] = figure;
	}
	else
	{
		cout << "There is no space left for another figure!" << endl;
		return false;
	}
}

void Document::Print()
{
	for (size_t i = 0; i < CurrentSize; i++)
	{
		// полиморфный вызов метода Print() у правильного наследника класса Figure
		figures[i]->Print();
	}
}

double Document::GetS()
{
	double result = 0;
	for (size_t i = 0; i < CurrentSize; i++)
	{
		// полиморфный вызов метода GetS() у правильного наследника класса Figure
		result += figures[i]->GetS();
	}
	return result;
}