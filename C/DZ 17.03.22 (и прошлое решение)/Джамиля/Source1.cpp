#include <iostream>
#include<string>
#include <conio.h>

using namespace std;


int main()
{
	// Пользователь вводит строку, программа подсчитывает сумму цифер в строке (арифметика указателей)



	char s[80];
	cin.getline(s, 79);
	char* p = s;
	int sum = 0;
	char k = 0;
	for (; *p;p++)
	{


		if (*p >= '0' && *p <= '9')
		{
			 k =*p;
			int number= atoi(&k);
			
			sum+= number;
		}
		
	}

	/*for (; *p;p++)
	{


		if (*p >= '0' && *p <= '9')
		{
		

			sum += *p-'0';
		}

	}*/

	cout << "SUMM= " << sum << endl;
	return 0;
}