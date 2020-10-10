using CoursePreReqResolver.Formatters;
using CoursePreReqResolver.InputParser;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoursePreReqResolver
{
    /// <summary>
    /// This class is like a Facade. 
    /// It uses an input parser to parse the input and also provides ability to select the formatter to format the output. 
    /// </summary>
    public class CoursePreReqResolver
    {
        public string GetOrderOfCourses(string[] input)
        {
            string result = String.Empty;

            try
            {
                //Use the parser to parse the input into output
                ArrayInputParser parser = new ArrayInputParser();
                var coursesInOrder = parser.ParseInput(input);

                //call the formatter to appropriately format the output
                ICourseOrderFormatter<string> formatter = new DefaultCourseOrderFormatter();
                result = formatter.Format(coursesInOrder);
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
