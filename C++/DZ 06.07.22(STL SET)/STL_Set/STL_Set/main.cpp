#include <iostream>
#include <set>
#include <unordered_set>
#include <algorithm>
#include <vector>
#include <iterator>

using namespace std;

void main()
{
	// указатель на элемент во множестве
	set <int>::iterator pos;

	// объявление множества
	set <int> s;
	
	// объявление мульти-множества
	//multiset <int> s;
	
	// добавление элементов во множество
	s.insert(3);
	s.insert(5);
	s.insert(1);
	s.insert(2);
	s.insert(2);
	s.insert(2);
	s.insert(2);
	s.insert(2);
	s.insert(2);
	s.insert(7);
	s.insert(9);

	// удаление по указателю
	//s.erase(s.begin());

	// удаление по значению
	//s.erase(2);

	// поиск во множестве (проверка на вхождение во множество)
	pos = s.find(33);
	if (pos != s.end())
		cout << "Element: " << *pos << endl;
	else cout << "Element not found!" << endl;

	// получить предыдущий элемент
	//cout << *s.lower_bound(3) << endl;

	// получить последующий элемент
	//cout << *s.upper_bound(3) << endl;

	// проверка на пустоту
	//cout << s.empty() << endl;

	// получить количество элементов
	//cout << s.size() << endl;

	// получить максимальный размер множества
	//cout << s.max_size() << endl;

	// количество входжений элемента
	cout << "count: " << s.count(2) << endl;
	
	set <int>::iterator p;
	//multiset <int>::iterator p;
	
	// получить все элементы множества
	for(p = s.begin(); p!=s.end(); p++)
	{
		cout << *p << endl;
	}
	
	// перечение множеств
	set <int> s2;
	s2.insert(3);
	s2.insert(5);
	s2.insert(50);

	set<int> s3;

	// перечение множеств
	//set_intersection(s.begin(), s.end(), s2.begin(), s2.end(),
	//	std::inserter(s3, s3.begin()));

	// разница множеств
	//set_difference(s.begin(), s.end(), s2.begin(), s2.end(),
	//	inserter(s3, s3.begin()));

	// объединение множеств
	set_union(s.begin(), s.end(), s2.begin(), s2.end(),
		std::inserter(s3, s3.begin()));

	set <int>::iterator p2;

	cout << "---------" << endl;
	// получить все элементы множества
	for (p2 = s3.begin(); p2 != s3.end(); p2++)
	{
		cout << *p2 << endl;
	}

	/*
	// объявление множества
	unordered_set <string> str_set;

	// добавление элементов во множество
	str_set.insert("Second");
	str_set.insert("First");
	str_set.insert("Third");
	str_set.insert("One");
	str_set.insert("One");
	str_set.insert("Begin");
	str_set.insert("End");
	str_set.insert("Hello");

	unordered_set <string>::iterator p3;

	cout << "---------" << endl;
	// получить все элементы множества
	for (p3 = str_set.begin(); p3 != str_set.end(); p3++)
	{
		cout << *p3 << endl;
	}
	*/
}
