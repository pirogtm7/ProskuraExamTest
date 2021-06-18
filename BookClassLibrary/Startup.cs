using System;
using System.Collections.Generic;
using System.Text;

namespace BookClassLibrary
{
	public class Startup
	{
		private Card _card;
		private IdGenerator _generator;

		public Card Card { get => _card; set => _card = value; }
		public IdGenerator Generator { get => _generator; set => _generator = value; }

		public void Start()
		{
			Generator = new IdGenerator();

			//razvorachivanie systemi
			Card = new Card(Generator.Count, new Reader((++Generator).Count, "Ricardo Milos"), 
				new Book { Id = (++Generator).Count, Name = "Put Samuraya", PageAmount = 669, State = "Perfect"});

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

			//Reader reader = new Reader();
			Card.Reader.UpcastDowncastTest();

			//upcast
			Person personUp = Card.Reader;
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

		public delegate void DelegateWithNoParamsOrReturnValue();
		public delegate void DelegateWithParam(string msg);
		public delegate void EventDelegate(string msg);

		//event declaration
		public event EventDelegate Notify;

		public void TestMethod()
		{
			//call event
			Notify?.Invoke("This is message for the event from test method");
		}

		//event handler 
		private static void EventMsg(string msg)
		{
			Console.WriteLine(msg);
		}

		public void DelegatesCall()
		{
			//create delegate instances and
			//notify first delegate with anonymous method
			DelegateWithNoParamsOrReturnValue delegateWithAnonymousMethod = delegate () {
				Console.WriteLine("This is message for delegate with anonymous method");
			};
			//notify next delegate with anonymous method even easier by using lambda-expression
			DelegateWithParam delegateWithLambdaOperatorAndExpression = (x) =>
				Console.WriteLine("This is message for delegate with parameter: " + x);

			//call delegates
			delegateWithAnonymousMethod();

			string msg = "Parameter for Lambda expression";
			delegateWithLambdaOperatorAndExpression(msg);

			//Startup instance is already created
			//add EventMsg event handler
			Notify += EventMsg;
			//call method that calls event
			TestMethod();
		}

		public void CustomExceptionDisplay()
		{
			try
			{
				Generator++;
			}
			catch (WrongIdException)
			{
				Console.WriteLine("Cannot create id 130");
			}
		}

	}
}
