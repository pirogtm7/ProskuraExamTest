using System;
using System.Collections.Generic;
using System.Text;

namespace BookClassLibrary
{
	public class Reader : Person
	{
		private string _name;
		private DateTime _birthDate;

		public string Name { get => _name; set => _name = value; }
		public DateTime BirthDate { get => _birthDate; set => _birthDate = value; }

		public Reader(int id, string name)
		{
			Id = id;
			Name = name;

			Console.WriteLine("Reader instance created");
		}

		public Reader()
		{

		}

		public new void UpcastDowncastTest()
		{
			Console.WriteLine("Method from child");
		}
	}
}
