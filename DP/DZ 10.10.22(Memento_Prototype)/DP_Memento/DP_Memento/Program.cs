using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_Memento
{
    class Program
    {
        static void Main()
        {
            // Класс имеет начальные данные
            SalesProspect s = new SalesProspect();
            s.Name = "Noel van Halen";
            s.Phone = "(412) 256-0990";
            s.Budget = 25000.0;

            // Инициализация хранилища резервных копий
            ProspectMemory memory = new ProspectMemory();

            // Выполнение back-up
            memory.Memento = s.SaveMemento();

            // Изменение свойств основного объекта
            s.Name = "Leo Welch";
            s.Phone = "(310) 209-7111";
            s.Budget = 1000000.0;

            // Восстановление данных основного объекта из резервной копии
            s.RestoreMemento(memory.Memento);

            // Wait for user
            Console.ReadKey();

        }

    }

    // Класс, данные которого нужно сохранять
    class SalesProspect
    {
        private string _name;
        private string _phone;
        private double _budget;

        // Gets or sets name
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                Console.WriteLine("Name:  " + _name);
            }
        }

        // Gets or sets phone
        public string Phone
        {
            get { return _phone; }
            set
            {
                _phone = value;
                Console.WriteLine("Phone: " + _phone);
            }
        }

        // Gets or sets budget

        public double Budget
        {
            get { return _budget; }
            set
            {
                _budget = value;
                Console.WriteLine("Budget: " + _budget);
            }
        }

        // Выполнение back-up
        public Memento SaveMemento()
        {
            Console.WriteLine("\nSaving state --\n");
            return new Memento(_name, _phone, _budget);
        }

        // Восстановление данных из back-up
        public void RestoreMemento(Memento memento)
        {
            Console.WriteLine("\nRestoring state --\n");
            this.Name = memento.Name;
            this.Phone = memento.Phone;
            this.Budget = memento.Budget;
        }
    }

    // Контейнер, позволяющий хранить данные (резервная копия)
    class Memento
    {
        private string _name;
        private string _phone;
        private double _budget;

        // Constructor
        public Memento(string name, string phone, double budget)
        {
            this._name = name;
            this._phone = phone;
            this._budget = budget;
        }

        // Gets or sets name

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        // Gets or set phone

        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        // Gets or sets budget

        public double Budget
        {
            get { return _budget; }
            set { _budget = value; }
        }
    }

    // Хранилище резервных копий
    class ProspectMemory
    {
        private Memento _memento;

        // Property
        public Memento Memento
        {
            set { _memento = value; }
            get { return _memento; }
        }
    }
}



