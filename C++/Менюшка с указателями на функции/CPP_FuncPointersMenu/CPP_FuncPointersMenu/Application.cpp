#include "Application.h"
#include <conio.h>
#include <iostream>
#include <string>

using namespace std;

Application::Application()
{
	// добавление пунктов в меню
	menu->Add('1', "Add string", &Application::Add_Pressed);
	menu->Add('2', "Show strings", &Application::Show_Pressed);
	menu->Add('3', "Say hello", &Application::SayHello_Pressed);
	menu->Add('4', "Say HI!!!!", &Application::SayHi_Pressed);
	menu->Add('x', "Exit from program", &Application::Exit_Pressed);
}

Application::~Application()
{
	delete menu;
}

void Application::Run()
{
	// передача управления меню
	menu->Run();
}

void Application::Add_Pressed()
{
	cout << "Please, enter a string" << endl;
	string str;
	cin >> str;

	lines.push_back(str);

	//char ch = _getch();
}

void Application::Show_Pressed()
{
	cout << "Strings in list:" << endl << endl;

	// указатель на текущий элемент списка
	list<string>::iterator current;

	size_t num = 0;
	for (current = lines.begin(); current != lines.end(); current++)
	{
		cout << num++ << ". " << (*current) << endl;
	}

	char ch = _getch();
}

void Application::Exit_Pressed()
{
	cout << "Good bye!!!" << endl;
	exit(0);
}

void Application::SayHello_Pressed()
{
	cout << "Hello world!!!" << endl;
	_getch();
}

void Application::SayHi_Pressed()
{
	cout << "Hi there!!!" << endl;
	_getch();
}