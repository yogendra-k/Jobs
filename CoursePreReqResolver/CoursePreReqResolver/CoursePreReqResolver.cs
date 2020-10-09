using CoursePreReqResolver.InputParser;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoursePreReqResolver
{
    /// <summary>
    /// This class is like a Facade. 
    /// It specifies the <c = IINputParser></c> and also selects the formatter to format the output. 
    /// </summary>
    public class CoursePreReqResolver
    {
        public string GetOrderOfCourses(string[] input)
        {
            string result = String.Empty;

            try
            {
                //Use the parser to parse the input into output
                IInputParser parser = new ArrayInputParser();
                parser.ParseInput(input);

                //call the formatter to appropriately format the output
            }
            catch (InputParserException ipe)
            {
                //log the exception
                result = ipe.Message;
            }
            catch (Exception )
            {
                //log the exception
                result = ErrorMessages.GENERIC_ERROR_MESSAGE;
            }

            return result;
        }
    }
}
