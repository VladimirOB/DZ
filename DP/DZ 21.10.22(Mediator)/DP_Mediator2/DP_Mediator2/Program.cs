using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_Mediator2
{
    class Program
    {
        static void Main()
        {
            // создание сервера сообщений
            Server srv = new Server();

            // создание клиентов и добавление на сервер
            Kiborg c1 = new Kiborg(srv);
            CanonRobot c2 = new CanonRobot(srv);

            // передача сообщений
            c1.Send("How are you?");
            c2.Send("Fine, thanks");

            // Wait for user 
            Console.Read();
        }
    }

    // "Mediator" 
    abstract class Mediator
    {
        public abstract void Send(string message);

        protected List<Unit> robots = new List<Unit>();

        public void Add(Unit r)
        {
            robots.Add(r);
        }
    }

    // "ConcreteMediator" 

    class Server : Mediator
    {
        public override void Send(string message)
        {
            foreach (Unit r in robots)
            {
                r.Notify(message);
            }
        }
    }

    // "Colleague"
    abstract class Unit
    {
        protected Mediator mediator;

        // Constructor 
        public Unit(Mediator mediator)
        {
            this.mediator = mediator;
            mediator.Add(this);
        }

        public abstract void Notify(string message);
    }

    // "ConcreteColleague1" 
    class Kiborg : Unit
    {
        // Constructor 
        public Kiborg(Mediator mediator)
            : base(mediator)
        {
        }

        public void Send(string message)
        {
            mediator.Send(message);
        }

        public override void Notify(string message)
        {
            Console.WriteLine("Colleague1 gets message: " + message);
        }
    }

    // "ConcreteColleague2" 
    class CanonRobot : Unit
    {
        // Constructor 
        public CanonRobot(Mediator mediator)
            : base(mediator)
        {
        }

        public void Send(string message)
        {
            mediator.Send(message);
        }

        public override void Notify(string message)
        {
            Console.WriteLine("Colleague2 gets message: "
              + message);
        }
    }
}


