using System;
using System.Collections.Generic;
using System.Text;

namespace CoursePreReqResolver.POCOs
{
    public class CourseAndPreReqs
    {
        public List<string> NonDependentCourses { get; set; }

        public IDictionary<string, List<string>> Courses { get; set; }

    }
}
