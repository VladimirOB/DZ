﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Generics
{
    public class ArmyUnit
    {
        public virtual string Name { get; set; }
        public virtual double Speed { get; set; }
        public virtual double Health { get; set; }

        public virtual void Attack(int x, int y) { }
        public virtual void Move(int x, int y) { }
        public virtual void Stop() { }
        public virtual void Defeat(int x, int y) { }
        public virtual void Defend(int x, int y) { }
        public virtual void Print() { }
    }

    public interface IUnit
    {
        string Name { get; set; }
        double Speed { get; set; }
        double Health { get; set; }

        void Attack(int x, int y);
        void Move(int x, int y);
        void Stop();
        void Defeat(int x, int y);
        void Defend(int x, int y);
        void Print();
    }

    public class Soldier : ArmyUnit
    {
        public int Age { get; set; }
        public int Weight { get; set; }
        public override string Name { get; set; }
        public override double Speed { get; set; }
        public override double Health { get; set; }

        public override void Attack(int x, int y)
        {
        }

        public override void Defeat(int x, int y)
        {
        }

        public override void Defend(int x, int y)
        {
        }

        public override void Move(int x, int y)
        {
        }

        public override void Print()
        {
            Console.WriteLine($"Soldier. Name: {Name}, Age: {Age}, Speed: {Speed}, Health: {Health}");
        }

        public override void Stop()
        {
        }
    }

    public class Tank : ArmyUnit
    {
        public int Weight { get; set; }
        public override string Name { get; set; }
        public override double Speed { get; set; }
        public override double Health { get; set; }

        public override void Attack(int x, int y)
        {
        }

        public override void Defeat(int x, int y)
        {
        }

        public override void Defend(int x, int y)
        {
        }

        public override void Move(int x, int y)
        {
        }

        public override void Print()
        {
            Console.WriteLine($"Tank. Name: {Name}, Weight: {Weight}, Speed: {Speed}, Health: {Health}");
        }

        public override void Stop()
        {
        }
    }

    // разрешаются в качестве T переменные класса Soldier и его потомки и разрешается создание новых объектов
    //public class UnitGroup<T> : IUnit where T : Soldier, new()

    // разрешаются в качестве T переменные классов, 
    // реализующие интерфейс IUnit и их потомки и разрешается создание новых объектов
    //public class UnitGroup<T>: IUnit where T: class, IUnit, new()
    public class UnitGroup<T> : ArmyUnit where T : ArmyUnit, new()
    {
        List<T> units = new List<T>();

        public override string Name { get; set; }
        public override double Speed { get; set; }
        public override double Health { get; set; }

        public void AddUnit(T unit)
        {
            units.Add(unit);
        }

        public void AddNewUnit(string name, double speed, double health)
        {
            T unit = new T() { Name = name, Speed = speed, Health = health};
            units.Add(unit);
        }

        public override void Attack(int x, int y)
        {
            foreach(T unit in units) 
                unit.Attack(x, y);
        }

        public override void Move(int x, int y)
        {
            foreach (T unit in units)
                unit.Move(x, y);
        }

        public override void Stop()
        {
            foreach (T unit in units)
                unit.Stop();
        }

        public override void Defeat(int x, int y)
        {
            foreach (T unit in units)
                unit.Defeat(x, y);
        }

        public override void Defend(int x, int y)
        {
            foreach (T unit in units)
                unit.Defend(x, y);
        }

        public override void Print()
        {
            foreach (T unit in units)
                unit.Print();
        }
    }
}
