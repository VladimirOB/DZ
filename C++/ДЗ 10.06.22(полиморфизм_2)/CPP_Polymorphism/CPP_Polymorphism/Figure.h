#pragma once

class Figure
{
protected:
	int X, Y;
public:
	Figure(int x, int y);
	virtual ~Figure();

	// методы должны быть обязательно реализованы у потомков
	void virtual Print() = 0;
	double virtual GetS() = 0;
};

