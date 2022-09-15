#pragma once

class Array
{
	//поля класса
	int* Arr;
	unsigned int Size;

public:
	Array();
	Array(int* arr, unsigned int size);
	Array(Array& arr2);
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
};

