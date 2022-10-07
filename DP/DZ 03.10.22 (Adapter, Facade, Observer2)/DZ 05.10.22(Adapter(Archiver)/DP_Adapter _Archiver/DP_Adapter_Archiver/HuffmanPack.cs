using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_Adapter_Archiver
{
    class HuffmanPack: PackAlgorithm
    {
        public int FgColor { get; set; }

        public int BgColor { get; set; }

        public HuffmanPack(string title)
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
            return null;
        }
    }
}
