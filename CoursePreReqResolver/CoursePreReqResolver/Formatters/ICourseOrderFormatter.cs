using System;
using System.Collections.Generic;
using System.Text;

namespace CoursePreReqResolver.Formatters
{
    public interface ICourseOrderFormatter<T>
    {
        public T Format(IEnumerable<string> coursesInOrder);
    }
}
