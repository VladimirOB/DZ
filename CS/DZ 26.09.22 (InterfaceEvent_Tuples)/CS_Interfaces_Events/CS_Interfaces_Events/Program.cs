using System;
using System.Collections.Generic;
using System.Text;

interface IReceiver
{
    int OnReceive(string str);
}

class Server
{
    // создание переменной-списка адресов функций (event)
    public List<IReceiver> subscribers { get; } = new List<IReceiver>();

    // метод, подписывающий клиентские классы на сообщения
    public void Add(IReceiver ev)
    {
        subscribers.Add(ev);
    }

    // метод, отписывающий клиентские классы на сообщения
    public void Remove(IReceiver ev)
    {
        subscribers.Remove(ev);
    }

    // метод, стартующий событие и вызывающий обработчики события в классах-подписчиках
    public void StartEvent(string str)
    {
        // если есть подписчики, то сообщить им о событии (вызвать их обработчики)
        foreach (var current in subscribers)
        {
            current.OnReceive(str);
        }
    }
}

// первый класс-подписчик
class Client1: IReceiver
{
    // обработчик события
    int IReceiver.OnReceive(string str)
    {
        Console.WriteLine("Client 1: {0}", str);
        return 0;
    }
}

// второй класс подписчик
class Client2: IReceiver
{
	// обработчик события
	int IReceiver.OnReceive(string str)
    {
        Console.WriteLine("Client 2: {0}", str);
        return 0;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // создание подписчиков и сервера
        Client1 c1 = new Client1();
        Client2 c2 = new Client2();
        Server server = new Server();

        // подписка на события
        server.Add(c1);
        server.Add(c2);
        server.Add(c1);
        server.Remove(c1);

        // старт события на сервере
        server.StartEvent("Alarm !!! Fire !!!");

        // старт события на сервере
        server.StartEvent("Disk failure!");
    }
}

