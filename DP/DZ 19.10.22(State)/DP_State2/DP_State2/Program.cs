using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DP_State2
{
    class Program
    {
        static void Main()
        {
            // Создание системы, основанной на состояниях и установка начального состояния
            CoffeeMachine coffeemat = new CoffeeMachine(new WaitForMoney());

            coffeemat.Start();

            // Wait for user 
            Console.Read();
        }
    }

    // "State" - абстрактный класс состояний
    abstract class State
    {
        // Метод меняет одно состояние на другое
        public abstract void Handle(CoffeeMachine context);
    }

    // Состояние ожидания денег
    class WaitForMoney : State
    {
        public override void Handle(CoffeeMachine context)
        {
            do
            {
                Console.WriteLine("Enter money:");
                int money = Convert.ToInt32(Console.ReadLine());

                if (money <= 0)
                {
                    context.State = new ErrorState();
                    return;
                }

                context.currentMoney += (UInt32)money;

            } while (context.currentMoney < 100);


            // Изменение состояния системы
            context.State = new CoffeeMaking();
        }
    }

    // Состояние приготовления кофе
    class CoffeeMaking : State
    {
        public override void Handle(CoffeeMachine context)
        {
            Console.WriteLine("Take your coffee!!!");

            context.currentMoney = 0;

            // Изменение состояния системы
            context.State = new WaitForMoney();
        }
    }

    // Состояние, при котором показывается сообщение о невозможности приготовления какого-то напитка
    class ErrorState : State
    {
        public override void Handle(CoffeeMachine context)
        {
            Console.WriteLine("Incorrect money!!!");

            context.currentMoney = 0;

            // Изменение состояния системы
            context.State = new WaitForMoney();
        }
    }

    // "Context" - класс системы, основанной на состояниях
    class CoffeeMachine
    {
        // Текущее состояние системы
        private State currentState;

        // Текущее количество внесенных денег
        public UInt32 currentMoney;

        // Все заработанные деньги
        UInt32 allMoney;

        // Constructor, принимает начальное состояние системы
        public CoffeeMachine(State state)
        {
            this.State = state;
        }

        // Property - текущее состояние системы
        public State State
        {
            get { return currentState; }
            set
            {
                currentState = value;
                Console.WriteLine("State: " + currentState.GetType().Name);
            }
        }

        public void Start()
        {
            while (true)
            {
                Request();
                Thread.Sleep(1000);
            }
        }

        // Запрос на изменение состояния
        public void Request()
        {
            currentState.Handle(this);
        }
    }
}
