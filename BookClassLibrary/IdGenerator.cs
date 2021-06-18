using System;
using System.Collections.Generic;
using System.Text;

namespace BookClassLibrary
{
	public class IdGenerator
	{
		private int _count = 100;
		public int Count { get => _count; set => _count = value; }

		//peregruzka unarnogo operatora and custom exception usage
		public static IdGenerator operator ++(IdGenerator c)
		{
			IdGenerator generator = new IdGenerator { Count = c.Count + 10 };
			if (generator.Count == 130)
			{
				throw new WrongIdException();
			}
			return generator;
		}
	}
}
