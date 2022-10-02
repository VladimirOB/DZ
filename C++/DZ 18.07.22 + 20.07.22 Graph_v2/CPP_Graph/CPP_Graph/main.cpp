#include <iostream>
#include "Graph.h"
#include <time.h>

using namespace std;

void main()
{
	Graph graph("test");

	graph.AddVertex("A", 10);
	graph.AddVertex("B", 20);
	graph.AddVertex("C", 30);
	graph.AddVertex("D", 25);
	graph.AddVertex("E", 21);

	graph.AddLink("A", "B", "link1", 12);
	graph.AddLink("B", "C", "link2", 23);
	graph.AddLink("D", "E", "link3", 2);
	graph.AddLink("C", "D", "link4", 21);
	graph.AddLink("B", "E", "link4", 21);
	//cout << "Max Links = " << graph.MaxLinks() << endl;
	//graph.Print();
	//cout << graph.title << endl;

	graph.GetRoute("A", "E");
	graph.PrintFoundPath();

	/*graph.AddVertex("One", 34);
	graph.AddVertex("Two", 45);
	graph.AddVertex("Three", 23);
	graph.AddVertex("Four", 78);
	graph.AddVertex("Five", 11);
	graph.AddVertex("Six", 21);

	graph.AddLink("One", "Two", "", 7);
	graph.AddLink("One", "Three", "", 9);
	graph.AddLink("One", "Six", "", 14);
	graph.AddLink("Two", "Three", "", 10);
	graph.AddLink("Two", "Four", "", 15);
	graph.AddLink("Three", "Four", "", 11);
	graph.AddLink("Three", "Six", "", 2);
	graph.AddLink("Four", "Five", "", 6);
	graph.AddLink("Five", "Six", "", 9);*/

	/*graph.AddLink("One", "Two", "", 1);
	graph.AddLink("Two", "Three", "", 2);
	graph.AddLink("Three", "Five", "", 3);
	graph.AddLink("Two", "Five", "", 6);*/

	/*graph.AddLink("One", "Two", "", 1);
	graph.AddLink("Two", "Three", "", 2);
	graph.AddLink("One", "Three", "", 5);*/

	//graph.GetRouteDijkstra("One", "Six");
	//graph.PrintFoundPath();
}