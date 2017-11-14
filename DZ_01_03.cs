/*
 * Created by SharpDevelop.
 * User: sergey.lezhenko
 * Date: 14.11.2017
 * Time: 14:43
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Diagnostics;
using System.Threading;

namespace DZ_01_3
{
	class Program
	{
		static bool isExit = false;
		public static void Main(string[] args)
		{
			AutoResetEvent state = new AutoResetEvent(false);
			ThreadPool.QueueUserWorkItem(new WaitCallback(SpeedTest), state);
			while(!isExit)
			{
				state.Set();
			}
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
		static void SpeedTest(object state)
		{
			DateTime time1, time2;
			ConsoleKeyInfo key;
			AutoResetEvent are = (AutoResetEvent)state;
			Stopwatch time = new Stopwatch();
			Random rnd = new Random();
			while (true) {
				char ch = Convert.ToChar(Convert.ToInt32('a') + rnd.Next() % 26);
				Console.Write("Press: {0}", ch);
				time.Start();
				time1 = DateTime.Now;
				do {
					key = Console.ReadKey(true);
					time2 = DateTime.Now;
				} while(key.KeyChar != ch && key.Key != ConsoleKey.Escape);
				time.Stop();
				Console.WriteLine(" - speed: {0}ms, {1}", (int)(time2 - time1).TotalMilliseconds, time.ElapsedMilliseconds);
				isExit = key.Key == ConsoleKey.Escape;
				are.WaitOne();
				time.Reset();
			}
		}
	}
}
