#include <iostream>
#include <stack>
#include <queue>
#include <string>
#include <vector>
#include <deque>

using namespace std;

class Point {
	int x, y;
};

void main()
{
	// помещение объекта пользовательского класса в стек
	stack <Point> ss;
	Point p;

	// добавление в конец стека
	ss.push(p);

	stack <int> st;

	// добавление в конец стека
	st.push(10);
	st.push(23);
	st.push(5);

	// получить количество элементов в стеке
	cout << "size: " << st.size() << endl;

	// прочитать вершину стека (без удаления)
	cout << st.top() << endl;

	// удалить крайний элемент стека
	st.pop();

	// прочитать вершину стека (без удаления)
	cout << st.top() << endl;
	

	
	queue <string> q;

	// добавление в конец очереди
	q.push("Hello");
	q.push("world");
	q.push("!!!");

	// выборка всех элементов из очереди
	while(!q.empty())
	{
		// прочитать ближайший к выходу элемент очереди
		cout << q.front() << endl;

		// удалить элемент из очереди
		q.pop();
	}

	// получить количество элементов в очереди
	cout << q.size() << endl;
	

	class MySort
	{
	public:
		bool operator() (int a, int b)
		{
			if(a%2 && b%2) return a<b;
			if(a%2==0 && b%2==0) return a>b;
			if(a%2==1 && b%2==0) return true;
			if(a%2==0 && b%2==1) return false;
		}
	};

	class MySort2
	{
	public:
		bool operator() (string a, string b)
		{
			return a.size() > b.size();
		}
	};

	// сортирующая очередь с приоритетами
	priority_queue <string, vector<string>, MySort2> pq;

	//priority_queue <string> pq;

	// добавление в очередь
	pq.push("34");
	pq.push("45");
	pq.push("22");
	pq.push("103");
	pq.push("2");
	pq.push("1");

	// выемка всех элементов из очереди
	while(!pq.empty())
	{
		// прочитать элемент, ближайший к выходу
		cout << pq.top() << endl;

		// удалить элемент, ближайший к выходу
		pq.pop();
	}

	// получить количество элементов в очереди
	cout << "size: " << pq.size() << endl;
}
