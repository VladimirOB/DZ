#pragma once

#include <iostream>

using namespace std;

// объявление шаблонного класса
// T - шаблонный параметр
// size - нешаблонный параметр (константа)
template <class T, int size>
class MyVector
{
protected:
	// объявление шаблонного массива
	T a[size] = {0};
public:
	// реализация конструктора внутри шаблонного класса
	MyVector()
	{
		for (size_t i = 0; i < size; i++)
		{
			a[i] = (float)i / 2 + 100;
		}
	}

	void Print()
	{
		for (size_t i = 0; i < size; i++)
		{
			cout << a[i] << " ";
		}
		cout << endl;
	}

	T Sum();

	T& operator[](size_t index);
};

// реализация шаблонных методов за пределами шаблонного класса
template <class T, int size>
T MyVector<T, size>::Sum()
{
	T result = 0;
	for (size_t i = 0; i < size; i++)
	{
		result += a[i];
	}
	return result;
}

template <class T, int size>
T& MyVector<T, size>::operator[](size_t index)
{
	if (index < size)
		return a[index];
	else throw exception("Index is out of bounds!");
}