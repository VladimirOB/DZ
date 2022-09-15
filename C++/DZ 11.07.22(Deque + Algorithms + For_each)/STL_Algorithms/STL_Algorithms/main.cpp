#include <iostream>
#include <vector>
#include <string>
#include <algorithm>
#include <functional>
#include <list>
#include <deque>
#include <iterator>

using namespace std;

void print(int elem)
{
	cout << elem << "  ";
}

void add(int& elem)
{
	elem += 3;
}

int add2(int elem)
{
	elem -= 3;
	return elem;
}

bool even(int elem)
{
	return elem % 2;
}

void main()
{	
	// объявление коллекций
	vector <int> v = { 0, 1, 2, 3, 4, 5, 6, 7, 9 };
	vector <int> v2;
	list <int> l;
	
	for_each(v.begin(), v.end(), print);
	/*v.push_back(9);
	
	// перебор элементов коллекции с целью выполнить какое-либо действие для каждого элемента
	// print будет запущен для каждого элемента
	for_each(v.begin(), v.end(), print);

	cout << endl;

	for_each(v.begin(), v.end(), add);

	for_each(v.begin(), v.end(), [](int n) { cout << n << " "; });

	cout << endl;
	
	// перебрать все элементы и к каждому прибавить 3
	for_each(v.begin(), v.end(), add);

	//for_each(v.begin(), v.end(), [](int& n) { n += 3; });
	
	for_each(v.begin(), v.end(), print);
	cout << endl;
	
	// подсчёт количества элементов
	cout << "count = " << count(v.begin(), v.end(), 8) << endl;
	
	// подсчёт количества элементов, удовлетворяющих условию
	//cout << count_if(v.begin(), v.end(), even) << endl;
	cout << count_if(v.begin(), v.end(), [](int n) { return n % 2; }) << endl;

	// подсчитать элементы, которые меньше 7 (устаревший способ)
	cout << count_if(v.begin(), v.end(), bind2nd(less<int>(), 7)) << endl;
	
	// подсчитать элементы, которые меньше 7
	cout << count_if(v.begin(), v.end(), [](auto const& elem) { return elem < 7; } ) << endl;*/
	
	/*
	// вернуть минимальный и максимальный элементы
	cout << "min: " << *min_element(v.begin(), v.end()) << endl;
	cout << "max: " << *max_element(v.begin(), v.end()) << endl;

	// поиск элемента по значению
	vector <int>::iterator pos;

	// возвращает итератор (указатель на найденный элемент)
	pos = find(v.begin(), v.end(), 5);
	cout << *pos << endl;

	// поиск элементов, которые больше 3 (устаревший)
	//pos = find_if(v.begin(), v.end(), bind2nd(greater<int>(), 3));

	// поиск элементов, которые больше 3
	pos = find_if(v.begin(), v.end(), [](int i) { return i > 3; });
	cout << *pos << endl;

	// поиск ВСЕХ элементов, которые больше 5
	auto it = find_if(begin(v), end(v), [](int i) { return i > 5; });

	// пока не достигнут конец найденных элементов
	while (it != end(v)) {

		// вывести на консоль
		cout << *it << " ";

		// получить указатель на следующий элемент
		it = find_if(next(it), end(v), [](int i) { return i > 5; });
	}
	cout << endl;

	// поиск соседних одинаковых элементов
	pos = adjacent_find(v.begin(), v.end());
	
	// если элементов нет
	if (pos == v.end())
		cout << "no!" << endl;
	else
		cout << "pos: " << distance(v.begin(), pos) << endl;	// вернуть номер первого из повторяющихся элементов														

	// копирование элементов из одной коллекции в другую (с реверсом)
	//copy(v.begin(), v.end(), back_inserter(l));
	copy(v.rbegin(), v.rend(), back_inserter(l));

	for_each(l.begin(), l.end(), print);
	cout << endl;
	*/

	
	// дэк вначале пустой
	/*deque <int> d;

	// добавление в конец
	back_insert_iterator <deque <int>> b_iter(d);
	*b_iter = 3;
	*b_iter = 5;
	*b_iter = 20;

	// добавление в начало
	front_insert_iterator <deque <int>> f_iter(d);
	*f_iter = 7;
	*f_iter = 9;
	*f_iter = 10;

	for_each(d.begin(), d.end(), print);
	cout << endl;
	
	// заполнение 5 двойками в конце
	fill_n(back_inserter(d), 5, 2);

	for_each(d.begin(), d.end(), print);
	cout << endl;
	
	// заполнение единицами содержимого вектора
	fill(d.begin()+1, d.end()-2, 1);

	for_each(d.begin(), d.end(), print);
	cout << endl;

	int a[] = { 1, 2, 3, 4, 5 };
	for (int& n : a)
	{
		n += 3;
	}

	for (int n : a)
	{
		cout << n << " ";
	}
	cout << endl;

	list<int> lst = { 1, 2, 3, 4, 5 };
	for (const int i : lst)
	{
		cout << i << " ";
	}
	cout << endl;

	for (string n : {"hello", "big", "world", "abc", "123456789"})
		cout << n.length() << " ";
	cout << endl;
	*/
}