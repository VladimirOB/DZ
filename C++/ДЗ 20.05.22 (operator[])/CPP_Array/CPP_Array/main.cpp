#define _CRT_SECURE_NO_WARNINGS
#include <iostream>
#include "Array.h"

using namespace std;

void main()
{
	int Size = 10;

	int* Arr = new int [Size] {1, 2, 3, 4, 5};

	Array arr(Arr, Size);

	// вызов конструктора копирования
	Array arr2 = arr;

	arr();

	arr.Print();

	if (arr == 12)
	{
		cout << "Yes!!!" << endl;
	}
	else
	{
		cout << "No!!!" << endl;
	}

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