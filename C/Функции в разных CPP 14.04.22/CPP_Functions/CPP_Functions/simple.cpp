#include <iostream>

using namespace std;

int add(int a, int b)
{
	return a + b;
}

void test()
{
	cout << "world!" << endl;
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
	for (int i = 0; s[i] != 0; i++)
	{
		if (s[i] == 'a')
			s[i] = '!';
	}
}