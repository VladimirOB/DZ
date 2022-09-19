using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Interfaces
{
    class Helicopter : IFly
    {
        public double this[int pos] => throw new NotImplementedException();

        public double Height => throw new NotImplementedException();

        public void Land()
        {
            throw new NotImplementedException();
        }

        public void Move(double x, double y, double z)
        {
            throw new NotImplementedException();
        }

        public void TakeOff()
        {
            throw new NotImplementedException();
        }
    }
}
