using System;
using System.Collections.Generic;
using System.Text;

namespace BookClassLibrary
{
	public abstract class BaseClass : IBaseClass
	{
		private int _id;

		//property
		public int Id { get => _id; set => _id = value; }

		public abstract void Display();
	}
}
