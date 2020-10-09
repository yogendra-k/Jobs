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

                //call the formatter to appropriately format the output
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }
    }
}
