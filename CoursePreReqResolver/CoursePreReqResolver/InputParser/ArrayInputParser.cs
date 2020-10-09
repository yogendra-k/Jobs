using System;
using System.Collections.Generic;
using System.Text;

namespace CoursePreReqResolver.InputParser
{
    public class ArrayInputParser : IInputParser
    {
        public IEnumerable<string> ParseInput(string[] input)
        {
            ValidateInput(input);

            return null;

        }

        private void ValidateInput(string[] input)
        {
            //Test if input is null
            if (input == null)
            {
                throw InputParserException.InvalidInputException(ErrorMessages.NULL_INPUT_MESSAGE);
            }

            
        }
    }

	

}
