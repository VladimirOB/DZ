#include "ArithmeticalException.h"
#include <iostream>

using namespace std;

ArithmeticalException::ArithmeticalException(const int code, const char* message)
{
	errorCode = code;
	strncpy(this->message, message, 99);

}

void ArithmeticalException::Print()
{
	cout << "ERROR: " << message << ", Code : " << errorCode << endl;
}
