#include <iostream>

using namespace std;

void test()
{
	cout << "world!" << endl;
}

int add(int a, int b)
{
	return a + b;
}

int sum(int* a, size_t size)
{
	int result = 0;
	for (size_t i = 0; i < size; i++)
	{
		result += a[i];
	}
	return result;
}

void str_change(char* s)
{
	for (int i = 0; s[i]!=0 ; i++)
	{
		if (s[i] == 'a')
			s[i] = '!';
	}
}

int calc(char* str)
{
	// Пользователь вводит строку вида 2234 + 455. 
	// Программа подсчитывает результат. Операторы: + - * / %

	enum Operations {
		Plus, Minus, Production, Division, Mod
	};

	enum States {
		WaitForFirstNumber,		// автомат ожидает первое число
		FirstNumber,			// автомат движется по первому числу
		WaitForOperator,		// автомат ожидает оператор
		WaitForNextNumber,		// автомат ожидает второе число
		NextNumber,				// автомат движется по второму числу
		ErrorState, 			// состояние ошибки парсинга
		FinalState  			// состояние окончания парсинга
	};

	States currentState = States::WaitForFirstNumber;

	int resultNumber = 0;
	int nextNumber = 0;
	Operations mainOperator = Operations::Plus;

	for (int i = 0; str[i] != 0; i++)
	{
		switch (currentState)
		{
		case WaitForFirstNumber:
			if (str[i] >= '0' && str[i] <= '9')
			{
				resultNumber = str[i] - 48;
				currentState = States::FirstNumber;
			}
			else if (str[i] != ' ')
			{
				currentState = States::ErrorState;
			}
			break;

		case FirstNumber:
			if (str[i] >= '0' && str[i] <= '9')
			{
				resultNumber = resultNumber * 10 + str[i] - 48;
			}
			else if (str[i] == ' ')
				currentState = States::WaitForOperator;
			else if (str[i] == ' ' || str[i] == '+' || str[i] == '-' || str[i] == '*' || str[i] == '/' || str[i] == '%')
			{
				currentState = States::WaitForOperator;
				i -= 1;
			}
			else
				currentState = States::ErrorState;
			break;

		case WaitForOperator:
			if (str[i] != ' ')
			{
				switch (str[i])
				{
				case '+':
					mainOperator = Plus;
					break;
				case '-':
					mainOperator = Minus;
					break;
				case '*':
					mainOperator = Production;
					break;
				case '/':
					mainOperator = Division;
					break;
				case '%':
					mainOperator = Mod;
					break;
				default:
					currentState = States::ErrorState;
					break;
				}
				if (currentState != States::ErrorState)
					currentState = WaitForNextNumber;
			}

			break;

		case WaitForNextNumber:
			if (str[i] >= '0' && str[i] <= '9')
			{
				nextNumber = str[i] - 48;
				currentState = States::NextNumber;
			}
			else if (str[i] != ' ')
			{
				currentState = States::ErrorState;
			}
			break;

		case NextNumber:
			if (str[i] >= '0' && str[i] <= '9')
			{
				nextNumber = nextNumber * 10 + str[i] - 48;
			}
			else if (str[i] == ' ' || str[i] == '+' || str[i] == '-' || str[i] == '*' || str[i] == '/' || str[i] == '%')
			{
				switch (mainOperator)
				{
				case Plus:
					resultNumber += nextNumber;
					break;
				case Minus:
					resultNumber -= nextNumber;
					break;
				case Production:
					resultNumber *= nextNumber;
					break;
				case Division:
					resultNumber /= nextNumber;
					break;
				case Mod:
					resultNumber %= nextNumber;
					break;
				}
				currentState = States::WaitForOperator;
				if (str[i] != ' ')
					i -= 1;
			}
			else currentState = States::ErrorState;
			break;
		}

		if (currentState == ErrorState)
			break;
	}

	if (currentState == NextNumber)
	{
		switch (mainOperator)
		{
		case Plus:
			resultNumber += nextNumber;
			break;
		case Minus:
			resultNumber -= nextNumber;
			break;
		case Production:
			resultNumber *= nextNumber;
			break;
		case Division:
			resultNumber /= nextNumber;
			break;
		case Mod:
			resultNumber %= nextNumber;
			break;
		}
	}

	if (currentState != ErrorState && currentState != WaitForNextNumber)
		return resultNumber;
	else
		throw 1;
}

void f(int n)
{
	cout << n << endl;
	if(n < 3)
		f(n+1);

	cout << "end" << endl;
}

void f2(int n)
{
	cout << n << endl;
	if (n > 1)
		f2(n-1);
}

void f3(int a, int b)
{
	cout << a << endl;
	if (a < b)
		f3(a + 1, b);
}

void str_add(char* s, char* s2)
{
	/*size_t len = strlen(s);
	int i = 0;
	for (; s2[i]!=0; i++)
	{
		s[i+len] = s2[i];
	}
	s[i + len] = 0;*/

	strcat(s, s2);
}

void gl_replace2(char* s, int pos)
{
	if (s[pos] == 'a' || s[pos] == 'e' || s[pos] == 'y' || s[pos] == 'i' || s[pos] == 'o' || s[pos] == 'u')
		s[pos] = '!';

	if (s[pos] != 0)
		gl_replace2(s, pos + 1);
}

void gl_replace(char* s)
{
	gl_replace2(s, 0);
}

int calc_sum(int* arr, size_t size, int pos)
{
	int result = arr[pos];

	if (pos < size)
	{
		int res = calc_sum(arr, size, pos + 1);
		result += res;
	}
	else return 0;
		

	return result;
}

int str_cmp(char* s, char* s2, int pos)
{
	int result = 1;

	if (s[pos] != s2[pos])
		return 0;

	if (s[pos] != 0 || s2[pos] != 0)
		result *= str_cmp(s, s2, pos + 1);

	return result;
}

int calc_str(char* s, int pos)
{
	int result = 0;

	if (s[pos] >= '1' && s[pos] <= '9')
		result = s[pos] - '0';

	if (s[pos] != 0)
	{
		int res = calc_str(s, pos + 1);
		result += res;
	}

	return result;
}

void main()
{
	/*int a, b;
	cin >> a >> b;
	cout << endl;
	f3(a, b);*/

	/*cout << "Hello " << endl;

	cout << "Result = " << add(3, 5) << endl;

	int b[] = { 1, 2, 3, 4, 5 };
	cout << "Sum = " << sum(b, 5) << endl;

	char str[80] = "Karabas-Barabas";
	cout << str << endl;
	str_change(str);
	cout << str << endl;
	*/

	/*char str[400];

	cout << "Enter a string:" << endl;
	cin.getline(str, 399);

	try {
		int result = calc(str);
		cout << "Result = " << result << endl;
	}
	catch (int ex)
	{
		cout << "Error in expression!" << endl;
	}*/

	// Написать функцию, которая принимает 2 строки и добавляет вторую строку в конец первой
	/*char s[40], s2[40];
	cin >> s >> s2;
	str_add(s, s2);

	cout << s << endl;*/

	// Рекурсивная функция принимает строку и заменяет все гласные буквы на '!'
	/*char str[40];
	cin.getline(str, 39);
	gl_replace(str);
	cout << str << endl;*/

	// Рекурсивная функция принимает массив чисел и его размер и возвращает сумму всех чисел (return)
	//int arr[2] = { 1, 2 };
	//cout << "Sum = " << calc_sum(arr, 2, 0) << endl;

	// Рекурсивная функция принимает 2 строки и возвращает true, если они равны и false, иначе
	/*char s[40], s2[40];
	cin >> s >> s2;

	cout << str_cmp(s, s2, 0) << endl;*/

	// Рекурсивная функция принимает строку и подсчитывает сумму цифер в строке
	char s[40];
	cin >> s;

	cout << calc_str(s, 0) << endl;
}

