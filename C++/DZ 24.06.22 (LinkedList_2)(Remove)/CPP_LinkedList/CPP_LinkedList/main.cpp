#define _CRT_SECURE_NO_WARNINGS

#include <iostream>
#include "LinkedList.h"

using namespace std;

void main()
{
	LinkedList lst;
	lst.Add("One");
	lst.Add("Two");
	lst.Add("Three");
	lst.Add("end");

	cout << lst << endl;
	cout << "Size of the list: " << lst.GetSize() << endl;

	char* s = new char[40];
	strcpy(s, "Hello");
	lst[2] = s;

	cout << lst[2] << endl;

	cout << lst << endl;
}