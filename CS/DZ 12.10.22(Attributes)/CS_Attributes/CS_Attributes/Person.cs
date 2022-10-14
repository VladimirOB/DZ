using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Attributes
{
    class Person
    {
        [OpenField]
        public String name;

        [OpenField]
        public String surname;

        [OpenField]
        public int age;

		[OpenField]
		public int salary;

        public String status;

        public Person()
        {

        }

        public Person(String name, String surname, int age, int salary, string status)
        {
            this.name = name;
            this.surname = surname;
            this.salary = salary;
            this.age = age;
            this.status = status;
        }

        public void Print()
        {
            Console.WriteLine(@"Name: {0}, Surname: {1}, Age: {2}, Salary: {3}, Status: {4}", name, surname, age, salary, status);
        }
    }
}
