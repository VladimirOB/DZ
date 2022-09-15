#pragma once

#define _CRT_SECURE_NO_WARNINGS

#include <iostream>
#include <list>

using namespace std;

// класс вершины графа
class Vertex
{
	friend class Graph;
	friend class Link;

	// название вершины
	string title;

	// номер вершины
	unsigned int id;

	// вес вершины графа
	int weight;

	// рёбра, подходящие к данной вершине
	list<Link*> links;

	// удаление ребра ТОЛЬКО у данной вершины
	bool RemoveLink(unsigned int linkId);

	// метка вершины, нужна для работы алгоритмов поиска (волновой и Дейкстры)
	int label;

	// минимальное расстояние до вершины в алгоритме Дейкстры
	unsigned int distance;

	// предыдущая вершина при движении по кратчайшему пути в алгоритме Дейкстры
	Vertex* prev;
public:
	Vertex(unsigned int id, const string title, int weight);
	~Vertex();

	// получить название вершины
	string GetTitle();

	// получить ключ вершины
	unsigned int GetId();

	// возвращает количество входящих рёбер
	unsigned int GetLinksCount();

	void Print();
};

