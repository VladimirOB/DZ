#include <iostream>
#include<string>
#include <conio.h>

using namespace std;


int main()
{
	//2. Пользователь вводит строку, программа удаляет из неё все цифры (арифметика указателей)

	

	char s[80];
	cin.getline(s,79);
	char* p = s;

	/*char b[80];
	char* f = b;

	for (; *p; p++)
	{
		if (*p < '0' || *p > '9' ) 
		{
			*f = *p;
			f++;
		}
	}

	*f = 0;

	cout << b << endl;*/


	/*	int i = 0;
	for (; *p;p++)
	{
		
		
		if (*p < '0' || *p > '9')
		{
			s[i] = *p;
			
			cout << s[i];
			i++;
		}
		
	}
	cout << endl;*/
	
	int i = 0;

	for (; *p;p++,i++)
	{


		if (*p >= '0' && *p <= '9')
		{

			s[i] = *(p + 1);
			
			
			i--;
		}
		else
			s[i] = *p;
		
	}
	if (*p == 0)
		s[i] = 0;
	printf("%s",s);
	cout << endl;
		
	return 0;
}


