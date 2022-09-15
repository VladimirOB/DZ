#pragma once
#include "Figure.h"

class Document
{
	Figure** figures;
	size_t MaxSize;
	size_t CurrentSize;
public:
	Document(size_t size);
	~Document();

	bool Add(Figure* figure);
	void Print();
	double GetS();
};

