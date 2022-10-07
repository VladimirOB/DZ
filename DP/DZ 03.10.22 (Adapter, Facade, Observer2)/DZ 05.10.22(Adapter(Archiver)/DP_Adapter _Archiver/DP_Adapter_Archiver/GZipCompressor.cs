using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_Adapter_Archiver
{
    // Адаптируемый класс
    class GZipCompressor
    {
        public int Length { get; set; }

        public GZipCompressor(int x)
        {
			Length = x;
        }

        public void Pack(string name)
        {

        }

        public void UnPack()
        {

        }

        public void ArchiveChecker()
        {

        }

        public List<string> ArchView()
        {
            return null;
        }
    }
}
