using System;
using System.Text;

namespace Test
{
	class Program
	{
		static void Main(string[] args)
		{
			// Regel 1 on Branch 1
			// Regel 2 on Branch 1
			// Regel 3 on Branch 1
			//
			// To insert a quote in a literal C# string add an extra quote.
			//
			var s = @"25;""text1"";18.0;303.50;""text2a;text2b;text2c"";2017-05-14 23:38:05;""woof"";;10";
			var result = StateParse(s);
			foreach (var str in result) Console.WriteLine(str);
		}
		/// <summary>
		/// Because there are ; inside a string you need a parser with state machine
		/// </summary>
		/// <param name="s"></param>
		/// <returns>array of strings</returns>
		private static string[] StateParse(string s)
		{
			var i = 0;
			var state=false;
			var sb = new StringBuilder(s);
			foreach (var c in s)
			{
				if (c == '"') state = !state; // The state machine.
				if (c == ';' && !state) sb[i] = ',';
				i++;
			}
			return sb.ToString().Split(',');
		}
	}
}
