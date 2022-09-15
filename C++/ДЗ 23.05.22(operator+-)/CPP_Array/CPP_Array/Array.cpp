#define _CRT_SECURE_NO_WARNINGS
#include <iostream>
#include "Array.h"

using namespace std;

Array::Array()
{
	cout << "Constr" << endl;
	size = 3;// размер массива
	arr = new int[size];
	for (size_t i = 0; i < size; i++)//заполнение массива единицами
	{
		arr[i] = 1;
	}
}

Array::Array(unsigned int size)
{
	cout << "Constr with params" << endl;
	if (arr != NULL && size > 0)//проверка  
	{
		this->size = size;
		arr = new int[size];

		for (size_t i = 0; i < size; i++)
		{
			arr[i] = rand()%10;
		}
	}
	else//значения по умолчанию		
	{
		size = 1;
		arr = new int[size];

		for (size_t i = 0; i < size; i++)
		{
			arr[i] = 1;
		}
	}
}

Array::Array(Array& arr2)
{
	cout << "Copy constr" << endl;

	size = arr2.size;
	arr = new int[size];

	for (size_t i = 0; i < size; i++)
	{
		arr[i] = arr2.arr[i];
	}
}

Array Array::operator= (const Array& source)
{
	// удаление старого массива
	if (arr != NULL)
		delete[] arr;

	// скопировать размер массива
	size = source.size;

	// выделить память под новый массив
	arr = new int[size];

	// скопировать сами значения
	for (size_t i = 0; i < size; i++)
	{
		arr[i] = source.arr[i];
	}

	return *this;
}

Array::~Array()
{
	cout << "Destr" << endl;
	delete[] arr;
}

int& Array::operator[] (unsigned pos)
{
	if (pos < size)
		return arr[pos];
	else
		throw exception("Incorrect index!!!");
}

void Array::operator() (int a, int b)
{
	srand(time(0));

	for (size_t i = 0; i < size; i++)
	{
		arr[i] = rand() % (b - a + 1) + a;
	}
}

void Array::operator() ()
{
	for (size_t i = 0; i < size; i++)
	{
		arr[i] = 0;
	}
}

bool Array::operator== (Array& arr2)
{
	if (size != arr2.size)
		return false;

	for (size_t i = 0; i < size; i++)
	{
		if (arr[i] != arr2.arr[i])
			return false;
	}

	return true;
}

bool Array::operator== (int n)
{
	for (size_t i = 0; i < size; i++)
	{
		if (arr[i] != n)
			return false;
	}

	return true;
}

Array Array::operator+ (int n)
{
	Array result = *this;
	for (size_t i = 0; i < size; i++)
	{
		result.arr[i] += n;
	}
	return result;
}

void Array::ReSize(unsigned int size)
{
	// если размеры не изменились - то выйти
	if (size == size)
		return;

	// выделить массив нового размера
	int* new_arr = new int[size];

	if (size < size)
	{
		// скопировать элементы, которые можно скопировать
		for (size_t i = 0; i < size; i++)
		{
			new_arr[i] = arr[i];
		}
	}

	if (size > size)
	{
		// скопировать элементы, которые можно скопировать
		for (size_t i = 0; i < size; i++)
		{
			if (i < size)
				new_arr[i] = arr[i];
			else 
				new_arr[i] = 0;
		}
	}
	
	// очистить память от старого массива
	delete[] arr;

	// сохранить адрес нового массива в классе
	arr = new_arr;

	// сохранить размер нового массива в классе
	size = size;
}

void Array::Set(unsigned int pos, int value)
{
	if (pos >= 0 && pos < size)
	{
		arr[pos] = value;
	}
}

// ГЕТТЕРЫ

unsigned int Array::GetSize()
{
	return size;
}

// методы класса, лучше писать с большой

void Array::Print()
{
	//cout << "this: " << this << endl;

	cout << " Size:" << size << endl;
	cout << " Array:" << endl;

	for (size_t i = 0; i < size; i++)
	{
		cout << " " << arr[i];
	}
	cout << endl << endl;
}

long Array::Sum()
{
	int sum = 0;
	for (size_t i = 0; i < size; i++)
	{
		sum += arr[i];
	}
	return sum;
}

long Array::Max()
{
	int max = arr[0];
	for (size_t i = 0; i < size; i++)
	{
		if (arr[i] > max)
			max = arr[i];
	}
	return max;
}

long Array::Min()
{
	int min = arr[0];
	for (size_t i = 0; i < size; i++)
	{
		if (arr[i] < min)
			min = arr[i];
	}
	return min;
}

int Array::Get(unsigned int pos)
{
	if (pos >= 0 && pos < size)
		return arr[pos];
	else return -1;	// ????
}

bool Array::SaveToFile(char* fileName)
{
	FILE* file = fopen(fileName, "wb");
	if (file != nullptr)
	{
		fwrite(arr, sizeof(int), size, file);
		fclose(file);
		return true;
	}
	else return false;
}

// загружает записи из файла и возвращает количество загруженных записей (-1 в случае сбоя)
bool Array::LoadFromFile(char* fileName)
{
	// открытие файла с записями для чтения
	FILE* file = fopen(fileName, "rb");

	// проверка на успешность открытия файла
	if (file != nullptr)
	{
		fseek(file, 0, SEEK_END);
		long file_size = _ftelli64(file);
		fseek(file, 0, SEEK_SET);

		// получить размер нового массива из файла
		long new_size = file_size / sizeof(int);

		// если размеры текущего массива и массива в файле не совпадают
		if (size != new_size)
		{
			// удаление сторого массива
			delete[] arr;

			// выделение памяти под новый массив
			arr = new int[new_size];

			// сохранить новый размер в поле класса
			size = new_size;
		}

		// чтение значений из файла
		fread(arr, sizeof(int), size, file);
		fclose(file);

		// возвратить новый размер БД (количество заполненных записей)
		return true;
	}
	else return false;
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