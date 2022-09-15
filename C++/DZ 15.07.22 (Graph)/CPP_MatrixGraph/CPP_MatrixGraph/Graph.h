#pragma once
#include <string>
#include <map>

using namespace std;

class Graph
{
	size_t MaxVertexCount;
	size_t CurrentVertexCount;
	double** links;
	map<string, unsigned>* vertices;
public:
	Graph(size_t max_vertex_count);
	~Graph();

	bool AddVertex(string title);

	bool AddLink(string title1, string title2, double weight);

	void PrintVertices();
	void PrintLinks(string title);

	void Print() {}

};

