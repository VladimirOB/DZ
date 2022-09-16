using System;

namespace Strategy
{
    class MainApp
    {
        static void Main()
        {
            Vector v;

            v = new Vector(new QuickSort());
            v.Sort();

            v.Strategy = new BubbleSort();
            v.Sort();

            v.Strategy = new InsertionSort();
            v.Sort();

            Console.Read();
        }
    }

    // "Strategy" 
    abstract class SortStrategy
    {
        public abstract void Sort();
    }

    // "ConcreteStrategyA" 

    class QuickSort : SortStrategy
    {
        public override void Sort()
        {
            Console.WriteLine(
              "Quick SORT!!!");
        }
    }

    // "ConcreteStrategyB" 

    class BubbleSort : SortStrategy
    {
        public override void Sort()
        {
            Console.WriteLine(
              "BUBBLE sort!!!");
        }
    }

    // "ConcreteStrategyC" 

    class InsertionSort : SortStrategy
    {
        public override void Sort()
        {
            Console.WriteLine(
              "Insertion sort!!!");
        }
    }

    // "Context" 

    class Vector
    {
        // Ссылка на объект, занимающийся сортировкой
        SortStrategy strategy;

        public SortStrategy Strategy
        {
            get
            {
                return strategy;
            }
            set
            {
                strategy = value;
            }
        }

        int[] numbers = new int[100];

        // Constructor 
        public Vector(SortStrategy strategy)
        {
            this.strategy = strategy;
        }

        public void Sort()
        {
            // Вызов метода Sort, объекта сортировки, ссылка на который хранится в классе
            strategy.Sort();
        }
    }
}
