using System;
using System.Collections.Generic;
using System.Linq;
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

            if (input.Any(x=>string.IsNullOrWhiteSpace(x)))
            {
                throw InputParserException.InvalidInputException(ErrorMessages.INVALID_INPUT_MESSAGE);
            }

            //Test if input contains ":" in every element
            if (input.Any(x => !x.Contains(":")))
            {
                throw InputParserException.InvalidInputException(ErrorMessages.INVALID_INPUT_MESSAGE);
            }

        }
    }
}
