using System;
using UtilityMethods;

public class Test
{
	public static void Main(string[] args)
	{
		if(args.Length != 2)
		{
			Console.WriteLine("Usage : Test <num1> <num2>");
			return;
		}
		int num1 = int.Parse(args[0]);
		int num2 = int.Parse(args[1]);

		int sum = AddClass.Add(num1, num2);
		int mult = MultClass.Multiply(num1, num2);

		Console.WriteLine("{0} + {1} => {2}", num1, num2, sum);
		Console.WriteLine("{0} * {1} => {2}", num1, num2, mult);
	}
}