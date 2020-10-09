using System;
using System.Collections.Generic;
using System.Text;

namespace CoursePreReqResolver.InputParser
{
	/// <summary>
	/// Parses the input to determine the course sequence
	/// Concrete implementations can parse the input into say a List of courses or may be into XML or JSON
	/// </summary>
	public interface IInputParser
	{
		IEnumerable<string> ParseInput(string[] input);
	}
}
