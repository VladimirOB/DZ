using System.Text;

namespace CS_First
{
	class Program
	{
		static void Main(string[] args)
		{
			/*Console.WriteLine("Command line arguments: ");

			int index = 0;
			foreach (var param in args)
			{
				Console.WriteLine($"{index++}. {param}");
			}*/

			/*Console.Write("Tell me your name, please: ");
			string? name = Console.ReadLine();
			Console.WriteLine($"Hello, {name}!");*/

			/*string? str1 = Console.ReadLine();
			string? str2 = Console.ReadLine();

			// int a = Convert.ToInt32(str1);

			int a = 0;
			int b = 0;
			if(Int32.TryParse(str2, out b) && Int32.TryParse(str1, out a))
			{
				Console.WriteLine(a + b);
			}
			else
			{
				Console.WriteLine("Numbers input error!!!");
			}*/

			/*Random random = new Random();
			for (int i = 0; i < 20; i++)
			{
				Console.WriteLine(random.Next(1, 10));
			}*/

			/*int[] a = new int[] { 1, 2, 33, 4, 5};
			for (int i = 0; i < a.Length; i++)
			{
				Console.WriteLine(@"{0}. {1}", i, a[i]);
			}
			Console.WriteLine();*/

			/*int[,] a = new int[3, 5] { { 1, 2, 3, 4, 5 }, { 6, 7, 8, 9, 0 }, { 1, 2, 3, 4, 5 } };
			for (int i = 0; i < a.GetLength(0); i++)
			{
				for (int k = 0; k < a.GetLength(1); k++)
				{
					Console.Write($"{a[i, k]} ");
				}
				Console.WriteLine();
			}*/

			/*int[][] a = new int[5][];
			for (int i = 0; i < 5; i++)
			{
				a[i] = new int[i + 1];
				for (int k = 0; k < i+1; k++)
				{
					a[i][k] = i * k + 1;
				}
			}

			for (int i = 0; i < a.Length; i++)
			{
				for (int k = 0; k < a[i].Length; k++)
				{
					Console.Write($"{a[i][k]} ");
				}
				Console.WriteLine();
			}*/

			/*string str = "Hello";
			str = str.Insert(3, "!!!");
			str = str + "???";
			Console.WriteLine(str);*/

			/*StringBuilder builder = new StringBuilder("Hello");
			builder.Insert(0, "_");
			builder.Remove(0, 1);
			builder.Append("!!!");
			builder.Replace("e", "a");

			Console.WriteLine(builder.ToString());*/

			string[] words = "Hello big world !!!".Split(" ");
			foreach (string word in words)
				Console.WriteLine(word);

			string res = string.Join(".", words);
			Console.WriteLine(res);
		}
	}
}