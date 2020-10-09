using System;
using System.Collections.Generic;
using System.Text;

namespace CoursePreReqResolver
{
	public class InputParserException : Exception
	{
		private InputParserException(string message) : base(message)
		{
		}

		public static InputParserException InvalidInputException(string message)
		{
			return new InputParserException(message);
		}
	}
}
