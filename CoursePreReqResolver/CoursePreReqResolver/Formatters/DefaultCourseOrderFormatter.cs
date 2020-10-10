using System;
using System.Collections.Generic;
using System.Text;

namespace CoursePreReqResolver.Formatters
{
    /// <summary>
    /// The DefaultCourseOrderFormatter formats the output as a comma separated string.
    /// </summary>
    public class DefaultCourseOrderFormatter : ICourseOrderFormatter<string>
    {
        public string Format(IEnumerable<string> coursesInOrder)
        {
            string result = string.Join(", ", coursesInOrder);
            return result;
        }
    }
}
