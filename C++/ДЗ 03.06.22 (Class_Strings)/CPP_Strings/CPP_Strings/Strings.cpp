#define _CRT_SECURE_NO_WARNINGS
#include "Strings.h"
#include <iostream>

using namespace std;

Strings::Strings(size_t maxRows)
{
	cout << "Params constr" << endl;

	MaxRows = maxRows;
	CurrentRows = 0;
	Str = new char* [MaxRows];
}

Strings::~Strings()
{
	cout << "Destr" << endl;

	// удаление всех заполненных строк
	for (size_t i = 0; i < CurrentRows; i++)
	{
		delete[] Str[i];
	}

	// удаление массива указателей на строки
	delete[] Str;
}

void Strings::Add(const char* str)
{
	if (CurrentRows < MaxRows)
	{
		Str[CurrentRows] = new char[strlen(str) + 1];
		strcpy(Str[CurrentRows++], str);
	}
	else
	{
		size_t new_size = MaxRows + 3;

		// создать новый массив с адресами строк (большего размера)
		char** new_str = new char* [new_size];

		cout << "Container resize. New size: " << new_size << endl;

		// скопировать адреса существующих строк
		for (size_t i = 0; i < CurrentRows; i++)
		{
			new_str[i] = Str[i];
		}

		// удалить старый (маленький) массив с адресами строк
		delete[] Str;

		// сохранить адрес массива указателей на строки в поле класса Str
		Str = new_str;

		// сохранить новый размер в классе
		MaxRows = new_size;

		// добавить новую строку в контейнер
		Add(str);
	}
}

Strings::Strings(const Strings& source)
{
	cout << "Copy constr" << endl;

	MaxRows = source.MaxRows;
	CurrentRows = source.CurrentRows;
	Str = new char* [MaxRows];

	// выделение памяти и копирование строк
	for (size_t i = 0; i < source.CurrentRows; i++)
	{
		Str[i] = new char[strlen(source.Str[i]) + 1];
		strcpy(Str[i], source.Str[i]);
	}
}

void Strings::Remove(size_t index)
{
	if (index < CurrentRows)
	{
		// удаление строки по индексу
		delete[] Str[index];

		// смещение адресов на 1 назад (чтобы избавиться от адреса удалённой строки в массиве адресов)
		for (size_t i = index; i < CurrentRows; i++)
		{
			Str[i] = Str[i + 1];
		}

		CurrentRows--;
	}
	else throw exception("Index out of bounds of container!");
}

void Strings::Print()
{
	for (size_t i = 0; i < CurrentRows; i++)
	{
		cout << Str[i] << endl;
	}

	cout << endl;
}

Strings Strings::operator+ (Strings& source)
{
	Strings result(CurrentRows + source.CurrentRows + 3);

	for (size_t i = 0; i < CurrentRows; i++)
	{
		result.Add(Str[i]);
	}

	for (size_t i = 0; i < source.CurrentRows; i++)
	{
		result.Add(source.Str[i]);
	}

	return result;
}