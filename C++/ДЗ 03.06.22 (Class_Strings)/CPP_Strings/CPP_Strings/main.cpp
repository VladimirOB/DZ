#include <iostream>
#include "Strings.h"

using namespace std;

void main()
{
	Strings str(2);
	str.Add("Hello");
	str.Add("world");
	str.Add("!!!");
	str.Remove(1);
	str.Print();

	Strings str2 = str;
	str2.Print();

	Strings str3 = str + str2;
	str3.Print();
}