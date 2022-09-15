#include <iostream>
#include "MyString.h"

using namespace std;

void test(MyString str)
{
	str.Print();
}

MyString test2()
{
	MyString tmp("Test");
	return tmp;
}

void main()
{
	//MyString str("Hello");
	//str.Print();

	// вызов конструктора копирования при создании объекта класса
	//MyString str2 = str;
	//str2.Print();

	// вызов конструктора копирования при передачу в функцию по значению
	//test(str);

	// передача объекта из функции по значению
	test2().Print();
}