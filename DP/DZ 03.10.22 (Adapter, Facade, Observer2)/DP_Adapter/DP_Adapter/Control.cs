using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter2
{
    abstract class Control
    {
        public int X { get; set; }
        public int Y { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public string Title { get; set; }
    }
}
