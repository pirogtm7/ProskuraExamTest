using BookClassLibrary;
using System;

namespace ProskuraExamTest
{
	class Program
	{
		static void Main(string[] args)
		{
			Startup startup = new Startup();

			startup.Start();
			Console.ReadKey();

			startup.UpcastDowncastExample();
			Console.ReadKey();

			startup.DelegatesCall();
			Console.ReadKey();

			startup.CustomExceptionDisplay();
			Console.ReadKey();
		}

	}
}