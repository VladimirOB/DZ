#include <iostream>
#include "MyString.h"

using namespace std;

void main()
{
	MyString str("Hello");
	str.Print();

	str.Set("Hello world!!!");
	str.Print();

	str.Set("Hello!!!");
	str.Print();
}