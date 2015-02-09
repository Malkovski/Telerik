namespace Task2BinaryToDecimal
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;

   public class BinaryToDecimal
	{
	   public static void Main(string[] args)
		{
			Console.WriteLine("Enter binary number!");
			string binar = Console.ReadLine();
			int result = 0;
			int cnt = 0;

			for (int i = binar.Length - 1; i >= 0; i--)
			{
				result += int.Parse(binar[i].ToString()) * (int)(Math.Pow(2, cnt));
				cnt++;
			}

			Console.WriteLine("Decimal is: {0}", result);
		}
	}
}
