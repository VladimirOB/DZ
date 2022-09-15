#include <iostream>
#include "MyVector.h"

using namespace std;

// объявление шаблонной функции
template <typename T> T add(T a, T b, T c)
{
	return a + b + c;
}

template <typename T> void minmax(T* a, size_t size, T& min, T& max)
{

}

int main()
{
	// вызов шаблонных функций
	/*cout << add(1, 2, 3) << endl;
	cout << add(1.1, 2.3, 3.5) << endl;
	cout << add('2', '1', (char)0) << endl;*/

	// создание экземпляров шаблонных классов
	MyVector<int, 5> vector;
	vector[1] = -1;
	vector.Print();
	cout << "Sum = " << vector.Sum() << endl;

	MyVector<float, 7> vector2;
	vector2.Print();
	cout << "Sum = " << vector2.Sum() << endl;

	MyVector<char, 7> vector3;
	vector3.Print();
	cout << "Sum = " << vector3.Sum() << endl;

	/*MyVector<char*, 7> vector4;
	vector4.Print();
	cout << "Sum = " << vector4.Sum() << endl;*/

	return 0;
}