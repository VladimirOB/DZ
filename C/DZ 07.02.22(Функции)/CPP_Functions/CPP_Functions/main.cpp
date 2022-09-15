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

void main()
{
	cout << "Hello " << endl;

	cout << "Result = " << add(3, 5) << endl;

	int b[] = { 1, 2, 3, 4, 5 };
	cout << "Sum = " << sum(b, 5) << endl;

	char str[80] = "Karabas-Barabas";
	cout << str << endl;
	str_change(str);
	cout << str << endl;
}

