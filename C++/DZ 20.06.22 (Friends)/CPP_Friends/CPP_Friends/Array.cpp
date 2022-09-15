#include <iostream>
#include "Array.h"

using namespace std;

Array::Array()
{
	cout << "Constr" << endl;
	size = 7;
	arr = new int[size];

	for (size_t i = 0; i < size; i++)
	{
		arr[i] = (int)(i + 1);
	}
}

Array::Array(size_t size)
{
	cout << "Constr" << endl;
	this->size = size;
	arr = new int[size];

	for (size_t i=0; i<size; i++)
	{
		arr[i] = (int)(i + 1);
	}
}

Array::Array(const Array& source)
{
	cout << "Copy constr" << endl;

	// скопировать размер исходного массива в размер создаваемого массива
	size = source.size;

	// выделить память для создаваемого массива
	arr = new int[size];

	// скопировать элементы исходного массива в создаваемый массив
	for (size_t i = 0; i < size; i++)
	{
		arr[i] = source.arr[i];
	}

}

Array::~Array()
{
	cout << "Destr" << endl;
	delete[] arr;
}

// оператор добавляет элементы второго массива к первому
// и возвращает новый объект Array
/*Array Array::operator+ (Array& second)
{
	// создание нового объекта
	Array result(size + second.size);

	// копирование элементов первого массива
	for (size_t i = 0; i < size; i++)
	{
		result.arr[i] = arr[i];
	}

	// копирование элементов второго массива
	for (size_t i = 0; i < second.size; i++)
	{
		result.arr[size + i] = second.arr[i];
	}

	// возврат нового объекта по значению
	return result;
}*/

// префиксный инкремент
Array& Array::operator++()
{
	//cout << "Prefix inc op" << endl;
	for (size_t i = 0; i < size; i++)
	{
		++arr[i];
	}
	return *this;
}

// постфиксный инкремент
Array Array::operator++(int)
{
	//cout << "Postfix inc op" << endl;
	Array result = *this;
	for (size_t i = 0; i < size; i++)
	{
		arr[i]++;
	}
	return result;
}

void Array::print()
{
	for (size_t i = 0; i < this->size; i++)
	{
		cout << this->arr[i] << " ";
	}
	cout << endl;
	//cout << "this: " << this << endl;
}

Array operator+ (Array& first, Array& second)
{
	// создание нового объекта
	Array result(first.size + second.size);

	// копирование элементов первого массива
	for (size_t i = 0; i < first.size; i++)
	{
		result.arr[i] = first.arr[i];
	}

	// копирование элементов второго массива
	for (size_t i = 0; i < second.size; i++)
	{
		result.arr[first.size + i] = second.arr[i];
	}

	// возврат нового объекта по значению
	return result;
}

ostream& operator << (ostream& os, const Array& array)
{
	for (size_t i = 0; i < array.size; i++)
	{
		os << array.arr[i] << " ";
	}

	return os;
}

istream& operator >> (istream& is, Array& array)
{
	for (size_t i = 0; i < array.size; i++)
	{
		is >> array.arr[i];
	}

	return is;
}