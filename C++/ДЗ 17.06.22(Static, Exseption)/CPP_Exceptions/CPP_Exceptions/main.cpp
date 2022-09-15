#include <iostream>
#include "ArithmeticalException.h"

using namespace std;

double division2(double a, double b)
{
	return a / b;
}

double division(double a, double b, int& errorCode)
{
	errorCode = 0;
	if (b == 0)
	{
		errorCode = 1;
		return 0;
	}

	return a / b;
}

double division(double a, double b)
{
	if (b == 0) {
		//throw 1.1;
		throw new ArithmeticalException(1, "Division by zero!");
		//throw exception("Division by zero!");
	}
		

	return a / b;
}

void main()
{
	/*double d = division2(3, 0);
	if(d != INFINITY)
		cout << ++d << endl;
	*/

	try
	{
		double res = division(3, 0);
		cout << "Result: " << res << endl;
	}
	catch (ArithmeticalException* ex)
	{
		ex->Print();
		delete ex;
	}
	catch (int error_code)
	{
		cout << "Error code: " << error_code << endl;
	}
	catch (exception& ex)
	{
		cout << ex.what() << endl;
	}
	catch (...)
	{
		cout << "Unknown error!!!" << endl;
	}

	/*int errorCode = 0;
	double res = division(3, 0, errorCode);

	switch (errorCode)
	{
		case 0:
		{
			cout << res << endl;
			break;
		}
		case 1:
		{
			cout << "Devision by zero!" << endl;
			break;
		}
		default:
			cout << "Unknown error!!!" << endl;
	}*/
}