using System;
using System.Collections.Generic;
using System.Text;

namespace CoursePreReqResolver.Formatters
{
    public class DefaultCourseOrderFormatter : ICourseOrderFormatter<string>
    {
        public string Format(IEnumerable<string> coursesInOrder)
        {
            string result = string.Join(", ", coursesInOrder);
            return result;
        }
    }
}
