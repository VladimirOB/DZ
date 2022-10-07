using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_Adapter_Archiver
{
    class Program
    {
        static void Main(string[] args)
        {
            MyArchiver window = new MyArchiver();

            window.algorithms.Add("txt", new GZipPack("GZip"));
            window.algorithms.Add("jpg", new LZWPack("LZW"));
            window.algorithms.Add("mp3", new HuffmanPack("Huffman"));

            Console.WriteLine(window);
        }
    }
}
