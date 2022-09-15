#include <iostream>
#include <conio.h>

using namespace std;

void main()
{
	// УКАЗАТЕЛИ

	/*
	// создание обычной переменной
	int a = 45;

	// создание указателя на обычную переменную (хранение адреса переменной a)
	int* p = &a;

	// вывод адреса на консоль
	cout << p << endl;

	// получить доступ к переменной по адресу из указателя
	cout << *p << endl;

	// получить доступ к переменной по имени
	cout << a << endl;
	*/

	/*
	// выделение памяти на куче (heap) для одной переменной типа int
	int* p = new int;

	// использование динамической памяти
	cin >> *p;
	cout << *p << endl;

	// очистка памяти, на которую указывает указатель
	delete p;
	*/

	/*int size = 0;
	cout << "Enter size of array: ";
	cin >> size;

	// выделение памяти на куче (heap) для массива типа int
	int* p = new int[size];

	// использование динамической памяти
	for (int i = 0; i < size; i++)
	{
		p[i] = rand() % 10;
	}

	for (int i = 0; i < size; i++)
	{
		cout << p[i] << " ";
	}
	cout << endl;

	// очистка массива, на который указывает указатель
	delete[] p;
	*/

	// Пользователь вводит размеры 2 массивов и они заполняются случайными числами в диапазоне [1, 50]
	// Программа объелиняет эти массивы в третий динамический массив и копирует все данные,
	// после чего все массивы выводятся на экран

	/*int size = 0;
	cout << "Enter size of the first array: ";
	cin >> size;

	int size2 = 0;
	cout << "Enter size of the second array: ";
	cin >> size2;

	// выделение памяти на куче (heap) для массива типа int
	int* p = new int[size];

	// использование динамической памяти
	for (int i = 0; i < size; i++)
	{
		p[i] = rand() % 50 + 1;
	}

	for (int i = 0; i < size; i++)
	{
		cout << p[i] << " ";
	}
	cout << endl;

	// выделение памяти на куче (heap) для массива типа int
	int* p2 = new int[size2];

	// использование динамической памяти
	for (int i = 0; i < size2; i++)
	{
		p2[i] = rand() % 50 + 1;
	}

	for (int i = 0; i < size2; i++)
	{
		cout << p2[i] << " ";
	}
	cout << endl;

	// выделение памяти на куче (heap) для массива типа int
	int* p3 = new int[size + size2];

	for (int i = 0; i < size; i++)
	{
		p3[i] = p[i];
	}
	for (int i = 0; i < size2; i++)
	{
		p3[i+size] = p2[i];
	}

	for (int i = 0; i < size + size2; i++)
	{
		cout << p3[i] << " ";
	}
	cout << endl;

	// очистка массива, на который указывает указатель
	delete[] p, p2;
	delete[] p3;*/

	// ДВУМЕРНЫЕ ДИНАМИЧЕСКИЕ МАССИВЫ
		
	/*int rows = 0;
	cout << "Enter number of rows: ";
	cin >> rows;

	int cols = 0;
	cout << "Enter number of columns: ";
	cin >> cols;

	int** a = new int* [rows];

	for (size_t i = 0; i < rows; i++)
	{
		a[i] = new int[cols];
	}

	for (size_t i = 0; i < rows; i++)
	{
		for (size_t k = 0; k < cols; k++)
		{
			a[i][k] = rand() % 10;
			cout << a[i][k] << " ";
		}
		cout << endl;
	}

	for (size_t i = 0; i < rows; i++)
	{
		delete[] a[i];
	}

	delete[] a;
	*/

	// Пользователь вводит размеры двумерного динамического массива, программа заполняет его
	// числами в диапазоне [1..20], выводит на экран, а потом меняет местами первую и последнюю
	// строки массива

	/*int rows = 0;
	cout << "Enter number of rows: ";
	cin >> rows;

	int cols = 0;
	cout << "Enter number of columns: ";
	cin >> cols;

	int** a = new int* [rows];

	for (size_t i = 0; i < rows; i++)
	{
		a[i] = new int[cols];
	}

	for (size_t i = 0; i < rows; i++)
	{
		for (size_t k = 0; k < cols; k++)
		{
			a[i][k] = rand() % 10;
			cout << a[i][k] << " ";
		}
		cout << endl;
	}

	for (size_t k = 0; k < cols; k++)
	{
		int tmp = a[0][k];
		a[0][k] = a[rows - 1][k];
		a[rows - 1][k] = tmp;
	}
	cout << endl;

	for (size_t i = 0; i < rows; i++)
	{
		for (size_t k = 0; k < cols; k++)
		{
			cout << a[i][k] << " ";
		}
		cout << endl;
	}

	for (size_t i = 0; i < rows; i++)
	{
		delete[] a[i];
	}

	delete[] a;
	*/

	
}