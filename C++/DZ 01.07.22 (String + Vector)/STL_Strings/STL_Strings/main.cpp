#include <iostream>
#include <string>
#include <vector>

using namespace std;

void main()
{
	// создание объектов класса string на основе строк языка C
	string s1 = "Hello " + string("world");
	string s2 = "abcd";

	// вывод в поток
	cout << s1 << endl;

	// чтение последнего символа строки
	char ch = s1[s1.length() - 1];

	// замены символов с 6 по 10 на "!!!"
	s1.replace(6, 10, "!!!");

	// добавление строки s2 в конец строки s1
	s1.append(s2);
	s1.append("...");

	cout << s1 << endl;

	cout << ch << endl;

	// выход за границы строки (exception)
	//cout << s1[100] << endl;

	// считать символ по индексу (аналог operator[])
	//cout << s1.at(0) << endl;

	// возвратить индекс первого вхождения подстроки
	cout << s1.find_first_of("l") << endl;

	int pos = s1.find_first_of("z");
	if(pos == -1)
		cout << "Substring not found" << endl;

	// возвратить индекс последнего вхождения подстроки
	cout << s1.find_last_of("l") << endl;

	// возвратить индекс первого вхождения подстроки отличной от заданной
	cout << s1.find_first_not_of("l") << endl;

	// удаление части строки через указатели
	//s1.erase(s1.begin()+3, s1.end()-2);

	// удаление части строки по индексам
	//s1.erase(3, 5);

	//cout << s1 << endl;

	// сравнение строк
	if(s1!=s2)
		cout << "String: " << s1 << " is not equal to string: " << s2 << endl;

	// получение из объекта string строки языка C
	char s[40];
	strcpy(s, s1.c_str());
	cout << s << endl;

	// -----------------------------------------------------------------------

	// Пользователь вводит строки, пока не напишет слово exit.
	// Программа объединяет все введенные строки в одну, слово exit не входит в результат
	string str;
	string tmp;
	while (true)
	{
		cin >> tmp;
		if (tmp == "exit")
			break;
		str += tmp;
	}
	cout << str << endl;
}