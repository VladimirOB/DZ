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
	/*char str[40];
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
	else cout << "No" << endl;*/

	// пользователь вводит строку, программа подсчитывает количество слов

	/*char str[400];
	cout << "Enter a string:" << endl;
	cin.getline(str, 399);

	bool is_word_found = false;
	int count = 0;
	for (int i = 0; str[i]!=0; i++)
	{
		switch (is_word_found)
		{
			// движемся по слову
			case true:
				if (str[i] == ' ')
				{
					i--;
					is_word_found = false;
				}
				break;
			// движемся по разделителям (по пробелам)
			case false:
				if (str[i] != ' ')
				{
					count++;
					i--;
					is_word_found = true;
				}
				break;
		}
	}
	cout << "Number of words: " << count << endl;*/

	// пользователь вводит строку, программа копирует слова в мапссив слов
	char str[400];
	char words[200][400];

	cout << "Enter a string:" << endl;
	cin.getline(str, 399);

	bool is_word_found = false;

	// количество слов и номер текущего слова
	int words_number = 0;

	// номер текущей буквы в текущем слове
	int letters_number = 0;

	for (int i = 0; str[i] != 0; i++)
	{
		switch (is_word_found)
		{
			// движемся по слову
		case true:
			if (str[i] == ' ') // найден разделитель
			{
				i--;

				// закончить текущее слово 0
				words[words_number][letters_number++] = 0;
				letters_number = 0;

				is_word_found = false;
				words_number++;
			}
			else // найден обычный символ
			{
				words[words_number][letters_number++] = str[i];
			}
			break;
			// движемся по разделителям (по пробелам)
		case false:
			if (str[i] != ' ')
			{
				i--;
				is_word_found = true;
			}
			break;
		}
	}
	// если в конце строки стоит не разделитель (пробел)
	if (str[strlen(str) - 1] != ' ')
	{
		// закончить последнее слово нулём
		words[words_number][letters_number++] = 0;

		// увеличить количество слов на 1
		words_number++;
	}
		
	cout << "Number of words: " << words_number << endl;

	for (int i = 0; i < words_number; i++)
	{
		cout << words[i] << endl;
	}

	return 0;
}