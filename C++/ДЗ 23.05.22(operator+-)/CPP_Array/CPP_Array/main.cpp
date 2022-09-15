#define _CRT_SECURE_NO_WARNINGS
#include <iostream>
#include "Array.h"

using namespace std;

void test(int b)
{
	b = 5;
}

void test2(int* p)
{
	*p = 5;
}

void test3(int& b)
{
	b = 5;
}

int& func(int& a)
{
	int temp = 9;
	return a;
}

void main()
{
	int a = 3;

	// возможности ссылок
	/*cout << a << endl;
	test3(a);
	cout << a << endl;
	func(a) = 57;
	cout << a << endl;*/

	// объявление указателя
	/*int* p;
	p = &a;
	cout << *p << endl;
	cout << p << endl;
	cout << &p << endl << endl;

	// объявление ссылки
	int& b = a;
	cout << &a << endl;
	cout << &b << endl;*/

	int Size = 10;

	int* Arr = new int [Size] {1, 2, 3, 4, 5};

	Array arr(Arr, Size);

	
	// вызов конструктора копирования
	Array arr2 = arr;

	/*arr.Print();

	Array arr3;
	arr3.Print();

	arr3 = arr;

	arr3.Print();

	arr3[1] = 33;
	cout << arr3[1] << endl;
	*/

	arr2 = arr + 3;

	arr.Print();
	arr2.Print();

	/*arr();

	arr.Print();

	if (arr == 12)
	{
		cout << "Yes!!!" << endl;
	}
	else
	{
		cout << "No!!!" << endl;
	}*/

	//cout << arr[1] << endl;

	// вызов конструктора копирования
	//Array arr2 = arr;

	//Array arr2(arr);
 	
	/*arr.Print();
	 
	cout << " Enter position to show element:";
	int pos = 0;
	cin >> pos;	
	cout << arr.Get(pos) << endl;
	
	cout << " Enter path to save:";
	char savePath[50];
	cin >> savePath;
	arr.SaveToFile(savePath);
	
	cout << " Enter path to load:";
	char loadPath[50];
	cin >> loadPath;
	arr.LoadFromFile(loadPath);*/

	//arr.Print();
	//arr2.Print();
}