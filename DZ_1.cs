using System;
using System.Collections;
using System.Threading;

namespace DZ_01_1_3
{
	class Program
	{
		public static void Main(string[] args)
		{
			int[] arr = new int[] { 4, 6, 8, -4, 34 };
			ThreadPool.QueueUserWorkItem(ThreadFunc, arr);
			Console.ReadKey(true);
		}
		static void ThreadFunc(object obj)
		{
			ICollection col = obj as ICollection;
			if(col!=null)
			{
				foreach (object item in col)
					Console.WriteLine("{0}", item.ToString());
			}
		}
	}
}
