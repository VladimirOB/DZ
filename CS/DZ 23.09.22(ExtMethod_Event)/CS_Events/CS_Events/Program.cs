using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Timers;
// объявление типа данных делегат
delegate int Subscriber(string str);

class Server
{
    // создание переменной-списка адресов функций (event)
    protected event Subscriber subsribers;
    System.Timers.Timer timer;
    int interval;

    public Server(int interval)
    {
        this.interval = interval;
    }

    public void Start()
    {
        timer = new System.Timers.Timer(interval);
        timer.Elapsed += Timer_Elapsed;
        timer.Start();
        for (int i = 0; i < 1000; i++)
        {
            Console.WriteLine(i);
            Thread.Sleep(1000);
        }
        timer.Stop();
    }

    private void Timer_Elapsed(object sender, ElapsedEventArgs e)
    {
        // старт события на сервере
        this.StartEvent("Alarm !!! Fire !!!");

        // старт события на сервере
        this.StartEvent("Disk failure!");
    }

    // метод, подписывающий клиентские классы на сообщения
    public void Add(Subscriber ev)
    {
        // оператор += добавляет ссылку на метод в event
        subsribers += ev;
    }

    // метод, отписывающий клиентские классы на сообщения
    public void Remove(Subscriber ev)
    {
        // оператор -= удаляет ссылку на метод из event
        subsribers -= ev;
    }

    // метод, стартующий событие и вызывающий обработчики события в классах-подписчиках
    public void StartEvent(string str)
    {
        // если есть подписчики, то сообщить им о событии (вызвать их обработчики)
        /*if(subsribers != null)
            subsribers(str);*/

        subsribers?.Invoke(str);
    }
}

// первый класс-подписчик
class Client1                                       
{
    // обработчик события
    public int OnEvent(string str)
    {
        Console.WriteLine("Client 1: {0}", str);
        return 0;
    }
}

// второй класс подписчик
class Client2
{
    // обработчик события
    public int OnGetEvent(string str)
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
        Server server = new Server(500);
        // подписка на события
        server.Add(c1.OnEvent);
        server.Add(c2.OnGetEvent);
        server.Add(c1.OnEvent);
        server.Remove(c1.OnEvent);

        server.Start();

        //// старт события на сервере
        //server.StartEvent("Alarm !!! Fire !!!");

        //// старт события на сервере
        //server.StartEvent("Disk failure!");
    }

   
}
