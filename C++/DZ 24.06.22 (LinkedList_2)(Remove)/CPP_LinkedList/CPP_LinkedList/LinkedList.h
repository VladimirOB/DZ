#pragma once

#include <iostream>

using namespace std;

struct Element
{
	char* Str;
	Element* next;
public:
	Element(const char* str, Element* next);
	~Element();
};

class LinkedList
{
	Element* First;
	Element* Last;
	size_t count;
public:
	LinkedList();
	~LinkedList();

	void Add(const char* str);
	void Print();
	size_t GetSize();
	bool Insert(size_t index, const char* str);
	char*& operator[](size_t index);

	friend ostream& operator<< (ostream& os, LinkedList& lst);
};

