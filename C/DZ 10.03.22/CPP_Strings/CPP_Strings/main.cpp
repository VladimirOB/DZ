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
	/*char str[400];
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
	}*/

	// Пользователь вводит строку вида 2234 + 455. 
	// Программа подсчитывает результат. Операторы: + - * / %

	/*enum Operations {
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

	char str[400];

	cout << "Enter a string:" << endl;
	cin.getline(str, 399);

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
					resultNumber = resultNumber*10 + str[i] - 48;
				}
				else if (str[i] == ' ')
					currentState = States::WaitForOperator;
				else if (str[i] == ' ' || str[i] == '+' || str[i] == '-' || str[i] == '*' || str[i] == '/' || str[i] == '%')
				{
					currentState = States::WaitForOperator;
					i -= 1;
				} else
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
					if(currentState != States::ErrorState)
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
		cout << "Result = " << resultNumber << endl;
	else
		cout << "Error in expresion!" << endl;*/

	//char s[80];
	//cin.getline(s, 79);

	/*for (size_t i = 0; i < strlen(s); i++)
	{
		cout << s[i] << endl;
	}*/

	/*for (size_t i = 0; s[i] != 0; i++)
	{
		cout << s[i] << endl;
	}*/

	// просмотр и вывод строки при помощи арифметики указателей
	/*for (char* p = s; *p; p++)
	{
		//printf("%p\n", p);
		cout << *p << endl;
	}*/

	// p[i] ~ *(p+i)

	// используя арифметику указателей вывести строку в обратном порядке
	/*char* p;
	for (p = s; *p; p++);

	for (; p>=s; p--)
		cout << *p << endl;*/

	/*int len = strlen(s);
	for (char* p = s+len-1; p >= s; p--)
		cout << *p << endl;*/

	// пользователь вводит строку, программа копирует все гласные буквы в другую строку и выводит результат
	char s[80];
	cin >> s;

	char b[80];
	char* p = s;
	char* f = b;

	for (; *p; p++) {
		if (*p == 'a' || *p == 'o' || *p == 'i' || *p == 'u' || *p == 'y' || *p == 'e') {
			*f = *p;
			f++;
		}
	}

	*f = 0;

	cout << b << endl;
	

	return 0;
}