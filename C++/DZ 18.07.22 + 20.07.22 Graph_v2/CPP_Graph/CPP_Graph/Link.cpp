#include "Link.h"

Link::Link(unsigned int id, const string _title, int weight, Vertex* from, Vertex* to)
{
	this->id = id;
	this->weight = weight;
	this->from = from;
	this->to = to;
	this->title = _title;
}

Link::~Link()
{
	// удалить указатели на удаляемое ребро в смежных вершинах
	from->RemoveLink(id);
	to->RemoveLink(id);
}

// возвратить Id ребра
unsigned int Link::GetId()
{
	return this->id;
}

string Link::GetTitle()
{
	return title;
}

void Link::Print()
{
	cout << "LINK: " << title << ", From: " << from->GetTitle() << ", To: " << to->GetTitle() << endl;
}