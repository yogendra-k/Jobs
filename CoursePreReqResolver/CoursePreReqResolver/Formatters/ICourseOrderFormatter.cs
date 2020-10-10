using System;
using System.Collections.Generic;
using System.Text;

namespace CoursePreReqResolver.Formatters
{
    /// <summary>
    /// Provides a contract so that we can have different formatters.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICourseOrderFormatter<T>
    {
        public T Format(IEnumerable<string> coursesInOrder);
    }
}
