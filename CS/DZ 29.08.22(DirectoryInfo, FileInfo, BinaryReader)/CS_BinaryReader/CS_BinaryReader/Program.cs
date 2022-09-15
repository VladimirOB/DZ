using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_BinaryReader
{
    class Program
    {
        
        static void CW1()
        {
            FileStream fs = new FileStream(@"data.dat", FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs, Encoding.Default);
            string s = "Hello";
            byte[] a = { 3, 5, 6, 7, 8 };
            bw.Write(s);
            bw.Write(a);
            //bw.Close();
            fs.Close();

            fs = new FileStream(@"data.dat", FileMode.Open, FileAccess.Read);
            Console.WriteLine($"Lenght: {fs.Length}");
            BinaryReader br = new BinaryReader(fs, Encoding.Default);
            s = "!!!";
            byte[] b = null;
            s = br.ReadString();
            b = br.ReadBytes(5);

            Console.WriteLine(s);
            foreach (byte i in b)
            {
                Console.WriteLine(i);
            }
            //br.Close();
            fs.Close();
        }

        static void Dictionary()
        {
            //Пользователь вводит имя файла, программа находит частотный словарь символов a - z и выводит его на экран
            FileStream fs = new FileStream("1.txt", FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs, Encoding.Default);
            byte[] b = new byte[fs.Length];
            int[] a = new int[26];
            
            br.Read(b, 0, b.Length);

            for (int i = 0; i < b.Length; i++)
            {
                if (b[i] > 96 && b[i] < 123)
                {
                    a[b[i] - 97]++;
                }
            }

            for (int i = 0; i < a.Length; i++)
            {
                char s = (char)(97 + i);
                Console.Write($"{s} = {a[i]} \n");
            }

            fs.Close();
        }

        static void Main(string[] args)
        {
            Dictionary();
        }
    }
}
