#include <iostream>
#include <map>
#include <unordered_map>
#include <string>
#include <windows.h>
#include <vector>

using namespace std;

class Person
{
public:
	string Name;
	string LastName;
};

struct StrComparator {
	bool operator()(const std::string& a, const std::string& b) const {

		//cout << "Comparator. " << "Key1: " << a << ", Key2: " << b << endl;

		if (a.compare(b) > 0)
			return true;

		if (a.compare(b) < 0)
			return false;

		//return a.size() > b.size();
	}
};

void main()
{
	SetConsoleOutputCP(1251);

	// map - словарь основанный на дереве поиска, позволяет быстро найти по ключу и сортирует по ключу
	typedef map <string, double> MyMap;

	// словарь для хранения строки в качестве ключа и числа с плавающей запятой в качестве значения
	map <string, double, StrComparator> m;
	//MyMap m;

	// добавление значений через operator[]
	m["Alex"] = 23.8;
	m["Ivan"] = 34.9;
	m["Nikolay"] = 25.8;
	m["Lena"] = 50.9;
	m["Boris"] = 33.8;
	m["Inna"] = 32.9;
	m["Sveta"] = 20;

	// если ключ уже существует, то произойдёт замена значения
	m["Sveta"] = 40;

	// добавление пары "ключ-значение" при помощи метода insert
	// если ключ уже существует, то ничего не произойдёт
	m.insert(make_pair("Sveta", 38));

	// количество вхождений ключа "Boris"
	cout << m.count("Boris") << endl;

	// проверка вхлждения и поиск значения осуществляется максимально быстро
	if (m.find("Lena") != m.end())
		cout << m["Lena"] << endl;

	// удаление из словаря (дерево поиска)
	//m.erase("Boris");

	// просмотр всех элементов словаря
	//MyMap::iterator pos;
	map <string, double>::iterator pos;

	// поле first - ключ
	// поле second - значение хранимой пары
	for(pos = m.begin(); pos!=m.end(); pos++)
	{
		pos->second*=2;
		cout << pos->first << " -> " << pos->second << endl;
	}
	
	// map - словарь основанный на дереве поиска, 
	// позволяет быстро найти по ключу и сортирует по ключу, допускает повторение ключей
	/*typedef multimap <string, string, StrComparator> MyDict;

	MyDict dict;

	// dict["Car"] = "машина"; // недопустимая операция для класса multimap

	// обчное добавление новых значений в словарь
	dict.insert(make_pair("Car", "машина"));
	dict.insert(make_pair("Automobile", "машина"));
	dict.insert(make_pair("Can", "банка"));
	dict.insert(make_pair("Cat", "кошка"));
	dict.insert(make_pair("Cat", "кот"));

	// поиск по ключу одного вхождения
	MyDict::iterator find_pos = dict.find("Car");

	if (dict.find("Car") != dict.end())
		cout << "find: " << find_pos->second << endl;

	// поиск по ключу всех вхождений ключа
	cout << "\nAll elements with key 'Cat': " << endl;

	// поиск указателя на первый элемент, соответсвующий ключу
	MyDict::iterator itlow = dict.lower_bound("Cat");

	// поиск указателя на последний элемент, соответсвующий ключу
	MyDict::iterator ithi = dict.upper_bound("Cat");

	// перебор в цикле всех элементов, соответствующих ключу
	for (MyDict::iterator it = itlow; it != ithi; ++it)
		std::cout << (*it).first << " => " << (*it).second << '\n';

	cout << "--------" << endl << endl;

	// перебор всех входящих пар ключ/значение
	MyDict::iterator pos;
	for (pos = dict.begin(); pos != dict.end(); pos++)
	{
		cout << pos->first << " -> " << pos->second << endl;
	}

	cout << "--------------" << endl;

	// поиск по значению (медленный)
	for (pos = dict.begin(); pos != dict.end(); pos++)
	{
		if (pos->second == "машина")
			cout << pos->first << " -> " << pos->second << endl;
	}
	*/
	
	// словарь, основанный на хэш-таблице, 
	// позволяет максимально быстро (быстрее map) найти по ключу, без сортировки
	/*
	typedef unordered_map <string, double> MyUnorderedMap;

	// словарь для хранения строки в качестве ключа и числа с плавающей запятой в качестве значения
	MyUnorderedMap m;

	// добавление значений через operator[]
	m["Alex"] = 23.8;
	m["Ivan"] = 34.9;
	m["Nikolay"] = 25.8;
	m["Lena"] = 50.9;
	m["Boris"] = 33.8;
	m["Inna"] = 32.9;
	m["Sveta"] = 20;

	// если ключ уже существует, то произойдёт замена значения
	m["Sveta"] = 40;

	// добавление пары "ключ-значение" при помощи метода insert
	// если ключ уже существует, то ничего не произойдёт
	m.insert(make_pair("Sveta", 38));

	// количество вхождений ключа "Boris"
	cout << m.count("Boris") << endl;

	// проверка вхлждения и поиск значения осуществляется максимально быстро
	if (m.find("Lena") != m.end())
		cout << m["Lena"] << endl;

	// удаление из словаря (хэш-таблица)
	m.erase("Boris");

	// просмотр всех элементов словаря
	MyUnorderedMap::iterator pos2;

	// поле first - ключ
	// поле second - значение хранимой пары
	for (pos2 = m.begin(); pos2 != m.end(); pos2++)
	{
		pos2->second *= 2;
		cout << pos2->first << " -> " << pos2->second << endl;
	}
	*/
	//typedef unordered_map <string, vector<vector<int>>> MyUnorderedMap2;

	/*typedef unordered_map <string, Person*> MyUnorderedMap3;

	MyUnorderedMap3 m2;
	m2["Alex"] = new Person();*/
}
