using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Правила определения структур
 * - от структур нельзя наследовать
 * - при создании структур не обязательно использовать оператор new
 * - перед использованием структур все поля в ней должны быть определены
 * - нельзя при объявлении полей структур сразу задавать им значения ???
 * - в конструкторах все значения должны быть полностью определены
 * - стуктура не может иметь констуктор без параметров ???
 */

namespace CS_Structures
{
    public struct Person
    {
        public int age;

        public int height;

        public string name;
        //public StringBuilder name;

        public Person(string name, int age, int height)
        {
            this.age = age;
            this.height = height;
            this.name = name;
            //this.name = new StringBuilder(name);
        }

        public void Print()
        {
            Console.WriteLine($"Person. Name: {name}, Age: {age}, Height: {height}");
        }
    }

    public class Address
    {
        public string City { get; set; }

        public string Street { get; set; }

        public int House { get; set; }

        public void Print()
        {
            Console.WriteLine($"Address. City: {City}, Street: {Street}, House: {House}");
        }
    }

    public class Student
    {
        public int age;

        public int height;

        public string name;

        public Address address;

        public Student(string name, int age, int height, string city, string street, int house)
        {
            this.age = age;
            this.height = height;
            this.name = name;

            address = new Address() { City = city, Street = street, House = house };
        }

        public void Print()
        {
            Console.WriteLine($"Student. Name: {name}, Age: {age}, Height: {height}");
            address.Print();
            Console.WriteLine();
        }

        // глубокое клонирование 
        public Student Clone()
        {
            // создание поверхностной копии объекта класса
            Student result = (Student)this.MemberwiseClone();

            result.address = new Address() { City = this.address.City, Street = this.address.Street, House = this.address.House};

            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // создание экземпляра структуры
            //Person person = new Person("Alex", 23, 187);

            // использование конструктора по умолчанию
            //Person person = new Person();

            // создание экземпляра структуры без оператора new
            Person person;

            // заполнение полей
            person.name = "Alex";
            person.age = 23;
            person.height = 180;

            person.Print();

            // побитовое копирование структур
            Person person2 = person;

            person.name = "Vasya";
            person.age = 34;
            person.height = 160;

            person.Print();
            person2.Print();

            /*Student student = new Student("Alex", 23, 187, "Moskow", "Lenina", 3);
            //student.Print();

            // создание ещё одной ссылки на единственный объект класса Student
            //Student student2 = student;

            // глубокое копирование одного объекта в другой
            Student student2 = student.Clone();

            // поменять поля в одном из объектов
            student.name = "Vasya";
            student.age = 34;
            student.height = 160;
            student.address.City = "Donetsk";
            student.address.House = 23;
            student.address.Street = "Lipskaya";

            student.Print();
            student2.Print();*/
        }
    }
}
