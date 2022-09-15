#include <iostream>
#include "Figure.h"
#include "Rectangle.h"

using namespace std;

struct A
{
	int d;

public:
	int a = 3;

	void Print() {
		cout << a << endl;
		cout << b << endl;
		cout << c << endl;
	}
	
protected:
	int b = 5;

private:
	int c = 7;
};

struct B: A
{
public:
	int aa = 3;

	void Print() {
		cout << a << endl;
		cout << b << endl;
		//cout << c << endl;
	}

protected:
	int bb = 5;

private:
	int cc = 7;
};

struct C : public B
{
public:
	int aaa = 3;

	void Print() {
		cout << a << endl;
		cout << b << endl;
		//cout << c << endl;
	}

protected:
	int bbb = 5;

private:
	int ccc = 7;
};

void main()
{
	//B a;
	//a.a = 45;

	//Figure figure(1, 2);
	//figure.Print();

	//Rectangle rect(1, 2, 3, 5);
	//rect.Print();
}