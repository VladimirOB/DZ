using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CS_Attributes
{
    class MyClass
    {
        public int MyProperty { get; set; }
    }

    // объявление атрибута
    class Info: Attribute
    {
        public string InfoText { get; set; }
    }

    // указание области использования атрибута
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Property)]
    class MethodAttribute: Attribute
    {
        public string HelpText { get; set; }

        public MethodAttribute(string helpText)
        {
            this.HelpText = helpText;
        }
    }

    [Info(InfoText = "This is a class")]
    class Customer
    {
        [Info(InfoText = "This is a field")]
        private string _CustomerCode;

        [Info(InfoText = "This is a property")]
        [Method("This is a method")]
        public string CustomerCode
        {
            get { return _CustomerCode; }
            set { _CustomerCode = value; }
        }

        [Info(InfoText = "This is a method")]
        [Method("This is a method")]
        public void Add()
        {
        }
    }

	class Car
    {
		[Check(MaxLength = 5, MinLength = 3)]
		public string Brand { get; set; }

        [Check(MaxLength = 10, MinLength = 3)]
        public string Model { get; set; }

        [Check(RangeMin = 1, RangeMax = 100000)]
        public int Price { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            /*Car car = new Car() { Brand = "Audi", Model = "Quattro", Price = 100000 };

            try
            {
                CarsChecker.CheckValues(car);
                Console.WriteLine("Successful!\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"Exception handled: {0}", ex.Message);
            }*/

            /*Person person = new Person("Alex", "Petrov", 34, 4567, "married");

            UserInterface ui = new UserInterface();

            ui.Write(person);
            Console.WriteLine();

            ui.Read(person);
            Console.WriteLine();

            ui.Write(person);
            */
            
            Person obj;
            
            //obj = (Person)Activator.CreateInstance(typeof(Person));
            //obj.Print();

            // динамическое создание объектов для класса, заданного строкой
            /*obj = (Person)Activator.CreateInstance(Type.GetType("CS_Attributes.Person"));
            obj.name = "Alex";
            obj.Print();

            var person = (Person)Assembly.GetExecutingAssembly().CreateInstance("CS_Attributes.Person");
            person.name = "Alex";
            person.Print();*/
        }
    }
}
