using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Disposable
{
    public class Person: IDisposable
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string Address { get; set; }

        public void Print()
        {
            Console.WriteLine($"Person: {FirstName} {LastName}, Age: {Age}, Address: {Address}");
        }

        // очистка неуправляемых ресурсов
        public void Dispose()
        {
            Console.WriteLine("Person Dispose!");
        }
    }
}
