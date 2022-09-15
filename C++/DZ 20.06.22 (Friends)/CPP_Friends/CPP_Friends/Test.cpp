#include "Test.h"
#include <iostream>
#include "Array.h"

using namespace std;

Test::Test(Array& arr)
{
	a = 3;
	b = 5;
	this->arr = &arr;
}

void Test::Print()
{
	cout << "a = " << a << endl;
	cout << "b = " << b << endl;

	for (size_t i = 0; i < arr->size; i++)
	{
		cout << arr->arr[i] << " ";
	}
	cout << endl;
}

void Test::Print2()
{
	for (size_t i = 0; i < arr->size; i++)
	{
		cout << arr->arr[i] << " ";
	}
	cout << endl;
}