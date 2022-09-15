#include "calc.h"

int calc(char* str)
{
	// Пользователь вводит строку вида 2234 + 455. 
	// Программа подсчитывает результат. Операторы: + - * / %

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