#include <iostream>
#include "Point.h"

using namespace std;

void test()
{
	// переменная n сохраняет своё значение при выходе из функции
	static int n = 0;

	cout << "n = " << n++ << endl;
}

void main()
{
	/*for (size_t i = 0; i < 5; i++)
	{
		test();
	}*/

	cout << "count = " << Point::GetCount() << endl;

	Point* p = new Point(1, 2);
	p->Print();
	
	cout << "count = " << Point::GetCount() << endl;
	
	Point* p2 = new Point(1, 2);
	(*p2).Print();

	cout << "count = " << Point::GetCount() << endl;

	delete p2;

	cout << "count = " << Point::GetCount() << endl;

	delete p;

	cout << "count = " << Point::GetCount() << endl;
}