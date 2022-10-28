using System;
using System.Collections;
using System.Collections.Generic;

namespace Visitor
{
    class MainApp
    {
        static void Main()
        {
            // Setup structure 
            Conveyor conveyor = new Conveyor();
            conveyor.Attach(new PackingSystem());
            conveyor.Attach(new LabelingSystem());

            // Create visitor objects 
            Can can = new Can();
            Box box = new Box();

            // Structure accepting visitors 
            conveyor.Accept(can);

            Console.WriteLine();

            conveyor.Accept(box);

            // Wait for user 
            Console.Read();
        }
    }

    // "Visitor" 

    abstract class Visitor
    {
        // действия, которые можно совершать с Visitor

        // взять объект с ленты ковейера
        public abstract void TakeObject(SubSystem subSystem);

        // взять объект на ленту ковейера
        public abstract void PutObject(SubSystem subSystem);

        // повернуть объект
        public abstract void RotateObject(SubSystem subSystem);

        // проверить объект на брак
        public abstract void CheckObject(SubSystem subSystem);
    }

    // "ConcreteVisitor1" 

    class Can : Visitor
    {
        public override void TakeObject(SubSystem subSystem)
        {
            Console.WriteLine("TakeObject. {0} visited by {1}", subSystem.GetType().Name, this.GetType().Name);
        }

        public override void PutObject(SubSystem subSystem)
        {
            Console.WriteLine("PutObject. {0} visited by {1}", subSystem.GetType().Name, this.GetType().Name);
        }

		public override void RotateObject(SubSystem subSystem)
		{
            Console.WriteLine("RotateObject. {0} visited by {1}", subSystem.GetType().Name, this.GetType().Name);
        }

		public override void CheckObject(SubSystem subSystem)
		{
            Console.WriteLine("CheckObject. {0} visited by {1}", subSystem.GetType().Name, this.GetType().Name);
        }
	}

    // "ConcreteVisitor2" 

    class Box : Visitor
    {
        public override void TakeObject(SubSystem subSystem)
        {
            Console.WriteLine("TakeObject. {0} visited by {1}", subSystem.GetType().Name, this.GetType().Name);
        }

        public override void PutObject(SubSystem subSystem)
        {
            Console.WriteLine("PutObject. {0} visited by {1}", subSystem.GetType().Name, this.GetType().Name);
        }

		public override void RotateObject(SubSystem subSystem)
		{
            Console.WriteLine("RotateObject. {0} visited by {1}", subSystem.GetType().Name, this.GetType().Name);
        }

		public override void CheckObject(SubSystem subSystem)
		{
            Console.WriteLine("CheckObject. {0} visited by {1}", subSystem.GetType().Name, this.GetType().Name);
        }
	}

    // "Element" 

    abstract class SubSystem
    {
        public abstract void Accept(Visitor visitor);
    }

    // "ConcreteElementA" 

    class PackingSystem : SubSystem
    {
        public override void Accept(Visitor visitor)
        {
            visitor.TakeObject(this);
            visitor.RotateObject(this);
            visitor.PutObject(this);
        }

        public void OperationA()
        {
        }
    }

    // "ConcreteElementB" 

    class LabelingSystem : SubSystem
    {
        public override void Accept(Visitor visitor)
        {
            visitor.TakeObject(this);
            visitor.CheckObject(this);
            visitor.PutObject(this);
        }

        public void OperationB()
        {
        }
    }

    // "ObjectStructure" 

    class Conveyor
    {
        private List<SubSystem> elements = new List<SubSystem>();

        public void Attach(SubSystem element)
        {
            elements.Add(element);
        }

        public void Detach(SubSystem element)
        {
            elements.Remove(element);
        }

        public void Accept(Visitor visitor)
        {
            foreach (SubSystem e in elements)
            {
                e.Accept(visitor);
            }
        }
    }
}


