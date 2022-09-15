#include <iostream>
#include <stdarg.h>

using namespace std;

// первый параметр - количество дальнейших параметров
void print(int count, ...)
{
	// объявление указателя для перемещения по стеку с параметрами
	va_list lst;

	// установить указатель на параметры в начало (на первый параметр)
	va_start(lst, count);

	// цикл по списку параметров
	for (size_t i = 0; i < count; i++)
	{
		// получить текущий параметр из стека параметров функции
		int current = va_arg(lst, char);

		cout << current << " ";
	}
	cout << endl;

	// очистка памяти от указателя на стек параметров
	va_end(lst);
}

// первый параметр - это просто значение, признак конца параметров - 0
int sum(int first, ...)
{
	int result = first;

	// объявление указателя для перемещения по стеку с параметрами
	va_list lst;

	// установить указатель на параметры в начало (на первый параметр)
	va_start(lst, first);

	// цикл по списку параметров
	while(true)
	{
		// получить текущий параметр из стека параметров функции
		int current = va_arg(lst, int);

		if (current == 0)
			break;

		result += current;
	}

	// очистка памяти от указателя на стек параметров
	va_end(lst);

	return result;
}

double double_pro(double first, ...)
{
	double result = first;

	// объявление указателя для перемещения по стеку с параметрами
	va_list lst;

	// установить указатель на параметры в начало (на первый параметр)
	va_start(lst, first);

	// цикл по списку параметров
	while (true)
	{
		// получить текущий параметр из стека параметров функции
		double current = va_arg(lst, double);

		if (current == 0)
			break;

		result *= current;
	}

	// очистка памяти от указателя на стек параметров
	va_end(lst);

	return result;
}

void main()
{
	print(3, 1, 2, 3);
	print(5, 9, 8, 7, 6, 5);
	print(0);
	print(2, 1, 2);

	cout << sum(1, 2, 3, 4, 5, 6, 7, 0) << endl;

	// функция с неопределённым количеством параметров принимает числа типа double и подсчитывает их произведение
	cout << double_pro(1.2, 1.2, 2.4, 3.5, 0) << endl;
}