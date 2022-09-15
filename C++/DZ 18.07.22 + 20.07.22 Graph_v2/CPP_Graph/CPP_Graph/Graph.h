#pragma once

#include "Vertex.h"
#include "Link.h"
#include <unordered_map>
#include <string>

class Graph
{
	// название графа
	string title;

	// номер следующей вершины, которая будет создана
	unsigned int vertexId = 0;

	// количество вершин графа
	unsigned int vertexCount = 0;

	// номер следующего ребра, который будет создан
	unsigned int linkId = 0;

	// количество рёбер графа
	unsigned int linkCount = 0;
	
	// указатель на список вершин графа
	unordered_map<string, Vertex*>* vertices;

public:

	// Результирующий список названий вершин - ответ алгоритмов поиска
	list<Vertex*> FoundVertices;

	Graph(const string title);
	~Graph();

	// находит вершину в списке вершин по её названию
	Vertex* FindVertex(const string title);

	// добавление вершины в граф
	unsigned int AddVertex(const string title, unsigned int weight);

	// добавление ребра, соединяющего две вершины
	unsigned int AddLink(const string from, const string to, const string title, unsigned int weight);

	// удаление вершины по Id
	bool RemoveVertex(unsigned int vertexId);

	// удаление вершины по названию
	bool RemoveVertex(const string title);

	// волновой алгоритм для невзвешенного графа
	void GetRoute(string from, string to);

	// алгоритм Дейкстры для взвешенных графов
	void GetRouteDijkstra(string from, string to);

	// печать результата поиска
	void PrintFoundPath();

	void Print();

	string MaxLinks();

	friend void main();
};

