using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_Adapter_Archiver
{
    abstract class PackAlgorithm
    {
        public int SourceSize { get; set; }

        public int PackSize { get; set; }

        public string Title { get; set; }

        public abstract void Compress(string filename);

		public abstract void DeCompress(string filename);

		public abstract void Test(string filename);

		public abstract string[] List(string filename);
	}
}
