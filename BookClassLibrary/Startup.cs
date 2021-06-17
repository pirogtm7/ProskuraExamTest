using System;
using System.Collections.Generic;
using System.Text;

namespace BookClassLibrary
{
	public class Startup
	{
		private int _count = 100;
		private Card _card;

		public int Count { get => _count; set => _count = value; }
		public Card Card { get => _card; set => _card = value; }

		public static Startup operator ++(Startup c)
		{
			Startup startup = new Startup { Count = c.Count + 10 };
			if (startup.Count == 130)
			{
				throw new WrongIdException();
			}
			return startup;
		}

		public void Start(int cardId, int readerId, int bookId)
		{
			//razvorachivanie systemi
			Card = new Card(cardId, new Reader(readerId, "Ricardo Milos"), 
				new Book { Id = bookId, Name = "Put Samuraya", PageAmount = 669, State = "Perfect"});

			Console.WriteLine($"Card details: id - {Card.Id}, return date - {Card.ReturnDate}");
			Console.WriteLine($"Reader details: id - {Card.Reader.Id}, name - {Card.Reader.Name}, birth date - {Card.Reader.BirthDate}");
			Console.WriteLine($"Book details: id - {Card.Book.Id}, name - {Card.Book.Name}, pages - {Card.Book.PageAmount}, state - {Card.Book.State}");

			//prove that overrode methods work
			Card.Display();
			Card.Book.Display();
			Card.Reader.Display();
		}

		public void UpcastDowncastExample()
		{
			//upcast downcast

			Reader reader = new Reader();
			reader.UpcastDowncastTest();

			//upcast
			Person personUp = reader;
			personUp.UpcastDowncastTest();

			//downcast
			Reader readerDown = (Reader)personUp;
			readerDown.UpcastDowncastTest();

			//try downcast without upcast and get system exception
			Person person = new Person();
			try
			{
				Reader readerDownWrong = (Reader)person;
			}
			catch (InvalidCastException)
			{
				Console.WriteLine("Failed to downcast without previous upcast");
			}
		}

		//Делегат, що представляє подію
		public delegate void EventDelegate(string msg);

		//Об'являємо подію
		public event EventDelegate Notify;

		public void TestMethod()
		{
			//Викликаємо подію
			Notify?.Invoke("This is message for the event from test method");
		}

		public void DelegatesCall()
		{
			//Анонімний метод
			DelegateWithNoParamsOrReturnValue delegateWithAnonymousMethod = delegate () {
				Console.WriteLine("This is message for delegate with anonymous method");
			};
			//Лямбда-оператор та лямбда-вираз
			DelegateWithParam delegateWithLambdaOperatorAndExpression = (x) =>
				Console.WriteLine("This is message for delegate with parameter: " + x);


			//Викликаємо методи, сповіщені з делегатами
			delegateWithAnonymousMethod();

			string msg = "Parameter for Lambda expression";
			delegateWithLambdaOperatorAndExpression(msg);

			//Створюємо екземпляр класу, що викликає подію
			//Додаємо обробник подій EventMsg
			Notify += EventMsg;
			//Викликаємо метод, що викликає подію
			TestMethod();
		}

		//Делегат без параметрів та повертаємого значення
		public delegate void DelegateWithNoParamsOrReturnValue();

		//Делегат з параметром
		public delegate void DelegateWithParam(string msg);

		private static void EventMsg(string msg)
		{
			Console.WriteLine(msg);
		}
	}
}
