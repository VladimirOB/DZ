#pragma once

class Strings
{
	char** Str;
	size_t MaxRows;
	size_t CurrentRows;

public:
	Strings(size_t maxRows);
	Strings(const Strings& source);
	~Strings();

	void Add(const char* str);
	void Remove(size_t index);
	void Print();

	Strings operator+ (Strings& source);
};
