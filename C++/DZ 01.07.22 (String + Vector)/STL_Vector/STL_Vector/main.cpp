#include <iostream>
#include <vector>
#include <algorithm>
#include <string>

using namespace std;

void main()
{
	/*vector <int> v;

	// зарезервировать память в массиве под новые значения
	v.reserve(1000);

	// добавление в конец вектора (массива)
	v.push_back(1);
	v.push_back(2);
	v.push_back(3);

	// вставка внутрь вектора
	v.insert(v.begin()+1, 5);
	v.insert(v.end(), 7);

	// просмотр всех элементов вектора
	for (int i = 0; i < v.size(); i++)
	{
		cout << v[i] << " ";
	}
	cout << endl;

	// удаление диапазона элементов
	//v.erase(v.begin() + 1, v.end() - 1);

	// удаление последнего элемента
	//v.pop_back();
	
	// очистка всего вектора и добавление пяти троек
	//v.assign(5, 3);

	// получить зарезервированный размер вектора
	cout << "maximum elements: " << v.capacity() << endl;
	
	// текущее количество элементов
	cout << "amount of elements: "<< v.size() << endl;

	// изменить количество заполненных элементов
	v.resize(10);
	
	// получить зарезервированный размер вектора
	cout << "maximum elements: " << v.capacity() << endl;

	// текущее количество элементов
	cout << "amount of elements: " << v.size() << endl;

	//  получить первый элемент вектора
	//cout << v.front() << endl;

	// получить последний элемент вектора
	//cout << v.back() << endl;

	// обращение к элементу по индексу
	v[0] = 54;

	// просмотр всех элементов вектора
	for (int i = 0; i < v.size(); i++)
	{
		cout << v[i] << endl;
	}*/

	// объявление векторов с резервированием памяти
	/*vector<int> v1(10);
	vector<int> v2(10);

	for (size_t x=0; x < v1.capacity(); x++) v1[x]=10-x;
	for (size_t x=0; x < v1.capacity(); x++) v2[x]=10-x;

	for (size_t x=0; x < v1.size(); x++) cout << v1[x] << " ";
	cout << endl;
	for (size_t x=0; x < v2.size(); x++) cout << v2[x] << " ";
	cout << endl;

	// сортировка векторов
	cout << "___________ SORT _____________" << endl;
	sort(v1.begin(), v1.end());
	sort(v2.begin()+1, v2.end()-1);

	// поменять вектора местами
	swap(v1, v2);
	v1.swap(v2);

	// вывод векторов на экран
	for (unsigned int x=0; x < v1.size(); x++) cout << v1[x] << " ";
	cout << endl;

	for (unsigned int x=0; x < v2.size(); x++) cout << v2[x] << " ";
	cout << endl;*/

	vector <string> vv;

	vv.reserve(1000);
	vv.push_back("abc");
	vv.push_back("123");
	vv.push_back("345");
	vv.insert(vv.begin(),"789");
	vv.insert(vv.end(),"qwe");

	//vv.erase(vv.begin()+1,vv.end()-1);
	//vv.pop_back();
	//vv.assign(5, "3");
	cout << vv.capacity() << endl;
	cout << vv.size() << endl;
	vv.resize(10);

	//cout << vv.front() << endl;
	//cout << vv.back() << endl;

	vv[0] = "hello";
	for(int i=0;i<vv.size();i++)
	{
		cout << vv[i] << endl;
	}
}
