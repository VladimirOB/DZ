using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_Adapter_Archiver
{
    // Адаптер
    class GZipPack: PackAlgorithm
    {
        // ссылка на адаптируемый объект
        GZipCompressor compressor;

        public GZipPack(string title)
        {
            // установка свойств адаптер
            this.Title = title;

            // установка свойств адаптируемого объекта
            compressor = new GZipCompressor(10000);
        }

        public override void Compress(string filename)
        {
            compressor.Pack(filename);
        }

        public override void DeCompress(string filename)
        {
            compressor.UnPack();
        }

        public override string[] List(string filename)
        {
            return compressor.ArchView().ToArray();
        }

        public override void Test(string filename)
        {
            compressor.ArchiveChecker();
        }
    }
}
