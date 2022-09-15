#pragma once

class Array;

class Test
{
	int a, b;
	Array* arr;
public:
	Test(Array& arr);
	void Print();
	void Print2();
};

