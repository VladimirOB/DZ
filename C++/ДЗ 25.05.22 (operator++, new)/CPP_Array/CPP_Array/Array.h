#pragma once

class Array
{
	//поля класса
	int* Arr;
	unsigned int Size;

public:
	Array();
	Array(int* arr, unsigned int size);
	Array(const Array& arr2);
	~Array();

	void ReSize(unsigned int size);
	unsigned int GetSize();
	void Print();
	long Sum();
	long Max();
	long Min();
	void Set(unsigned int pos, int value);
	int Get(unsigned int pos);
	bool SaveToFile(char* fileName);
	bool LoadFromFile(char* fileName);

	Array operator= (const Array& source);
	int& operator[] (unsigned pos);
	void operator() (int a, int b);
	void operator() ();

	// ==, !=, >, <, >=, <=
	bool operator== (Array& arr2);
	bool operator== (int n);

	Array operator+ (int n);
	Array& operator+= (int n);

	Array& operator++ ();
	Array operator++ (int);
	operator int();

	void* operator new(size_t size);
	void operator delete(void* p);

	void* operator new[](size_t size);
	void operator delete[](void* p);
};

