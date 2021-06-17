using System;
using System.Collections.Generic;
using System.Text;

namespace BookClassLibrary
{
	public class Book : BaseClass
	{
		private string _name;
		private int _pageAmount;
		private string _state;

		public string Name { get => _name; set => _name = value; }
		public int PageAmount { get => _pageAmount; set => _pageAmount = value; }
		public string State { get => _state; set => _state = value; }

		public Book(Book book)
		{
			Id = book.Id;
			Name = book.Name;
			PageAmount = book.PageAmount;
			State = book.State;

			Console.WriteLine("Book instance created");
		}

		public Book()
		{

		}

		public override void Display()
		{
			Console.WriteLine("Book display method");
		}


		//public static Book operator ++(Book c)
		//{
		//	return new Book { Id = c.Id + 10 };
		//}
	}
}
