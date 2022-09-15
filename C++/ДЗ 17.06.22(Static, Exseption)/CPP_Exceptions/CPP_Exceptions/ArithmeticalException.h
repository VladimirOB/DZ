#pragma once
class ArithmeticalException
{
	int errorCode;
	char message[100];
public:
	ArithmeticalException(const int code, const char* message);
	void Print();
};

