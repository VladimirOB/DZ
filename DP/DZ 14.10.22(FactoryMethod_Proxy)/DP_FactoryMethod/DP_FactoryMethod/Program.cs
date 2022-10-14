using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_FactoryMethod
{
    class Program
    {
        static void Main()
        {
            // An array of creators 
            Creator creator;

            creator = new ConcreteCreatorA();
            //creator = new ConcreteCreatorB();

            Product product = creator.FactoryMethod();
            Console.WriteLine("Created {0}", product.GetType().Name);

            // Wait for user 
            Console.Read();
        }
    }

    // "Product" 
    abstract class Product
    {
    }

    // "ConcreteProductA" 
    class ConcreteProductA : Product
    {
    }

    // "ConcreteProductB" 
    class ConcreteProductB : Product
    {
    }

    // "Creator" 
    abstract class Creator
    {
        // Фабричный метод
        public abstract Product FactoryMethod();
    }

    // "ConcreteCreator" 

    class ConcreteCreatorA : Creator
    {
        public override Product FactoryMethod()
        {
            return new ConcreteProductA();
        }
    }

    // "ConcreteCreator" 

    class ConcreteCreatorB : Creator
    {
        public override Product FactoryMethod()
        {
            return new ConcreteProductB();
        }
    }
}


