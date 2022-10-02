using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_Observer
{
    class MainApp
    {
        static void Main()
        {
            // Создание наблюдаемого объекта
            ConcreteSubject s = new ConcreteSubject();

            // Добавление наблюдателей
            s.Attach(new ConcreteObserver(s, "X"));
            s.Attach(new ConcreteObserver(s, "Y"));
            s.Attach(new ConcreteObserver(s, "Z"));

            // Изменение свойства наблюдаемого объекта
            s.SubjectState = "ABC";

            // Уведомление наблюдателей об изменении свойств
            s.Notify();

            // Wait for user 
            Console.Read();
        }
    }

    // "Subject" - абстрактный наблюдаемый объект, который задаёт поведение всех наблюдаемых объектов
    abstract class Subject
    {
        // Список наблюдателей
        private List<Observer> observers = new List<Observer>();

        // Добавление наблюдателя
        public void Attach(Observer observer)
        {
            observers.Add(observer);
        }

        // Удаление наблюдателя
        public void Detach(Observer observer)
        {
            observers.Remove(observer);
        }

        // Перебор и уведомление всех наблюдателей
        public void Notify()
        {
            foreach (Observer o in observers)
            {
                o.Update();
            }
        }
    }

    // "ConcreteSubject" - конкретный наблюдаемый объект
    class ConcreteSubject : Subject
    {
        // Конкретное свойство
        private string subjectState;

        // Property 
        public string SubjectState
        {
            get { return subjectState; }
            set { subjectState = value; }
        }
    }

    // "Observer" - абстрактный наблюдатель, задаёт поведение всех наблюдателей
    abstract class Observer
    {
        // Метод, который вызывается наблюдаемыми объектами
        public abstract void Update();
    }

    // "ConcreteObserver" - конкретный наблюдатель, который реагирует на изменения свойств наблюдаемых объектов
    class ConcreteObserver : Observer
    {
        // Конкретные свойства наблюдателей
        private string name;
        private string observerState;

        // ссылка на наблюдаемый объект
        private ConcreteSubject subject;

        // Constructor 
        public ConcreteObserver(ConcreteSubject subject, string name)
        {
            this.subject = subject;
            this.name = name;
        }

        public override void Update()
        {
            observerState = subject.SubjectState;
            Console.WriteLine("Observer {0}'s new state is {1}",
              name, observerState);
        }

        // Property 
        public ConcreteSubject Subject
        {
            get { return subject; }
            set { subject = value; }
        }
    }
}
