#include <iostream>
#include <time.h>

using namespace std;

int main()
{
	srand(time(0));

	/*const int rows = 5;
	const int columns = 5;
	//int a[rows][columns] = { {1, 2, 3}, {4, 5, 6} };
	int a[rows][columns];
	unsigned long int sum = 0, pro = 1;

	for (int i = 0; i < rows; i++)
	{
		// цикл по ячейкам строки (столбцам)
		for (int k = 0; k < columns; k++)
		{
			a[i][k] = rand() % 9 + 1;
		}
	}

	// цикл по строкам
	for (int i = 0; i < rows; i++)
	{
		// цикл по ячейкам строки (столбцам)
		for (int k = 0; k < columns; k++)
		{
			cout << a[i][k] << " ";
			sum += a[i][k];
			pro *= a[i][k];
		}
		cout << endl;
	}
	cout << endl;
	cout << "Sum = " << sum << endl;
	cout << "Pro = " << pro << endl;*/

	// пользователь вводит массив 3 строки, 4 столбца, программа находит в массиве
	// все нечётные отрицательные числа и копирует их в одномерный массив, который выведет на экран
	/*const int rows = 3;
	const int columns = 4;
	int a[rows][columns];
	int result[rows * columns];

	for (int i = 0; i < rows; i++)
	{
		// цикл по ячейкам строки (столбцам)
		for (int k = 0; k < columns; k++)
		{
			cin >> a[i][k];
		}
	}
	int n = 0;
	// цикл по строкам
	for (int i = 0; i < rows; i++)
	{
		// цикл по ячейкам строки (столбцам)
		for (int k = 0; k < columns; k++)
		{
			cout << a[i][k] << " ";
			if (a[i][k] % 2 == -1)
			{
				result[n] = a[i][k];
				n++;
			}
		}
		cout << endl;
	}
	cout << endl;
	for (int i = 0; i < n; i++)
	{
		cout << result[i] << " ";
	}
	cout << endl;*/

	// программа заполняет массив 5 x 5 случайными числами, программа подсчитывает сумму элементов по периметру
	/*const int rows = 3;
	const int columns = 3;
	int a[rows][columns];
	int sum = 0;

	for (int i = 0; i < rows; i++)
	{
		// цикл по ячейкам строки (столбцам)
		for (int k = 0; k < columns; k++)
		{
			a[i][k] = rand() % 10;
		}
	}
	// цикл по строкам
	for (int i = 0; i < rows; i++)
	{
		// цикл по ячейкам строки (столбцам)
		for (int k = 0; k < columns; k++)
		{
			cout << a[i][k] << " ";
			if (i == 0 || i == rows - 1 || k == 0 || k == columns - 1)
				sum += a[i][k];
		}
		cout << endl;
	}
	cout << endl;
	cout << "Sum = " << sum << endl;*/

	//2. Программа заполняет двумерный массив 4x5 случайными числами в диапазоне [20; 49]
	//После чего программа переворачивает массив на 90 градусов по часовой стрелке(копирует элементы в другой массив)
	//и выводит результат на экран
	// 
	//1 2 3 4 5
	//5 6 7 8 9
	//1 2 3 4 5
	//9 8 7 6 5

	//9 1 5 1
	//8 2 6 2
	//7 3 7 3
	//6 4 8 4
	//5 5 9 5

	/*const int rows = 7;
	const int columns = 3;
	int c[rows][columns];
	int p[columns][rows];
	int a = 20, b = 49;

	for (int i = 0; i < rows; i++)
	{
		for (int k = 0; k < columns; k++)
		{
			c[i][k] = rand() % (b - a + 1) + a;
			cout << c[i][k] << " ";
		}
		cout << endl;
	}
	cout << endl;

	for (int i = 0; i < columns; i++)
	{
		for (int k = 0; k < rows; k++)
		{
			p[i][k] = c[rows - k - 1][i];
			cout << p[i][k] << " ";
		}
		cout << endl;
	}*/

	// Программа заполняет двумерный массив 4x5 случайными числами в диапазоне[-10; 39]
	// и копирует все положительные числа в первый одномерный массив, а отрицальные элементы во второй одномерный массив

	/*
	srand(time(0));
	const int rows = 4;
	const int columns = 5;
	int c[rows][columns], q[rows * columns], p[rows * columns];
	int a = -10, b = 39, n = 0, o = 0;


	for (int i = 0; i < rows; i++)
	{
		for (int k = 0; k < columns; k++)
		{
			c[i][k] = rand() % (b - a + 1) + a;
			cout << c[i][k] << " ";
		}
		cout << endl;
	}
	cout << endl;

	for (int i = 0; i < rows; i++)
	{
		for (int k = 0; k < columns; k++)
		{
			if (c[i][k] > 0)
			{
				q[n] = c[i][k];
				n++;
			}
			if (c[i][k] < 0)
			{
				p[o] = c[i][k];
				o++;
			}
		}
	}
	cout << endl;
	cout << "1:" << endl;
	for (int i = 0; i < n; i++)
	{
		cout << q[i] << " ";
	}

	cout << endl;
	cout << "2:" << endl;
	for (int i = 0; i < o; i++)
	{
		cout << p[i] << " ";
	}*/

	// программа заполняет 2 массива 3x4 случайными числами в диапазоне [10, 30]
	// программа показывает массивы на экран и подсчитывает, сколько в массивах одинаковых
	// чисел и выводит список общих чисел без повторений

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

	int size = 0;
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

	return 0;
}