#define _CRT_SECURE_NO_WARNINGS
#include <iostream>
#include "Array.h"

using namespace std;


void main()
{
	int Size = 0;
	cout << "Enter array size: ";
	cin >> Size;
	int* Arr=new int [Size];

	cout << "Enter array ellements:\n ";
	for (size_t i = 0; i < Size; i++)
	{
		cin >> Arr[i];
	}

	Array arr2;

	Array arr(Arr, Size);
 	
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

	arr.Print();
	arr2.Print();

	cout << &arr << endl;
	cout << &arr2 << endl;

}