using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Interfaces
{
	public class MyTest : IPrintable, ITest
	{
		public void Print()
		{
			
		}

		void IPrintable.Print()
		{
			
		}

		void ITest.Print()
		{
			
		}
	}
}
