#pragma once

class MyString
{
	//поля класса
	char* String;
	unsigned int MaxSize;

public:
	MyString();
	MyString(const char* string);
	MyString(const MyString& str2);
	~MyString();

	void Set(const char* string);
	char* GetString();
	int GetSize();
	void Print();
	long GetVowelsCount();
	void ToUper();
	void ToLower();
	void RemoveDigits();
};
