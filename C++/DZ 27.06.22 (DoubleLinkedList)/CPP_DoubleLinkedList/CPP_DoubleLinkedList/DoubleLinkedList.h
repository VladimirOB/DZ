#pragma once

#include <iostream>

using namespace std;

struct Element
{
	char* Str;
	Element* next;
	Element* prev;
public:
	Element(const char* str, Element* prev, Element* next);
	~Element();
};

class DoubleLinkedList
{
	Element* First;
	Element* Last;
	size_t count;
public:
	DoubleLinkedList();
	~DoubleLinkedList();

	void Add(const char* str);
	void Print();
	void PrintBack();
	size_t GetSize();
	bool Insert(size_t index, const char* str);
	bool EqualsReverse(DoubleLinkedList& lst2);

	char*& operator[](size_t index);

	friend ostream& operator<< (ostream& os, DoubleLinkedList& lst);
};

