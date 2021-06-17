using System;
using System.Collections.Generic;
using System.Text;

namespace BookClassLibrary
{
	public class Person : BaseClass
	{
		//auto-property
		public int Age { get; set; }

		public Person()
		{
			Console.WriteLine("Person instance created");
		}

		public void UpcastDowncastTest()
		{
			Console.WriteLine("Method from parent");
		}

		public override void Display()
		{
			Console.WriteLine("Person display method");
		}
	}
}
