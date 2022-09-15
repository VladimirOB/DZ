#define _CRT_SECURE_NO_WARNINGS

#include "LinkedList.h"
#include <iostream>

using namespace std;

Element::Element(const char* str, Element* next)
{
	Str = new char[strlen(str) + 1];
	strcpy(Str, str);
	this->next = next;
}

Element::~Element()
{
	delete[] Str;
}

LinkedList::LinkedList()
{
	First = Last = nullptr;
	count = 0;
}

LinkedList::~LinkedList()
{
	Element* current = First;
	while (current != nullptr)
	{
		Element* tmp = current;
	
		// переместить текущий указатель на следующую ячейку списка
		current = current->next;

		delete tmp;
	}
}

void LinkedList::Add(const char* str)
{
	Element* elem = new Element(str, nullptr);

	// если список пустой
	if (First == nullptr)
	{
		First = Last = elem;
	}
	else
	{
		// добавить вновь созданную ячейку списка в конец списка
		Last->next = elem;

		// исправить указатель на последнюю ячейку (переместить в него адрес вновь созданной последней ячейки)
		Last = elem;
	}

	count++;
}

bool LinkedList::Insert(size_t index, const char* str)
{
	// если список пустой
	if (First == nullptr)
	{
		Add(str);
		return true;
	}
	else
	{
		Element* element = new Element(str, nullptr);

		// если вставляется самый первый элемент
		if (index == 0)
		{
			element->next = First;
			First = element;
			count++;
			return true;
		}
		else // вставляется элемент в середину
		{
			// указатель на текущий элемент, перед которым нужно вставить новый элемент
			Element* current = First;

			// указатель на предыдущий элемент, после которого нужно вставить новый элемент
			Element* prev = nullptr;

			// номер текущего элемента
			unsigned current_index = 0;

			// перебрать все элементы списка
			while (current != nullptr)
			{
				// если найден элемент, перед которым нужно вставить новый
				if (index == current_index)
				{
					// привязать новый элемент к предыдущему (prev)
					prev->next = element;

					// привязать новый элемент к последующему (current)
					element->next = current;
					count++;
					return true;
				}

				// текущий элемент становится предыдущим
				prev = current;

				// текущий элемент сдвигается на следующий
				current = current->next;

				// номер текущего элемента увеличить на 1
				current_index++;
			}
			return false;
		}
	}
}

void LinkedList::Print()
{
	Element* current = First;
	while (current != nullptr)
	{
		cout << current->Str << " ";

		// переместить текущий указатель на следующую ячейку списка
		current = current->next;
	}
	cout << endl;
}

size_t LinkedList::GetSize()
{
	return count;
}

char*& LinkedList::operator[](size_t index)
{
	Element* current = First;

	// номер текущего элемента
	unsigned current_index = 0;
	while (current != nullptr)
	{
		if (index == current_index)
		{
			return current->Str;
		}

		// переместить текущий указатель на следующую ячейку списка
		current = current->next;
		current_index++;
	}
	throw std::out_of_range("");
}

ostream& operator<< (ostream& os, LinkedList& lst)
{
	Element* current = lst.First;
	while (current != nullptr)
	{
		os << current->Str << " ";

		// переместить текущий указатель на следующую ячейку списка
		current = current->next;
	}
	os << endl;

	return os;
}