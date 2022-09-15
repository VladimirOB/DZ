#pragma once
class Point
{
protected:

	// обычные поля класса
	int x, y;

	// объявление статического поля класса
	static unsigned count;
public:
	
	Point(int x, int y);
	~Point();
	void Print();

	// объявление статического метода
	static unsigned GetCount();
};

