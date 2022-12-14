#define _CRT_SECURE_NO_WARNINGS

#include <iostream>

using namespace std;

void main()
{
	// выделение памяти под 1 значение типа int
	/*int* p = (int*)malloc(sizeof(int));
	cin >> *p;
	cout << p << endl;
	cout << *p << endl;

	// освобождение памяти средствами языка C
	free(p);*/

	// выделение памяти под массив типа int

	/*int arr_size = 5;

	cout << "Enter size of array: ";
	cin >> arr_size;

	unsigned int* a = (unsigned int*)malloc(arr_size * sizeof(unsigned int));

	for (size_t i = 0; i < arr_size; i++)
	{
		cin >> a[i];
	}

	//char* str = (char*)a;
	//strcpy(str, "Hello big world!!!");

	for (size_t i = 0; i < arr_size; i++)
	{
		cout << a[i] << " ";
	}
	cout << endl;

	// освобождение памяти средствами языка C
	free(a);*/

	const int rows = 5;
	const int cols = 4;
	int a[rows][cols] = { {1, 2, 3, 4}, {5, 6, 7, 8}, {9, 0, 1, 2} };

	for (size_t i = 0; i < rows; i++)
	{
		for (size_t k = 0; k < cols; k++)
		{
			cout << a[i][k] << " ";
		}
		cout << endl;
	}

	int* p = (int*) a;
	for (size_t i = 0; i < rows*cols; i++)
	{
		cout << p[i] << " ";
	}
	cout << endl;
}