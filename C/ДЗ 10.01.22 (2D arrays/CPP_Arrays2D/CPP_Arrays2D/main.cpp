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
	const int rows = 3;
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
	cout << "Sum = " << sum << endl;

	return 0;
}