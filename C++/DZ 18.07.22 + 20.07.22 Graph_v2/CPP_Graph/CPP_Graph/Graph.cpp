#include "Graph.h"
#include <list>

using namespace std;

Graph::Graph(const string _title)
{
	title = _title;

	// выделение памяти под словарь вершин
	vertices = new unordered_map<string, Vertex*>();
}

Graph::~Graph()
{
	// перебор списка вершин и удаление каждой вершины
	unordered_map<string, Vertex*>::iterator pos = vertices->begin();
	while (pos != vertices->end())
	{
		// указатель на текущую вершину
		Vertex* currentVertex = pos->second;

		// переместить указатель на следующую вершину
		pos++;

		// удалить текущую вершину
		delete currentVertex;
	}

	// удаление списка вершин графа
	delete vertices;
}

// поиск вершины по названию
Vertex* Graph::FindVertex(const string title)
{
	unordered_map<string, Vertex*>::iterator pos = vertices->find(title);
	if (pos != vertices->end())
		return pos->second;

	return nullptr;
}

// добавление вершины в граф
unsigned int Graph::AddVertex(const string title, unsigned int weight)
{
	if (FindVertex(title) == 0)
	{
		Vertex* vertex = new Vertex(vertexId++, title, weight);
		if (vertex != nullptr)
		{
			// добавление вершины в список вершин
			vertices->insert(make_pair(title, vertex));

			// увеличить количество вершин на 1
			vertexCount++;

			// возвратить Id созданной вершины
			return vertexId-1;
		}
	}
	return -1;
}

unsigned int Graph::AddLink(const string from, const string to, const string title, unsigned int weight)
{
	// получить указатели на вершины по их названиям
	Vertex* vertexFrom = FindVertex(from);
	Vertex* vertexTo = FindVertex(to);

	if (vertexFrom != nullptr && vertexTo != nullptr)
	{
		// создание объекта ребра
		Link* link = new Link(linkId++, title, weight, vertexFrom, vertexTo);
		if (link != nullptr)
		{
			// добавление указателей на созданное ребро в списки рёбер каждой из соединяемых вершин
			vertexFrom->links.push_back(link);
			vertexTo->links.push_back(link);

			// увеличить количество рёбер на 1
			linkCount++;

			// возвратить Id созданного ребра
			return linkId-1;
		}
	}

	return -1;
}

// удаление вершины по Id
bool Graph::RemoveVertex(unsigned int vertexId)
{
	// перебор списка вершин
	unordered_map<string, Vertex*>::iterator pos;
	for (pos = vertices->begin(); pos != vertices->end(); pos++)
	{
		Vertex* currentVertex = pos->second;

		// если найдена нужная вершина
		if (currentVertex->id == vertexId)
		{
			// из общего количества рёбер графа вычесть количество рёбер, подходящее к удаляемой вершине
			linkCount -= currentVertex->GetLinksCount();

			// уменьшить количество вершин на 1
			vertexCount--;

			// удаление вершины
			delete currentVertex;

			vertices->erase(pos);
			
			return true;
		}
	}
	
	return false;
}

// удаление вершины по названию
bool Graph::RemoveVertex(const string title)
{
	unordered_map<string, Vertex*>::iterator pos;
	for (pos = vertices->begin(); pos != vertices->end(); pos++)
	{
		Vertex* currentVertex = pos->second;

		if (currentVertex->title == title)
		{
			linkCount -= currentVertex->GetLinksCount();
			vertexCount--;

			vertices->erase(pos);

			delete currentVertex;

			return true;
		}
	}

	return false;
}

void Graph::Print()
{
	cout << "GRAPH: " << title << endl;
	cout << "Vertices: " << vertexCount << " Links: " << linkCount << endl << endl;

	// перебрать список вершин и напечатать все вершины
	unordered_map<string, Vertex*>::iterator pos;
	for (pos = vertices->begin(); pos != vertices->end(); pos++)
	{
		pos->second->Print();
	}
}

// волновой алгоритм для невзвешенного графа
void Graph::GetRoute(string from, string to)
{
	// очистить предыдущий результат
	FoundVertices.clear();

	// Список текущих просмотренных вершин, обрабатываемых на текущей итерации
	list<Vertex*> oldFront;

	// Список текущих помеченных вершин, обрабатываемых на следующей итерации
	list<Vertex*> newFront;

	// Дискретное время (номер итерации)
	int t = 0;

	Vertex* vertexFrom = FindVertex(from);
	Vertex* vertexTo = FindVertex(to);

	// Если начальная и конечная вершины присутствуют в графе
	if (vertexFrom != nullptr && vertexTo != nullptr)
	{
		// Перебрать множество вершин и пометить их как непосещённые
		for (unordered_map<string, Vertex*>::iterator i = vertices->begin(); i != vertices->end(); i++) {
			i->second->label = -1;
		}

		// Пометить начальную вершину как посещённую и поместить в список для текущей обработки
		vertexFrom->label = 0;
		oldFront.push_back(vertexFrom);

		// Пока не закончились помеченные вершины с необработанными соседями
		while (oldFront.size() > 0) {

			// Перебрать все помеченные вершины с необработанными соседями
			for (Vertex* vertex: oldFront) 
			{
				// Для текущей вершины перебрать множество соседних вершин
				for (Link* link: vertex->links) {

					Vertex* current = FindVertex(link->to->title);

					// Если текущая вершина оказалась искомой
					if (current == vertexTo) {

						current->label = t + 1;
						Vertex* reverse = current;

						// Цикл по вершинам для возврата назад
						while (reverse->label > 0)
						{
							FoundVertices.push_back(reverse);

							for (Link* link: reverse->links)
							{
								if (link->from->label == reverse->label - 1)
								{
									reverse = link->from;
									break;
								}
							}
						}

						FoundVertices.push_back(vertexFrom);
						FoundVertices.reverse();

						// Конец алгоритма
						return;
					}

					if (current->label == -1) 
					{
						current->label = t + 1;
						newFront.push_back(current);
					}
				}

			}

			oldFront.clear();
			copy(newFront.begin(), newFront.end(), back_inserter(oldFront));
			newFront.clear();
			t++;
		}
	}
}

// алгоритм Дейкстры для взвешенных графов
void Graph::GetRouteDijkstra(string from, string to)
{
	// очистить предыдущий результат
	FoundVertices.clear();

	Vertex* vertexFrom = FindVertex(from);
	Vertex* vertexTo = FindVertex(to);

	// Если начальная и конечная вершины присутствуют в графе
	if (vertexFrom != nullptr && vertexTo != nullptr)
	{
		// Перебрать множество вершин и пометить их как непосещённые, текущее расстояние до вершмн - бесконечность
		for (unordered_map<string, Vertex*>::iterator vertex = vertices->begin(); vertex != vertices->end(); vertex++)
		{
			vertex->second->label = 0;
			vertex->second->distance = 1000000;
			vertex->second->prev = nullptr;
		}

		// Пометить стартовую вершину как посещённую, расстояние до неё равно 0
		vertexFrom->distance = 0;

		while (true)
		{
			// Вершина с минимальным расстоянием от текущей
			Vertex* minVertex = nullptr;

			// Перебрать множество соседних вершин для вершины с минимальным расстоянием
			for (unordered_map<string, Vertex*>::iterator vertex = vertices->begin(); vertex != vertices->end(); vertex++)
			{
				if (minVertex == nullptr && vertex->second->label == 0) minVertex = vertex->second;
				if (minVertex != nullptr && vertex->second->label == 0 && minVertex->distance > vertex->second->distance) minVertex = vertex->second;
			}

			// Если дистанция до вершины с минимальным расстоянием равна бесконечности - решения нет
			if (minVertex == nullptr || minVertex->distance == 1000000) 
				return;	// решения нет

			// Если вершина с минимальным расстоянием является искомой
			if (minVertex == vertexTo)
			{
				// Двигаться по вершинам в обратном направлении и добавлять их названия в массив результатов
				Vertex* v = minVertex;
				while (v != nullptr)
				{
					FoundVertices.push_back(v);
					v = v->prev;
				}

				// Реверс массива результатов
				FoundVertices.reverse();

				// конец алгоритма
				return;
			}

			minVertex->label = 1;

			// Для минимальной вершины перебрать множество соседних вершин
			for (Link* link : minVertex->links)
			{
				Vertex* currentVertex = (link->from == minVertex)? link->to : link->from;

				// Если соседняя вершина не посещена и отмеченная дистанция до неё больше дистанции до минимальной вершины + вес связующего ребра
				if (currentVertex->label == 0 && currentVertex->distance > (minVertex->distance + link->weight))
				{
					// Поменять дистанцию к соседней вершине
					currentVertex->distance = minVertex->distance + link->weight;

					// Указать минимальную вершину как предыдущую на пути к соседней
					currentVertex->prev = minVertex;
				}
			}
		}
	}
}

// печать результата поиска
void Graph::PrintFoundPath()
{
	for (list<Vertex*>::iterator i = FoundVertices.begin(); i != FoundVertices.end(); i++) {
		cout << (*i)->title << " ";
	}
}

string Graph::MaxLinks()
{
	unsigned MaxLinks = 0;
	string Title;

	for (auto it = vertices->begin(); it != vertices->end(); it++)
	{
		if (MaxLinks < it->second->GetLinksCount())
		{
			MaxLinks = it->second->GetLinksCount();
			Title = it->second->title;
		}
	}
	return Title;
}