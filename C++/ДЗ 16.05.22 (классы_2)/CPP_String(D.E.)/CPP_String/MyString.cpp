#define _CRT_SECURE_NO_WARNINGS
#include <iostream>

#include "MyString.h"

using namespace std;

MyString::MyString()
{
	MaxSize = 3;// размер массива
	String = new char[MaxSize];
	for (size_t i = 0; i < MaxSize; i++)//заполнение массива единицами
	{
		String[i] = 'a';
	}
}

MyString::MyString(const char* string)
{

	if (string != NULL)//проверка  
	{
		int size = 0;
		while (string[size] != 0) {
			size++;
		}
		String = new char[size];

		for (size_t i = 0; i < size; i++)
		{
			String[i] = string[i];
		}
		MaxSize = size;
	}
	else//значения по умолчанию		
	{
		MaxSize = 1;
		String = new char[MaxSize];

		for (size_t i = 0; i < MaxSize; i++)
		{
			String[i] = 1;
		}
	}
}

MyString::~MyString()
{
	delete[] String;
}

void MyString::Set(const char* str)
{
	size_t size = strlen(str);
	if (size >= MaxSize)
	{
		// выделить массив нового размера для новой строки
		char* new_mas = new char[size+1];

		// скопировать строку str в новый массив
		strcpy(new_mas, str);

		// очистить память от старого массива
		delete[] String;

		// сохранить адрес нового массива в классе
		String = new_mas;

		// сохранить размер нового массива в классе
		MaxSize = size;
	}
	else
	{
		// скопировать строку str в новый массив
		strcpy(String, str);
	}
}


// ГЕТТЕРЫ

char* MyString::GetString()
{
	return String;
}
int MyString::GetSize()
{
	int size = 0;
	while (String[size] != 0 && size <= MaxSize) {
		size++;
	}
	return size;
}

void MyString::Print()
{
	cout << " MaxSize:" << MaxSize << endl;
	cout << " String: ";

	for (size_t i = 0; i < MaxSize; i++)
	{
		cout << String[i];
		if (String[i] == 0) {
			break;
		}
	}
	cout << endl << endl;
}

long MyString::GetVowelsCount()
{
	int count = 0;
	for (size_t i = 0; i < MaxSize; i++)
	{
		if (String[i] == 'a' || String[i] == 'e' || String[i] == 'y' || String[i] == 'u' || String[i] == 'i' || String[i] == 'o')
			count++;
	}
	return count;
}

void MyString::ToUper()
{
	for (int i = 0; i < MaxSize; i++) {
		if (String[i] >= 97 && String[i] <= 122)
			String[i] -= 32;
	}
}

void MyString::ToLower()
{
	for (int i = 0; i < MaxSize; i++) {
		if (String[i] >= 65 && String[i] <= 90)
			String[i] += 32;
	}
}
void MyString::RemoveDigits()
{
	char* new_mas = new char[MaxSize];
	int i1 = 0;
	for (int i = 0; i < MaxSize; i++) {
		if (String[i] >= 48 && String[i] <= 57) {}
		else {
			new_mas[i1] = String[i];
			i1++;
		}
	}
	new_mas[i1] = 0;
	delete[] String;

	// сохранить адрес нового массива в классе
	String = new_mas;
}