/*
 * Created by SharpDevelop.
 * User: sergey.lezhenko
 * Date: 13.11.2017
 * Time: 15:54
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Threading;
using System.IO;

namespace DZ_01_2
{
	public class Bank
	{
		int _money;
		string _name;
		int _percent;
		public int Money
		{
			set
			{
				_money = value;
				ThreadPool.QueueUserWorkItem(SaveLog, this);
			}
			get { return _money; }
		}
		public string Name
		{
			set
			{
				_name = value;
				ThreadPool.QueueUserWorkItem(SaveLog, this);
			}
			get { return _name; }
		}
		public int Percent
		{
			set
			{
				_percent = value;
				ThreadPool.QueueUserWorkItem(SaveLog, this);
			}
			get { return _percent; }
		}
		public Bank()
		{
		}
		private static void SaveLog(object obj)
		{
			Bank bank = obj as Bank;
			if(bank!=null)
			{
				int i=0;
				for (; i < 5; i++) {
					try {
						File.AppendAllText("./bank.log",
							DateTime.Now.ToString()
							+ "> Name: " + bank.Name
							+ "; Money: " + bank.Money
							+ "; Percent: " + bank.Percent + "\n");
						i = 0;
						break;
					} catch (IOException) {
						Thread.Sleep(100);
					}
				}
				if (i == 5)
					Console.WriteLine("Ошибка записи в файл лога.");
			}
		}
	}
}
