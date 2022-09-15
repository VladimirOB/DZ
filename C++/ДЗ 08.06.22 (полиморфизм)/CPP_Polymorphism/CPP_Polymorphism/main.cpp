#include <iostream>
#include "Figure.h"
#include "Rectangle.h"
#include "Circle.h"
#include <time.h>
#include "Document.h"

using namespace std;

void main()
{
	srand(time(0));

	Document doc(20);

	for (size_t i = 0; i < 10; i++)
	{
		int n = rand() % 3;
		switch (n)
		{
		case 0:
			doc.Add(new Rectangle(rand() % 10, rand() % 10, rand() % 10, rand() % 10));
			break;
		case 1:
			doc.Add(new Circle(rand() % 10, rand() % 10, rand() % 10));
			break;
		default:
			doc.Add(new Figure(rand() % 10, rand() % 10));
			break;
		}
	}

	doc.Print();
	cout << "Document square: " << doc.GetS() << endl;

	//Figure figure(1, 2);
	//figure.Print();

	//Rectangle rect(1, 2, 3, 5);
	//rect.Print();

	//Circle circle(3, 7, 5);
	//circle.Print();
	
	/*int n = rand() % 3;

	Figure* figure = NULL;

	switch (n)
	{
		case 0:
			figure = new Rectangle(1, 2, 3, 4);
			break;
		case 1:
			figure = new Circle(1, 2, 5);
			break;
		default:
			figure = new Figure(1, 2);
			break;
	}

	figure->Print();
	cout << "S = " << figure->GetS() << endl;

	delete figure;*/
}