#include <iostream>
#include <list>
#include <stdlib.h>
#include <time.h>

using namespace std;

void main()
{
	srand(time(0));

	// создание пустого списка
	list <int> l1;

	// создание списка и помещение в него элемента "3"
	list <int> l2(3);

	// создание списка и помещение в него 3 элементов "9"
	list <int> l3(3, 9);

	cout << "size: " << l3.size() << endl;

	// проверка на пустоту списка
	if (l1.empty())
		cout << " int List empty " << endl;

	// добавление в конец списка
	l3.push_back(1);

	// добавление в начало списка
	l3.push_front(2);

	// вставка элемента в начало списка
	l3.insert(++l3.begin(), 5);

	// вставка 5 элементов в конец списка
	l3.insert(--l3.end(), 5, rand() % 10);

	//l3.sort();

	// создание специального указателя STL на текущий элемент списка для простора
	// от начала до конца
	list<int>::iterator current;

	// перебор всех элементов списка от начала до конца
	for (current = l3.begin(); current != l3.end(); current++)
	{
		cout << *current << endl;
	}

	// создание специального указателя STL на текущий элемент списка для простора
	// от конца в начало
	/*list<int>::reverse_iterator r_current;

	// перебор всех элементов списка от конца в начало
	for (r_current = l3.rbegin(); r_current != l3.rend(); r_current++)
	{
		cout << *r_current << endl;
	}*/

	cout << endl;

}
