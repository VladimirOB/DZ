#pragma once

#include <iostream>
#include "Test.h"

using namespace std;

class Array
{
	// указатель на динамический одномерный массив
	int* arr;

	// размер динамического массива
	size_t size;

public:
	// конструкторы класса
	Array();
	Array(size_t size);
	Array(const Array& source);

	// деструктор класса
	~Array();

	// оператор добавляет элементы второго массива к первому
	// и возвращает новый объект Array
	//Array operator+ (Array& second);

	// префиксный инкремент
	Array& operator++();

	// постфиксный инкремент
	Array operator++(int n);

	void print();

	// friend Test;
	friend void Test::Print();
	friend void Test::Print2();

	friend Array operator+ (Array& first, Array& second);
	friend ostream& operator << (ostream& os, const Array & array);
	friend istream& operator >> (istream& is, Array& array);
};