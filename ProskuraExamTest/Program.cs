using BookClassLibrary;
using System;

namespace ProskuraExamTest
{
	class Program
	{
		static void Main(string[] args)
		{
			Startup startup = new Startup();

			startup.Start(startup.Count, (++startup).Count, (++startup).Count);
			Console.ReadKey();

			startup.UpcastDowncastExample();
			Console.ReadKey();

			startup.DelegatesCall();
			Console.ReadKey();

			try
			{
				startup++;
			}
			catch (WrongIdException)
			{
				Console.WriteLine("Cannot create id 130");
			}
			Console.ReadKey();
		}

	}
}