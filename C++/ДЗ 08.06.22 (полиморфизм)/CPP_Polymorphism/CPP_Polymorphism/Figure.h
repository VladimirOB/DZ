#pragma once

class Figure
{
protected:
	int X, Y;
public:
	Figure(int x, int y);
	~Figure();

	void virtual Print();
	double virtual GetS();
};

