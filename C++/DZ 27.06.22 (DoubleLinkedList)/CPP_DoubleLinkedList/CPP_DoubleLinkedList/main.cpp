#define _CRT_SECURE_NO_WARNINGS

#include <iostream>
#include "DoubleLinkedList.h"

using namespace std;

void main()
{
	DoubleLinkedList lst;
	lst.Add("One");
	lst.Add("Two");

	cout << lst << endl;
	lst.PrintBack();

	DoubleLinkedList lst2;
	lst2.Add("Two");
	lst2.Add("One");

	cout << lst.EqualsReverse(lst2) << endl;
}