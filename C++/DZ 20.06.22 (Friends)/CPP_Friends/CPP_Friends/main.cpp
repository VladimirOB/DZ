#include <iostream>
#include "Array.h"
#include "Test.h"

using namespace std;

int main()
{
	// запуск обычного конструктора с параметрами
	Array arr(7);
	arr.print();

	Array arr2(7);
	arr2.print();

	Array arr3 = arr + arr2;
	//arr3.print();

	cin >> arr;

	cout << "Array 3:" << endl << arr3 << endl << "Array 1:" << endl << arr << endl;

	/*Array arr5(7);
	Test test(arr5);
	test.Print();
	test.Print2();*/

	return 0;
}