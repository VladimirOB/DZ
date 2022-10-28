using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_State
{
    class Program
    {
        static void Main()
        {
            // Создание системы, основанной на состояниях и установка начального состояния
            Context c = new Context(new ConcreteStateA());

            // Запросы на изменение состояний
            c.Request();
            c.Request();
            c.Request();
            c.Request();

            // Wait for user 
            Console.Read();
        }
    }

    // "State" - абстрактный класс состояний
    abstract class State
    {
        // Метод меняет одно состояние на другое
        public abstract void Handle(Context context);
    }

    // "ConcreteStateA" - конкретное состояние системы
    class ConcreteStateA : State
    {
        public override void Handle(Context context)
        {
            // Какие-то действия с контекстом (возможно, с пользователем)

            // Изменение состояния системы
            context.State = new ConcreteStateB();
        }
    }

    // "ConcreteStateB" - конкретное состояние системы
    class ConcreteStateB : State
    {
        public override void Handle(Context context)
        {
            // Изменение состояния системы
            context.State = new ConcreteStateC();
        }
    }

    // "ConcreteStateC" - конкретное состояние системы
    class ConcreteStateC : State
    {
        public override void Handle(Context context)
        {
            // Изменение состояния системы
            context.State = new ConcreteStateA();
        }
    }

    // "Context" - класс системы, основанной на состояниях
    class Context
    {
        public int ContextProperty { get; set; }

        // Текущее состояние системы
        private State state;

        // Constructor, принимает начальное состояние системы
        public Context(State state)
        {
            this.State = state;
        }

        // Property - текущее состояние системы
        public State State
        {
            get { return state; }
            set
            {
                state = value;
                Console.WriteLine("State: " +
                  state.GetType().Name);
            }
        }

        // Запрос на изменение состояния
        public void Request()
        {
            state.Handle(this);
        }
    }
}
