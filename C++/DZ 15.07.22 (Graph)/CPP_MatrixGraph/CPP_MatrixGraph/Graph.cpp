#include "Graph.h"
#include <map>
#include <iostream>

using namespace std;

Graph::Graph(size_t max_vertex_count)
{
	this->MaxVertexCount = max_vertex_count;
	CurrentVertexCount = 0;

	// словарь вершин графа (связь названия вершины и номером вершины в двумерном массиве)
	vertices = new map<string, unsigned>;

	// двумерный массив связей между вершинами
	links = new double* [MaxVertexCount];
	for (size_t i = 0; i < MaxVertexCount; i++)
	{
		links[i] = new double[MaxVertexCount];

		// нет никах связей между любыми вершинами
		for (size_t k = 0; k < MaxVertexCount; k++)
		{
			links[i][k] = 0;
		}
	}
}

Graph::~Graph()
{
	delete vertices;

	for (size_t i = 0; i < MaxVertexCount; i++)
	{
		delete[] links[i];
	}
	delete[] links;
}

bool Graph::AddVertex(string title)
{
	// если вершина с таким именем в графе отсутсвует
	if (vertices->find(title) == vertices->end())
	{
		vertices->insert(make_pair(title, CurrentVertexCount++));
		return true;
	}
	else
	{
		cout << "The vertex with name: '" << title << "' already exists!!!" << endl;
		return false;
	}
}

void Graph::PrintVertices()
{
	map <string, unsigned>::iterator pos;

	// поле first - ключ
	// поле second - значение хранимой пары
	for (pos = vertices->begin(); pos != vertices->end(); pos++)
	{
		cout << pos->first << " -> " << pos->second << endl;
	}
}

bool Graph::AddLink(string title1, string title2, double weight)
{
	// если вершины с такими именами в графе отсутсвуют
	if (vertices->find(title1) == vertices->end() || vertices->find(title2) == vertices->end())
	{
		cout << "Wrong vertex name" << endl;
		return false;
	}

	// получить по названию вершины её индекс в массиве рёбер
	unsigned vertex1_index = vertices->find(title1)->second;

	// получить по названию вершины её индекс в массиве рёбер
	unsigned vertex2_index = vertices->find(title2)->second;

	links[vertex1_index][vertex2_index] = weight;
	links[vertex2_index][vertex1_index] = weight;
	
	return true;
}

void Graph::PrintLinks(string title)
{
	if (vertices->find(title) != vertices->end())
	{
		cout << title << " links: ";

		// получить по названию вершины её индекс в массиве рёбер
		unsigned vertex_index = vertices->find(title)->second;

		for (size_t i = 0; i < CurrentVertexCount; i++)
		{
			cout << links[vertex_index][i] << " ";
		}
		cout << endl;
	}
}