#include <iostream>
#include <conio.h>

using namespace std;

int main()
{
	/*int code;
	do
	{
		char ch;
		ch = _getch();
		code = ch;
		cout << ch << " - " << code << endl;
	} while (code != 27);*/

	/*char str[40] = {'H', 'e', 'l', 'l', 'o', 0};
	str[0] = 'H';
	str[1] = 'i';
	str[2] = '!';
	str[3] = 0;*/

	/*char str[40] = "Hello";
	strcpy_s(str, "abc");

	cin.getline(str, 39);

	cout << str << endl;*/

	// подсчёт количества букв 'a'
	/*char str[40];
	cin.getline(str, 39);

	int count = 0;
	for (size_t i = 0; str[i]!=0; i++)
	{
		if (str[i] == 'a')
			count++;
		cout << str[i] << endl;
	}
	cout << endl << "Count = " << count << endl;*/

	// пользователь вводит строку, программа определяет, является ли она целым положительным числом
	char str[40];
	cin.getline(str, 39);

	int count = 0, digits = 0;
	for (size_t i = 0; str[i] != 0; i++)
	{
		if (str[i] >= '0' && str[i] <= '9')
			digits++;
		count++;
	}
	if (digits == count)
		cout << "Yes!!!" << endl;
	else cout << "No" << endl;

	return 0;
}