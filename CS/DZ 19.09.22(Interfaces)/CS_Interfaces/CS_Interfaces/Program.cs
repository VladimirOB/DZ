using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            //Helicopter choper = new Helicopter();
            //choper.Move(1, 2, 3);

            /*List<IFly> airForces = new List<IFly>();
            airForces.Add(new Helicopter());
            airForces.Add(new Fly());
            airForces.Add(new Fly());
            airForces.Add(new Helicopter());

            foreach (object item in airForces)
            {
                (item as IFly)?.TakeOff();
            }

            foreach (IFly item in airForces)
            {
                item.TakeOff();
            }

            object fly = new Fly();

            // проверить, является ли ссылка объектом класса Fly
            if (fly is Fly)
            {
                ((Fly)fly).Eat();
            }

            // проверка реализации интерфейса
			if (fly is IFly)
			{
                ((IFly)fly).Land();
			}

			// приведение к типу Fly
			Fly realFly = fly as Fly;
            realFly?.Eat();

            if(realFly != null)
            {
                realFly.Eat();
            }

            // приведение к типу Fly
            (fly as Fly)?.Eat();*/

            /*List<IPrintable> lst = new List<IPrintable>();
            lst.Add(new MyTest());
            lst.Add(new Fly());*/

            Cat cat = new Cat();

            // вызов метода Move интерфейса IAlive
            IAlive alive = cat;
            alive.Move(1, 2);

            (cat as IAlive).Move(1, 2);
            ((IAlive)cat).Move(1, 2);

            // вызов метода Move интерфейса IHunter
            IHunter hunter = cat;
            hunter.Move(3, 4);

            // вызов метода Move класса Cat
            cat.Move(3, 5);
        }
    }
}
