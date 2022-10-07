using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_Adapter_Archiver
{
    class LZWPack: PackAlgorithm
    {
        public string Hint { get; set; }

        public int WatermarkColor { get; set; }

        public LZWPack(string title)
        {
            this.Title = title;
        }

        public override void Compress(string filename)
        {
        }

        public override void DeCompress(string filename)
        {
        }

        public override void Test(string filename)
        {
        }

        public override string[] List(string filename)
        {
            throw new NotImplementedException();
        }
    }
}
