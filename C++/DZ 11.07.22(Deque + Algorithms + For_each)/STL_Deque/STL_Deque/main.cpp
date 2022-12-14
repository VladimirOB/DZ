#include <iostream>
#include <deque>
#include <vector>
#include <algorithm>
#include <time.h>

using namespace std;

void main()
{
	/*
	// Deque - double ended queue
	deque <int> v;
	
	// добавление в конец дека
	v.push_back(1);
	v.push_back(2);
	v.push_back(3);

	// добавление в начало дека
	v.push_front(4);

	// удаление из начала дека
	v.pop_front();

	// удаление из конца дека
	v.pop_back();

	// вставка елемента
	v.insert(v.begin(), 5);
	v.insert(v.end(), 7);

	// удаление диапазона элементов
	//v.erase(v.begin()+1,v.end()-1);
	
	// заполнение определённым количеством элементов, с предварительным удалением
	//v.assign(5, 3);

	// текущий размер
	//cout << v.size() << endl;

	// изменение текущего размера
	//v.resize(10);

	// получить первый элемент
	//cout << v.front() << endl;

	// получить последний элемент
	//cout << v.back() << endl;

	// обращение по индексу
	// v[0] = 54;
	// v.at(0) = 99;

	// очистка всех элементов
	// v.clear();

	// проверка на пустоту
	// v.empty();

	// перебор всех елементов
	for (int i = 0; i < v.size(); i++)
	{
		cout << v[i] << endl;
	}

	cout << endl;

	deque <int>::reverse_iterator p;
	for (p = v.rbegin(); p != v.rend(); p++)
	{
		cout << *p << endl;
	}
	*/

	srand(time(0));

	deque <int> v1(10);
	deque <int> v2(10);
	for (int x=0; x < v1.size();x++) v1[x] = rand() % 100;
	for (int x=0; x < v2.size();x++) v2[x] = rand() % 100;
	cout << endl;

	cout << "___________ SORT _____________" << endl;

	// полная сортировка дека
	//sort(v1.begin(),v1.end());

	// частичная сортировка (диапазон элементов)
	sort(v2.begin()+1,v2.end()-1);

	// поменять местами
	//swap(v1,v2);
	v1.swap(v2);

	for (int x=0;x < v1.size();x++) cout << v1[x] << " ";
	cout << endl;

	for (int x=0;x < v2.size();x++) cout << v2[x] << " ";
	cout << endl;
}
