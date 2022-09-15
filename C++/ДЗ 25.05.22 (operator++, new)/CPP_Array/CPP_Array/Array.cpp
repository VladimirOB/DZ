#define _CRT_SECURE_NO_WARNINGS
#include <iostream>
#include "Array.h"

using namespace std;

Array::Array()
{
	cout << "Constr" << endl;
	Size = 3;// размер массива
	Arr = new int[Size];
	for (size_t i = 0; i < Size; i++)//заполнение массива единицами
	{
		Arr[i] = 1;
	}
}

Array::Array(int* arr, unsigned int size)
{
	cout << "Constr with params" << endl;
	if (arr != NULL && size > 0)//проверка  
	{
		this->Size = size;
		Arr = new int[Size];

		for (size_t i = 0; i < size; i++)
		{
			Arr[i] = arr[i];
		}
	}
	else//значения по умолчанию		
	{
		Size = 1;
		Arr = new int[Size];

		for (size_t i = 0; i < Size; i++)
		{
			Arr[i] = 1;
		}
	}
}

Array::Array(const Array& arr2)
{
	cout << "Copy constr" << endl;

	Size = arr2.Size;
	Arr = new int[Size];

	for (size_t i = 0; i < Size; i++)
	{
		Arr[i] = arr2.Arr[i];
	}
}

Array Array::operator= (const Array& source)
{
	// удаление старого массива
	if (Arr != NULL)
		delete[] Arr;

	// скопировать размер массива
	Size = source.Size;

	// выделить память под новый массив
	Arr = new int[Size];

	// скопировать сами значения
	for (size_t i = 0; i < Size; i++)
	{
		Arr[i] = source.Arr[i];
	}

	return *this;
}

Array::~Array()
{
	cout << "Destr" << endl;
	delete[] Arr;
}

int& Array::operator[] (unsigned pos)
{
	if (pos < Size)
		return Arr[pos];
	else
		throw exception("Incorrect index!!!");
}

void Array::operator() (int a, int b)
{
	srand(time(0));

	for (size_t i = 0; i < Size; i++)
	{
		Arr[i] = rand() % (b - a + 1) + a;
	}
}

void Array::operator() ()
{
	for (size_t i = 0; i < Size; i++)
	{
		Arr[i] = 0;
	}
}

bool Array::operator== (Array& arr2)
{
	if (Size != arr2.Size)
		return false;

	for (size_t i = 0; i < Size; i++)
	{
		if (Arr[i] != arr2.Arr[i])
			return false;
	}

	return true;
}

bool Array::operator== (int n)
{
	for (size_t i = 0; i < Size; i++)
	{
		if (Arr[i] != n)
			return false;
	}

	return true;
}

Array Array::operator+ (int n)
{
	Array result = *this;
	for (size_t i = 0; i < Size; i++)
	{
		result.Arr[i] += n;
	}
	return result;
}

Array& Array::operator+= (int n)
{
	for (size_t i = 0; i < Size; i++)
	{
		Arr[i] += n;
	}

	return *this;
}

Array& Array::operator++ ()
{
	for (size_t i = 0; i < Size; i++)
	{
		Arr[i]++;
	}

	return *this;
}

Array Array::operator++ (int)
{
	Array old = *this;

	for (size_t i = 0; i < Size; i++)
	{
		Arr[i]++;
	}

	return old;
}

Array::operator int()
{
	int sum = 0;
	for (size_t i = 0; i < Size; i++)
	{
		sum += Arr[i];
	}
	return sum;
}

void* Array::operator new(size_t size)
{
	cout << "Operator new!!!" << endl;
	void* p = malloc(size);
	return p;
}

void Array::operator delete(void* p)
{
	cout << "Operator delete!!!" << endl;
	free(p);
}

void* Array::operator new[](size_t size)
{
	cout << "Operator new[]!!!" << endl;
	void* p = malloc(size);
	return p;
}

void Array::operator delete[](void* p)
{
	cout << "Operator delete[]!!!" << endl;
	free(p);
}

void Array::ReSize(unsigned int size)
{
	// если размеры не изменились - то выйти
	if (size == Size)
		return;

	// выделить массив нового размера
	int* new_arr = new int[size];

	if (size < Size)
	{
		// скопировать элементы, которые можно скопировать
		for (size_t i = 0; i < size; i++)
		{
			new_arr[i] = Arr[i];
		}
	}

	if (size > Size)
	{
		// скопировать элементы, которые можно скопировать
		for (size_t i = 0; i < size; i++)
		{
			if (i < Size)
				new_arr[i] = Arr[i];
			else 
				new_arr[i] = 0;
		}
	}
	
	// очистить память от старого массива
	delete[] Arr;

	// сохранить адрес нового массива в классе
	Arr = new_arr;

	// сохранить размер нового массива в классе
	Size = size;
}

void Array::Set(unsigned int pos, int value)
{
	if (pos >= 0 && pos < Size)
	{
		Arr[pos] = value;
	}
}

// ГЕТТЕРЫ

unsigned int Array::GetSize()
{
	return Size;
}

// методы класса, лучше писать с большой

void Array::Print()
{
	//cout << "this: " << this << endl;

	cout << " Size:" << Size << endl;
	cout << " Array:" << endl;

	for (size_t i = 0; i < Size; i++)
	{
		cout << " " << Arr[i];
	}
	cout << endl << endl;
}

long Array::Sum()
{
	int sum = 0;
	for (size_t i = 0; i < Size; i++)
	{
		sum += Arr[i];
	}
	return sum;
}

long Array::Max()
{
	int max = Arr[0];
	for (size_t i = 0; i < Size; i++)
	{
		if (Arr[i] > max)
			max = Arr[i];
	}
	return max;
}

long Array::Min()
{
	int min = Arr[0];
	for (size_t i = 0; i < Size; i++)
	{
		if (Arr[i] < min)
			min = Arr[i];
	}
	return min;
}

int Array::Get(unsigned int pos)
{
	if (pos >= 0 && pos < Size)
		return Arr[pos];
	else return -1;	// ????
}

bool Array::SaveToFile(char* fileName)
{
	FILE* file = fopen(fileName, "wb");
	if (file != nullptr)
	{
		fwrite(Arr, sizeof(int), Size, file);
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
		if (Size != new_size)
		{
			// удаление сторого массива
			delete[] Arr;

			// выделение памяти под новый массив
			Arr = new int[new_size];

			// сохранить новый размер в поле класса
			Size = new_size;
		}

		// чтение значений из файла
		fread(Arr, sizeof(int), Size, file);
		fclose(file);

		// возвратить новый размер БД (количество заполненных записей)
		return true;
	}
	else return false;
}