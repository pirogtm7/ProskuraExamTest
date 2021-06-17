using System;
using System.Collections.Generic;
using System.Text;

namespace BookClassLibrary
{
	public class Card : BaseClass 
	{
		private Book _book;
		private Reader _reader;
		private DateTime _returnDate;

		public Book Book { get => _book; set => _book = value; }
		public Reader Reader { get => _reader; set => _reader = value; }
		public DateTime ReturnDate { get => _returnDate; set => _returnDate = value; }

		public Card(int cardId, Reader reader,
			Book paramBook)
		{
			Id = cardId;
			Book = new Book(paramBook);
			Reader = reader;
			//would be much easier to do this in one line but you gotta do what Proskura tells you to do
			ReturnDate = DateTime.Now.AddDays(30);

			Console.WriteLine("Card instance created");
		}

		public override void Display()
		{
			Console.WriteLine("Card display method");
		}

		//popitka zdelat druguyu peregruzku operatora

		//step one
		//public Card()
		//{
		//	ReturnDate = DateTime.Now;
		//}

		////step two
		//public static Card operator ++(Card cardWithoutProperDate)
		//{
		//	return new Card { ReturnDate = cardWithoutProperDate.ReturnDate.AddDays(30) };
		//}

		////step three
		//public Card(int cardId, Reader reader,
		//	Book paramBook, DateTime returnDate)
		//{
		//	Id = cardId;
		//	Book = new Book(paramBook);
		//	Reader = new Reader(reader.Id, reader.Name);
		//	ReturnDate = returnDate;
		//}
	}
}
